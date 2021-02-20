QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_FILIALPESSOA') and o.name = 'FK_INFM_FIL_FK_FILIAL_INFM_FIL2'
BANCODEDADOS INFORMATIZ
alter table INFM_FILIALPESSOA
   add constraint FK_INFM_FIL_FK_FILIAL_INFM_FIL2 foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)