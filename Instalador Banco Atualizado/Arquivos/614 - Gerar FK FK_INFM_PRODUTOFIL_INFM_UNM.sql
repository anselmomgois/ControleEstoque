QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOFILIAL') and o.name = 'FK_INFM_PRODUTOFIL_INFM_UNM'
BANCODEDADOS IGERENCE
alter table INFM_PRODUTOFILIAL
   add constraint FK_INFM_PRODUTOFIL_INFM_UNM foreign key (IDUNIDADEMEDIDAMINESTOQUE)
      references INFM_UNIDADEMEDIDA (IDUNIDADEMEDIDA)