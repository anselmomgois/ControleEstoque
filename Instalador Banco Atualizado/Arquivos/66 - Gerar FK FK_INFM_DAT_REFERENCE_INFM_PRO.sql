QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_DATOSCOMPRAPROD') and o.name = 'FK_INFM_DAT_REFERENCE_INFM_PRO'
BANCODEDADOS IGERENCE
alter table INFM_DATOSCOMPRAPROD
   add constraint FK_INFM_DAT_REFERENCE_INFM_PRO foreign key (IDPRODUTOFILIAL)
      references INFM_PRODUTOFILIAL (IDPRODUTOFILIAL)