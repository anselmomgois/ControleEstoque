QUERYVALIDACAO SELECT 1 FROM SYS.TABLES AS T JOIN SYS.COLUMNS AS C ON T.OBJECT_ID = C.OBJECT_ID WHERE T.TYPE = 'U' AND T.NAME = 'INFM_ITEMVENDAACRESCIMO' AND C.NAME = 'NUMVALOR'
BANCODEDADOS IGERENCE
ALTER TABLE INFM_ITEMVENDAACRESCIMO ADD NUMVALOR NUMERO_DECIMAL not null