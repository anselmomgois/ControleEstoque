QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PESSOACRM') and o.name = 'FK_INFM_PES_CRM_INFM_GRU'
BANCODEDADOS IGERENCE
alter table INFM_PESSOACRM
   add constraint FK_INFM_PES_CRM_INFM_GRU foreign key (IDGRUPOCOMPROMISSO)
      references INFM_GRUPOCOMPROMISSO (IDGRUPOCOMPROMISSO)