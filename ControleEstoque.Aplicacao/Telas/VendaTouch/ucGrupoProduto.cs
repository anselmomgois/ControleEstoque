using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Informatiz.ControleEstoque.Aplicacao.Telas.VendaTouch
{
    public partial class ucGrupoProduto : UserControl
    {

        public delegate void dGrupoProdutoSelecionado(Comum.Clases.GrupoProduto grupoProduto, bool imageOn);
        public event dGrupoProdutoSelecionado EventoGrupoProdutoSelecionado;


        public Comum.Clases.GrupoProduto grupoProduto;
        PictureBox pic = null;
        bool ImageOn;

        public ucGrupoProduto(Comum.Clases.GrupoProduto gp)
        {
            InitializeComponent();
            grupoProduto = gp;
            pic = new PictureBox();
            label1.Text = gp.Descricao;
            SetImage(Informatiz.ControleEstoque.Aplicacao.Properties.Resources.button_on, grupoProduto.Descricao, Brushes.Black, true);

            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Tag = gp.Identificador;
            pic.Name = gp.Identificador;

            pic.BringToFront();
            pic.MouseHover += new EventHandler(pic_MouseHover);
            pic.MouseLeave += new EventHandler(pic_MouseLeave);
            pic.Click += new EventHandler(pic_Click);
            pnlPicture.Controls.Add(pic);
        }

        private void pic_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pic_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void pic_Click(object sender, EventArgs e)
        {
            if (ImageOn)
            {
                SetImage(Informatiz.ControleEstoque.Aplicacao.Properties.Resources.button_off, grupoProduto.Descricao, Brushes.Red, false);
            }
            else
            {
                SetImage(Informatiz.ControleEstoque.Aplicacao.Properties.Resources.button_on, grupoProduto.Descricao, Brushes.Black, true);
            }

            EventoGrupoProdutoSelecionado(grupoProduto, ImageOn);
        }

        public void SetImage(Image img, string descricao, Brush cor, bool imageOn)
        {
            pic.Image = img;
            ImageOn = imageOn;
            //var font = new Font("Arial", 40, FontStyle.Bold, GraphicsUnit.Pixel);
            //var graphics = Graphics.FromImage(pic.Image);
            //graphics.DrawString(descricao, font, cor, new Point(40, 40));
        }

    }
}
