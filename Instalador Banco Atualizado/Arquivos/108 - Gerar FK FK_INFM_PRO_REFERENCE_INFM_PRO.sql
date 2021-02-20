QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOPROMOCAOPRODF') and o.name = 'FK_INFM_PRO_REFERENCE_INFM_PRO'
BANCODEDADOS IGERENCE
alter table INFM_PRODUTOPROMOCAOPRODF
   add constraint FK_INFM_PRO_REFERENCE_INFM_PRO foreign key (IDPRODUTOSERVICO)
      references INFM_PRODUTOSERVICO (IDPRODUTOSERVICO)