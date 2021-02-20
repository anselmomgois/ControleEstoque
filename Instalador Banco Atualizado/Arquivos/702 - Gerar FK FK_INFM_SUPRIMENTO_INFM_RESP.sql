QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_SUPRIMENTO') and o.name = 'FK_INFM_SUP_REF_INFM_RES'
BANCODEDADOS IGERENCE
alter table INFM_SUPRIMENTO
   add constraint FK_INFM_SUP_REF_INFM_RES foreign key (IDRESPONSAVELCAIXA)
      references INFM_RESPONSAVELCAIXA (IDRESPONSAVELCAIXA)