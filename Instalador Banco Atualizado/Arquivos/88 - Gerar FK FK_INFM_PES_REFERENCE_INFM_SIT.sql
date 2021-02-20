QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PESSOA') and o.name = 'FK_INFM_PES_REFERENCE_INFM_SIT'
BANCODEDADOS IGERENCE
alter table INFM_PESSOA
   add constraint FK_INFM_PES_REFERENCE_INFM_SIT foreign key (IDSITUACAOPESSOA)
      references INFM_SITUACAO_PESSOA (IDSITUACAOPESSOA)