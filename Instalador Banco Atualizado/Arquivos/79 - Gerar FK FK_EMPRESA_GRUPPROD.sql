QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_GRUPOPRODUTO') and o.name = 'FK_EMPRESA_GRUPPROD'
BANCODEDADOS IGERENCE
alter table INFM_GRUPOPRODUTO
   add constraint FK_EMPRESA_GRUPPROD foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)