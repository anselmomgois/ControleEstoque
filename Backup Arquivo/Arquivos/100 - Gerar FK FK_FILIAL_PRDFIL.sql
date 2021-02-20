QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOFILIAL') and o.name = 'FK_FILIAL_PRDFIL'
BANCODEDADOS INFORMATIZ
alter table INFM_PRODUTOFILIAL
   add constraint FK_FILIAL_PRDFIL foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)