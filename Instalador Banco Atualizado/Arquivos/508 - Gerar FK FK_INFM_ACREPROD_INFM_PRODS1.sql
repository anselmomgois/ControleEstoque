QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_ACRESCIMOPRODUTO') and o.name = 'FK_INFM_ACREPROD_INFM_PRODS1'
BANCODEDADOS IGERENCE
alter table INFM_ACRESCIMOPRODUTO
   add constraint FK_INFM_ACREPROD_INFM_PRODS1 foreign key (IDPRODUTOSERVICO)
      references INFM_PRODUTOSERVICO (IDPRODUTOSERVICO)