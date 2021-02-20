QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOFILIAL') and o.name = 'FKUNIDADEMEDPRODFIL1'
BANCODEDADOS INFORMATIZ
alter table INFM_PRODUTOFILIAL
   add constraint FKUNIDADEMEDPRODFIL1 foreign key (IDUNIDADEMEDIDAVENDA)
      references INFM_UNIDADEMEDIDA (IDUNIDADEMEDIDA)