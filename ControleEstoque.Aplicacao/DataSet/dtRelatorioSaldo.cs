namespace Informatiz.ControleEstoque.Aplicacao.DataSet
{


    public partial class dtRelatorioSaldo
    {

        public void PopularDataSet(System.Collections.Generic.List<Comum.Clases.Relatorios.RelatorioEstoque> objProdutos,
                                   Comum.Clases.Empresa Empresa)
        {

            ProdutosRow drProdutos = null;

            if (objProdutos != null)
            {

                foreach (Comum.Clases.Relatorios.RelatorioEstoque re in objProdutos)
                {
                    drProdutos = (ProdutosRow)(this.Produtos.NewRow());

                    drProdutos.NomeProduto = re.Descricao;
                    drProdutos.CodigoBarras = re.CodigoBarras;
                    drProdutos.CodigoProduto = re.Codigo;
                    drProdutos.CodigoFilial = re.CodigoFilial;
                    drProdutos.DescricaoFilial = re.DescricaoFilial;
                    drProdutos.Estoque = re.Estoque;
                    drProdutos.Email = re.Email;
                    drProdutos.TelefoneCelular = re.TelefoneCelular;
                    drProdutos.TelefoneFax = re.TelefoneFax;
                    drProdutos.TelefoneFixo = re.TelefoneFixo;

                    this.Produtos.Rows.Add(drProdutos);
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
