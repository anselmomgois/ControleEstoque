QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOOPCAO') and o.name = 'FK_INFM_PRODSERV_INFM_PROOP1'
BANCODEDADOS IGERENCE
alter table INFM_PRODUTOOPCAO
   add constraint FK_INFM_PRODSERV_INFM_PROOP1 foreign key (IDPRODUTOSERVICO)
      references INFM_PRODUTOSERVICO (IDPRODUTOSERVICO)