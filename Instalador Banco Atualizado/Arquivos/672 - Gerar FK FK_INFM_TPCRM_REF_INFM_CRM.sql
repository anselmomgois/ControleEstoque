QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_INTEGRACAOAPI') and o.name = 'FK_INFM_TPCRM_REF_INFM_CRM'
BANCODEDADOS IGERENCE
alter table INFM_INTEGRACAOAPI
   add constraint FK_INFM_TPCRM_REF_INFM_CRM foreign key (IDTIPOCRM)
      references INFM_TIPOCRM (IDTIPOCRM)