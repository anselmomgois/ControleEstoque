QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_UNIDADEMEDPRODUTO') and o.name = 'FK_INFM_UNI_REFERENCE_INFM_PRO'
BANCODEDADOS IGERENCE
alter table INFM_UNIDADEMEDPRODUTO
   add constraint FK_INFM_UNI_REFERENCE_INFM_PRO foreign key (IDPRODUTOSERVICO)
      references INFM_PRODUTOSERVICO (IDPRODUTOSERVICO)