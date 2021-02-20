QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FK_INFM_PRO_FK_PRODDE_INFM_PRO'
BANCODEDADOS INFORMATIZ
alter table INFM_PRODUTOSERVICO
   add constraint FK_INFM_PRO_FK_PRODDE_INFM_PRO foreign key (IDPRODUTODERIVACAO)
      references INFM_PRODUTODERIVACAO (IDPRODUTODERIVACAO)