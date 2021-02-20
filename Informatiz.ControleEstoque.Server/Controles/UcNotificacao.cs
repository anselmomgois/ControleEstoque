using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CharmNotification;

namespace Informatiz.ControleEstoque.Server.Controles
{
    public partial class UcNotificacao : UserControl
    {
        public UcNotificacao()
        {
            InitializeComponent();
        }

        private DateTime HoraInicio;

        public enum TipoImagem
        {
            INFORMACAO = 1,
            ERRO = 2,
            SUCESSO = 3,
            WARNING = 4,
            UPDATE = 5,
            DOWNLOAD = 6
        }
        public void ExibirMensagem(string Mensagem, TipoImagem TipoImagem)
        {



            ppNotificacao.TitleText = "I - GERENCE";
            ppNotificacao.ContentText = Mensagem;
            ppNotificacao.ShowCloseButton = true;
            ppNotificacao.ShowOptionsButton = false;
            ppNotificacao.ShowGrip = true;
            ppNotificacao.Delay = 3000;
            ppNotificacao.AnimationInterval = 10;
            ppNotificacao.AnimationDuration = 1000;
            ppNotificacao.TitlePadding = new Padding(0);
            ppNotificacao.ContentPadding = new Padding(0);
            ppNotificacao.ImagePadding = new Padding(0);
            ppNotificacao.Scroll = true;
            if (TipoImagem == UcNotificacao.TipoImagem.SUCESSO)
            {
                ppNotificacao.Image = Properties.Resources.agt_action_success;
            }
            else if (TipoImagem == UcNotificacao.TipoImagem.ERRO)
            {
                ppNotificacao.Image = Properties.Resources.symbol_error;
            }
            else
            {
                ppNotificacao.Image = Properties.Resources.symbol_information;
            }

            ppNotificacao.Popup();

            HoraInicio = DateTime.Now;
            tmpTimer.Start();


        }

        private void tmpTimer_Tick(object sender, EventArgs e)
        {

            DateTime objHora = HoraInicio.AddSeconds(5);
            if (DateTime.Now > objHora)
            {
                ppNotificacao.Hide();
                tmpTimer.Stop();
            }


        }


    }
}
