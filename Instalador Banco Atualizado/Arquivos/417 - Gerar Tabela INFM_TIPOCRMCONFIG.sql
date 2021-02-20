QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_TIPOCRMCONFIG') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_TIPOCRMCONFIG (
   IDTIPOCRMCONFIG      OBJETO_ID            not null,
   IDTIPOCRM            OBJETO_ID            null,
   IDTIPOEMPREGADO      OBJETO_ID            null,
   BOLEMPREGADOATUAL    LOGICO               not null,
   NELQUANTDIASDATA     INTEIRO              null,
   NELQUANTFUNCIONARIOS INTEIRO              not null,
   NELNIVEL             INTEIRO              not null,
   DESNIVELCONFIG       DESCRICAO100         not null,
   constraint PK_INFM_TIPOCRMCONFIG primary key (IDTIPOCRMCONFIG))