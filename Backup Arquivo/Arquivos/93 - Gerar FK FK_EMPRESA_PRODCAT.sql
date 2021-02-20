QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODCATEGORIA') and o.name = 'FK_EMPRESA_PRODCAT'
BANCODEDADOS INFORMATIZ
alter table INFM_PRODCATEGORIA
   add constraint FK_EMPRESA_PRODCAT foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)