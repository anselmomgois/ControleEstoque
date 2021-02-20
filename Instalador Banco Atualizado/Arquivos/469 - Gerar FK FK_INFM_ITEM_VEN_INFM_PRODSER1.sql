QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_ITEMVENDA') and o.name = 'FK_INFM_ITEM_VEN_INFM_PRODSER1'
BANCODEDADOS IGERENCE
alter table INFM_ITEMVENDA
   add constraint FK_INFM_ITEM_VEN_INFM_PRODSER1 foreign key (IDPRODUTOSERVICO)
      references INFM_PRODUTOSERVICO (IDPRODUTOSERVICO)