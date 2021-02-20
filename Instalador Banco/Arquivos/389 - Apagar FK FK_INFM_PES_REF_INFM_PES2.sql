QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PESSOACRM') and o.name = 'FK_INFM_PES_REF_INFM_PES2 '
BANCODEDADOS INFORMATIZ
VALIDACAOINVERSA
ALTER TABLE INFM_PESSOACRM DROP CONSTRAINT FK_INFM_PES_REF_INFM_PES2