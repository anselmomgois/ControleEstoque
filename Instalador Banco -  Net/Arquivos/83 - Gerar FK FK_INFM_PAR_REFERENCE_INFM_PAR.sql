QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PARAMETROVALOR') and o.name = 'FK_INFM_PAR_REFERENCE_INFM_PAR'
BANCODEDADOS INFORMATIZ
alter table INFM_PARAMETROVALOR
   add constraint FK_INFM_PAR_REFERENCE_INFM_PAR foreign key (IDPARAMETRO)
      references INFM_PARAMETROS (IDPARAMETRO)