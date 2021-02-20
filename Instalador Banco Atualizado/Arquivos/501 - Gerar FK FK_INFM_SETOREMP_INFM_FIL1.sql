QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_SETOREMPRESA') and o.name = 'FK_INFM_SETOREMP_INFM_FIL1'
BANCODEDADOS IGERENCE
alter table INFM_SETOREMPRESA
   add constraint FK_INFM_SETOREMP_INFM_FIL1 foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)