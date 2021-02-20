QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_ITEMVENDA') and o.name = 'FK_INFM_ITEMVENDA_INFM_PESCANC'
BANCODEDADOS IGERENCE
alter table INFM_ITEMVENDA
   add constraint FK_INFM_ITEMVENDA_INFM_PESCANC foreign key (IDPESSOACANCELAMENTO)
      references INFM_PESSOA (IDPESSOA)