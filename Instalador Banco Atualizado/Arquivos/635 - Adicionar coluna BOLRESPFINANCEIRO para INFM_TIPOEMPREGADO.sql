QUERYVALIDACAO SELECT 1 FROM SYS.TABLES AS T JOIN SYS.COLUMNS AS C ON T.OBJECT_ID = C.OBJECT_ID WHERE T.TYPE = 'U' AND T.NAME = 'INFM_TIPOEMPREGADO' AND C.NAME = 'BOLRESPFINANCEIRO'
BANCODEDADOS IGERENCE
ALTER TABLE INFM_TIPOEMPREGADO ADD BOLRESPFINANCEIRO BOLEANO NULL