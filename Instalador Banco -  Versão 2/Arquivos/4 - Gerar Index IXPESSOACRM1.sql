QUERYVALIDACAO select 1 from sys.sysindexes r join sys.sysobjects o on (o.id = r.id) where r.id = object_id('INFM_PESSOACRM') and r.name = 'IXPESSOACRM1'
BANCODEDADOS INFORMATIZ
create index IXPESSOACRM1 on INFM_PESSOACRM (DTHPROXAGENDAMENTO ASC,DTHPROXAGENDAMENTOFIN ASC)