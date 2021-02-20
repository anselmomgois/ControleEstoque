QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_DIASEMANAPROMOCAO') and o.name = 'FK_INFM_DIA_REF_INFM_PRO'
BANCODEDADOS IGERENCE
alter table INFM_DIASEMANAPROMOCAO
   add constraint FK_INFM_DIA_REF_INFM_PRO foreign key (IDPRODUTOPROMOCAO)
      references INFM_PRODUTOPROMOCAO (IDPRODUTOPROMOCAO)