/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     16/03/2014 10:24:14                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFMA_EMPRESA') and o.name = 'FK_INFMA_EM_REFERENCE_INFMA_LI')
alter table INFMA_EMPRESA
   drop constraint FK_INFMA_EM_REFERENCE_INFMA_LI
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFMA_EMPRESA')
            and   type = 'U')
   drop table INFMA_EMPRESA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFMA_LICENCA')
            and   type = 'U')
   drop table INFMA_LICENCA
go

if exists(select 1 from systypes where name='BOLEANO')
   drop type BOLEANO
go

if exists(select 1 from systypes where name='CODIGO20')
   drop type CODIGO20
go

if exists(select 1 from systypes where name='DATAHORA')
   drop type DATAHORA
go

if exists(select 1 from systypes where name='DECIMAL1')
   drop type DECIMAL1
go

if exists(select 1 from systypes where name='DESCRICAO100')
   drop type DESCRICAO100
go

if exists(select 1 from systypes where name='DESCRICAO200')
   drop type DESCRICAO200
go

if exists(select 1 from systypes where name='DESCRICAO50')
   drop type DESCRICAO50
go

if exists(select 1 from systypes where name='DESCRICAO_CURTA')
   drop type DESCRICAO_CURTA
go

if exists(select 1 from systypes where name='INTEIRO')
   drop type INTEIRO
go

if exists(select 1 from systypes where name='INTEIROSEQ')
   drop type INTEIROSEQ
go

if exists(select 1 from systypes where name='LOGICO')
   drop type LOGICO
go

if exists(select 1 from systypes where name='NUMERO_DECIMAL')
   drop type NUMERO_DECIMAL
go

if exists(select 1 from systypes where name='OBJETOID')
   drop type OBJETOID
go

if exists(select 1 from systypes where name='OBJETO_ID')
   drop type OBJETO_ID
go

if exists(select 1 from systypes where name='OBJETO_IMAGEM')
   drop type OBJETO_IMAGEM
go

if exists(select 1 from systypes where name='OBSERVACAOLONGA')
   drop type OBSERVACAOLONGA
go

if exists(select 1 from systypes where name='OBSERVACAOMIN')
   drop type OBSERVACAOMIN
go

/*==============================================================*/
/* Domain: BOLEANO                                              */
/*==============================================================*/
create type BOLEANO
   from bit
go

/*==============================================================*/
/* Domain: CODIGO20                                             */
/*==============================================================*/
create type CODIGO20
   from varchar(20)
go

/*==============================================================*/
/* Domain: DATAHORA                                             */
/*==============================================================*/
create type DATAHORA
   from datetime
go

/*==============================================================*/
/* Domain: DECIMAL1                                             */
/*==============================================================*/
create type DECIMAL1
   from decimal(8,2)
go

/*==============================================================*/
/* Domain: DESCRICAO100                                         */
/*==============================================================*/
create type DESCRICAO100
   from varchar(100)
go

/*==============================================================*/
/* Domain: DESCRICAO200                                         */
/*==============================================================*/
create type DESCRICAO200
   from varchar(200)
go

/*==============================================================*/
/* Domain: DESCRICAO50                                          */
/*==============================================================*/
create type DESCRICAO50
   from varchar(50)
go

/*==============================================================*/
/* Domain: DESCRICAO_CURTA                                      */
/*==============================================================*/
create type DESCRICAO_CURTA
   from varchar(50)
go

/*==============================================================*/
/* Domain: INTEIRO                                              */
/*==============================================================*/
create type INTEIRO
   from integer
go

/*==============================================================*/
/* Domain: INTEIROSEQ                                           */
/*==============================================================*/
create type INTEIROSEQ
   from integer not null
go

/*==============================================================*/
/* Domain: LOGICO                                               */
/*==============================================================*/
create type LOGICO
   from bit
go

/*==============================================================*/
/* Domain: NUMERO_DECIMAL                                       */
/*==============================================================*/
create type NUMERO_DECIMAL
   from decimal(8,2)
go

/*==============================================================*/
/* Domain: OBJETOID                                             */
/*==============================================================*/
create type OBJETOID
   from varchar(36)
go

/*==============================================================*/
/* Domain: OBJETO_ID                                            */
/*==============================================================*/
create type OBJETO_ID
   from varchar(36)
go

/*==============================================================*/
/* Domain: OBJETO_IMAGEM                                        */
/*==============================================================*/
create type OBJETO_IMAGEM
   from image
go

/*==============================================================*/
/* Domain: OBSERVACAOLONGA                                      */
/*==============================================================*/
create type OBSERVACAOLONGA
   from varchar(Max)
go

/*==============================================================*/
/* Domain: OBSERVACAOMIN                                        */
/*==============================================================*/
create type OBSERVACAOMIN
   from varchar(500)
go

/*==============================================================*/
/* Table: INFMA_EMPRESA                                         */
/*==============================================================*/
create table INFMA_EMPRESA (
   IDEMPRESA            OBJETO_ID            not null,
   IDLICENCA            OBJETO_ID            null,
   CODEMPRESA           INTEIRO              not null,
   DESEMPRESA           DESCRICAO50          not null,
   constraint PK_INFMA_EMPRESA primary key (IDEMPRESA)
)
go

/*==============================================================*/
/* Table: INFMA_LICENCA                                         */
/*==============================================================*/
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
   constraint PK_INFMA_LICENCA primary key (IDLICENCA)
)
go

alter table INFMA_EMPRESA
   add constraint FK_INFMA_EM_REFERENCE_INFMA_LI foreign key (IDLICENCA)
      references INFMA_LICENCA (IDLICENCA)
go

