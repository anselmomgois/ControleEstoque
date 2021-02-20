QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTONUMEROSERIE') and o.name = 'FK_INFM_PRODNUMSE_INFM_DATCOMP1'
BANCODEDADOS IGERENCE
alter table INFM_PRODUTONUMEROSERIE
   add constraint FK_INFM_PRODNUMSE_INFM_DATCOMP1 foreign key (IDDATOSCOMPRAPROD)
      references INFM_DATOSCOMPRAPROD (IDDATOSCOMPRAPROD)