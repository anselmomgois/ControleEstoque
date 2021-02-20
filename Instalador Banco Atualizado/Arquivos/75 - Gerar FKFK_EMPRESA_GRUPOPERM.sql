QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_GRUPOPERMISSAO') and o.name = 'FK_EMPRESA_GRUPOPERM'
BANCODEDADOS IGERENCE
alter table INFM_GRUPOPERMISSAO
   add constraint FK_EMPRESA_GRUPOPERM foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)