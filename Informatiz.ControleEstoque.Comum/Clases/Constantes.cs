using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Constantes
    {
        public const string VARIAVEL_INT_DATA_INICIO = "{DATA_INICIO}";
        public const string VARIAVEL_INT_DATA_FIM = "{DATA_FIM}";

        public const string PACKAGE_TRACKING_URL = "http://sro.micropost.com.br/consulta.php?objetos={0}";

        public const string CHAVE_CRIPITOGRAFIA = "INFORMATIZCECONTROLEESTOQUE";
        public const string ARQUIVO_CONEXAO = "CONEXAO";
        public const string STRING_CONEXAO = "INFMTZCS";

        public const string COD_ACESSO_LIMITADO = "1";
        public const string COD_ACESSO_TOTAL = "2";


        public const string COD_PERMISSAO_PRINCIPAL = "PRINCIPAL";
        public const string COD_PERMISSAO_CLIENTE = "CLIENTE";
        public const string COD_PERMISSAO_FUNCIONARIO = "FUNCIONARIO";
        public const string COD_PERMISSAO_FORNECEDOR = "FORNECEDOR";
        public const string COD_PERMISSAO_GRUPOPERMISSAO = "GRUPOPERMISSAO";
        public const string COD_PERMISSAO_PERMISSAOUSUARIO = "PERMISSOESUSUARIO";
        public const string COD_PERMISSAO_CONFIGURACAOENDERECO = "ENDERECO";
        public const string COD_PERMISSAO_CORES = "COR";
        public const string COD_PERMISSAO_INTEGRACAOAPI = "INTEGRACAOAPI";
        public const string COD_PERMISSAO_PROCESSO = "PROCESSO";
        public const string COD_PERMISSAO_GUARDARESTOQUEATUAL = "GUARDARESTOQUEATUAL";
        public const string COD_PERMISSAO_UNIDADE_MEDIDA = "UNIDADEMEDIDA";
        public const string COD_PERMISSAO_PRODUTO_CATEGORIA = "PRODUTOCATEGORIA";
        public const string COD_PERMISSAO_PRODUTO_MARCA = "PRODUTOMARCA";
        public const string COD_PERMISSAO_SEGMENTO_COMERCIAL = "SEGMENTOCOMERCIAL";
        public const string COD_PERMISSAO_PRODUTO_DERIVACAO = "PRODUTODERIVACAO";
        public const string COD_PERMISSAO_GRUPO_PRODUTO = "GRUPOPRODUTO";
        public const string COD_PERMISSAO_GRUPO_COMPROMISSO = "GRUPOCOMPROMISSO";
        public const string COD_PERMISSAO_COMPROMISSO = "COMPROMISSO";
        public const string COD_PERMISSAO_PRODUTO_SERVICO = "PRODUTOSERVICO";
        public const string COD_PERMISSAO_PRODUTO_COMISSAO = "PRODUTOCOMISSAO";
        public const string COD_PERMISSAO_PRODUTO_CST = "PRODUTOCST";
        public const string COD_PERMISSAO_PRODUTO_CFOP = "PRODUTOCFOP";
        public const string COD_PERMISSAO_PRODUTO_NCM = "PRODUTONCM";
        public const string COD_PERMISSAO_PRODUTO_PROMOCAO = "PRODUTOPROMOCAO";
        public const string COD_PERMISSAO_RELATORIO_ESTOQUE = "RELATORIOESTOQUE";
        public const string COD_PERMISSAO_EMPRESA = "EMPRESA";
        public const string COD_PERMISSAO_PROPOSTA = "PROPOSTA";
        public const string COD_PERMISSAO_RELATORIO_PESSOAS = "RELATORIOPESSOAS";
        public const string COD_PERMISSAO_VER_AGENDA_TODOS = "VERAGENDATODOS";
        public const string COD_PERMISSAO_ADMINISTRADORA = "ADMINISTRADORA";
        public const string COD_PERMISSAO_STATUS_CRM = "STATUSCRM";
        public const string COD_PERMISSAO_TIPO_EMPREGADO = "TIPOEMPREGADO";
        public const string COD_PERMISSAO_TIPO_CRM = "TIPOCRM";
        public const string COD_PERMISSAO_COMPRAS = "COMPRAS";
        public const string COD_PERMISSAO_FORMA_PAGAMENTO = "FORMA_PAGAMENTO";
        public const string COD_PERMISSAO_REALIZAR_COMPRA_OUTRA_FILIAL = "REALIZAR_COMPRA_OUTRA_FILIAL";
        public const string COD_PERMISSAO_PARAMETROS = "PARAMETROS";
        public const string COD_PERMISSAO_CAIXA = "CAIXA";
        public const string COD_PERMISSAO_OBSERVACAO = "OBSERVACAO";
        public const string COD_PERMISSAO_MESA = "MESA";
        public const string COD_PERMISSAO_VENDASIMPLES = "VENDASIMPLES";
        public const string COD_PERMISSAO_VENDACOMANDA = "VENDACOMANDA";
        public const string COD_PERMISSAO_SETOREMPRESA = "SETOREMPRESA";

        public const string COD_TIPO_PRODUTO_SERVICO_SERV = "SERVICO";
        public const string COD_TIPO_PRODUTO_SERVICO_PROD = "PRODUTO";

        public const string COD_TIPO_PROMOCAO_EMPRESA = "EM";
        public const string COD_TIPO_PROMOCAO_ESTOQUE = "ET";
        public const string COD_TIPO_PROMOCAO_FILIAL = "FL";

        public const Int32 COD_PUBLICIDADE_AMIGO = 1;
        public const Int32 COD_PUBLICIDADE_CONSULTOR = 2;

        public const string PARAM_NOME_SERVIDOR_BD = "SERVIDORBD";
        public const string PARAM_NUM_PORTA = "NUMPORTA";
        public const string PARAM_NOME_BD = "NOMEBD";
        public const string PARAM_COD_USUARIO_BD = "USUARIOBD";
        public const string PARAM_SENHA_BD = "SENHABD";
        public const string PARAM_BOL_AUTENTICACAO_INTEGRADA = "AUTENTICACAOINTEGRADA";
    }
}
