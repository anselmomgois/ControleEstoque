QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_STATUS_CRM') and o.name = 'FK_INFM_STA_REFERENCE_INFM_EMP'
BANCODEDADOS IGERENCE
alter table INFM_STATUS_CRM
   add constraint FK_INFM_STA_REFERENCE_INFM_EMP foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)