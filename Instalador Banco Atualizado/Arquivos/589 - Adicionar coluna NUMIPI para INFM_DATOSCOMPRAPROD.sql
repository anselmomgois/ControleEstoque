QUERYVALIDACAO SELECT 1 FROM SYS.TABLES AS T JOIN SYS.COLUMNS AS C ON T.OBJECT_ID = C.OBJECT_ID WHERE T.TYPE = 'U' AND T.NAME = 'INFM_DATOSCOMPRAPROD' AND C.NAME = 'NUMIPI'
BANCODEDADOS IGERENCE
ALTER TABLE INFM_DATOSCOMPRAPROD ADD NUMIPI NUMERO_DECIMAL NULL