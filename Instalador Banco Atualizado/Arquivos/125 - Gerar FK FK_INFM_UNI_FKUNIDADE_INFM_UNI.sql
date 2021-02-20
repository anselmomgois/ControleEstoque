QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_UNIDADEMEDPRODUTO') and o.name = 'FK_INFM_UNI_FKUNIDADE_INFM_UNI'
BANCODEDADOS IGERENCE
alter table INFM_UNIDADEMEDPRODUTO
   add constraint FK_INFM_UNI_FKUNIDADE_INFM_UNI foreign key (IDUNIDADEMEDIDA)
      references INFM_UNIDADEMEDIDA (IDUNIDADEMEDIDA)