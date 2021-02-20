QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_ITEMPROCESSOERRO') and o.name = 'FK_INFM_ITEMPROCESSOERRO_INFM_PROCESSO'
BANCODEDADOS IGERENCE
alter table INFM_ITEMPROCESSOERRO
   add constraint FK_INFM_ITEMPROCESSOERRO_INFM_PROCESSO foreign key (IDPROCESSO)
      references INFM_PROCESSO (IDPROCESSO)