QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PERGUNTAOPCAO') and o.name = 'FK_INFM_PERGOP_REF_INFM_PERG'
BANCODEDADOS IGERENCE
alter table INFM_PERGUNTAOPCAO
   add constraint FK_INFM_PERGOP_REF_INFM_PERG foreign key (IDPERGUNTA)
      references INFM_PERGUNTAS (IDPERGUNTA)