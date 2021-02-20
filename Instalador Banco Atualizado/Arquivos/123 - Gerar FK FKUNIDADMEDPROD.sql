QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_UNIDADEMEDIDA') and o.name = 'FKUNIDADMEDPROD'
BANCODEDADOS IGERENCE
alter table INFM_UNIDADEMEDIDA
   add constraint FKUNIDADMEDPROD foreign key (IDUNIDADEMEDIDAPAI)
      references INFM_UNIDADEMEDIDA (IDUNIDADEMEDIDA)