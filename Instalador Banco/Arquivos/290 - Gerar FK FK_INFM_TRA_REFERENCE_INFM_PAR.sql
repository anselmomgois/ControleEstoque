QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_TRANSACOES') and o.name = 'FK_INFM_TRA_REFERENCE_INFM_PAR'
BANCODEDADOS INFORMATIZ
alter table INFM_TRANSACOES
   add constraint FK_INFM_TRA_REFERENCE_INFM_PAR foreign key (IDPARCELAMENTO)
      references INFM_PARCELAMENTO (IDPARCELAMENTO)