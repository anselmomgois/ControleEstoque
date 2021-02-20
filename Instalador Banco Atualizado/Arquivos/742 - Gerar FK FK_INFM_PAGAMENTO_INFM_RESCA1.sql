QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PAGAMENTO') and o.name = 'FK_INFM_PAGAMENTO_INFM_RESCA1'
BANCODEDADOS IGERENCE
alter table INFM_PAGAMENTO
   add constraint FK_INFM_PAGAMENTO_INFM_RESCA1 foreign key (IDRESPONSAVELCAIXA)
      references INFM_RESPONSAVELCAIXA (IDRESPONSAVELCAIXA)