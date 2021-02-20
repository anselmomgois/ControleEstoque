QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_MESAVENDA') and o.name = 'FK_INFM_MESAVENDA_INFM_MESA1'
BANCODEDADOS IGERENCE
alter table INFM_MESAVENDA
   add constraint FK_INFM_MESAVENDA_INFM_MESA1 foreign key (IDMESA)
      references INFM_MESA (IDMESA)