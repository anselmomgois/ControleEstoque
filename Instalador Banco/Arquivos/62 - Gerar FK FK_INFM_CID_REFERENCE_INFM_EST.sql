QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_CIDADE') and o.name = 'FK_INFM_CID_REFERENCE_INFM_EST'
BANCODEDADOS INFORMATIZ
alter table INFM_CIDADE
   add constraint FK_INFM_CID_REFERENCE_INFM_EST foreign key (IDESTADO)
      references INFM_ESTADO (IDESTADO)