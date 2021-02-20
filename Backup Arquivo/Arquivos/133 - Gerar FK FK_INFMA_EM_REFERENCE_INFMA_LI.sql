QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFMA_EMPRESA') and o.name = 'FK_INFMA_EM_REFERENCE_INFMA_LI'
BANCODEDADOS INFORMATIZ
alter table INFMA_EMPRESA
   add constraint FK_INFMA_EM_REFERENCE_INFMA_LI foreign key (IDLICENCA)
      references INFMA_LICENCA (IDLICENCA)