QUERYVALIDACAO SELECT 1 FROM SYS.TABLES AS T JOIN SYS.COLUMNS AS C ON T.OBJECT_ID = C.OBJECT_ID WHERE T.TYPE = 'U' AND T.NAME = 'INFM_INTEGRACAOAPI' AND C.NAME = 'IDTIPOCRM'
BANCODEDADOS IGERENCE
ALTER TABLE INFM_INTEGRACAOAPI ADD IDTIPOCRM OBJETO_ID NULL