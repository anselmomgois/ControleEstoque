QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_GRUPOCOMPROMISSOSUBGRUPO') and o.name = 'FK_INFM_GRU_REF_INFM_GRU_1'
BANCODEDADOS IGERENCE
alter table INFM_GRUPOCOMPROMISSOSUBGRUPO
   add constraint FK_INFM_GRU_REF_INFM_GRU_1 foreign key (IDGRUPOCOMPROMISSO)
      references INFM_GRUPOCOMPROMISSO (IDGRUPOCOMPROMISSO)