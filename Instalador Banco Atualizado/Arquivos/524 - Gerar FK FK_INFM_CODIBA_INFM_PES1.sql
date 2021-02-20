QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_CODIGOBARRASPESSOA') and o.name = 'FK_INFM_CODIBA_INFM_PES1'
BANCODEDADOS IGERENCE
alter table INFM_CODIGOBARRASPESSOA
   add constraint FK_INFM_CODIBA_INFM_PES1 foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)