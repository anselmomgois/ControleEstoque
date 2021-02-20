QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_SUPRIMENTO') and o.name = 'FK_INFM_SUP_REF_INFM_PES'
BANCODEDADOS IGERENCE
alter table INFM_SUPRIMENTO
   add constraint FK_INFM_SUP_REF_INFM_PES foreign key (IDPESSOASUPERVISOR)
      references INFM_PESSOA (IDPESSOA)