QUERYVALIDACAO SELECT 1 FROM SYS.TABLES AS T JOIN SYS.COLUMNS AS C ON T.OBJECT_ID = C.OBJECT_ID WHERE T.TYPE = 'U' AND T.NAME = 'INFM_RESPOSTAPERGUNTA' AND C.NAME = 'IDCRM'
BANCODEDADOS INFORMATIZ
VALIDACAOINVERSA
ALTER TABLE INFM_RESPOSTAPERGUNTA DROP COLUMN IDCRM