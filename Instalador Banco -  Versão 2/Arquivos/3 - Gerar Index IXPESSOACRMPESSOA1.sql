QUERYVALIDACAO select 1 from sys.sysindexes r join sys.sysobjects o on (o.id = r.id) where r.id = object_id('INFM_PESSOACRMPESSOA') and r.name = 'IXPESSOACRMPESSOA1'
BANCODEDADOS INFORMATIZ
create index IXPESSOACRMPESSOA1 on INFM_PESSOACRMPESSOA (IDPESSOA ASC)