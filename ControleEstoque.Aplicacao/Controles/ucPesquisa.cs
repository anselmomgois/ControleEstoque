using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using Informatiz.ControleEstoque.Comum.Extencoes;

namespace Informatiz.ControleEstoque.Aplicacao.Controles
{
    public partial class ucPesquisa : UserControl
    {
        public ucPesquisa(Comum.Enumeradores.TipoControle TipoControle, int X, int Y)
        {
            InitializeComponent();
            _TipoControle = TipoControle;
            _Y = Y;
            _X = X;
        }

        public enum Evento
        {
            Multiplicar,
            Igual,
            Enter,
            Nothing
        }

        #region "Eventos"
        public delegate void ExibirGridDelegate(DataGridView Grid);
        public event ExibirGridDelegate ExibirGrid;
        public delegate void OcultarGridDelegate(DataGridView Grid);
        public event OcultarGridDelegate OcultarGrid;
        public delegate void SelecionarItemDelegate(object Item);
        public event SelecionarItemDelegate SelecionarItem;
        #endregion

        #region "Variaveis"

        private Comum.Enumeradores.TipoControle _TipoControle;
        private List<Comum.Clases.ProdutoDisponivelVenda> _ProdutosVenda;
        private object _dados;
        private DataGridView GridPesquisa;
        private int _X;
        private int _Y;

        #endregion

        #region "Propriedades"

        public object Dados
        {
            get
            {
                return _dados;
            }
            set
            {
                _dados = value;
                ConverterObjeto();
            }
        }

        #endregion

        #region "Metodos"

        private void ConverterObjeto()
        {
            if (_dados == null) return;

            switch (_TipoControle)
            {
                case Comum.Enumeradores.TipoControle.ProdutosTelaVenda:

                    _ProdutosVenda = (List<Comum.Clases.ProdutoDisponivelVenda>)_dados;
                    break;
            }
        }

        public void SetarFocus()
        {
            txtPesquisa.Focus();
        }

        public void CriarGrid()
        {
            switch (_TipoControle)
            {
                case Comum.Enumeradores.TipoControle.ProdutosTelaVenda:
                    GridPesquisa = new DataGridView();

                    GridPesquisa.Columns.Add(new DataGridViewImageColumn()
                    {
                        Name = "colIdentificador",
                        HeaderText = "Identificador",
                        Visible = false,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    });

                    if (Parametros.Parametros.ParametrosAplicacao.RecuperarImagemProduto)
                    {
                        GridPesquisa.Columns.Add(new DataGridViewImageColumn()
                        {
                            Name = "colImagem",
                            HeaderText = "Imagem",
                            AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                            Width = 100
                        });
                    }

                    GridPesquisa.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colCodigo",
                        HeaderText = "Codigo",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                        Width = 50
                    });

                    GridPesquisa.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colCodigoBarras",
                        HeaderText = "Codigo Barras",
                        DefaultCellStyle = new DataGridViewCellStyle() { WrapMode = DataGridViewTriState.True },
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                        Width = 150
                    });

                    GridPesquisa.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colDescricao",
                        HeaderText = "Descrição",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });

                    GridPesquisa.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colUnidadeMedida",
                        HeaderText = "Unidade",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                        Width = 70
                    });

                    GridPesquisa.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colMarca",
                        HeaderText = "Marca",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                        Width = 70
                    });

                    GridPesquisa.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colCategoria",
                        HeaderText = "Categoria",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                        Width = 70
                    });

                    GridPesquisa.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colObservacao",
                        HeaderText = "Observação",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                        Width = 150
                    });

                    GridPesquisa.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colValor",
                        HeaderText = "Valor",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                        Width = 70
                    });

                    break;
            }
            GridPesquisa.Name = "GridPesquisa";
            GridPesquisa.Width = txtPesquisa.Width;
            GridPesquisa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridPesquisa.Height = 180;
            GridPesquisa.Visible = false;
            GridPesquisa.AllowUserToDeleteRows = false;
            GridPesquisa.AllowUserToResizeColumns = false;
            GridPesquisa.AllowUserToAddRows = false;
            GridPesquisa.Location = new Point(_X, _Y);
            GridPesquisa.ScrollBars = ScrollBars.Vertical;
            GridPesquisa.CellDoubleClick += GridPesquisa_CellDoubleClick;
            GridPesquisa.KeyDown += GridPesquisa_KeyDown;
        }

        private void GridPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        txtPesquisa.Text = string.Empty;
                        txtPesquisa.Focus();
                        OcultarGrid(GridPesquisa);

                        break;
                    case Keys.Enter:

                        if (GridPesquisa.SelectedRows != null && GridPesquisa.SelectedRows.Count > 0)
                        {
                            Tuple<Evento, decimal, string, Boolean, string> DadosFiltro = RecuperarEvento();
                            if (DadosFiltro != null)
                            {
                                decimal Quantidade = 1;
                                decimal Valor = 0;

                                if (DadosFiltro.Item1 == Evento.Multiplicar)
                                {
                                    Quantidade = DadosFiltro.Item2;
                                }
                                else if (DadosFiltro.Item1 == Evento.Igual)
                                {
                                    Valor = DadosFiltro.Item2;
                                }
                                SelecionarItemGrid(GridPesquisa.Rows[GridPesquisa.SelectedRows[0].Index].Cells["colIdentificador"].Value as string, Quantidade, Valor);
                            }
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void GridPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (_TipoControle)
                {
                    case Comum.Enumeradores.TipoControle.ProdutosTelaVenda:

                        Tuple<Evento, decimal, string, Boolean, string> DadosFiltro = RecuperarEvento();
                        if (DadosFiltro != null)
                        {
                            decimal Quantidade = 1;
                            decimal Valor = 0;

                            if (DadosFiltro.Item1 == Evento.Multiplicar)
                            {
                                Quantidade = DadosFiltro.Item2;
                            }
                            else if (DadosFiltro.Item1 == Evento.Igual)
                            {
                                Valor = DadosFiltro.Item2;
                            }
                            SelecionarItemGrid(GridPesquisa.Rows[GridPesquisa.SelectedRows[0].Index].Cells["colIdentificador"].Value as string, Quantidade, Valor);
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void SelecionarItemGrid(string Identificador, decimal Quantidade = 1, decimal Valor = 0)
        {
            if (_ProdutosVenda != null && _ProdutosVenda.Count > 0)
            {
                Comum.Clases.ProdutoDisponivelVenda ProdutoSelecionado = _ProdutosVenda.Find(p => p.Produto != null && p.Produto.Identificador == Identificador);

                if (ProdutoSelecionado != null)
                {
                    if ((Valor > 0 || !Classes.Util.IsNumeric(Quantidade.ToString())) && !ProdutoSelecionado.Produto.VendaAGranel)
                    {
                        return;
                    }

                    ProdutoSelecionado.NumQuantidadeVendido = Quantidade;
                    ProdutoSelecionado.NumValorProdutoCalculado = Valor;
                    SelecionarItem(ProdutoSelecionado);
                    txtPesquisa.Text = string.Empty;
                    txtPesquisa.Focus();
                    GridPesquisa.Visible = false;
                    OcultarGrid(GridPesquisa);
                }
            }
        }

        private Int32 CalcularLocation(Control Controle)
        {
            Int32 Y = 0;

            if (Controle != null && Controle.GetType() != typeof(Form))
            {
                Y = Controle.Location.Y;

                Y += CalcularLocation(Controle.Parent);
            }

            return Y;
        }

        private void FiltrarProdutos(Evento Evento, string Texto, Boolean CodigoBarras, string ValorOriginalCodigoBarras, decimal Quantidade = 1, decimal Valor = 0)
        {
            if (_ProdutosVenda != null && _ProdutosVenda.Count > 0)
            {

                List<Comum.Clases.ProdutoDisponivelVenda> ProdutosFiltrados;
                if (CodigoBarras)
                {

                    ProdutosFiltrados = (from Comum.Clases.ProdutoDisponivelVenda ps in _ProdutosVenda
                                         where !string.IsNullOrEmpty(Texto) &&
                                         ps.Produto != null &&
                                         (ps.Produto.CodigosBarras != null && ps.Produto.CodigosBarras.Count > 0 && ps.Produto.CodigosBarras.Exists(cb => cb.CodigoBarras.ToUpper().Contains(ValorOriginalCodigoBarras)))
                                         select ps).ToList();

                    if (ProdutosFiltrados == null || ProdutosFiltrados.Count == 0)
                    {
                        ProdutosFiltrados = (from Comum.Clases.ProdutoDisponivelVenda ps in _ProdutosVenda
                                             where !string.IsNullOrEmpty(Texto) &&
                                             ps.Produto != null &&
                                             ps.Produto.Codigo.ToString().Equals(Texto.ToUpper())
                                             select ps).ToList();
                    }
                    else
                    {
                        Valor = 0;
                        Quantidade = 1;
                    }

                }
                else
                {
                    ProdutosFiltrados = (from Comum.Clases.ProdutoDisponivelVenda ps in _ProdutosVenda
                                         where !string.IsNullOrEmpty(Texto) &&
                                         ps.Produto != null &&
                                         (ps.Produto.Descricao.ToUpper().Contains(Texto.ToUpper()) ||
                                          ps.Produto.Codigo.ToString().Contains(Texto.ToUpper()) ||
                                          (ps.Produto.UnidadesMedida != null && ps.Produto.UnidadesMedida.Count > 0 && ps.Produto.UnidadesMedida.Exists(um => um.Descricao.ToUpper().Contains(Texto.ToUpper()))) ||
                                          (ps.Produto.ProdutoMarca != null && ps.Produto.ProdutoMarca.Descricao.ToUpper().Contains(Texto.ToUpper())) ||
                                          (ps.Produto.ProdutoCategoria != null && ps.Produto.ProdutoCategoria.Descricao.ToUpper().Contains(Texto.ToUpper())) ||
                                          (!string.IsNullOrEmpty(ps.Produto.Observacao) && ps.Produto.Observacao.ToUpper().Contains(Texto.ToUpper())) ||
                                          (ps.Produto.CodigosBarras != null && ps.Produto.CodigosBarras.Count > 0 && ps.Produto.CodigosBarras.Exists(cb => cb.CodigoBarras.ToUpper().Contains(Texto.ToUpper()))))
                                         select ps).ToList();
                }

                if (ProdutosFiltrados != null && ProdutosFiltrados.Count > 0)
                {
                    if (ProdutosFiltrados.Count == 1 && (Evento == Evento.Enter || Evento == Evento.Multiplicar || Evento == Evento.Igual))
                    {
                        SelecionarItemGrid(ProdutosFiltrados.FirstOrDefault().Produto.Identificador, Quantidade, Valor);

                    }
                    else
                    {
                        GridPesquisa.Visible = true;
                        GridPesquisa.Rows.Clear();
                        foreach (var p in ProdutosFiltrados)
                        {
                            GridPesquisa.Rows.Add();


                            GridPesquisa.Rows[GridPesquisa.Rows.Count - 1].Cells["colIdentificador"].Value = p.Produto.Identificador;
                            GridPesquisa.Rows[GridPesquisa.Rows.Count - 1].Cells["colDescricao"].Value = p.Produto.Descricao;
                            GridPesquisa.Rows[GridPesquisa.Rows.Count - 1].Cells["colCodigo"].Value = p.Produto.Codigo;
                            GridPesquisa.Rows[GridPesquisa.Rows.Count - 1].Cells["colUnidadeMedida"].Value = p.Produto.UnidadesMedida != null && p.Produto.UnidadesMedida.Count > 0 ? p.Produto.UnidadesMedida.FirstOrDefault().Descricao : string.Empty;
                            GridPesquisa.Rows[GridPesquisa.Rows.Count - 1].Cells["colMarca"].Value = p.Produto.ProdutoMarca != null ? p.Produto.ProdutoMarca.Descricao : string.Empty;
                            GridPesquisa.Rows[GridPesquisa.Rows.Count - 1].Cells["colCategoria"].Value = p.Produto.ProdutoCategoria != null ? p.Produto.ProdutoCategoria.Descricao : string.Empty;
                            GridPesquisa.Rows[GridPesquisa.Rows.Count - 1].Cells["colObservacao"].Value = !string.IsNullOrEmpty(p.Produto.Observacao) ? p.Produto.Observacao : string.Empty;
                            GridPesquisa.Rows[GridPesquisa.Rows.Count - 1].Cells["colValor"].Value = p.NumValorVendaVarejo != null && p.NumValorVendaVarejo > 0 ? Convert.ToDecimal(p.NumValorVendaVarejo).ToString("N2") : string.Empty;

                            if (p.Produto.CodigosBarras != null && p.Produto.CodigosBarras.Count > 0)
                            {
                                GridPesquisa.Rows[GridPesquisa.Rows.Count - 1].Cells["colCodigoBarras"].Value = System.String.Join(Environment.NewLine, p.Produto.CodigosBarras.Select(cb => cb.CodigoBarras).ToArray());
                                GridPesquisa.Rows[GridPesquisa.Rows.Count - 1].Height = 15 * p.Produto.CodigosBarras.Count;
                                
                            }

                            if (p.Produto.ImgProduto != null && Parametros.Parametros.ParametrosAplicacao.RecuperarImagemProduto)
                            {

                                MemoryStream imgBits = new MemoryStream(p.Produto.ImgProduto);
                                Bitmap img = new Bitmap(imgBits);

                                GridPesquisa.Rows[GridPesquisa.Rows.Count - 1].Cells["colImagem"].Value = ConfigurarDimenssaoImagem(img, 60, 60);
                                GridPesquisa.Rows[GridPesquisa.Rows.Count - 1].Height = 60;
                                GridPesquisa.Columns["colImagem"].Width = 60;

                            }

                        }

                        GridPesquisa.SendToBack();
                        GridPesquisa.BringToFront();
                        ExibirGrid(GridPesquisa);

                    }
                }
                else
                {
                    GridPesquisa.Visible = false;
                    OcultarGrid(GridPesquisa);
                    txtPesquisa.Focus();
                }

            }
        }

        public Bitmap ConfigurarDimenssaoImagem(Bitmap image, int maxWidth, int maxHeight)
        {

            int originalWidth = image.Width;
            int originalHeight = image.Height;

            float ratioX = (float)maxWidth / (float)originalWidth;
            float ratioY = (float)maxHeight / (float)originalHeight;
            float ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        /// <summary>
        /// Method to get encoder infor for given image format.
        /// </summary>
        /// <param name="format">Image format</param>
        /// <returns>image codec info.</returns>
        private ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }


        static Image EscalaPercentual(Image imgFoto, int Percentual)
        {
            if (imgFoto.Height > 70)
            {
                float nPorcentagem = ((float)Percentual / 100);

                int fonteLargura = imgFoto.Width;     //armazena a largura original da imagem origem
                int fonteAltura = imgFoto.Height;   //armazena a altura original da imagem origem
                int origemX = 0;        //eixo x da imagem origem
                int origemY = 0;        //eixo y da imagem origem

                int destX = 0;          //eixo x da imagem destino
                int destY = 0;          //eixo y da imagem destino
                                        //Calcula a altura e largura da imagem redimensionada
                int destWidth = (int)(fonteLargura * nPorcentagem);
                int destHeight = (int)(fonteAltura * nPorcentagem);

                //Cria um novo objeto bitmap
                Bitmap bmImagem = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);
                //Define a resolu~ção do bitmap.
                bmImagem.SetResolution(imgFoto.HorizontalResolution, imgFoto.VerticalResolution);
                //Crima um objeto graphics e defina a qualidade
                Graphics grImagem = Graphics.FromImage(bmImagem);
                grImagem.InterpolationMode = InterpolationMode.HighQualityBicubic;

                //Desenha a imge usando o método DrawImage() da classe grafica
                grImagem.DrawImage(imgFoto,
                    new Rectangle(destX, destY, destWidth, destHeight),
                    new Rectangle(origemX, origemY, fonteLargura, fonteAltura),
                    GraphicsUnit.Pixel);

                grImagem.Dispose();  //libera o objeto grafico

                return bmImagem;
            }

            return imgFoto;
        }

        private Tuple<Evento, decimal, string, Boolean, string> RecuperarEvento()
        {
            Tuple<Evento, decimal, string, Boolean, string> DadosRetorno = null;

            if (txtPesquisa.Text.Contains("*"))
            {
                string[] Dados = txtPesquisa.Text.Split(Convert.ToChar("*"));
                string Texto = string.Empty;
                decimal Quantidade = 0;
                if (Dados.Count() > 1)
                {
                    Texto = Dados.LastOrDefault().Replace("=", string.Empty);
                    Quantidade = Classes.Util.IsDecimal(Dados.FirstOrDefault()) ? Convert.ToDecimal(Dados.FirstOrDefault()) : 1;
                    DadosRetorno = new Tuple<Evento, decimal, string, Boolean, string>(Evento.Multiplicar, Quantidade, Texto, false, string.Empty);
                }
            }
            else if (txtPesquisa.Text.Contains("="))
            {
                string[] Dados = txtPesquisa.Text.Split(Convert.ToChar("="));
                string Texto = string.Empty;
                decimal Valor = 0;
                if (Dados.Count() > 1)
                {
                    Texto = Dados.LastOrDefault().Replace("*", string.Empty);
                    Valor = Classes.Util.IsDecimal(Dados.FirstOrDefault()) ? Convert.ToDecimal(Dados.FirstOrDefault()) : 1;
                    DadosRetorno = new Tuple<Evento, decimal, string, Boolean, string>(Evento.Igual, Valor, Texto, false, string.Empty);
                }
            }
            else if (frmUtil.Validacao.ValidarValorCampo(txtPesquisa.Text.Trim(), frmUtil.Enumeradores.TipoValidacao.EAN13))
            {
                Int32 CodigoProduto;
                string Texto = string.Empty;
                decimal Quantidade = 0;
                string strQuantidade = string.Empty;
                string strIntero = string.Empty;
                string strDecimal = string.Empty;
                Comum.Enumeradores.Enumeradores.TipoCodigoBarras TipoCodigo = Comum.Enumeradores.Enumeradores.TipoCodigoBarras.SEIS_POSICOES;

                if(!string.IsNullOrEmpty(Parametros.Parametros.ParametrosAplicacao.TipoCodigoBarras))
                {

                    TipoCodigo = EnumExtension.RecuperarEnum<Comum.Enumeradores.Enumeradores.TipoCodigoBarras>(Parametros.Parametros.ParametrosAplicacao.TipoCodigoBarras);
                }

                switch (TipoCodigo)
                {
                    case Comum.Enumeradores.Enumeradores.TipoCodigoBarras.SEIS_POSICOES:

                        CodigoProduto = Convert.ToInt32(txtPesquisa.Text.Trim().Substring(1, 6));
                        Texto = CodigoProduto.ToString();
                        strQuantidade = txtPesquisa.Text.Trim().Substring(7);
                        strQuantidade = strQuantidade.Trim().Substring(0, 5);


                        if (Parametros.Parametros.ParametrosAplicacao.CodigoBarrasPorValor)
                        {
                            strIntero = strQuantidade.Trim().Substring(0, 3);
                            strDecimal = strQuantidade.Trim().Substring(3);
                            Quantidade = Convert.ToDecimal(string.Format("{0},{1}", strIntero, strDecimal));

                            DadosRetorno = new Tuple<Evento, decimal, string, Boolean, string>(Evento.Igual, Quantidade, Texto, true, txtPesquisa.Text.Trim());
                        }
                        else
                        {
                            strIntero = strQuantidade.Trim().Substring(0, 2);
                            strDecimal = strQuantidade.Trim().Substring(2);
                            Quantidade = Convert.ToDecimal(string.Format("{0},{1}", strIntero, strDecimal));

                            DadosRetorno = new Tuple<Evento, decimal, string, Boolean, string>(Evento.Multiplicar, Quantidade, Texto, true, txtPesquisa.Text.Trim());
                        }

                        break;

                    case Comum.Enumeradores.Enumeradores.TipoCodigoBarras.CINCO_POSICOES:

                        CodigoProduto = Convert.ToInt32(txtPesquisa.Text.Trim().Substring(1, 5));
                        Texto = CodigoProduto.ToString();
                        strQuantidade = txtPesquisa.Text.Trim().Substring(6);
                        strQuantidade = strQuantidade.Trim().Substring(0, 6);


                        if (Parametros.Parametros.ParametrosAplicacao.CodigoBarrasPorValor)
                        {
                            strIntero = strQuantidade.Trim().Substring(0, 4);
                            strDecimal = strQuantidade.Trim().Substring(4);
                            Quantidade = Convert.ToDecimal(string.Format("{0},{1}", strIntero, strDecimal));

                            DadosRetorno = new Tuple<Evento, decimal, string, Boolean, string>(Evento.Igual, Quantidade, Texto, true, txtPesquisa.Text.Trim());
                        }
                        else
                        {
                            strIntero = strQuantidade.Trim().Substring(0, 3);
                            strDecimal = strQuantidade.Trim().Substring(3);
                            Quantidade = Convert.ToDecimal(string.Format("{0},{1}", strIntero, strDecimal));

                            DadosRetorno = new Tuple<Evento, decimal, string, Boolean, string>(Evento.Multiplicar, Quantidade, Texto, true, txtPesquisa.Text.Trim());
                        }

                        break;

                    case Comum.Enumeradores.Enumeradores.TipoCodigoBarras.QUATRO_POSICOES:

                        CodigoProduto = Convert.ToInt32(txtPesquisa.Text.Trim().Substring(1, 4));
                        Texto = CodigoProduto.ToString();
                        strQuantidade = txtPesquisa.Text.Trim().Substring(5);
                        strQuantidade = strQuantidade.Trim().Substring(0, 7);


                        if (Parametros.Parametros.ParametrosAplicacao.CodigoBarrasPorValor)
                        {
                            strIntero = strQuantidade.Trim().Substring(0, 5);
                            strDecimal = strQuantidade.Trim().Substring(5);
                            Quantidade = Convert.ToDecimal(string.Format("{0},{1}", strIntero, strDecimal));

                            DadosRetorno = new Tuple<Evento, decimal, string, Boolean, string>(Evento.Igual, Quantidade, Texto, true, txtPesquisa.Text.Trim());
                        }
                        else
                        {
                            strIntero = strQuantidade.Trim().Substring(0, 4);
                            strDecimal = strQuantidade.Trim().Substring(4);
                            Quantidade = Convert.ToDecimal(string.Format("{0},{1}", strIntero, strDecimal));

                            DadosRetorno = new Tuple<Evento, decimal, string, Boolean, string>(Evento.Multiplicar, Quantidade, Texto, true, txtPesquisa.Text.Trim());
                        }

                        break;
                }
                


            }
            else
            {
                DadosRetorno = new Tuple<Evento, decimal, string, Boolean, string>(Evento.Nothing, 0, txtPesquisa.Text.Trim(), false, string.Empty);
            }

            return DadosRetorno;
        }

        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                switch (_TipoControle)
                {
                    case Comum.Enumeradores.TipoControle.ProdutosTelaVenda:

                        if (txtPesquisa.Text.Length > 2)
                        {
                            Tuple<Evento, decimal, string, Boolean, string> DadosFiltro = RecuperarEvento();

                            if (DadosFiltro != null)
                            {
                                if (DadosFiltro.Item1 == Evento.Multiplicar)
                                {
                                    FiltrarProdutos(Evento.Multiplicar, DadosFiltro.Item3, DadosFiltro.Item4, DadosFiltro.Item5, DadosFiltro.Item2);
                                }
                                else if (DadosFiltro.Item1 == Evento.Igual)
                                {
                                    FiltrarProdutos(Evento.Igual, DadosFiltro.Item3, DadosFiltro.Item4, DadosFiltro.Item5, 1, DadosFiltro.Item2);
                                }
                                else
                                {
                                    FiltrarProdutos(Evento.Nothing, DadosFiltro.Item3, false, string.Empty, 0);
                                }
                            }
                        }
                        else if (GridPesquisa != null && GridPesquisa.Visible)
                        {
                            GridPesquisa.Visible = false;
                            OcultarGrid(GridPesquisa);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }

        }

        private void txtPesquisa_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (GridPesquisa != null)
                {
                    GridPesquisa.Width = txtPesquisa.Width;
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down && GridPesquisa != null && GridPesquisa.Visible)
                {
                    GridPesquisa.Focus();
                }
                else if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtPesquisa.Text.Trim()))
                {
                    FiltrarProdutos(Evento.Enter, txtPesquisa.Text, false, string.Empty);
                }
                else if (e.KeyCode == Keys.Escape && !string.IsNullOrEmpty(txtPesquisa.Text.Trim()) && GridPesquisa.Visible)
                {
                    GridPesquisa.Visible = false;
                    OcultarGrid(GridPesquisa);
                    txtPesquisa.Text = string.Empty;
                    txtPesquisa.Focus();
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }
}
