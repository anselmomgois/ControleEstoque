QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_GRUPOPRODUTOSUBGRUPO') and o.name = 'FK_INFM_GRUPROD_GRUPRODPROD'
BANCODEDADOS IGERENCE
alter table INFM_GRUPOPRODUTOSUBGRUPO
   add constraint FK_INFM_GRUPROD_GRUPRODPROD foreign key (IDGRUPOPRODUTO)
      references INFM_GRUPOPRODUTO (IDGRUPOPRODUTO)