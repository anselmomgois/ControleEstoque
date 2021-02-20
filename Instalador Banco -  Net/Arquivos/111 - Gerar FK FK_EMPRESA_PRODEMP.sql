QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FK_EMPRESA_PRODEMP'
BANCODEDADOS INFORMATIZ
alter table INFM_PRODUTOSERVICO
   add constraint FK_EMPRESA_PRODEMP foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)