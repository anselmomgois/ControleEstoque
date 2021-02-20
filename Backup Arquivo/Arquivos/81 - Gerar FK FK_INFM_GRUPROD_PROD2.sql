QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_GRUPOPRODUTOSUBGRUPO') and o.name = 'FK_INFM_GRUPROD_PROD2'
BANCODEDADOS INFORMATIZ
alter table INFM_GRUPOPRODUTOSUBGRUPO
   add constraint FK_INFM_GRUPROD_PROD2 foreign key (IDGRUPOPRODUTOPAI)
      references INFM_GRUPOPRODUTO (IDGRUPOPRODUTO)