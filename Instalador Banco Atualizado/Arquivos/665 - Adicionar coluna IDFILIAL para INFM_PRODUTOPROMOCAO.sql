QUERYVALIDACAO SELECT 1 FROM SYS.TABLES AS T JOIN SYS.COLUMNS AS C ON T.OBJECT_ID = C.OBJECT_ID WHERE T.TYPE = 'U' AND T.NAME = 'INFM_PRODUTOPROMOCAO' AND C.NAME = 'IDFILIAL'
BANCODEDADOS IGERENCE
ALTER TABLE INFM_PRODUTOPROMOCAO ADD IDFILIAL OBJETO_ID NULL