QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_ITEMVENDAACRESCIMO') and o.name = 'FK_INFM_ITEMVEDA_INFM_PRODS1'
BANCODEDADOS IGERENCE
alter table INFM_ITEMVENDAACRESCIMO
   add constraint FK_INFM_ITEMVEDA_INFM_PRODS1 foreign key (IDACRESCIMO)
      references INFM_PRODUTOSERVICO (IDPRODUTOSERVICO)