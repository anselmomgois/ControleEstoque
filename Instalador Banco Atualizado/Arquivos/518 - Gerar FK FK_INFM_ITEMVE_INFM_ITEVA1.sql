QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_ITEMVENDAACRESCIMO') and o.name = 'FK_INFM_ITEMVE_INFM_ITEVA1'
BANCODEDADOS IGERENCE
alter table INFM_ITEMVENDAACRESCIMO
   add constraint FK_INFM_ITEMVE_INFM_ITEVA1 foreign key (IDITEMVENDA)
      references INFM_ITEMVENDA (IDITEMVENDA)