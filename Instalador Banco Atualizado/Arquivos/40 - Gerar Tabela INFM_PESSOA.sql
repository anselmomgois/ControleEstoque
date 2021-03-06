QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PESSOA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PESSOA (
   IDENDERECO           OBJETOID             null,
   IDPESSOA             OBJETOID             not null,
   IDSITUACAOPESSOA     OBJETOID             null,
   IDPESSOARESPONSAVEL  OBJETOID             null,
   IDSEGMENTOCOMERCIAL  OBJETOID             null,
   IDENDERECOEMPRESA    OBJETOID             null,
   IDEMPRESA            OBJETOID             null,
   CODPESSOA            INTEIROSEQ           identity,
   DESNOME              DESCRICAO100         not null,
   DESNOMEFANTASIA      DESCRICAO100         null,
   DESRG                DESCRICAO50          null,
   DTHNASCIMENTO        DATAHORA             null,
   DESCPF               DESCRICAO50          null,
   DESCNPJ              DESCRICAO50          null,
   DTHCADASTRO          DATAHORA             null,
   DESINSCRICAOESTADUAL DESCRICAO50          null,
   DESTELEFONEFIXO      DESCRICAO50          null,
   DESTELEFONEFAX       DESCRICAO50          null,
   DESTELEFONECELULAR   DESCRICAO50          null,
   DESHABILITACAO       DESCRICAO50          null,
   NUMCOMISSAO          NUMERO_DECIMAL       null,
   NUMSALARIO           NUMERO_DECIMAL       null,
   DTHADMISSAO          DATAHORA             null,
   DESCONTATO           DESCRICAO100         null,
   OBSPESSOA            OBSERVACAOMIN        null,
   NUMLIMITE            NUMERO_DECIMAL       null,
   DESEMAIL             DESCRICAO100         null,
   DESNOMEPAI           DESCRICAO100         null,
   DESNOMEMAE           DESCRICAO100         null,
   DESEMPRESA           DESCRICAO100         null,
   DESFONEEMPRESA       DESCRICAO50          null,
   DESCARGO             DESCRICAO50          null,
   OBSREFPESSOAL        OBSERVACAOMIN        null,
   DTHALMOCOINICIO      CODIGO20             null,
   DTHALMOCOFIM         CODIGO20             null,
   CODLOGIN             CODIGO20             null,
   DESSENHA             DESCRICAO200         null,
   CODTABMERCADORIA     INTEIRO              null,
   BOLALTERARSENHA      LOGICO               not null,
   BOLFUNICIONARIOATIVO LOGICO               null,
   BOLFORNECEDORATIVO   LOGICO               not null,
   NUMENDERECO          INTEIRO              null,
   DESCOMPLEMENTOENDER  DESCRICAO100         null,
   DESPONTOREFERENCIA   OBSERVACAOMIN        null,
   CODTABELAMERCADORIA  INTEIRO              null,
   NUMENDERECOEMP       INTEIRO              null,
   DESCOMPLEMENTOENDEREMP DESCRICAO100         null,
   DESPONTOREFERENCIAEMP OBSERVACAOMIN        null,
   constraint PK_INFM_PESSOA primary key (IDPESSOA))