QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FK_INFM_PRODSERV_INFM_SETOR'
BANCODEDADOS IGERENCE
alter table INFM_PRODUTOSERVICO
   add constraint FK_INFM_PRODSERV_INFM_SETOR foreign key (IDSETOREMPRESA)
      references INFM_SETOREMPRESA (IDSETOREMPRESA)