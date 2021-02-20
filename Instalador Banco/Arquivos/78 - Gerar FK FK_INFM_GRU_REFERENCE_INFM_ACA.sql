QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_GRUPOPERMISSAOACAO') and o.name = 'FK_INFM_GRU_REFERENCE_INFM_ACA'
BANCODEDADOS INFORMATIZ
alter table INFM_GRUPOPERMISSAOACAO
   add constraint FK_INFM_GRU_REFERENCE_INFM_ACA foreign key (IDACAO)
      references INFM_ACAO (IDACAO)