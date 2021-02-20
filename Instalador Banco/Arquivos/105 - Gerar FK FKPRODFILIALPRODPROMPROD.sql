QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOPROMOCAOPRODF') and o.name = 'FKPRODFILIALPRODPROMPROD'
BANCODEDADOS INFORMATIZ
alter table INFM_PRODUTOPROMOCAOPRODF
   add constraint FKPRODFILIALPRODPROMPROD foreign key (IDPRODUTOFILIAL)
      references INFM_PRODUTOFILIAL (IDPRODUTOFILIAL)