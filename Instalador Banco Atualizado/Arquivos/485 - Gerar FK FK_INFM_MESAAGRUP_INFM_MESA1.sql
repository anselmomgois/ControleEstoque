QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_MESAAGRUPAR') and o.name = 'FK_INFM_MESAAGRUP_INFM_MESA2'
BANCODEDADOS IGERENCE
alter table INFM_MESAAGRUPAR
   add constraint FK_INFM_MESAAGRUP_INFM_MESA2 foreign key (IDMESAAUXILIAR)
      references INFM_MESA (IDMESA)