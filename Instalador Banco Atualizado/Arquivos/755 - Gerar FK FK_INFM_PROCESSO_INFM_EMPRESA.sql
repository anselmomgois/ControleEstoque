QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PROCESSO') and o.name = 'FK_INFM_PROCESSO_INFM_EMPRESA'
BANCODEDADOS IGERENCE
alter table INFM_PROCESSO
   add constraint FK_INFM_PROCESSO_INFM_EMPRESA foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)