QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_FILIAL') and o.name = 'FK_INFM_FIL_FK_PESSOA_INFM_PES1'
BANCODEDADOS INFORMATIZ
alter table INFM_FILIAL
   add constraint FK_INFM_FIL_FK_PESSOA_INFM_PES1 foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)