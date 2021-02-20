QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_LICENCA') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_LICENCA (
   IDLICENCA            OBJETO_ID            not null,
   CODLICENCA           DESCRICAO200         not null,
   SESSOESINFINITAS     LOGICO               not null,
   NUMQUANTIDADESESSOES INTEIRO              not null,
   NUMVALIDADE          INTEIRO              null,
   VALIDADEINFINITA     LOGICO               not null,
   CHAVEATIVA           LOGICO               not null,
   NUMQUANTIDADEACESSOS INTEIRO              null,
   DATAATIVACAO         DATAHORA             null,
   constraint PK_INFM_LICENCA primary key (IDLICENCA))