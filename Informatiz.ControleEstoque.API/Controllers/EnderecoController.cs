using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Endereco")]
    public class EnderecoController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RegistrarEndereco")]
        [Classes.ValidateModel]
        public ContratoServico.Endereco.RegistrarEndereco.RespostaRegistrarEndereco RegistrarEndereco(ContratoServico.Endereco.RegistrarEndereco.PeticaoRegistrarEndereco Peticao)
        {

            ContratoServico.Endereco.RegistrarEndereco.RespostaRegistrarEndereco objSaida = new ContratoServico.Endereco.RegistrarEndereco.RespostaRegistrarEndereco();

            try
            {

                objSaida.Estado = LogicaNegocio.Endereco.RegistrarEndereco(Peticao.Cep,Peticao.IdentificadorEstado,Peticao.IdentificadorCidade, 
                    Peticao.IdentificadorBairro,Peticao.Rua,Peticao.Usuario,Peticao.RuaPesquisar,Peticao.IdentificadorEndereco);

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("RecuperarEstado")]
        [Classes.ValidateModel]
        public ContratoServico.Endereco.RecuperarEstado.RespostaRecuperarEstado RecuperarEstado(ContratoServico.Endereco.RecuperarEstado.PeticaoRecuperarEstado Peticao)
        {

            ContratoServico.Endereco.RecuperarEstado.RespostaRecuperarEstado objSaida = new ContratoServico.Endereco.RecuperarEstado.RespostaRecuperarEstado();

            try
            {

                objSaida.Estados = LogicaNegocio.Estado.RecuperarEstado(Peticao.Usuario, Peticao.IdentificadorEstado);

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("RecuperarCidades")]
        [Classes.ValidateModel]
        public ContratoServico.Endereco.RecuperarCidades.RespostaRecuperarCidades RecuperarCidades(ContratoServico.Endereco.RecuperarCidades.PeticaoRecuperarCidades Peticao)
        {

            ContratoServico.Endereco.RecuperarCidades.RespostaRecuperarCidades objSaida = new ContratoServico.Endereco.RecuperarCidades.RespostaRecuperarCidades();

            try
            {

                objSaida.Cidades = LogicaNegocio.Cidade.RecuperarCidades(Peticao.Codigo,Peticao.Nome,Peticao.Usuario,Peticao.IdentificadorEstado,Peticao.Identificador);

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("RecuperarBairro")]
        [Classes.ValidateModel]
        public ContratoServico.Endereco.RecuperarBairro.RespostaRecuperarBairro RecuperarBairro(ContratoServico.Endereco.RecuperarBairro.PeticaoRecuperarBairro Peticao)
        {

            ContratoServico.Endereco.RecuperarBairro.RespostaRecuperarBairro objSaida = new ContratoServico.Endereco.RecuperarBairro.RespostaRecuperarBairro();

            try
            {

                objSaida.Bairros = LogicaNegocio.Bairro.RecuperarBairro(Peticao.Codigo,Peticao.Nome,Peticao.Usuario,Peticao.IdentificadorCidade,Peticao.Identificador);

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("PesquisarEndereco")]
        [Classes.ValidateModel]
        public ContratoServico.Endereco.PesquisarEndereco.RespostaPesquisarEndereco PesquisarEndereco(ContratoServico.Endereco.PesquisarEndereco.PeticaoPesquisarEndereco Peticao)
        {

            ContratoServico.Endereco.PesquisarEndereco.RespostaPesquisarEndereco objSaida = new ContratoServico.Endereco.PesquisarEndereco.RespostaPesquisarEndereco();

            try
            {

                objSaida.Enderecos = LogicaNegocio.Endereco.PesquisarEndereco(Peticao.Usuario,Peticao.Cep,Peticao.Rua,Peticao.IdentificadorBairro,Peticao.Codigo,Peticao.Identificador);

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("SetCidades")]
        [Classes.ValidateModel]
        public ContratoServico.Endereco.SetCidades.RespostaSetCidades SetCidades(ContratoServico.Endereco.SetCidades.PeticaoSetCidades Peticao)
        {

            ContratoServico.Endereco.SetCidades.RespostaSetCidades objSaida = new ContratoServico.Endereco.SetCidades.RespostaSetCidades();

            try
            {

                LogicaNegocio.Cidade.SetCidades(Peticao.Cidade,Peticao.IdentificadorEstado,Peticao.Usuario);

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("SetBairro")]
        [Classes.ValidateModel]
        public ContratoServico.Endereco.SetBairro.RespostaSetBairro SetBairro(ContratoServico.Endereco.SetBairro.PeticaoSetBairro Peticao)
        {

            ContratoServico.Endereco.SetBairro.RespostaSetBairro objSaida = new ContratoServico.Endereco.SetBairro.RespostaSetBairro();

            try
            {

                LogicaNegocio.Bairro.SetBairro(Peticao.Bairro,Peticao.IdentificadorCidade,Peticao.Usuario);

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("SetEndereco")]
        [Classes.ValidateModel]
        public ContratoServico.Endereco.SetEndereco.RespostaSetEndereco SetEndereco(ContratoServico.Endereco.SetEndereco.PeticaoSetEndereco Peticao)
        {

            ContratoServico.Endereco.SetEndereco.RespostaSetEndereco objSaida = new ContratoServico.Endereco.SetEndereco.RespostaSetEndereco();

            try
            {
                LogicaNegocio.Endereco.SetEndereco(Peticao.Endereco,Peticao.IdentificadorBairro,Peticao.Usuario);
                
                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }
    }
}
