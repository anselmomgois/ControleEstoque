QUERYVALIDACAO SELECT 1 FROM SYS.TABLES AS T JOIN SYS.COLUMNS AS C ON T.OBJECT_ID = C.OBJECT_ID WHERE T.TYPE = 'U' AND T.NAME = 'INFM_COMPRA' AND C.NAME = 'NUMBASECALCULO'
BANCODEDADOS IGERENCE
ALTER TABLE INFM_COMPRA ADD NUMBASECALCULO NUMERO_DECIMAL NULL