QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PESSOAMESA') and o.name = 'FK_INFM_PESSOA_INFM_PESSOAMES1'
BANCODEDADOS IGERENCE
alter table INFM_PESSOAMESA
   add constraint FK_INFM_PESSOA_INFM_PESSOAMES1 foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)