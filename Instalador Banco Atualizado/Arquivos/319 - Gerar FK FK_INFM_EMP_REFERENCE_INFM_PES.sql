QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_EMPRESA') and o.name = 'FK_INFM_EMP_REFERENCE_INFM_PES'
BANCODEDADOS IGERENCE
alter table INFM_EMPRESA
   add constraint FK_INFM_EMP_REFERENCE_INFM_PES foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)