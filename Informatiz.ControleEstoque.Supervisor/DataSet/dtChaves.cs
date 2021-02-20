namespace Informatiz.ControleEstoque.Supervisor.DataSet {
    
    
    public partial class dtChaves {

        public void PopularDataSet(Comum.Clases.Chave objChave)
        {

            if (objChave != null)
            {

                ChaveRow drChave = (ChaveRow)(this.Chave.NewRow());
                
                drChave.ChaveAcesso = objChave.ChaveAcesso;

                if (!objChave.ValidadeInfinita && objChave.Validade != null)
                {
                    drChave.Validade = System.Convert.ToString(objChave.Validade) + " Dias";
                }

                if (objChave.ValidadeInfinita)
                {
                    drChave.ValidadeInfinita = "Sim";
                }
                else
                {
                    drChave.ValidadeInfinita = "Não";
                }

                if (objChave.QuantidadeSessoes != null && objChave.QuantidadeSessoes > 0)
                {
                    drChave.QuantidadeSessoes = (int)(objChave.QuantidadeSessoes);
                }

                if (objChave.SessoesInfinitas)
                {
                    drChave.SessoesInfinitas = "Sim";
                }
                else
                {
                    drChave.SessoesInfinitas = "Não";
                }


                this.Chave.Rows.Add(drChave);

            }
        
        }
    }
}
