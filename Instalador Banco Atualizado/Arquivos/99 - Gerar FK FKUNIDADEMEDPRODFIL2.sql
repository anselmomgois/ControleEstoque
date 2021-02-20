QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOFILIAL') and o.name = 'FKUNIDADEMEDPRODFIL2'
BANCODEDADOS IGERENCE
alter table INFM_PRODUTOFILIAL
   add constraint FKUNIDADEMEDPRODFIL2 foreign key (IDUNIDADEMEDIDAESTOQUE)
      references INFM_UNIDADEMEDIDA (IDUNIDADEMEDIDA)