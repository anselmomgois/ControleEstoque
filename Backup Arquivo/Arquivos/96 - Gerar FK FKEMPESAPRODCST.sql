QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOCST') and o.name = 'FKEMPESAPRODCST'
BANCODEDADOS INFORMATIZ
alter table INFM_PRODUTOCST
   add constraint FKEMPESAPRODCST foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)