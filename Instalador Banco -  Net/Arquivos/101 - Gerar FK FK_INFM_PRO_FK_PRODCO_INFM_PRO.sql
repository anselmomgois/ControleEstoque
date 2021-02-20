QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOFILIAL') and o.name = 'FK_INFM_PRO_FK_PRODCO_INFM_PRO'
BANCODEDADOS INFORMATIZ
alter table INFM_PRODUTOFILIAL
   add constraint FK_INFM_PRO_FK_PRODCO_INFM_PRO foreign key (IDPRODUTOCOMISSAO)
      references INFM_PRODUTOCOMISSAO (IDPRODUTOCOMISSAO)