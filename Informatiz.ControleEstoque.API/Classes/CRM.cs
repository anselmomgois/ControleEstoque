using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Informatiz.ControleEstoque.Comum.Extencoes;


namespace Informatiz.ControleEstoque.API.Classes
{
    public class CRM
    {
        private static object _LockObjectCarregamento = new object();
        private static object _LockObjectInstance = new object();
        private static object _LockObjecSortearFuncionarios = new object();

        private static List<Comum.Clases.FuncionarioCrm> _EstatisticaFuncionariosCrm = null;
        public static List<Comum.Clases.FuncionarioCrm> EstatisticaFuncionariosCrm
        {
            get
            {
                return _EstatisticaFuncionariosCrm;
            }
        }

        public static void InformarAgendamento(string CodigoUsuario)
        {
            if(_EstatisticaFuncionariosCrm != null && _EstatisticaFuncionariosCrm.Count > 0)
            {
                var objFuncEstatistica = (from Comum.Clases.FuncionarioCrm fcrm in _EstatisticaFuncionariosCrm
                                          where fcrm.Funcionario != null && fcrm.Funcionario.Usuario == CodigoUsuario
                                          select fcrm).FirstOrDefault();

                if (objFuncEstatistica != null) objFuncEstatistica.QuantidadeVezesEscolhido += 1;
            }
        }
        public static void CarregarFuncionarios(List<Comum.Clases.Pessoa> FuncionariosEscolhidos)
        {
            if (FuncionariosEscolhidos != null && FuncionariosEscolhidos.Count > 0)
            {
                if (_EstatisticaFuncionariosCrm == null)
                {
                    lock (_LockObjectInstance)
                    {
                        if (_EstatisticaFuncionariosCrm == null) _EstatisticaFuncionariosCrm = new List<Comum.Clases.FuncionarioCrm>();
                    }
                }

                foreach (var f in FuncionariosEscolhidos)
                {
                    if (!_EstatisticaFuncionariosCrm.Exists(ef => ef.Funcionario.Identificador == f.Identificador))
                    {
                        lock (_LockObjectCarregamento)
                        {
                            if (!_EstatisticaFuncionariosCrm.Exists(ef => ef.Funcionario.Identificador == f.Identificador))
                            {
                                _EstatisticaFuncionariosCrm.Add(new Comum.Clases.FuncionarioCrm()
                                {
                                    Funcionario = f.Clone<Comum.Clases.Pessoa>()
                                });
                            }
                        }
                    }
                }
            }
        }

        public static List<Comum.Clases.Pessoa> SortearFuncionariosCompromisso(Comum.Clases.TipoCrm TipoCrm)
        {
            lock (_LockObjecSortearFuncionarios)
            {
                List<Comum.Clases.Pessoa> objPessoasRetorno = new List<Comum.Clases.Pessoa>();
                Int32 QuantidadeFuncionarios = 0;

                if (_EstatisticaFuncionariosCrm != null && _EstatisticaFuncionariosCrm.Count > 0 && TipoCrm != null &&
                    TipoCrm.TiposCrmConfig != null && TipoCrm.TiposCrmConfig.Count > 0)
                {

                    Comum.Clases.TipoCrmConfig TipoConfigNivel = TipoCrm.TiposCrmConfig.FindAll(tc => tc.Nivel == 1).FirstOrDefault();

                    if (TipoConfigNivel != null)
                    {
                        QuantidadeFuncionarios = TipoConfigNivel.QuantidadeEmpregados;

                        List<Comum.Clases.FuncionarioCrm> objFuncionariosElegiveis = null;

                        if (TipoConfigNivel.Pessoas != null && TipoConfigNivel.Pessoas.Count > 0)
                        {
                            objFuncionariosElegiveis = (from Comum.Clases.Pessoa pe in TipoConfigNivel.Pessoas
                                                        join Comum.Clases.FuncionarioCrm fcrm in _EstatisticaFuncionariosCrm on pe.Identificador equals fcrm.Funcionario.Identificador
                                                        select fcrm).ToList();

                            if (objFuncionariosElegiveis != null && objFuncionariosElegiveis.Count > 0) QuantidadeFuncionarios = objFuncionariosElegiveis.Count;
                        }
                        else
                        {
                            objFuncionariosElegiveis = (from Comum.Clases.FuncionarioCrm fcrm in _EstatisticaFuncionariosCrm
                                                        where (TipoConfigNivel.TipoEmpregado == null ||
                                                              (fcrm.Funcionario.TipoEmpregado != null && fcrm.Funcionario.TipoEmpregado.Identificador == TipoConfigNivel.TipoEmpregado.Identificador))
                                                        select fcrm).ToList();
                        }                        


                        if (objFuncionariosElegiveis != null && objFuncionariosElegiveis.Count > 0)
                        {
                            if (objFuncionariosElegiveis.Count < QuantidadeFuncionarios)
                            {
                                QuantidadeFuncionarios = objFuncionariosElegiveis.Count;
                            }

                            Int32 QuantidadeRestante = QuantidadeFuncionarios;


                            foreach (Comum.Clases.FuncionarioCrm fcrm in objFuncionariosElegiveis.OrderBy(f => f.QuantidadeVezesEscolhido))
                            {
                                if (QuantidadeRestante > 0)
                                {
                                    objPessoasRetorno.Add(fcrm.Funcionario);
                                    fcrm.QuantidadeVezesEscolhido += 1;

                                    QuantidadeRestante -= 1;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            return objPessoasRetorno;
                        }
                    }
                }

                return null;
            }
        }




    }
}