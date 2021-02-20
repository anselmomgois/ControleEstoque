QUERYVALIDACAO select 1 from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F') where r.fkeyid = object_id('INFM_PRODUTOCOMISSAO') and o.name = 'FK_FILIAL_PRODCOMIS'
BANCODEDADOS IGERENCE
alter table INFM_PRODUTOCOMISSAO
   add constraint FK_FILIAL_PRODCOMIS foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)