QUERYVALIDACAO SELECT C.* FROM SYS.TABLES AS T JOIN SYS.COLUMNS AS C ON T.OBJECT_ID = C.OBJECT_ID WHERE T.TYPE = 'U' AND T.NAME = 'INFM_CRM' AND C.NAME = 'OBSCOMPROMISSO' AND IS_NULLABLE = 1
BANCODEDADOS INFORMATIZ
alter table INFM_CRM
   alter column OBSCOMPROMISSO OBSERVACAOLONGA null