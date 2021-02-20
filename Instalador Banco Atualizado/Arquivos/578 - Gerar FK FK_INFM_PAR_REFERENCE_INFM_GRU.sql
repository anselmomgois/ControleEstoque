QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PARAMETROS') and o.name = 'FK_INFM_PAR_REFERENCE_INFM_GRU'
BANCODEDADOS IGERENCE
alter table INFM_PARAMETROS
   add constraint FK_INFM_PAR_REFERENCE_INFM_GRU foreign key (IDGRUPOPARAMETRO)
      references INFM_GRUPOPARAMETRO (IDGRUPOPARAMETRO)