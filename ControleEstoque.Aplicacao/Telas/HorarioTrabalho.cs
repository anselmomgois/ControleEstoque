using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class HorarioTrabalho : TelaBase.BaseCE
    {
        #region"Variaveis"

        private Comum.Enumeradores.Enumeradores.CodigoDiaSemana _DiaSemana;
        private String _Descricao;
        private String _HoraInicio;
        private String _HoraFim;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Propriedades"

        public String HoraFim
        {
            get
            {
                return _HoraFim;
            }
        }

        public String HoraInicio
        {
            get
            {
                return _HoraInicio;
            }
        }

        #endregion

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnAceitar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tlpPrincipal);
            lblDia.Text = "Horário de trabalho de " + _Descricao;
            txtHorarioEntrada.Text = _HoraInicio;
            txtHorarioSaida.Text = _HoraFim;
            base.Inicializar();
        }

        public HorarioTrabalho(Comum.Enumeradores.Enumeradores.CodigoDiaSemana DiaSemana, String Descricao, String HoraInicio, String HoraFim)
        {
            InitializeComponent();

            _Descricao = Descricao;
            _DiaSemana = DiaSemana;
            _HoraFim = HoraFim;
            _HoraInicio = HoraInicio;

        }
              

        private void btnAceitar_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtHorarioEntrada.Text.Replace(":", "").Trim()))
                {
                    Aplicacao.Classes.Util.ExibirMensagemErro("Favor informar o horário de entrada.");
                    return;
                }

                if (string.IsNullOrEmpty(txtHorarioSaida.Text.Replace(":", "").Trim()))
                {
                    Aplicacao.Classes.Util.ExibirMensagemErro("Favor informar o horário de saída.");
                    return;
                }

                _HoraInicio = txtHorarioEntrada.Text;
                _HoraFim = txtHorarioSaida.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtHorarioEntrada_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
