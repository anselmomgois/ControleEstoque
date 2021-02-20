QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_DATOSCOMPRAPROD') and o.name = 'FK_INFM_DAT_REFERENCE_INFM_UNI'
BANCODEDADOS INFORMATIZ
alter table INFM_DATOSCOMPRAPROD
   add constraint FK_INFM_DAT_REFERENCE_INFM_UNI foreign key (IDUNIDADEMEDIDA)
      references INFM_UNIDADEMEDIDA (IDUNIDADEMEDIDA)