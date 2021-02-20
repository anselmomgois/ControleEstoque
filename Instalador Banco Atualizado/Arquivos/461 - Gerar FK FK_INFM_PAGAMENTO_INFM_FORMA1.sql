QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PAGAMENTO') and o.name = 'FK_INFM_PAGAMENTO_INFM_FORMA1'
BANCODEDADOS IGERENCE
alter table INFM_PAGAMENTO
   add constraint FK_INFM_PAGAMENTO_INFM_FORMA1 foreign key (IDFORMAPAGAMENTO)
      references INFM_FORMAPAGAMENTO (IDFORMAPAGAMENTO)