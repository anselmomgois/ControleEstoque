QUERYVALIDACAO SELECT 1 FROM SYS.TABLES AS T JOIN SYS.COLUMNS AS C ON T.OBJECT_ID = C.OBJECT_ID WHERE T.TYPE = 'U' AND T.NAME = 'INFM_PESSOACRM' AND C.NAME = 'IDPESSOA'
BANCODEDADOS INFORMATIZ
VALIDACAOINVERSA
ALTER TABLE INFM_PESSOACRM DROP COLUMN IDPESSOA