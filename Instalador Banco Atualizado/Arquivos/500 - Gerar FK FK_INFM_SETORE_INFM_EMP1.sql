QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_SETOREMPRESA') and o.name = 'FK_INFM_SETORE_INFM_EMP1'
BANCODEDADOS IGERENCE
alter table INFM_SETOREMPRESA
   add constraint FK_INFM_SETORE_INFM_EMP1 foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)