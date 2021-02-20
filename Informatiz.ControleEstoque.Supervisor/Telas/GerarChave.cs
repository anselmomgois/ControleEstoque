using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Supervisor
{
    public partial class GerarChave : Form
    {
        public GerarChave()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ContratoServico.GerarChave.Peticao objPeticao = new ContratoServico.GerarChave.Peticao();
            Comunicacao.Proxy objProxy = new Comunicacao.Proxy();

            objPeticao.SessoesInfinita = chkSessoesInfinitas.Checked;
            objPeticao.QuantidadeSessoes = Convert.ToInt32(txtQuantidadeSessoes.Text);
            objPeticao.NumValidade = Convert.ToInt32(txtValidadeDias.Text);
            objPeticao.ValidadeInfinita = chkValidadeInfinita.Checked;

            ContratoServico.GerarChave.Respuesta objRespuesta = objProxy.GerarChave(objPeticao);

            if (objRespuesta.CodigoErro != 0)
            {
                MessageBox.Show(objRespuesta.DescricaoErro);
            }
            else
            {
                lblChaveGerada.Text = objRespuesta.ChaveGerada;
            }
        }
    }
}
