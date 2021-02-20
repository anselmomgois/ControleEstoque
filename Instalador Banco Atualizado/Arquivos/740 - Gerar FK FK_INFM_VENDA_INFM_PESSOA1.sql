QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_VENDA') and o.name = 'FK_INFM_VENDA_INFM_PESSOA3'
BANCODEDADOS IGERENCE
alter table INFM_VENDA
   add constraint FK_INFM_VENDA_INFM_PESSOA3 foreign key (IDPESSOAVENDA)
      references INFM_PESSOA (IDPESSOA)