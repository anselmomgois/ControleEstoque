QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PARCELAMENTO') and o.name = 'FK_INFM_PAR_REFERENCE_INFM_DOC'
BANCODEDADOS INFORMATIZ
alter table INFM_PARCELAMENTO
   add constraint FK_INFM_PAR_REFERENCE_INFM_DOC foreign key (IDDOCUMENTO)
      references INFM_DOCUMENTO (IDDOCUMENTO)