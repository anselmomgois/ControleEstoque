QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PERMISSAOACAO') and o.name = 'FK_INFM_PER_REFERENCE_INFM_PER'
BANCODEDADOS INFORMATIZ
alter table INFM_PERMISSAOACAO
   add constraint FK_INFM_PER_REFERENCE_INFM_PER foreign key (IDPERMISSAO)
      references INFM_PERMISSAO (IDPERMISSAO)