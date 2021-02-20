QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_FILIALBAIRRO') and o.name = 'FK_INFM_FIL_FK_FILIAL_INFM_FIL1'
BANCODEDADOS IGERENCE
alter table INFM_FILIALBAIRRO
   add constraint FK_INFM_FIL_FK_FILIAL_INFM_FIL1 foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)