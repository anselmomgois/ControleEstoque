QUERYVALIDACAO SELECT 1 FROM SYS.TABLES AS T JOIN SYS.COLUMNS AS C ON T.OBJECT_ID = C.OBJECT_ID WHERE T.TYPE = 'U' AND T.NAME = 'INFM_VENDA' AND C.NAME = 'NUMACRESCIMO'
BANCODEDADOS IGERENCE
ALTER TABLE INFM_VENDA ADD NUMACRESCIMO NUMERO_DECIMAL null