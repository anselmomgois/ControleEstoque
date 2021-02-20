QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_RESPONSAVELCAIXA') and o.name = 'FK_INFM_RESPCAIX_INFM_CAIXA1'
BANCODEDADOS IGERENCE
alter table INFM_RESPONSAVELCAIXA
   add constraint FK_INFM_RESPCAIX_INFM_CAIXA1 foreign key (IDCAIXA)
      references INFM_CAIXA (IDCAIXA)