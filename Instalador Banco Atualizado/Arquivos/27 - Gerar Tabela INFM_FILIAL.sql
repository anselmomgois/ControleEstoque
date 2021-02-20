QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_FILIAL') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_FILIAL (
   IDFILIAL             OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   IDENDERECO           OBJETOID             null,
   IDPESSOA             OBJETOID             null,
   CODFILIAL            INTEIROSEQ           identity,
   DESFILIAL            DESCRICAO50          not null,
   BOLMATRIZ            LOGICO               not null,
   NUMENDERECO          INTEIRO              null,
   DESCOMPENDERECO      DESCRICAO200         null,
   DESPONTREFENDERECO   DESCRICAO200         null,
   DTHABERTURA          DATAHORA             null,
   DESTELEFONEFIXO      DESCRICAO50          null,
   DESTELEFONEFAX       DESCRICAO50          null,
   DESTELEFONECEL       DESCRICAO50          null,
   OBSFILIAL            OBSERVACAOMIN        null,
   DESEMAIL             DESCRICAO100         null,
   NUMPISPER            NUMERO_DECIMAL       null,
   NUMCONFINSPER        NUMERO_DECIMAL       null,
   NUMOUTDESPPER        NUMERO_DECIMAL       null,
   NUMCONTSOCPER        NUMERO_DECIMAL       null,
   CODTABMERCADORIA     INTEIRO              null,
   BOLATIVA             LOGICO               not null,
   constraint PK_INFM_FILIAL primary key (IDFILIAL))