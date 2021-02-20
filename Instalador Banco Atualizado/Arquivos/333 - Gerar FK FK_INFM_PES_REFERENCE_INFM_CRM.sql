QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PESSOACRM') and o.name = 'FK_INFM_PES_REF_INFM_CRM3'
BANCODEDADOS IGERENCE
alter table INFM_PESSOACRM
   add constraint FK_INFM_PES_REF_INFM_CRM3 foreign key (IDCRM)
      references INFM_CRM (IDCRM)