QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_ITEMPROCESSOERRO') and o.name = 'FK_INFM_ITEMPROCESSO_INFM_ITEMPROCESSOERRO'
BANCODEDADOS IGERENCE
alter table INFM_ITEMPROCESSOERRO
   add constraint FK_INFM_ITEMPROCESSO_INFM_ITEMPROCESSOERRO foreign key (IDITEMPROCESSO)
      references INFM_ITEMPROCESSO (IDITEMPROCESSO)