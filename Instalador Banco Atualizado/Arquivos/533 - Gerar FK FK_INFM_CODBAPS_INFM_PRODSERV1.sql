QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_CODIGOBARRASPRODSERV') and o.name = 'FK_INFM_CODBAPS_INFM_PRODSERV1'
BANCODEDADOS IGERENCE
alter table INFM_CODIGOBARRASPRODSERV
   add constraint FK_INFM_CODBAPS_INFM_PRODSERV1 foreign key (IDPRODUTOSERVICO)
      references INFM_PRODUTOSERVICO (IDPRODUTOSERVICO)