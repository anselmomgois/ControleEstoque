QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_DATOSCOMPRAPROD') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_DATOSCOMPRAPROD (
   IDDATOSCOMPRAPROD    OBJETOID             not null,
   IDPESSOA             OBJETOID             null,
   IDUNIDADEMEDIDA      OBJETOID             null,
   IDPRODUTOFILIAL      OBJETOID             null,
   DTHCOMPRA            DATAHORA             not null,
   NUMUNIDADECOMPRA     DECIMAL1             not null,
   NUMUNIDADEVENDA      DECIMAL1             null,
   NUMVALORCOMPRA       NUMERO_DECIMAL       not null,
   NUMVENDA1            NUMERO_DECIMAL       null,
   NUMVENDA2            NUMERO_DECIMAL       null,
   NUMVENDA3            NUMERO_DECIMAL       null,
   NUMESTOQUE           DECIMAL1             not null,
   constraint PK_INFM_DATOSCOMPRAPROD primary key (IDDATOSCOMPRAPROD))