QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PESSOA') and o.name = 'FK_INFM_PES_REFERENCE_INFM_PES'
BANCODEDADOS INFORMATIZ
alter table INFM_PESSOA
   add constraint FK_INFM_PES_REFERENCE_INFM_PES foreign key (IDPESSOARESPONSAVEL)
      references INFM_PESSOA (IDPESSOA)