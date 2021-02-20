QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_COMPRA') and o.name = 'FK_INFM_COMPRA_INFM_FILIAL1'
BANCODEDADOS IGERENCE
alter table INFM_COMPRA
   add constraint FK_INFM_COMPRA_INFM_FILIAL1 foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)