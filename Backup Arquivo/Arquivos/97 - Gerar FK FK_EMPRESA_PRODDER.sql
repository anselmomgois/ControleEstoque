QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTODERIVACAO') and o.name = 'FK_EMPRESA_PRODDER'
BANCODEDADOS INFORMATIZ
alter table INFM_PRODUTODERIVACAO
   add constraint FK_EMPRESA_PRODDER foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)