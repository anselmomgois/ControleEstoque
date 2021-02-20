QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_STATUS_CRM') and o.name = 'FK_INFM_STATUSCRM_INFM_STAAG'
BANCODEDADOS IGERENCE
alter table INFM_STATUS_CRM
   add constraint FK_INFM_STATUSCRM_INFM_STAAG foreign key (IDSTATUSCRMAGRUP)
      references INFM_STATUSCRMAGRUP (IDSTATUSCRMAGRUP)