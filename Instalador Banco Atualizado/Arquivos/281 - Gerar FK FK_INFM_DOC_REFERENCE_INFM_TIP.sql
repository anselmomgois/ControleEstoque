QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_DOCUMENTO') and o.name = 'FK_INFM_DOC_REFERENCE_INFM_TIP'
BANCODEDADOS IGERENCE
alter table INFM_DOCUMENTO
   add constraint FK_INFM_DOC_REFERENCE_INFM_TIP foreign key (IDTIPODOCUMENTO)
      references INFM_TIPODOCUMENTO (IDTIPODOCUMENTO)