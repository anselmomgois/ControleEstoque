QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_MESA') and o.name = 'FK_INFM_MESA_INFM_FILIAL1'
BANCODEDADOS IGERENCE
alter table INFM_MESA
   add constraint FK_INFM_MESA_INFM_FILIAL1 foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)