namespace Informatiz.ControleEstoque.Aplicacao.DataSet
{


    public partial class dtFicha
    {

        public void PopularDataSet(System.Collections.Generic.List<Comum.Clases.Pergunta> objPerguntas,
                                 Comum.Clases.Empresa Empresa)
        {

            if (objPerguntas != null && objPerguntas.Count > 0)
            {

                PerguntasRow drPerguntasDataSet = null;

                foreach (Comum.Clases.Pergunta p in objPerguntas)
                {

                    drPerguntasDataSet = (PerguntasRow)(this.Perguntas.NewRow());

                    drPerguntasDataSet.Pergunta = p.DesPergunta;

                    if (p.TipoComponente == Comum.Enumeradores.Enumeradores.TipoComponente.TEXTBOX)
                    {
                        drPerguntasDataSet.Resposta = p.Resposta;
                    }
                    else if (p.TipoComponente == Comum.Enumeradores.Enumeradores.TipoComponente.COMBOBOX)
                    {
                        drPerguntasDataSet.Resposta = p.Resposta;
                    }
                    else
                    {

                        if (p.Resposta == "1")
                        {
                            drPerguntasDataSet.Resposta = "Sim";
                        }
                        else
                        {
                            drPerguntasDataSet.Resposta = "Não";
                        }
                    }



                    this.Perguntas.Rows.Add(drPerguntasDataSet);

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
