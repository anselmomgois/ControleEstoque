QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_CRM') and o.name = 'FK_INFM_CRM_REFERENCE_INFM_GRU'
BANCODEDADOS IGERENCE
VALIDACAOINVERSA
ALTER TABLE INFM_CRM DROP CONSTRAINT FK_INFM_CRM_REFERENCE_INFM_GRU