QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_ITEMVENDAOBSERVACAO') and o.name = 'FK_INFM_ITEMVOB_INFM_OBS1'
BANCODEDADOS IGERENCE
alter table INFM_ITEMVENDAOBSERVACAO
   add constraint FK_INFM_ITEMVOB_INFM_OBS1 foreign key (IDOBSERVACAO)
      references INFM_OBSERVACAO (IDOBSERVACAO)