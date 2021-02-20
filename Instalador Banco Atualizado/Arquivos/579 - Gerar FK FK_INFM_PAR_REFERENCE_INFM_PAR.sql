QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PARAMETROOPCAO') and o.name = 'FK_INFM_PAR_REF_INFM_PAR_OP'
BANCODEDADOS IGERENCE
alter table INFM_PARAMETROOPCAO
   add constraint FK_INFM_PAR_REF_INFM_PAR_OP foreign key (IDPARAMETRO)
      references INFM_PARAMETROS (IDPARAMETRO)