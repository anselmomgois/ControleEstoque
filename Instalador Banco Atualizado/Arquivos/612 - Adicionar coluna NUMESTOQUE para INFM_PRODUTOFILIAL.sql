QUERYVALIDACAO SELECT 1 FROM SYS.TABLES AS T JOIN SYS.COLUMNS AS C ON T.OBJECT_ID = C.OBJECT_ID WHERE T.TYPE = 'U' AND T.NAME = 'INFM_PRODUTOFILIAL' AND C.NAME = 'NUMESTOQUE'
BANCODEDADOS IGERENCE
ALTER TABLE INFM_PRODUTOFILIAL ADD NUMESTOQUE NUMERO_DECIMAL_10_3 NULL