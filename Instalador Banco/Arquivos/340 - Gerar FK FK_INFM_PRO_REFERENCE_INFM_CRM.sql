QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PROPOSTA') and o.name = 'FK_INFM_PRO_REFERENCE_INFM_CRM'
BANCODEDADOS INFORMATIZ
alter table INFM_PROPOSTA
   add constraint FK_INFM_PRO_REFERENCE_INFM_CRM foreign key (IDCRM)
      references INFM_CRM (IDCRM)