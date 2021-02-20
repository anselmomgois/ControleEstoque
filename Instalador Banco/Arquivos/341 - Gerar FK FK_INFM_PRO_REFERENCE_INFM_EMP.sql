QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PROPOSTA') and o.name = 'FK_INFM_PRO_REFERENCE_INFM_EMP1'
BANCODEDADOS INFORMATIZ
alter table INFM_PROPOSTA
   add constraint FK_INFM_PRO_REFERENCE_INFM_EMP1 foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)