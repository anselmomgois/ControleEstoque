QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PERMISSAO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PERMISSAO (
   IDPERMISSAO          OBJETOID             not null,
   CODPERMISSAO         CODIGO20             not null,
   DESPERMISSAO         DESCRICAO100         not null,
   BOLOBRIGATORIA       BOLEANO              not null,
   constraint PK_INFM_PERMISSAO primary key (IDPERMISSAO))