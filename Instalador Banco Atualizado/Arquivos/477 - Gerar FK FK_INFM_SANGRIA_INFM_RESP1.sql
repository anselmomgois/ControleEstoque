QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_SANGRIA') and o.name = 'FK_INFM_SANGRIA_INFM_RESP1'
BANCODEDADOS IGERENCE
alter table INFM_SANGRIA
   add constraint FK_INFM_SANGRIA_INFM_RESP1 foreign key (IDRESPONSAVELCAIXA)
      references INFM_RESPONSAVELCAIXA (IDRESPONSAVELCAIXA)