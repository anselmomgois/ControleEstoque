QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_CRM') and o.name = 'FK_INFM_CRM_REF_INFM_TIPOCRM'
BANCODEDADOS IGERENCE
alter table INFM_CRM
   add constraint FK_INFM_CRM_REF_INFM_TIPOCRM foreign key (IDTIPOCRM)
      references INFM_TIPOCRM (IDTIPOCRM)