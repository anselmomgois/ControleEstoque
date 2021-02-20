QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_SALDOFILIAL') and o.name = 'FK_INFM_SAL_REFERENCE_INFM_FIL'
BANCODEDADOS INFORMATIZ
alter table INFM_SALDOFILIAL
   add constraint FK_INFM_SAL_REFERENCE_INFM_FIL foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)