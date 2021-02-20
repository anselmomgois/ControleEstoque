QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_EMPRESA') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_EMPRESA (
   IDEMPRESA            OBJETOID             not null,
   CODEMPRESA           INTEIROSEQ           identity,
   DESEMPRESA           DESCRICAO50          not null,
   DESCNPJ              DESCRICAO50          null,
   DESINSCRICAOESTADUAL DESCRICAO50          null,
   CODACESSO            CODIGO20             not null,
   CODLICENCA           DESCRICAO200         null,
   NUMQUANTIDADESESSOES INTEIRO              null,
   NUMQUANTIDADEACESSADA INTEIRO              null,
   NUMQUANTIDADEACESSO  INTEIRO              null,
   SESSOSILIMITADAS     LOGICO               null,
   VALIDADEILIMITADA    LOGICO               null,
   constraint PK_INFM_EMPRESA primary key (IDEMPRESA))