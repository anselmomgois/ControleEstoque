using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CharmNotification;

namespace Informatiz.ControleEstoque.Aplicacao.Controles
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

            //Notification n = new Notification();
            //switch(TipoImagem)
            //{
            //    case TipoImagem.INFORMACAO:
            //        n.BackColor1 = Color.FromArgb(50, 100, 125);
            //        n.BackColor2 = Color.FromArgb(68, 136, 171);
            //        n.Icon = Properties.Resources.question_32;
            //        n.TextForeColor = Color.WhiteSmoke;
            //        n.TitleForeColor = Color.White;
            //        break;

            //    case TipoImagem.SUCESSO:

            //        n.BackColor1 = Color.FromArgb(76, 125, 36);
            //        n.BackColor2 = Color.FromArgb(102, 171, 36);
            //        n.Icon = Properties.Resources.ic_verified_user_48px_32;
            //        n.TextForeColor = Color.WhiteSmoke;
            //        n.TitleForeColor = Color.White;

            //        break;

            //    case TipoImagem.ERRO:

            //        n.BackColor1 = Color.FromArgb(175, 75, 50);
            //        n.BackColor2 = Color.FromArgb(239, 102, 66);
            //        n.Icon = Properties.Resources._678080_shield_error_32;
            //        n.TextForeColor = Color.WhiteSmoke;
            //        n.TitleForeColor = Color.White;

            //        break;

            //    case TipoImagem.WARNING:

            //        n.BackColor1 = Color.FromArgb(157, 125, 38);
            //        n.BackColor2 = Color.FromArgb(239, 171, 51);
            //        n.Icon = Properties.Resources._678136_shield_warning_32;
            //        n.TextForeColor = Color.WhiteSmoke;
            //        n.TitleForeColor = Color.White;

            //        break;

            //    case TipoImagem.UPDATE:

            //        n.Icon = Properties.Resources.windows_32;
            //        n.BackColor2 = Color.FromArgb(35, 35, 35);
            //        n.BackColor1 = Color.FromArgb(28, 28, 28);
            //        n.TitleForeColor = Color.WhiteSmoke;
            //        n.TextForeColor = Color.WhiteSmoke;

            //        break;

            //    case TipoImagem.DOWNLOAD:

            //        n.Icon = Properties.Resources.Download_32;
            //        n.BackColor2 = Color.FromArgb(35, 35, 35);
            //        n.BackColor1 = Color.FromArgb(28, 28, 28);
            //        n.TitleForeColor = Color.WhiteSmoke;
            //        n.TextForeColor = Color.WhiteSmoke;

            //        break;
            //}

            //n.Title = "I - GERENCE";
            //n.Text = Mensagem;
            //n.Duration = 2000;       
            //n.ShowNotification();

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
