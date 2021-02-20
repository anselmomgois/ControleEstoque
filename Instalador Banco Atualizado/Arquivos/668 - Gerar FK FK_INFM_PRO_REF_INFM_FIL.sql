QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOPROMOCAO') and o.name = 'FK_INFM_PRO_REF_INFM_FIL'
BANCODEDADOS IGERENCE
alter table INFM_PRODUTOPROMOCAO
   add constraint FK_INFM_PRO_REF_INFM_FIL foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)