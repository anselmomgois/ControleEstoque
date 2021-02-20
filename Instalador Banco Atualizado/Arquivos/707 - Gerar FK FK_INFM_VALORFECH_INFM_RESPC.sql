QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_VALORFECHAMENTO') and o.name = 'FK_INFM_VALORFECH_INFM_RESPC'
BANCODEDADOS IGERENCE
alter table INFM_VALORFECHAMENTO
   add constraint FK_INFM_VALORFECH_INFM_RESPC foreign key (IDRESPONSAVELCAIXA)
      references INFM_RESPONSAVELCAIXA (IDRESPONSAVELCAIXA)