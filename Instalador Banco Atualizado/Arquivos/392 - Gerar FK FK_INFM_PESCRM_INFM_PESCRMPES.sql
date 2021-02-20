QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PESSOACRMPESSOA') and o.name = 'FK_INFM_PESCRM_INFM_PESCRMPES'
BANCODEDADOS IGERENCE
alter table INFM_PESSOACRMPESSOA
   add constraint FK_INFM_PESCRM_INFM_PESCRMPES foreign key (IDPESSOACRM)
      references INFM_PESSOACRM (IDPESSOACRM)