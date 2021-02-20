QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_ACRESCIMOPRODUTO') and o.name = 'FK_INFM_ACREPROD_INFM_PRODS2'
BANCODEDADOS IGERENCE
alter table INFM_ACRESCIMOPRODUTO
   add constraint FK_INFM_ACREPROD_INFM_PRODS2 foreign key (IDACRESCIMO)
      references INFM_PRODUTOSERVICO (IDPRODUTOSERVICO)