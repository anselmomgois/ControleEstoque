QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_TIPOCRMCONFIG') and o.name = 'FK_INFM_TIP_REF_INFM_TIP_2'
BANCODEDADOS IGERENCE
alter table INFM_TIPOCRMCONFIG
   add constraint FK_INFM_TIP_REF_INFM_TIP_2 foreign key (IDTIPOEMPREGADO)
      references INFM_TIPOEMPREGADO (IDTIPOEMPREGADO)