QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_CAIXA') and o.name = 'FK_INFM_CAIXA_INFM_EMPRESA1'
BANCODEDADOS IGERENCE
alter table INFM_CAIXA
   add constraint FK_INFM_CAIXA_INFM_EMPRESA1 foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)