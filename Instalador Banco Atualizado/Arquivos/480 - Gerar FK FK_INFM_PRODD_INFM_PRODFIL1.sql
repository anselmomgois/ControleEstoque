QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOVALORDINAMICO') and o.name = 'FK_INFM_PRODD_INFM_PRODFIL1'
BANCODEDADOS IGERENCE
alter table INFM_PRODUTOVALORDINAMICO
   add constraint FK_INFM_PRODD_INFM_PRODFIL1 foreign key (IDPRODUTOFILIAL)
      references INFM_PRODUTOFILIAL (IDPRODUTOFILIAL)