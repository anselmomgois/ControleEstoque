QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_TIPOPESSOA_PESSOA') and o.name = 'FK_INFM_TIP_REFERENCE_INFM_TIP'
BANCODEDADOS IGERENCE
alter table INFM_TIPOPESSOA_PESSOA
   add constraint FK_INFM_TIP_REFERENCE_INFM_TIP foreign key (IDTIPOPESSOA)
      references INFM_TIPOPESSOA (IDTIPOPESSOA)