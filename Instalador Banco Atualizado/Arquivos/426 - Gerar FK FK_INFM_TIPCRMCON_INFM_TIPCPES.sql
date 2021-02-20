QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_TIPOCRMCONFIGPESSOA') and o.name = 'FK_INFM_TIPCRMCON_INFM_TIPCPES'
BANCODEDADOS IGERENCE
alter table INFM_TIPOCRMCONFIGPESSOA
   add constraint FK_INFM_TIPCRMCON_INFM_TIPCPES foreign key (IDTIPOCRMCONFIG)
      references INFM_TIPOCRMCONFIG (IDTIPOCRMCONFIG)