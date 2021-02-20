QUERYVALIDACAO select 1 from  sysindexes where  id    = object_id('INFM_PESSOA') and   name  = 'AK_INFM_PESSOA2' and   indid > 0 and   indid < 255
BANCODEDADOS IGERENCE
create index AK_INFM_PESSOA2 on INFM_PESSOA (
DESTELEFONECELULAR ASC)