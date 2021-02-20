QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOCFOP') and o.name = 'FKEMPRESAPRODCFOP'
BANCODEDADOS INFORMATIZ
alter table INFM_PRODUTOCFOP
   add constraint FKEMPRESAPRODCFOP foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)