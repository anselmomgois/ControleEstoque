QUERYVALIDACAO select 1 from  sysindexes where  id    = object_id('INFM_COMPRA') and   name  = 'AK_INFM_COMPRA1' and   indid > 0 and   indid < 255
BANCODEDADOS IGERENCE
create unique index AK_INFM_COMPRA1 on INFM_COMPRA (
IDEMPRESA ASC,
CODCOMPRA ASC)