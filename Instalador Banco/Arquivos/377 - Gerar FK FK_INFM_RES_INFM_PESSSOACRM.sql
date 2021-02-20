QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_RESPOSTAPERGUNTA') and o.name = 'FK_INFM_RES_INFM_PESSSOACRM'
BANCODEDADOS INFORMATIZ
alter table INFM_RESPOSTAPERGUNTA
   add constraint FK_INFM_RES_INFM_PESSSOACRM foreign key (IDPESSOACRM)
      references INFM_PESSOACRM (IDPESSOACRM)