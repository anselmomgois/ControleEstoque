QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_RESPOSTAPERGUNTA') and o.name = 'FK_INFM_RES_REFERENCE_INFM_CRM'
BANCODEDADOS INFORMATIZ
VALIDACAOINVERSA
DELETE INFM_RESPOSTAPERGUNTA