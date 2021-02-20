QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FKPRODUTOCFOPPRODSERV'
BANCODEDADOS IGERENCE
alter table INFM_PRODUTOSERVICO
   add constraint FKPRODUTOCFOPPRODSERV foreign key (IDPRODUTOCFOP)
      references INFM_PRODUTOCFOP (IDPRODUTOCFOP)