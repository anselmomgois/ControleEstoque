QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_ITEMVENDA_NUMSERIE') and o.name = 'FK_INFM_ITEMVNUMS_INFM_ITEMV1'
BANCODEDADOS IGERENCE
alter table INFM_ITEMVENDA_NUMSERIE
   add constraint FK_INFM_ITEMVNUMS_INFM_ITEMV1 foreign key (IDITEMVENDA)
      references INFM_ITEMVENDA (IDITEMVENDA)