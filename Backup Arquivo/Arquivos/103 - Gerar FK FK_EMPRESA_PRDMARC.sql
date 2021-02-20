QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOMARCA') and o.name = 'FK_EMPRESA_PRDMARC'
BANCODEDADOS INFORMATIZ
alter table INFM_PRODUTOMARCA
   add constraint FK_EMPRESA_PRDMARC foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)