QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_VALORFECHAMENTO') and o.name = 'FK_INFM_VALORFEC_INFM_PESSOA'
BANCODEDADOS IGERENCE
alter table INFM_VALORFECHAMENTO
   add constraint FK_INFM_VALORFEC_INFM_PESSOA foreign key (IDPESSOASUPERVISOR)
      references INFM_PESSOA (IDPESSOA)