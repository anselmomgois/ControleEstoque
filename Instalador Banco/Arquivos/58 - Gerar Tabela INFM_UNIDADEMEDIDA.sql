QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_UNIDADEMEDIDA') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_UNIDADEMEDIDA (
   IDUNIDADEMEDIDA      OBJETOID             not null,
   IDUNIDADEMEDIDAPAI   OBJETOID             null,
   IDEMPRESA            OBJETOID             null,
   CODUNIDADEMEDIDA     CODIGO20             not null,
   NUMUNIDADEPAI        NUMERO_DECIMAL       null,
   DESUNIDADEMEDIDA     DESCRICAO100         not null,
   constraint PK_INFM_UNIDADEMEDIDA primary key (IDUNIDADEMEDIDA))