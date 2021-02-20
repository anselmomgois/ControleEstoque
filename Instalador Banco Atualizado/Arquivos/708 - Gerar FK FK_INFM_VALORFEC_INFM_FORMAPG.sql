QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_VALORFECHAMENTO') and o.name = 'FK_INFM_VALORFEC_INFM_FORMAPG'
BANCODEDADOS IGERENCE
alter table INFM_VALORFECHAMENTO
   add constraint FK_INFM_VALORFEC_INFM_FORMAPG foreign key (IDFORMAPAGAMENTO)
      references INFM_FORMAPAGAMENTO (IDFORMAPAGAMENTO)