QUERYVALIDACAO SELECT 1 FROM SYS.TABLES AS T JOIN SYS.COLUMNS AS C ON T.OBJECT_ID = C.OBJECT_ID WHERE T.TYPE = 'U' AND T.NAME = 'INFM_PROPOSTA' AND C.NAME = 'CODPROPOSTA'
BANCODEDADOS INFORMATIZ
ALTER TABLE INFM_PROPOSTA ADD CODPROPOSTA INTEIROSEQ identity