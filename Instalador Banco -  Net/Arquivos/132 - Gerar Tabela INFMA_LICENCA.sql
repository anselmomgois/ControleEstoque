QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFMA_LICENCA') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFMA_LICENCA (
   IDLICENCA            OBJETO_ID            not null,
   CODLICENCA           DESCRICAO200         not null,
   SESSOESINFINITAS     LOGICO               not null,
   NUMQUANTIDADESESSOES INTEIRO              not null,
   NUMVALIDADE          INTEIRO              null,
   VALIDADEINFINITA     LOGICO               not null,
   CHAVEATIVA           LOGICO               not null,
   NUMQUANTIDADEACESSOS INTEIRO              null,
   DATAATIVACAO         DATAHORA             null,
   constraint PK_INFMA_LICENCA primary key (IDLICENCA))