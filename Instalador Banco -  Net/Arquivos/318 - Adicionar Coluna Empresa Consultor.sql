QUERYVALIDACAO SELECT 1 FROM SYS.TABLES AS T JOIN SYS.COLUMNS AS C ON T.OBJECT_ID = C.OBJECT_ID WHERE T.TYPE = 'U' AND T.NAME = 'INFM_EMPRESA' AND C.NAME = 'IDPESSOA'
BANCODEDADOS INFORMATIZ
ALTER TABLE INFM_EMPRESA ADD IDPESSOA OBJETOID NULL