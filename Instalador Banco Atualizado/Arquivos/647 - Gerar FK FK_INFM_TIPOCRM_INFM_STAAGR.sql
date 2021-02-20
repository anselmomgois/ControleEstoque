QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_TIPOCRM') and o.name = 'FK_INFM_TIPOCRM_INFM_STAAGR'
BANCODEDADOS IGERENCE
alter table INFM_TIPOCRM
   add constraint FK_INFM_TIPOCRM_INFM_STAAGR foreign key (IDSTATUSCRMAGRUP)
      references INFM_STATUSCRMAGRUP (IDSTATUSCRMAGRUP)