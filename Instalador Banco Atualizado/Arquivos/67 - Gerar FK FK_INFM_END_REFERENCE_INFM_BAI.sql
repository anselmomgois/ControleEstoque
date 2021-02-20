QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_ENDERECO') and o.name = 'FK_INFM_END_REFERENCE_INFM_BAI'
BANCODEDADOS IGERENCE
alter table INFM_ENDERECO
   add constraint FK_INFM_END_REFERENCE_INFM_BAI foreign key (IDBAIRRO)
      references INFM_BAIRRO (IDBAIRRO)