QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PERGUNTAS') and o.name = 'FK_INFM_PER_REFERENCE_INFM_GRU'
BANCODEDADOS INFORMATIZ
alter table INFM_PERGUNTAS
   add constraint FK_INFM_PER_REFERENCE_INFM_GRU foreign key (IDGRUPOCOMPROMISSO)
      references INFM_GRUPOCOMPROMISSO (IDGRUPOCOMPROMISSO)