namespace Informatiz.ControleEstoque.Aplicacao.DataSet
{


    public partial class dtRelatorioPessoas
    {

        public void PopularDataSet(System.Collections.Generic.List<Comum.Clases.Relatorios.RelatorioPessoas> objPessoas,
                                  Comum.Clases.Empresa Empresa)
        {

            if (objPessoas != null)
            {

                PessoasRow drPessoas = null;

                foreach (Comum.Clases.Relatorios.RelatorioPessoas objPes in objPessoas)
                {
                    drPessoas = (PessoasRow)(this.Pessoas.NewRow());

                    drPessoas.Bairro = objPes.Bairro;
                    drPessoas.Cargo = objPes.Cargo;
                    drPessoas.Cidade = objPes.Cidade;
                    drPessoas.CNPJ = objPes.CNPJ;
                    if (objPes.Comissao != null)
                    {
                        drPessoas.Comissao = (decimal)(objPes.Comissao);
                    }
                    drPessoas.CPF = objPes.CPF;
                    if (objPes.DataAdmissao != null)
                    {
                        drPessoas.DataAdmissao = (System.DateTime)(objPes.DataAdmissao);
                    }

                    if (objPes.DataAdmissao != null)
                    {
                        drPessoas.DataNascimento = (System.DateTime)(objPes.DataNascimento);
                    }
                    drPessoas.Email = objPes.Email;
                    drPessoas.EmpresaTrabalha = objPes.EmpresaTrabalha;
                    drPessoas.Endereco = objPes.Endereco;
                    drPessoas.Estado = objPes.Estado;
                    drPessoas.Fax = objPes.Fax;
                    drPessoas.CEP = objPes.CEP;

                    if (objPes.FornecedorAtivo)
                    {
                        drPessoas.FornecedorAtivo = "Ativo";
                    }
                    else
                    {
                        drPessoas.FornecedorAtivo = "Inativo";
                    }

                    if (objPes.FuncionarioAtivo)
                    {
                        drPessoas.FuncionarioAtivo = "Ativo";
                    }
                    else
                    {
                        drPessoas.FuncionarioAtivo = "Inativo";
                    }

                    if (objPes.LimiteCredito != null)
                    {
                        drPessoas.LimieteCredito = (decimal)(objPes.LimiteCredito);
                    }

                    drPessoas.Nome = objPes.Nome;
                    drPessoas.NomeFantasia = objPes.NomeFantasia;

                    if (objPes.Numero != null)
                    {
                        drPessoas.Numero = (System.Int32)(objPes.Numero);
                    }

                    drPessoas.RG = objPes.RG;
                    if (objPes.Salario != null)
                    {
                        drPessoas.Salario = (decimal)(objPes.Salario);
                    }
                    drPessoas.SegmentoComercial = objPes.SegmentoComercial;
                    drPessoas.SituacaoCliente = objPes.SituacaoCliente;
                    drPessoas.TelefoneCelular = objPes.TelefoneCelular;
                    drPessoas.TelefoneFixo = objPes.TelefoneFixo;
                    drPessoas.Usuario = objPes.Usuario;

                    this.Pessoas.Rows.Add(drPessoas);
                }
            }

            if (Empresa != null)
            {

                EmpresaRow drEmpresa = (EmpresaRow)(this.Empresa.NewRow());

                drEmpresa.Nome = Empresa.Nome;
                drEmpresa.InscricaoEstadudal = Empresa.InscricaoEstadual;
                drEmpresa.CNPJ = Empresa.Cnpj;

                this.Empresa.Rows.Add(drEmpresa);

                if (Empresa.Filiais != null && Empresa.Filiais.Count > 0)
                {
                    FilialRow drFilial = (FilialRow)(this.Filial.NewRow());

                    drFilial.Codigo = Empresa.Filiais[0].Codigo;
                    drFilial.Email = Empresa.Filiais[0].Email;
                    drFilial.Nome = Empresa.Filiais[0].Nome;
                    drFilial.TelefoneCelular = Empresa.Filiais[0].TelefoneMovel;
                    drFilial.TelefoneFax = Empresa.Filiais[0].TelefoneFax;
                    drFilial.TelefoneFixo = Empresa.Filiais[0].TelefoneFixo;

                    if (Empresa.Filiais[0].Endereco != null)
                    {

                        drFilial.Estado = Empresa.Filiais[0].Endereco.Nome;

                        if (Empresa.Filiais[0].Endereco.Cidades != null &&
                            Empresa.Filiais[0].Endereco.Cidades.Count > 0)
                        {
                            drFilial.Cidade = Empresa.Filiais[0].Endereco.Cidades[0].Nome;

                            if (Empresa.Filiais[0].Endereco.Cidades[0].Bairros != null && Empresa.Filiais[0].Endereco.Cidades[0].Bairros.Count > 0)
                            {
                                drFilial.Bairro = Empresa.Filiais[0].Endereco.Cidades[0].Bairros[0].Nome;

                                if (Empresa.Filiais[0].Endereco.Cidades[0].Bairros[0].Enderecos != null &&
                                   Empresa.Filiais[0].Endereco.Cidades[0].Bairros[0].Enderecos.Count > 0)
                                {
                                    drFilial.Endereco = Empresa.Filiais[0].Endereco.Cidades[0].Bairros[0].Enderecos[0].DescricaoRua;
                                    drFilial.CEP = Empresa.Filiais[0].Endereco.Cidades[0].Bairros[0].Enderecos[0].DescricaoCep;

                                    if (Empresa.Filiais[0].Endereco.Cidades[0].Bairros[0].Enderecos[0].Numero != null)
                                    {
                                        drFilial.Numero = System.Convert.ToInt32(Empresa.Filiais[0].Endereco.Cidades[0].Bairros[0].Enderecos[0].Numero);
                                    }
                                }
                            }

                        }
                    }

                    this.Filial.Rows.Add(drFilial);
                }
            }
        }
    }
}
