using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Informatiz.ControleEstoque.Comum;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Server.Telas
{
    public partial class SelecionarEmpresa : TelaBase.BaseCE
    {
        public SelecionarEmpresa(List<Comum.Clases.Empresa> Empresas)
        {
            InitializeComponent();

            _Empresas = Empresas;
            PreencherEmpresas();
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Variaveis"

        private List<Comum.Clases.Empresa> _Empresas;
        private List<Comum.Clases.Filiais> _Filiais;

        #endregion

        #region"Propriedades"

        public Comum.Clases.Empresa EmpresaUsuarioSelecionada { get; set; }

        #endregion

        #region"Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.aceitar, new EventHandler(btnLogar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);

        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tableLayoutPanel3);
            base.Inicializar();
        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado)
        {
            base.DesabilitarControles(NomeControles, Habilitado);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        private void PreencherEmpresas()
        {

            if (_Empresas != null && _Empresas.Count > 0)
            {

                List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_Empresas, "Identificador", "Nome");

                ddlEmpresa = frmWindows.Util.PreencherCombobox(ddlEmpresa, Items);

                if (_Empresas.Count == 1)
                {
                    ddlEmpresa.SelectedIndex = 0;
                    ddlEmpresa.Enabled = false;
                }

            }
        }

        private void PreencherFiliais()
        {

            Comum.Clases.Empresa EmpresaSelecionada = null;

            if (ddlEmpresa.SelectedItem != null)
            {
                EmpresaSelecionada = (Comum.Clases.Empresa)(frmWindows.Util.RecuperarItemSelecionado(ddlEmpresa, _Empresas, "Identificador"));

                Comum.Clases.Empresa objEmpresa = (from emp in _Empresas where emp.Identificador == EmpresaSelecionada.Identificador select emp).FirstOrDefault();

                if (objEmpresa != null && objEmpresa.Filiais != null && objEmpresa.Filiais.Count > 0)
                {
                    _Filiais = objEmpresa.Filiais;
                    List<frmWindows.Item> ItemsFiliais = frmWindows.Util.ConverterItems(objEmpresa.Filiais, "Identificador", "Nome");
                    ddlFilial = frmWindows.Util.PreencherCombobox(ddlFilial, ItemsFiliais);
                }

            }
        }

        private void RecuperarEmpresa()
        {

            if (ddlEmpresa.SelectedItem != null && ddlFilial.SelectedItem != null)
            {

                Comum.Clases.Filiais objFilial = (Comum.Clases.Filiais)(frmWindows.Util.RecuperarItemSelecionado(ddlFilial, _Filiais, "Identificador"));
                Comum.Clases.Empresa EmpresaSelecionada = (Comum.Clases.Empresa)(frmWindows.Util.RecuperarItemSelecionado(ddlEmpresa, _Empresas, "Identificador"));
                Comum.Clases.Empresa objEmpSel = (from emp in _Empresas where emp.Identificador == EmpresaSelecionada.Identificador select emp).FirstOrDefault();

                if (objEmpSel != null)
                {

                    objEmpSel.Filiais.RemoveAll(f => f.Identificador != objFilial.Identificador);
                    EmpresaUsuarioSelecionada = objEmpSel;
                }
            }
            else
            {
                Classes.Util.ExibirMensagemErro("Favor selecionar uma filial.");
                return;
            }

            this.Close();
        }

        #endregion

        private void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                PreencherFiliais();

            }
            catch (Exception ex)
            {
                Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {

            try
            {

                RecuperarEmpresa();

            }
            catch (Exception ex)
            {
                Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }

        }


    }
}
