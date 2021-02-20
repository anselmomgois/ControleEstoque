QUERYVALIDACAO select 1 from  sysindexes where  id    = object_id('INFM_CAIXA') and   name  = 'AK_INFM_CAIXA2' and   indid > 0 and   indid < 255
BANCODEDADOS IGERENCE
create unique index AK_INFM_CAIXA2 on INFM_CAIXA (
IDEMPRESA ASC,
IDFILIAL ASC,
DESHOST ASC)