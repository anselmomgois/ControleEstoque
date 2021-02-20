using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas.TelaBase
{
    public partial class Base : Form
    {
        private Ribbon objRibon;

        public Base()
        {
            InitializeComponent();

            objRibon = new Ribbon();
            objRibon.CaptionBarVisible = false;
            objRibon.Dock = DockStyle.Fill;
            objRibon.Height = 130;
            objRibon.Margin = new Padding(0);
            pnlMenu.Controls.Add(objRibon);
            objRetorno = new KeyValuePair<string, string>();
            _LinhaSelecionadaGrid = new Dictionary<string, KeyValuePair<string, string>>();
            
        }



        #region "Constantes"

        public const string gPadrao = "gPadrao";
        public const string tPadrao = "tPadrao";
        public const string tNomeParao = "I - GERENCE";
        public const string gNomePadrao = "Opções";
        public const string btnMais = "btnMais";

        #endregion

        public delegate void ModificarDelegate(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex);
        public event ModificarDelegate ModificarRegistro;
        public delegate void DeletarDelegate(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex);
        public event DeletarDelegate DeletarRegistro;
        public delegate void InserirDelegate(string NomeGrid);
        public event InserirDelegate InserirRegistro;

        #region "Variaveis"
        private List<Classes.BotaoAtalho> _Atalhos;
        private  Dictionary<string, KeyValuePair<string, string>> _LinhaSelecionadaGrid;
        private  KeyValuePair<string, string> objRetorno;
        private Nullable<DateTime> _execucaoDoubleClick;
        #endregion

        #region "Metodos"

        public virtual Boolean ItemMenuVisivel(string NomeGrupo, string NomeTab, string NomeBotao)
        {

            NomeTab = (string.IsNullOrEmpty(NomeTab) ? tPadrao : NomeTab);
            NomeGrupo = (string.IsNullOrEmpty(NomeGrupo) ? gPadrao : NomeGrupo);

            RibbonTab rbnTAb = objRibon.Tabs.Find(t => t.Name == NomeTab);

            if (rbnTAb != null)
            {

                RibbonPanel objPanelRibon = rbnTAb.Panels.Find(p => p.Name == NomeGrupo);

                if (objPanelRibon != null)
                {
                    try
                    {
                        RibbonButton objButon = (RibbonButton)objPanelRibon.Items.Find(b => b.Name == NomeBotao);

                        if (objButon != null)
                        {
                           return objButon.Visible;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }

            return false;

        }

        public virtual void OcultarItemMenu(string NomeGrupo, string NomeTab, string NomeBotao, Boolean Ocultar)
        {

            NomeTab = (string.IsNullOrEmpty(NomeTab) ? tPadrao : NomeTab);
            NomeGrupo = (string.IsNullOrEmpty(NomeGrupo) ? gPadrao : NomeGrupo);

            RibbonTab rbnTAb = objRibon.Tabs.Find(t => t.Name == NomeTab);

            if (rbnTAb != null)
            {

                RibbonPanel objPanelRibon = rbnTAb.Panels.Find(p => p.Name == NomeGrupo);

                if (objPanelRibon != null)
                {
                    try
                    {
                        RibbonButton objButon = (RibbonButton)objPanelRibon.Items.Find(b => b.Name == NomeBotao);

                        if (objButon != null)
                        {
                            objButon.Visible = !Ocultar;
                        }
                        objRibon.Refresh();
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }

        }

        public virtual void AtualizarItemMenu(string NomeGrupo, string NomeTab, string NomeBotao, string Texto, Image imgBotao)
        {

            NomeTab = (string.IsNullOrEmpty(NomeTab) ? tPadrao : NomeTab);
            NomeGrupo = (string.IsNullOrEmpty(NomeGrupo) ? gPadrao : NomeGrupo);

            RibbonTab rbnTAb = objRibon.Tabs.Find(t => t.Name == NomeTab);

            if (rbnTAb != null)
            {

                RibbonPanel objPanelRibon = rbnTAb.Panels.Find(p => p.Name == NomeGrupo);

                if (objPanelRibon != null)
                {
                    try
                    {
                        RibbonButton objButon = (RibbonButton)objPanelRibon.Items.Find(b => b.Name == NomeBotao);

                        if (objButon != null)
                        {
                            if (!string.IsNullOrEmpty(Texto))
                            {
                                objButon.Text = Texto;
                            }

                            if (imgBotao != null)
                            {
                                objButon.Image = imgBotao;
                            }

                            objRibon.Refresh();

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
        }

        public virtual void AtualizarItemMenu(string NomeGrupo, string NomeTab, string NomeBotao, string Texto, Image imgBotao, Int32 Width)
        {

            NomeTab = (string.IsNullOrEmpty(NomeTab) ? tPadrao : NomeTab);
            NomeGrupo = (string.IsNullOrEmpty(NomeGrupo) ? gPadrao : NomeGrupo);

            RibbonTab rbnTAb = objRibon.Tabs.Find(t => t.Name == NomeTab);

            if (rbnTAb != null)
            {

                RibbonPanel objPanelRibon = rbnTAb.Panels.Find(p => p.Name == NomeGrupo);

                if (objPanelRibon != null)
                {
                    try
                    {
                        RibbonButton objButon = (RibbonButton)objPanelRibon.Items.Find(b => b.Name == NomeBotao);

                        if (objButon != null)
                        {

                            if (Width > 0)
                            {
                                objButon.MinimumSize = new Size(Width, objButon.MinimumSize.Height);
                            }

                            if (!string.IsNullOrEmpty(Texto))
                            {
                                objButon.Text = Texto;
                            }

                            if (imgBotao != null)
                            {
                                objButon.Image = imgBotao;
                            }

                            objRibon.Refresh();

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
        }

        public virtual void AdicionarComboMenu(string NomeGrupo, string NomeTab)
        {
            NomeTab = (string.IsNullOrEmpty(NomeTab) ? tPadrao : NomeTab);
            NomeGrupo = (string.IsNullOrEmpty(NomeGrupo) ? gPadrao : NomeGrupo);

            RibbonTab rbnTAb = objRibon.Tabs.Find(t => t.Name == NomeTab);

            if (rbnTAb != null)
            {

                RibbonPanel objPanelRibon = rbnTAb.Panels.Find(p => p.Name == NomeGrupo);

                if (objPanelRibon != null && !objPanelRibon.Items.Exists(i => i.GetType() == typeof(RibbonButtonList)))
                {

                    RibbonButtonList objButon = new RibbonButtonList()
                    {
                        Text = "Mais",
                        Name = btnMais,
                        Image = Properties.Resources.plus_orange,
                        TextAlignment = RibbonItem.RibbonItemTextAlignment.Center
                    };

                    objPanelRibon.Items.Add(objButon);


                    ReordenarMenu(objPanelRibon.Name, objPanelRibon.OwnerTab.Name, objPanelRibon);
                }
            }
        }

        public virtual void ReordenarMenu(string NomeGrupo, string NomeTab, RibbonPanel objPanel)
        {
            NomeTab = (string.IsNullOrEmpty(NomeTab) ? tPadrao : NomeTab);
            NomeGrupo = (string.IsNullOrEmpty(NomeGrupo) ? gPadrao : NomeGrupo);

            RibbonTab rbnTAb = objRibon.Tabs.Find(t => t.Name == NomeTab);

            if (rbnTAb != null)
            {

                RibbonPanel objPanelRibon = rbnTAb.Panels.Find(p => p.Name == NomeGrupo);

                if (objPanelRibon != null)
                {
                    RibbonButton objButon = (RibbonButton)objPanel.Items.FindAll(i => i.GetType() != typeof(RibbonButtonList)).LastOrDefault();


                    if (objPanelRibon.Items.Exists(i => i.GetType() == typeof(RibbonButtonList)))
                    {
                        objPanelRibon.Items.RemoveAt(objPanel.Items.Count - 2);

                        RibbonButtonList objButonList = (RibbonButtonList)objPanelRibon.Items.Find(b => b.Name == btnMais);

                        objButonList.DropDownItems.Add(objButon);
                    }

                }
            }
        }

        public virtual void AdicionarItemMenu(string NomeGrupo, string TextoGrupo, string NomeTab, string TextoTab, string TextoBotao,
                                              string NomeBotao, Image ImgBotao, EventHandler Evento, Boolean Visivel = true)
        {
            NomeTab = (string.IsNullOrEmpty(NomeTab) ? tPadrao : NomeTab);
            NomeGrupo = (string.IsNullOrEmpty(NomeGrupo) ? gPadrao : NomeGrupo);
            TextoGrupo = (string.IsNullOrEmpty(TextoGrupo) ? gNomePadrao : TextoGrupo);
            TextoTab = (string.IsNullOrEmpty(TextoTab) ? tNomeParao : TextoTab);

            RibbonTab rbnTAb = objRibon.Tabs.Find(t => t.Name == NomeTab);

            if (rbnTAb == null)
            {
                objRibon.Tabs.Add(new RibbonTab()
                {
                    Name = NomeTab,
                    Text = TextoTab
                });

                rbnTAb = objRibon.Tabs.LastOrDefault();
            }

            RibbonPanel objPanelRibon = rbnTAb.Panels.Find(p => p.Name == NomeGrupo);

            if (objPanelRibon == null)
            {
                rbnTAb.Panels.Add(new RibbonPanel()
                {
                    Name = NomeGrupo,
                    Text = TextoGrupo
                });

                objPanelRibon = rbnTAb.Panels.LastOrDefault();
            }

            RibbonButton objButon = new RibbonButton()
            {
                Text = TextoBotao,
                Name = NomeBotao,
                Image = ImgBotao,
                Visible = Visivel,
                TextAlignment = RibbonItem.RibbonItemTextAlignment.Center
            };


            objButon.Click += Evento;

            if (objPanelRibon.Items.Exists(i => i.GetType() == typeof(RibbonButtonList)))
            {
                RibbonButtonList objButonList = (RibbonButtonList)objPanelRibon.Items.Find(b => b.Name == btnMais);

                objButonList.DropDownItems.Add(objButon);
            }
            else
            {
                objPanelRibon.Items.Add(objButon);

                if (objPanelRibon.SizeMode != RibbonElementSizeMode.Large && objPanelRibon.OwnerTab != null)
                {
                    AdicionarComboMenu(objPanelRibon.Name, objPanelRibon.OwnerTab.Name);
                }

            }
        }


        public virtual void AdicionarItemMenu(string NomeGrupo, string TextoGrupo, string NomeTab, string TextoTab, string TextoBotao,
                                             string NomeBotao, Image ImgBotao, EventHandler Evento, Boolean FlashHabilitado, Boolean Visivel = true)
        {

            NomeTab = (string.IsNullOrEmpty(NomeTab) ? tPadrao : NomeTab);
            NomeGrupo = (string.IsNullOrEmpty(NomeGrupo) ? gPadrao : NomeGrupo);
            TextoGrupo = (string.IsNullOrEmpty(TextoGrupo) ? gNomePadrao : TextoGrupo);
            TextoTab = (string.IsNullOrEmpty(TextoTab) ? tNomeParao : TextoTab);

            RibbonTab rbnTAb = objRibon.Tabs.Find(t => t.Name == NomeTab);

            if (rbnTAb == null)
            {
                objRibon.Tabs.Add(new RibbonTab()
                {
                    Name = NomeTab,
                    Text = TextoTab
                });

                rbnTAb = objRibon.Tabs.LastOrDefault();

            }

            RibbonPanel objPanelRibon = rbnTAb.Panels.Find(p => p.Name == NomeGrupo);

            if (objPanelRibon == null)
            {
                rbnTAb.Panels.Add(new RibbonPanel()
                {
                    Name = NomeGrupo,
                    Text = TextoGrupo
                });

                objPanelRibon = rbnTAb.Panels.LastOrDefault();
            }

            RibbonButton objButon = new RibbonButton()
            {
                Text = TextoBotao,
                Name = NomeBotao,
                Image = ImgBotao,
                Visible = Visivel,
                TextAlignment = RibbonItem.RibbonItemTextAlignment.Center,
                FlashEnabled = FlashHabilitado
            };

            objButon.Click += Evento;

            if (objPanelRibon.Items.Exists(i => i.GetType() == typeof(RibbonButtonList)))
            {
                RibbonButtonList objButonList = (RibbonButtonList)objPanelRibon.Items.Find(b => b.Name == btnMais);

                objButonList.DropDownItems.Add(objButon);
            }
            else
            {
                objPanelRibon.Items.Add(objButon);

                if (objPanelRibon.SizeMode != RibbonElementSizeMode.Large && objPanelRibon.OwnerTab != null)
                {
                    AdicionarComboMenu(objPanelRibon.Name, objPanelRibon.OwnerTab.Name);
                }

            }

        }

        public virtual void AdicionarItemMenu(string NomeGrupo, string TextoGrupo, string NomeTab, string TextoTab, string TextoBotao,
                                              string NomeBotao, Image ImgBotao, EventHandler Evento,
                                              Nullable<Keys> Key, Boolean Alt, Boolean Shift, Boolean Control, Boolean Visivel = true)
        {
            NomeTab = (string.IsNullOrEmpty(NomeTab) ? tPadrao : NomeTab);
            NomeGrupo = (string.IsNullOrEmpty(NomeGrupo) ? gPadrao : NomeGrupo);
            TextoGrupo = (string.IsNullOrEmpty(TextoGrupo) ? gNomePadrao : TextoGrupo);
            TextoTab = (string.IsNullOrEmpty(TextoTab) ? tNomeParao : TextoTab);

            RibbonTab rbnTAb = objRibon.Tabs.Find(t => t.Name == NomeTab);

            if (rbnTAb == null)
            {
                objRibon.Tabs.Add(new RibbonTab()
                {
                    Name = NomeTab,
                    Text = TextoTab
                });

                rbnTAb = objRibon.Tabs.LastOrDefault();
            }

            RibbonPanel objPanelRibon = rbnTAb.Panels.Find(p => p.Name == NomeGrupo);

            if (objPanelRibon == null)
            {
                rbnTAb.Panels.Add(new RibbonPanel()
                {
                    Name = NomeGrupo,
                    Text = TextoGrupo
                });

                objPanelRibon = rbnTAb.Panels.LastOrDefault();
            }

            RibbonButton objButon = new RibbonButton()
            {
                Text = TextoBotao,
                Name = NomeBotao,
                Image = ImgBotao,
                Visible = Visivel,
                TextAlignment = RibbonItem.RibbonItemTextAlignment.Center
            };

            if (Key != null)
            {
                if (_Atalhos == null) { _Atalhos = new List<Classes.BotaoAtalho>(); }

                if (!_Atalhos.Exists(a => a.Shift == Shift && a.Key == Key && a.Control == Control && a.Alt == Alt))
                {
                    _Atalhos.Add(new Classes.BotaoAtalho()
                    {
                        Alt = Alt,
                        Key = (Keys)Key,
                        Control = Control,
                        NomeBotao = NomeBotao,
                        NomeGrupo = NomeGrupo,
                        NomeTab = NomeTab,
                        Shift = Shift
                    });
                }
            }
            objButon.Click += Evento;

            if (objPanelRibon.Items.Exists(i => i.GetType() == typeof(RibbonButtonList)))
            {
                RibbonButtonList objButonList = (RibbonButtonList)objPanelRibon.Items.Find(b => b.Name == btnMais);

                objButonList.DropDownItems.Add(objButon);
            }
            else
            {
                objPanelRibon.Items.Add(objButon);

                if (objPanelRibon.SizeMode != RibbonElementSizeMode.Large && objPanelRibon.OwnerTab != null)
                {
                    AdicionarComboMenu(objPanelRibon.Name, objPanelRibon.OwnerTab.Name);
                }
            }


        }

        public virtual void AdicionarItemMenu(string NomeGrupo, string TextoGrupo, string NomeTab, string TextoTab, string TextoBotao,
                                             string NomeBotao, Image ImgBotao, EventHandler Evento, Int32 Width, Boolean Visivel = true)
        {
            NomeTab = (string.IsNullOrEmpty(NomeTab) ? tPadrao : NomeTab);
            NomeGrupo = (string.IsNullOrEmpty(NomeGrupo) ? gPadrao : NomeGrupo);
            TextoGrupo = (string.IsNullOrEmpty(TextoGrupo) ? gNomePadrao : TextoGrupo);
            TextoTab = (string.IsNullOrEmpty(TextoTab) ? tNomeParao : TextoTab);

            RibbonTab rbnTAb = objRibon.Tabs.Find(t => t.Name == NomeTab);

            if (rbnTAb == null)
            {
                objRibon.Tabs.Add(new RibbonTab()
                {
                    Name = NomeTab,
                    Text = TextoTab
                });

                rbnTAb = objRibon.Tabs.LastOrDefault();
            }

            RibbonPanel objPanelRibon = rbnTAb.Panels.Find(p => p.Name == NomeGrupo);

            if (objPanelRibon == null)
            {
                rbnTAb.Panels.Add(new RibbonPanel()
                {
                    Name = NomeGrupo,
                    Text = TextoGrupo
                });

                objPanelRibon = rbnTAb.Panels.LastOrDefault();
            }

            RibbonButton objButon = new RibbonButton()
            {
                Text = TextoBotao,
                Name = NomeBotao,
                Image = ImgBotao,
                Visible = Visivel,
                TextAlignment = RibbonItem.RibbonItemTextAlignment.Center
            };

            if (Width > 0)
            {
                objButon.MinimumSize = new Size(Width, objButon.MinimumSize.Height);
            }

            objButon.Click += Evento;

            if (objPanelRibon.Items.Exists(i => i.GetType() == typeof(RibbonButtonList)))
            {
                RibbonButtonList objButonList = (RibbonButtonList)objPanelRibon.Items.Find(b => b.Name == btnMais);

                objButonList.DropDownItems.Add(objButon);
            }
            else
            {
                objPanelRibon.Items.Add(objButon);

                if (objPanelRibon.SizeMode != RibbonElementSizeMode.Large && objPanelRibon.OwnerTab != null)
                {
                    AdicionarComboMenu(objPanelRibon.Name, objPanelRibon.OwnerTab.Name);
                }

            }
        }


        public virtual void AdicionarItemMenu(string NomeGrupo, string TextoGrupo, string NomeTab, string TextoTab, string TextoBotao,
                                             string NomeBotao, Image ImgBotao, EventHandler Evento, Boolean FlashHabilitado, Int32 Width, Boolean Visivel = true)
        {

            NomeTab = (string.IsNullOrEmpty(NomeTab) ? tPadrao : NomeTab);
            NomeGrupo = (string.IsNullOrEmpty(NomeGrupo) ? gPadrao : NomeGrupo);
            TextoGrupo = (string.IsNullOrEmpty(TextoGrupo) ? gNomePadrao : TextoGrupo);
            TextoTab = (string.IsNullOrEmpty(TextoTab) ? tNomeParao : TextoTab);

            RibbonTab rbnTAb = objRibon.Tabs.Find(t => t.Name == NomeTab);

            if (rbnTAb == null)
            {
                objRibon.Tabs.Add(new RibbonTab()
                {
                    Name = NomeTab,
                    Text = TextoTab
                });

                rbnTAb = objRibon.Tabs.LastOrDefault();

            }

            RibbonPanel objPanelRibon = rbnTAb.Panels.Find(p => p.Name == NomeGrupo);

            if (objPanelRibon == null)
            {
                rbnTAb.Panels.Add(new RibbonPanel()
                {
                    Name = NomeGrupo,
                    Text = TextoGrupo
                });

                objPanelRibon = rbnTAb.Panels.LastOrDefault();
            }

            RibbonButton objButon = new RibbonButton()
            {
                Text = TextoBotao,
                Name = NomeBotao,
                Image = ImgBotao,
                Visible = Visivel,
                TextAlignment = RibbonItem.RibbonItemTextAlignment.Center,
                FlashEnabled = FlashHabilitado
            };

            if (Width > 0)
            {
                objButon.MinimumSize = new Size(Width, objButon.MinimumSize.Height);
            }

            objButon.Click += Evento;

            if (objPanelRibon.Items.Exists(i => i.GetType() == typeof(RibbonButtonList)))
            {
                RibbonButtonList objButonList = (RibbonButtonList)objPanelRibon.Items.Find(b => b.Name == btnMais);

                objButonList.DropDownItems.Add(objButon);
            }
            else
            {
                objPanelRibon.Items.Add(objButon);

                if (objPanelRibon.SizeMode != RibbonElementSizeMode.Large && objPanelRibon.OwnerTab != null)
                {
                    AdicionarComboMenu(objPanelRibon.Name, objPanelRibon.OwnerTab.Name);
                }

            }

        }

        public virtual void AdicionarItemMenu(string NomeGrupo, string TextoGrupo, string NomeTab, string TextoTab, string TextoBotao,
                                              string NomeBotao, Image ImgBotao, EventHandler Evento,
                                              Nullable<Keys> Key, Boolean Alt, Boolean Shift, Boolean Control, Int32 Width, Boolean Visivel = true)
        {
            NomeTab = (string.IsNullOrEmpty(NomeTab) ? tPadrao : NomeTab);
            NomeGrupo = (string.IsNullOrEmpty(NomeGrupo) ? gPadrao : NomeGrupo);
            TextoGrupo = (string.IsNullOrEmpty(TextoGrupo) ? gNomePadrao : TextoGrupo);
            TextoTab = (string.IsNullOrEmpty(TextoTab) ? tNomeParao : TextoTab);

            RibbonTab rbnTAb = objRibon.Tabs.Find(t => t.Name == NomeTab);

            if (rbnTAb == null)
            {
                objRibon.Tabs.Add(new RibbonTab()
                {
                    Name = NomeTab,
                    Text = TextoTab
                });

                rbnTAb = objRibon.Tabs.LastOrDefault();
            }

            RibbonPanel objPanelRibon = rbnTAb.Panels.Find(p => p.Name == NomeGrupo);

            if (objPanelRibon == null)
            {
                rbnTAb.Panels.Add(new RibbonPanel()
                {
                    Name = NomeGrupo,
                    Text = TextoGrupo
                });

                objPanelRibon = rbnTAb.Panels.LastOrDefault();
            }

            RibbonButton objButon = new RibbonButton()
            {
                Text = TextoBotao,
                Name = NomeBotao,
                Image = ImgBotao,
                Visible = Visivel,
                TextAlignment = RibbonItem.RibbonItemTextAlignment.Center
            };

            if (Key != null)
            {
                if (_Atalhos == null) { _Atalhos = new List<Classes.BotaoAtalho>(); }

                if (!_Atalhos.Exists(a => a.Shift == Shift && a.Key == Key && a.Control == Control && a.Alt == Alt))
                {
                    _Atalhos.Add(new Classes.BotaoAtalho()
                    {
                        Alt = Alt,
                        Key = (Keys)Key,
                        Control = Control,
                        NomeBotao = NomeBotao,
                        NomeGrupo = NomeGrupo,
                        NomeTab = NomeTab,
                        Shift = Shift
                    });
                }
            }

            if (Width > 0)
            {
                objButon.MinimumSize = new Size(Width, objButon.MinimumSize.Height);
            }

            objButon.Click += Evento;

            if (objPanelRibon.Items.Exists(i => i.GetType() == typeof(RibbonButtonList)))
            {
                RibbonButtonList objButonList = (RibbonButtonList)objPanelRibon.Items.Find(b => b.Name == btnMais);

                objButonList.DropDownItems.Add(objButon);
            }
            else
            {
                objPanelRibon.Items.Add(objButon);

                if (objPanelRibon.SizeMode != RibbonElementSizeMode.Large && objPanelRibon.OwnerTab != null)
                {
                    AdicionarComboMenu(objPanelRibon.Name, objPanelRibon.OwnerTab.Name);
                }
            }


        }

        public virtual void OcultarTab(string NomeTab, Boolean Ocultar)
        {
            RibbonTab rbnTAb = objRibon.Tabs.Find(t => t.Name == NomeTab);

            if (rbnTAb != null)
            {
                rbnTAb.Visible = !Ocultar;
            }
        }

        public virtual void AdicionarOrbMenu(string NomeTab, string TextoTab, Boolean Ocultar, EventHandler Evento, Image imgItem)
        {
            objRibon.CaptionBarVisible = true;
            objRibon.OrbImage = Properties.Resources.logo_reduzido;


            RibbonOrbMenuItem objItemMenu = (objRibon.OrbDropDown.MenuItems.Exists(m => m.Name == NomeTab) ? (RibbonOrbMenuItem)objRibon.OrbDropDown.MenuItems.Find(m => m.Name == NomeTab) : null);
            objRibon.OrbDropDown.Height = 70;
            objRibon.OrbDropDown.Width = 160;

            if (objItemMenu == null)
            {
                objRibon.OrbDropDown.MenuItems.Add(new RibbonOrbMenuItem()
                {
                    Name = NomeTab,
                    Text = TextoTab,
                    Image = imgItem
                });
                objItemMenu = (RibbonOrbMenuItem)objRibon.OrbDropDown.MenuItems.LastOrDefault();
                objItemMenu.Click += Evento;

            }

            objItemMenu.Text = TextoTab;
            if (tlpTopo.RowStyles[0].Height == 130)
            {
                tlpTopo.RowStyles[0].Height = 160;
                objRibon.Height = 160;
            }

        }

        public virtual void AtualizarTextoOrbMenu(string NomeTab, string TextoTab)
        {
            objRibon.CaptionBarVisible = true;
            objRibon.OrbImage = Properties.Resources.logo_reduzido;


            RibbonOrbMenuItem objItemMenu = (objRibon.OrbDropDown.MenuItems.Exists(m => m.Name == NomeTab) ? (RibbonOrbMenuItem)objRibon.OrbDropDown.MenuItems.Find(m => m.Name == NomeTab) : null);

            if (objItemMenu != null)
            {
                objItemMenu = (RibbonOrbMenuItem)objRibon.OrbDropDown.MenuItems.LastOrDefault();
                objItemMenu.Text = TextoTab;

            }
        }

        public virtual Boolean ExisteOrbMenu(string NomeTab)
        {
            return objRibon.OrbDropDown.MenuItems.Exists(m => m.Name == NomeTab);

        }

        public void RecuperarLinhaSelecionadaGrid(Control controle)
        {


            if (controle is DataGridView)
            {
                DataGridView objGrid = (DataGridView)(controle);
                objGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                objGrid.MultiSelect = false;
                objGrid.SelectionChanged += ObjGrid_SelectionChanged;
                objGrid.KeyDown += ObjGrid_KeyDown;
                objGrid.CellDoubleClick += ObjGrid_CellDoubleClick;
                
            }

            // chamada recursiva para configurar os controles filhos do item atual 
            if (controle.Controls != null && controle.Controls.Count > 0)
            {
                foreach (Control controleFilho in controle.Controls)
                {
                    RecuperarLinhaSelecionadaGrid(controleFilho);

                }
            }
        }
        
        private void ObjGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (_execucaoDoubleClick != null)
            {
                int totalSeconds = (DateTime.Now.Subtract(Convert.ToDateTime(_execucaoDoubleClick))).Seconds;
                if (totalSeconds < 3)
                {
                    _execucaoDoubleClick = null;
                    return;
                }
                _execucaoDoubleClick = null;
            }
            RecuperarItemSelecionado(sender, ref objRetorno);
            
            if(string.IsNullOrEmpty(objRetorno.Key))
            {
                RecuperarLinhaSelecionada(sender);
                RecuperarItemSelecionado(sender, ref objRetorno);
            }
            DataGridView objGrid = (DataGridView)(sender);

            ModificarRegistro(objRetorno, objGrid.Name,e.RowIndex,e.ColumnIndex);
            _execucaoDoubleClick = DateTime.Now;
        }

        
        private void ObjGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RecuperarItemSelecionado(sender, ref objRetorno);

                if (string.IsNullOrEmpty(objRetorno.Key))
                {
                    RecuperarLinhaSelecionada(sender);
                    RecuperarItemSelecionado(sender, ref objRetorno);
                }
                DataGridView objGrid = (DataGridView)(sender);

                DeletarRegistro(objRetorno, objGrid.Name,objGrid.CurrentRow.Index,objGrid.CurrentCell.ColumnIndex);
            }
            else if(e.KeyCode == Keys.Insert)
            {
                DataGridView objGrid = (DataGridView)(sender);
                InserirRegistro(objGrid.Name);
            }
        }

        private void RecuperarItemSelecionado(object sender, ref KeyValuePair<string, string> objRetorno)
        {
            if (sender != null)
            {
                DataGridView objGrid = (DataGridView)(sender);

                if (_LinhaSelecionadaGrid != null && _LinhaSelecionadaGrid.Count > 0)
                {
                    _LinhaSelecionadaGrid.TryGetValue(objGrid.Name, out objRetorno);
                }
                
            }

        }
        private void ObjGrid_SelectionChanged(object sender, EventArgs e)
        {
            RecuperarLinhaSelecionada(sender);
        }

        private void RecuperarLinhaSelecionada(object sender)
        {
            if (sender != null && !DesabilitarSelecaoLinha)
            {
                DataGridView objGrid = (DataGridView)(sender);

                string Coluna = (from DataGridViewColumn c in objGrid.Columns where c.Name.ToUpper().Contains("ID") select c.Name).FirstOrDefault();
                if (!string.IsNullOrEmpty(Coluna) && objGrid.CurrentRow != null && !string.IsNullOrEmpty(objGrid.CurrentRow.Cells[Coluna].Value as string) && !objGrid.MultiSelect)
                {
                    if (_LinhaSelecionadaGrid == null) { _LinhaSelecionadaGrid = new Dictionary<string, KeyValuePair<string, string>>(); }

                    if (_LinhaSelecionadaGrid.ContainsKey(objGrid.Name))
                    {
                        _LinhaSelecionadaGrid.Remove(objGrid.Name);
                    }

                    KeyValuePair<string, string> objDic = new KeyValuePair<string, string>(Coluna, objGrid.CurrentRow.Cells[Coluna].Value as string);
                    _LinhaSelecionadaGrid.Add(objGrid.Name, objDic);


                }
            }
        }

        public virtual void Inicializar()
        {

            if (!(DesignMode))
            {

                // adicionar evento de foco ao entrar e sair dos componentes
                Classes.Util.ConfigurarFocoComponentes(this);
                Classes.Util.ConfigurarEstilo(this);
                RecuperarLinhaSelecionadaGrid(this);
            }
        }

        protected virtual void MontarMenu(Boolean GerarGrupo)
        {

            if (GerarGrupo)
            {
                AdicionarItemMenu("gSair", "Sair", "tSair", "Sair",
    "Sair (F11)", "btnSair",
    Properties.Resources.exit, new EventHandler(btnSair_Click), Keys.F11, false, false, false);
            }
            else
            {
                AdicionarItemMenu(null, null, null, null,
                    "Sair (F11)", "btnSair",
                    Properties.Resources.exit, new EventHandler(btnSair_Click), Keys.F11, false, false, false);
            }
        }

        protected virtual void MontarMenu(Boolean GerarGrupo, Boolean GerarBotaoSair)
        {

            if (GerarBotaoSair)
            {
                if (GerarGrupo)
                {
                    AdicionarItemMenu("gSair", "Sair", "tSair", "Sair",
        "Sair (F11)", "btnSair",
        Properties.Resources.exit, new EventHandler(btnSair_Click), Keys.F11, false, false, false);
                }
                else
                {
                    AdicionarItemMenu(null, null, null, null,
                        "Sair (F11)", "btnSair",
                        Properties.Resources.exit, new EventHandler(btnSair_Click), Keys.F11, false, false, false);
                }
            }
        }

        public virtual void ConfigurarFocoComponentes()
        {

            // adicionar evento de foco ao entrar e sair dos componentes
            Classes.Util.ConfigurarFocoComponentes(this);

        }

        public virtual void AcionarTeclaAtalho(Control controle)
        {

            if (_Atalhos != null && _Atalhos.Count > 0)
            {
                if ((controle is DataGridView))
                {
                    DataGridView grid = controle as DataGridView;

                    if (grid != null)
                    {
                        grid.KeyDown += Base_KeyDown;
                    }


                }
                else if ((controle is Form) || (controle is MaskedTextBox) || (controle is ComboBox) || (controle is TextBox) || (controle is DateTimePicker) ||
                    (controle is RichTextBox) || (controle is NumericUpDown) || (controle is TreeView) || (controle is ListBox) || (controle is Ribbon))
                {
                    controle.KeyDown += Base_KeyDown;

                }
                else if((controle is TableLayoutPanel) || (controle is Panel))
                {
                    if (controle is TableLayoutPanel)
                    {
                        TableLayoutPanel objPanel = (TableLayoutPanel)controle;
                        objPanel.PreviewKeyDown += ObjPanel_PreviewKeyDown;
                    }
                    else
                    {
                        Panel objPanel = (Panel)controle;
                        objPanel.PreviewKeyDown += ObjPanel_PreviewKeyDown;
                    }
                }

                // chamada recursiva para configurar os controles filhos do item atual 

                foreach (Control controleFilho in controle.Controls)
                {
                    AcionarTeclaAtalho(controleFilho);

                }
            }
        }
               

        public virtual void ExecutarItemMenu(Classes.BotaoAtalho atalho)
        {
            if (atalho != null)
            {
                RibbonTab rbnTAb = objRibon.Tabs.Find(t => t.Name == atalho.NomeTab);

                if (rbnTAb != null)
                {

                    RibbonPanel objPanelRibon = rbnTAb.Panels.Find(p => p.Name == atalho.NomeGrupo);

                    if (objPanelRibon != null)
                    {
                        try
                        {
                            RibbonButton objButon = (RibbonButton)objPanelRibon.Items.Find(b => b.Name == atalho.NomeBotao);

                            if (objButon != null)
                            {
                                objButon.OnClick(null);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                }
            }


        }
        #endregion

        #region "Propriedades"
        public Boolean DesabilitarSelecaoLinha { get; set; }

        public Dictionary<string, KeyValuePair<string, string>> LinhaSelecionadaGrid
        {
            get
            {
                return _LinhaSelecionadaGrid;
            }
        }

        #endregion
        #region "Eventos"

        private void ObjPanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {

                if (_Atalhos != null && _Atalhos.Count > 0)
                {
                    Classes.BotaoAtalho objAtalho = _Atalhos.Find(a => a.Alt == e.Alt && a.Control == e.Control && a.Key == e.KeyCode && a.Shift == e.Shift);

                    if (objAtalho != null)
                    {
                        ExecutarItemMenu(objAtalho);
                    }

                }
            }
            catch
            (Exception ex)
            {

            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }


        }

        private void Base_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (_Atalhos != null && _Atalhos.Count > 0)
                {
                    Classes.BotaoAtalho objAtalho = _Atalhos.Find(a => a.Alt == e.Alt && a.Control == e.Control && a.Key == e.KeyCode && a.Shift == e.Shift);

                    if (objAtalho != null)
                    {
                        ExecutarItemMenu(objAtalho);
                    }

                }
            }
            catch
            (Exception ex)
            {

            }
        }

        #endregion


    }
}
