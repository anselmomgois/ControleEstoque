QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FKPRODCSTPRODSERVICO'
BANCODEDADOS IGERENCE
alter table INFM_PRODUTOSERVICO
   add constraint FKPRODCSTPRODSERVICO foreign key (IDPRODUTOCST)
      references INFM_PRODUTOCST (IDPRODUTOCST)