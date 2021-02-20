using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class ModificarImagem : TelaBase.BaseCE
    {
        public ModificarImagem()
        {
            InitializeComponent();
        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.AlterarImagemCentral)
            {
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Imagem alterada com sucesso");
            }

        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tlpPrincipal);

            ContratoServico.RecuperarImagem.Peticao objPeticao = new ContratoServico.RecuperarImagem.Peticao();
            Comunicacao.Proxy objProxy = new Comunicacao.Proxy();

            objPeticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            ContratoServico.RecuperarImagem.Resposta objRespuesta = objProxy.RecuperarImagem(objPeticao);

            if (objRespuesta != null && objRespuesta.objImagem != null && objRespuesta.objImagem.ImgImagemCentral != null)
            {

                MemoryStream imgBits = new MemoryStream(objRespuesta.objImagem.ImgImagemCentral);
                Bitmap img = new Bitmap(imgBits);
                Image objFoto = img;
                imgProduto.Image = objFoto;

            }

            base.Inicializar();
        }

        private string CaminhoImagem;

        private void lnkAlterarFoto_Click(object sender, EventArgs e)
        {
            try
            {

                if (fdgImgImagemCentral.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    CaminhoImagem = fdgImgImagemCentral.FileName;
                    imgProduto.Load(fdgImgImagemCentral.FileName);


                    if (!string.IsNullOrEmpty(CaminhoImagem))
                    {

                        //Cria um novo FileStream para leitura da imagem
                        FileStream fs = new FileStream(CaminhoImagem, FileMode.Open, FileAccess.Read);

                        //Cria um array de Bytes do tamanho do FileStream
                        byte[] picture = new byte[fs.Length - 1];

                        //Lê os bytes do FileStream para o array criado
                        fs.Read(picture, 0, picture.Length);

                        //Fecha o FileStream ficando a imagem guardada no array
                        fs.Close();

                        Comum.Clases.Imagem objImagem = new Comum.Clases.Imagem();

                        objImagem.ImgImagemCentral = picture;

                        ContratoServico.Informatiz.AlterarImagemCentral.PeticaoAlterarImagemCentral Peticao = new ContratoServico.Informatiz.AlterarImagemCentral.PeticaoAlterarImagemCentral();

                        Peticao.ImagemCentral = objImagem;
                        Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;


                        Agente.Agente.InvocarServico<ContratoServico.Informatiz.AlterarImagemCentral.RespostaAlterarImagemCentral, ContratoServico.Informatiz.AlterarImagemCentral.PeticaoAlterarImagemCentral>(Peticao,
                                SDK.Operacoes.operacao.AlterarImagemCentral,
                                new Comum.ParametrosTela.Generica() { PreencherObjeto = false, ExibirMensagemNenhumRegistro = false }, null, true);

                    }

                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                Cursor = Cursors.Default;
            }
        }
               
    }
}
