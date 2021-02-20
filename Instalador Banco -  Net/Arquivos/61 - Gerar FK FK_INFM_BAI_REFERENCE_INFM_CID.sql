QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_BAIRRO') and o.name = 'FK_INFM_BAI_REFERENCE_INFM_CID'
BANCODEDADOS INFORMATIZ
alter table INFM_BAIRRO
   add constraint FK_INFM_BAI_REFERENCE_INFM_CID foreign key (IDCIDADE)
      references INFM_CIDADE (IDCIDADE)