QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_ITEMVENDA') and o.name = 'FK_INFM_ITEMVENDA_INFM_PRODNUMS1'
BANCODEDADOS IGERENCE
alter table INFM_ITEMVENDA
   add constraint FK_INFM_ITEMVENDA_INFM_PRODNUMS1 foreign key (IDPRODUTONUMEROSERIE)
      references INFM_PRODUTONUMEROSERIE (IDPRODUTONUMEROSERIE)