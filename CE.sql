/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     17/06/2014 20:51:56                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_ADMINISTRADORA') and o.name = 'FK_INFM_ADM_REFERENCE_INFM_EMP')
alter table INFM_ADMINISTRADORA
   drop constraint FK_INFM_ADM_REFERENCE_INFM_EMP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_BAIRRO') and o.name = 'FK_INFM_BAI_REFERENCE_INFM_CID')
alter table INFM_BAIRRO
   drop constraint FK_INFM_BAI_REFERENCE_INFM_CID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_CIDADE') and o.name = 'FK_INFM_CID_REFERENCE_INFM_EST')
alter table INFM_CIDADE
   drop constraint FK_INFM_CID_REFERENCE_INFM_EST
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_COR') and o.name = 'FK_INFM_COR_REFERENCE_INFM_EMP')
alter table INFM_COR
   drop constraint FK_INFM_COR_REFERENCE_INFM_EMP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_CRM') and o.name = 'FK_INFM_CRM_REFERENCE_INFM_EMP')
alter table INFM_CRM
   drop constraint FK_INFM_CRM_REFERENCE_INFM_EMP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_CRM') and o.name = 'FK_INFM_CRM_REFERENCE_INFM_GRU')
alter table INFM_CRM
   drop constraint FK_INFM_CRM_REFERENCE_INFM_GRU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_CRM') and o.name = 'FK_INFM_CRM_REF_INFM_PES2')
alter table INFM_CRM
   drop constraint FK_INFM_CRM_REF_INFM_PES2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_CRM') and o.name = 'FK_INFM_CRM_REFERENCE_INFM_PES')
alter table INFM_CRM
   drop constraint FK_INFM_CRM_REFERENCE_INFM_PES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_DATOSCOMPRAPROD') and o.name = 'FK_INFM_DAT_REFERENCE_INFM_PES')
alter table INFM_DATOSCOMPRAPROD
   drop constraint FK_INFM_DAT_REFERENCE_INFM_PES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_DATOSCOMPRAPROD') and o.name = 'FK_INFM_DAT_REFERENCE_INFM_UNI')
alter table INFM_DATOSCOMPRAPROD
   drop constraint FK_INFM_DAT_REFERENCE_INFM_UNI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_DATOSCOMPRAPROD') and o.name = 'FK_INFM_DAT_REFERENCE_INFM_PRO')
alter table INFM_DATOSCOMPRAPROD
   drop constraint FK_INFM_DAT_REFERENCE_INFM_PRO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_DOCUMENTO') and o.name = 'FK_INFM_DOC_REFERENCE_INFM_FIL')
alter table INFM_DOCUMENTO
   drop constraint FK_INFM_DOC_REFERENCE_INFM_FIL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_DOCUMENTO') and o.name = 'FK_INFM_DOC_REFERENCE_INFM_PES')
alter table INFM_DOCUMENTO
   drop constraint FK_INFM_DOC_REFERENCE_INFM_PES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_DOCUMENTO') and o.name = 'FK_INFM_DOC_REFERENCE_INFM_TIP')
alter table INFM_DOCUMENTO
   drop constraint FK_INFM_DOC_REFERENCE_INFM_TIP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_DOCUMENTO') and o.name = 'FK_INFM_DOC_REFERENCE_INFM_LOC')
alter table INFM_DOCUMENTO
   drop constraint FK_INFM_DOC_REFERENCE_INFM_LOC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_DOCUMENTO') and o.name = 'FK_INFM_DOC_REFERENCE_INFM_FOR')
alter table INFM_DOCUMENTO
   drop constraint FK_INFM_DOC_REFERENCE_INFM_FOR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_DOCUMENTO') and o.name = 'FK_INFM_DOC_REFERENCE_INFM_ADM')
alter table INFM_DOCUMENTO
   drop constraint FK_INFM_DOC_REFERENCE_INFM_ADM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_DOCUMENTO') and o.name = 'FK_INFM_DOC_REFERENCE_INFM_DOC')
alter table INFM_DOCUMENTO
   drop constraint FK_INFM_DOC_REFERENCE_INFM_DOC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_EMPRESA') and o.name = 'FK_INFM_EMP_REFERENCE_INFM_LIC')
alter table INFM_EMPRESA
   drop constraint FK_INFM_EMP_REFERENCE_INFM_LIC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_EMPRESA') and o.name = 'FK_INFM_EMP_REFERENCE_INFM_PUB')
alter table INFM_EMPRESA
   drop constraint FK_INFM_EMP_REFERENCE_INFM_PUB
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_EMPRESA') and o.name = 'FK_INFM_EMP_REFERENCE_INFM_PES')
alter table INFM_EMPRESA
   drop constraint FK_INFM_EMP_REFERENCE_INFM_PES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_ENDERECO') and o.name = 'FK_INFM_END_REFERENCE_INFM_BAI')
alter table INFM_ENDERECO
   drop constraint FK_INFM_END_REFERENCE_INFM_BAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_FILIAL') and o.name = 'FK_INFM_FIL_FK_PESSOA_INFM_PES1')
alter table INFM_FILIAL
   drop constraint FK_INFM_FIL_FK_PESSOA_INFM_PES1
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_FILIAL') and o.name = 'FK_INFM_FIL_REFERENCE_INFM_EMP')
alter table INFM_FILIAL
   drop constraint FK_INFM_FIL_REFERENCE_INFM_EMP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_FILIAL') and o.name = 'FK_INFM_FIL_REFERENCE_INFM_END')
alter table INFM_FILIAL
   drop constraint FK_INFM_FIL_REFERENCE_INFM_END
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_FILIALBAIRRO') and o.name = 'FK_INFM_FIL_FK_FILIAL_INFM_FIL1')
alter table INFM_FILIALBAIRRO
   drop constraint FK_INFM_FIL_FK_FILIAL_INFM_FIL1
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_FILIALBAIRRO') and o.name = 'FK_INFM_FIL_REFERENCE_INFM_BAI')
alter table INFM_FILIALBAIRRO
   drop constraint FK_INFM_FIL_REFERENCE_INFM_BAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_FILIALPESSOA') and o.name = 'FK_INFM_FIL_FK_FILIAL_INFM_FIL2')
alter table INFM_FILIALPESSOA
   drop constraint FK_INFM_FIL_FK_FILIAL_INFM_FIL2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_FILIALPESSOA') and o.name = 'FK_INFM_FIL_FK_PESSOA_INFM_PES')
alter table INFM_FILIALPESSOA
   drop constraint FK_INFM_FIL_FK_PESSOA_INFM_PES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_GRUPOCOMPROMISSO') and o.name = 'FK_INFM_GRU_REFERENCE_INFM_EMP')
alter table INFM_GRUPOCOMPROMISSO
   drop constraint FK_INFM_GRU_REFERENCE_INFM_EMP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_GRUPOCOMPROMISSOSUBGRUPO') and o.name = 'FK_INFM_GRU_REFERENCE_INFM_GRU')
alter table INFM_GRUPOCOMPROMISSOSUBGRUPO
   drop constraint FK_INFM_GRU_REFERENCE_INFM_GRU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_GRUPOCOMPROMISSOSUBGRUPO') and o.name = 'FK_INFM_GRU_REF_INFM_GRU_1')
alter table INFM_GRUPOCOMPROMISSOSUBGRUPO
   drop constraint FK_INFM_GRU_REF_INFM_GRU_1
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_GRUPOPERMISSAO') and o.name = 'FK_EMPRESA_GRUPOPERM')
alter table INFM_GRUPOPERMISSAO
   drop constraint FK_EMPRESA_GRUPOPERM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_GRUPOPERMISSAOACAO') and o.name = 'FK_INFM_GRUPOPER_GRUPOPA')
alter table INFM_GRUPOPERMISSAOACAO
   drop constraint FK_INFM_GRUPOPER_GRUPOPA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_GRUPOPERMISSAOACAO') and o.name = 'FK_INFM_GRU_REFERENCE_INFM_PER')
alter table INFM_GRUPOPERMISSAOACAO
   drop constraint FK_INFM_GRU_REFERENCE_INFM_PER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_GRUPOPERMISSAOACAO') and o.name = 'FK_INFM_GRU_REFERENCE_INFM_ACA')
alter table INFM_GRUPOPERMISSAOACAO
   drop constraint FK_INFM_GRU_REFERENCE_INFM_ACA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_GRUPOPRODUTO') and o.name = 'FK_EMPRESA_GRUPPROD')
alter table INFM_GRUPOPRODUTO
   drop constraint FK_EMPRESA_GRUPPROD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_GRUPOPRODUTOSUBGRUPO') and o.name = 'FK_INFM_GRUPROD_GRUPRODPROD')
alter table INFM_GRUPOPRODUTOSUBGRUPO
   drop constraint FK_INFM_GRUPROD_GRUPRODPROD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_GRUPOPRODUTOSUBGRUPO') and o.name = 'FK_INFM_GRUPROD_PROD2')
alter table INFM_GRUPOPRODUTOSUBGRUPO
   drop constraint FK_INFM_GRUPROD_PROD2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_HORATRABALHO') and o.name = 'FK_INFM_HOR_REFERENCE_INFM_PES')
alter table INFM_HORATRABALHO
   drop constraint FK_INFM_HOR_REFERENCE_INFM_PES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PARAMETROVALOR') and o.name = 'FK_INFM_PAR_REFERENCE_INFM_PAR')
alter table INFM_PARAMETROVALOR
   drop constraint FK_INFM_PAR_REFERENCE_INFM_PAR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PARAMETROVALOR') and o.name = 'FK_INFM_PAR_REFERENCE_INFM_FIL')
alter table INFM_PARAMETROVALOR
   drop constraint FK_INFM_PAR_REFERENCE_INFM_FIL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PARCELAMENTO') and o.name = 'FK_INFM_PAR_REFERENCE_INFM_DOC')
alter table INFM_PARCELAMENTO
   drop constraint FK_INFM_PAR_REFERENCE_INFM_DOC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PERMISSAOACAO') and o.name = 'FK_INFM_PER_REFERENCE_INFM_PER')
alter table INFM_PERMISSAOACAO
   drop constraint FK_INFM_PER_REFERENCE_INFM_PER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PERMISSAOACAO') and o.name = 'FK_INFM_PER_REFERENCE_INFM_ACA')
alter table INFM_PERMISSAOACAO
   drop constraint FK_INFM_PER_REFERENCE_INFM_ACA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PESSOA') and o.name = 'FK_INFM_PES_PK_ENDERE_INFM_END')
alter table INFM_PESSOA
   drop constraint FK_INFM_PES_PK_ENDERE_INFM_END
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PESSOA') and o.name = 'FK_INFM_PES_REFERENCE_INFM_SIT')
alter table INFM_PESSOA
   drop constraint FK_INFM_PES_REFERENCE_INFM_SIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PESSOA') and o.name = 'FK_INFM_PES_REFERENCE_INFM_PES')
alter table INFM_PESSOA
   drop constraint FK_INFM_PES_REFERENCE_INFM_PES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PESSOA') and o.name = 'FK_INFM_PES_REFERENCE_INFM_SEG')
alter table INFM_PESSOA
   drop constraint FK_INFM_PES_REFERENCE_INFM_SEG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PESSOA') and o.name = 'FK_INFM_PES_REFERENCE_INFM_END')
alter table INFM_PESSOA
   drop constraint FK_INFM_PES_REFERENCE_INFM_END
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PESSOA') and o.name = 'FK_INFM_PES_REFERENCE_INFM_EMP')
alter table INFM_PESSOA
   drop constraint FK_INFM_PES_REFERENCE_INFM_EMP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PESSOACRM') and o.name = 'FK_INFM_PES_REF_INFM_CRM3')
alter table INFM_PESSOACRM
   drop constraint FK_INFM_PES_REF_INFM_CRM3
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PESSOACRM') and o.name = 'FK_INFM_PES_REF_INFM_PES2')
alter table INFM_PESSOACRM
   drop constraint FK_INFM_PES_REF_INFM_PES2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODCATEGORIA') and o.name = 'FK_EMPRESA_PRODCAT')
alter table INFM_PRODCATEGORIA
   drop constraint FK_EMPRESA_PRODCAT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOCFOP') and o.name = 'FKEMPRESAPRODCFOP')
alter table INFM_PRODUTOCFOP
   drop constraint FKEMPRESAPRODCFOP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOCOMISSAO') and o.name = 'FK_FILIAL_PRODCOMIS')
alter table INFM_PRODUTOCOMISSAO
   drop constraint FK_FILIAL_PRODCOMIS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOCST') and o.name = 'FKEMPESAPRODCST')
alter table INFM_PRODUTOCST
   drop constraint FKEMPESAPRODCST
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTODERIVACAO') and o.name = 'FK_EMPRESA_PRODDER')
alter table INFM_PRODUTODERIVACAO
   drop constraint FK_EMPRESA_PRODDER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOFILIAL') and o.name = 'FKUNIDADEMEDPRODFIL1')
alter table INFM_PRODUTOFILIAL
   drop constraint FKUNIDADEMEDPRODFIL1
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOFILIAL') and o.name = 'FKUNIDADEMEDPRODFIL2')
alter table INFM_PRODUTOFILIAL
   drop constraint FKUNIDADEMEDPRODFIL2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOFILIAL') and o.name = 'FK_FILIAL_PRDFIL')
alter table INFM_PRODUTOFILIAL
   drop constraint FK_FILIAL_PRDFIL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOFILIAL') and o.name = 'FK_INFM_PRO_FK_PRODCO_INFM_PRO')
alter table INFM_PRODUTOFILIAL
   drop constraint FK_INFM_PRO_FK_PRODCO_INFM_PRO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOFILIAL') and o.name = 'FK_INFM_PRO_FK_PRODSE_INFM_PRO')
alter table INFM_PRODUTOFILIAL
   drop constraint FK_INFM_PRO_FK_PRODSE_INFM_PRO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOMARCA') and o.name = 'FK_EMPRESA_PRDMARC')
alter table INFM_PRODUTOMARCA
   drop constraint FK_EMPRESA_PRDMARC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTONCM') and o.name = 'FK_INFM_PRO_REFERENCE_INFM_EMP')
alter table INFM_PRODUTONCM
   drop constraint FK_INFM_PRO_REFERENCE_INFM_EMP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOPROMOCAOPRODF') and o.name = 'FKPRODFILIALPRODPROMPROD')
alter table INFM_PRODUTOPROMOCAOPRODF
   drop constraint FKPRODFILIALPRODPROMPROD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOPROMOCAOPRODF') and o.name = 'FKPRODPROMOCAOPROD')
alter table INFM_PRODUTOPROMOCAOPRODF
   drop constraint FKPRODPROMOCAOPROD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOPROMOCAOPRODF') and o.name = 'FK_INFM_PRO_REFERENCE_INFM_DAT')
alter table INFM_PRODUTOPROMOCAOPRODF
   drop constraint FK_INFM_PRO_REFERENCE_INFM_DAT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOPROMOCAOPRODF') and o.name = 'FK_INFM_PRO_REFERENCE_INFM_PRO')
alter table INFM_PRODUTOPROMOCAOPRODF
   drop constraint FK_INFM_PRO_REFERENCE_INFM_PRO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FKPRODCSTPRODSERVICO')
alter table INFM_PRODUTOSERVICO
   drop constraint FKPRODCSTPRODSERVICO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FK_INFM_PRO_FKPRODNCM_INFM_PRO')
alter table INFM_PRODUTOSERVICO
   drop constraint FK_INFM_PRO_FKPRODNCM_INFM_PRO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FKPRODUTOCFOPPRODSERV')
alter table INFM_PRODUTOSERVICO
   drop constraint FKPRODUTOCFOPPRODSERV
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FK_EMPRESA_PRODEMP')
alter table INFM_PRODUTOSERVICO
   drop constraint FK_EMPRESA_PRODEMP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FK_INFM_PRO_FK_PRODCA_INFM_PRO')
alter table INFM_PRODUTOSERVICO
   drop constraint FK_INFM_PRO_FK_PRODCA_INFM_PRO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FK_INFM_PRO_FK_PRODDE_INFM_PRO')
alter table INFM_PRODUTOSERVICO
   drop constraint FK_INFM_PRO_FK_PRODDE_INFM_PRO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FK_INFM_PRO_FK_PRODMA_INFM_PRO')
alter table INFM_PRODUTOSERVICO
   drop constraint FK_INFM_PRO_FK_PRODMA_INFM_PRO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FK_INFM_PRO_REFERENCE_INFM_TIP')
alter table INFM_PRODUTOSERVICO
   drop constraint FK_INFM_PRO_REFERENCE_INFM_TIP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FK_INFM_PRO_REFERENCE_INFM_GRU')
alter table INFM_PRODUTOSERVICO
   drop constraint FK_INFM_PRO_REFERENCE_INFM_GRU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_PRODUTOSERVICO') and o.name = 'FK_INFM_PRO_REFERENCE_INFM_COR')
alter table INFM_PRODUTOSERVICO
   drop constraint FK_INFM_PRO_REFERENCE_INFM_COR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_SALDOFILIAL') and o.name = 'FK_INFM_SAL_REFERENCE_INFM_FIL')
alter table INFM_SALDOFILIAL
   drop constraint FK_INFM_SAL_REFERENCE_INFM_FIL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_SALDOPESSOA') and o.name = 'FK_INFM_SAL_REFERENCE_INFM_DOC')
alter table INFM_SALDOPESSOA
   drop constraint FK_INFM_SAL_REFERENCE_INFM_DOC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_SALDOPESSOA') and o.name = 'FK_INFM_SAL_REFERENCE_INFM_PES')
alter table INFM_SALDOPESSOA
   drop constraint FK_INFM_SAL_REFERENCE_INFM_PES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_SEGMENTOCOMERCIAL') and o.name = 'FK_INFM_SEG_REFERENCE_INFM_EMP')
alter table INFM_SEGMENTOCOMERCIAL
   drop constraint FK_INFM_SEG_REFERENCE_INFM_EMP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_SESSAO') and o.name = 'FK_INFM_SES_REFERENCE_INFM_PES')
alter table INFM_SESSAO
   drop constraint FK_INFM_SES_REFERENCE_INFM_PES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_SESSAO') and o.name = 'FK_INFM_SES_REFERENCE_INFM_FIL')
alter table INFM_SESSAO
   drop constraint FK_INFM_SES_REFERENCE_INFM_FIL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_TIPOPESSOA_PESSOA') and o.name = 'FK_INFM_TIP_REFERENCE_INFM_TIP')
alter table INFM_TIPOPESSOA_PESSOA
   drop constraint FK_INFM_TIP_REFERENCE_INFM_TIP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_TIPOPESSOA_PESSOA') and o.name = 'FK_INFM_TIP_REFERENCE_INFM_PES')
alter table INFM_TIPOPESSOA_PESSOA
   drop constraint FK_INFM_TIP_REFERENCE_INFM_PES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_TRANSACOES') and o.name = 'FK_INFM_TRA_REFERENCE_INFM_DOC')
alter table INFM_TRANSACOES
   drop constraint FK_INFM_TRA_REFERENCE_INFM_DOC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_TRANSACOES') and o.name = 'FK_INFM_TRA_REFERENCE_INFM_PAR')
alter table INFM_TRANSACOES
   drop constraint FK_INFM_TRA_REFERENCE_INFM_PAR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_UNIDADEMEDIDA') and o.name = 'FKUNIDADMEDPROD')
alter table INFM_UNIDADEMEDIDA
   drop constraint FKUNIDADMEDPROD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_UNIDADEMEDIDA') and o.name = 'FK_INFM_UNI_REFERENCE_INFM_EMP')
alter table INFM_UNIDADEMEDIDA
   drop constraint FK_INFM_UNI_REFERENCE_INFM_EMP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_UNIDADEMEDPRODUTO') and o.name = 'FK_INFM_UNI_FKUNIDADE_INFM_UNI')
alter table INFM_UNIDADEMEDPRODUTO
   drop constraint FK_INFM_UNI_FKUNIDADE_INFM_UNI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_UNIDADEMEDPRODUTO') and o.name = 'FK_INFM_UNI_REFERENCE_INFM_PRO')
alter table INFM_UNIDADEMEDPRODUTO
   drop constraint FK_INFM_UNI_REFERENCE_INFM_PRO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_USUPERMISSAOACAO') and o.name = 'FK_INFM_USU_REFERENCE_INFM_PER')
alter table INFM_USUPERMISSAOACAO
   drop constraint FK_INFM_USU_REFERENCE_INFM_PER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_USUPERMISSAOACAO') and o.name = 'FK_INFM_USU_REFERENCE_INFM_ACA')
alter table INFM_USUPERMISSAOACAO
   drop constraint FK_INFM_USU_REFERENCE_INFM_ACA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_USUPERMISSAOACAO') and o.name = 'FK_INFM_USU_REFERENCE_INFM_PES')
alter table INFM_USUPERMISSAOACAO
   drop constraint FK_INFM_USU_REFERENCE_INFM_PES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFM_USUPERMISSAOACAO') and o.name = 'FK_INFM_USU_REFERENCE_INFM_GRU')
alter table INFM_USUPERMISSAOACAO
   drop constraint FK_INFM_USU_REFERENCE_INFM_GRU
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_ACAO')
            and   type = 'U')
   drop table INFM_ACAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_ADMINISTRADORA')
            and   type = 'U')
   drop table INFM_ADMINISTRADORA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_BAIRRO')
            and   type = 'U')
   drop table INFM_BAIRRO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_CIDADE')
            and   type = 'U')
   drop table INFM_CIDADE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_COR')
            and   type = 'U')
   drop table INFM_COR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_CRM')
            and   type = 'U')
   drop table INFM_CRM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_DATOSCOMPRAPROD')
            and   type = 'U')
   drop table INFM_DATOSCOMPRAPROD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_DOCUMENTO')
            and   type = 'U')
   drop table INFM_DOCUMENTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_EMPRESA')
            and   type = 'U')
   drop table INFM_EMPRESA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_ENDERECO')
            and   type = 'U')
   drop table INFM_ENDERECO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_ESTADO')
            and   type = 'U')
   drop table INFM_ESTADO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_FILIAL')
            and   type = 'U')
   drop table INFM_FILIAL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_FILIALBAIRRO')
            and   type = 'U')
   drop table INFM_FILIALBAIRRO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_FILIALPESSOA')
            and   type = 'U')
   drop table INFM_FILIALPESSOA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_FORMAPAGAMENTO')
            and   type = 'U')
   drop table INFM_FORMAPAGAMENTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_GRUPOCOMPROMISSO')
            and   type = 'U')
   drop table INFM_GRUPOCOMPROMISSO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_GRUPOCOMPROMISSOSUBGRUPO')
            and   type = 'U')
   drop table INFM_GRUPOCOMPROMISSOSUBGRUPO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_GRUPOPERMISSAO')
            and   type = 'U')
   drop table INFM_GRUPOPERMISSAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_GRUPOPERMISSAOACAO')
            and   type = 'U')
   drop table INFM_GRUPOPERMISSAOACAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_GRUPOPRODUTO')
            and   type = 'U')
   drop table INFM_GRUPOPRODUTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_GRUPOPRODUTOSUBGRUPO')
            and   type = 'U')
   drop table INFM_GRUPOPRODUTOSUBGRUPO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_HORATRABALHO')
            and   type = 'U')
   drop table INFM_HORATRABALHO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_LICENCA')
            and   type = 'U')
   drop table INFM_LICENCA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_LOCALDOCUMENTO')
            and   type = 'U')
   drop table INFM_LOCALDOCUMENTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_LOGERROR')
            and   type = 'U')
   drop table INFM_LOGERROR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PARAMETROS')
            and   type = 'U')
   drop table INFM_PARAMETROS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PARAMETROVALOR')
            and   type = 'U')
   drop table INFM_PARAMETROVALOR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PARCELAMENTO')
            and   type = 'U')
   drop table INFM_PARCELAMENTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PERMISSAO')
            and   type = 'U')
   drop table INFM_PERMISSAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PERMISSAOACAO')
            and   type = 'U')
   drop table INFM_PERMISSAOACAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PESSOA')
            and   type = 'U')
   drop table INFM_PESSOA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PESSOACRM')
            and   type = 'U')
   drop table INFM_PESSOACRM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PRODCATEGORIA')
            and   type = 'U')
   drop table INFM_PRODCATEGORIA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PRODUTOCFOP')
            and   type = 'U')
   drop table INFM_PRODUTOCFOP
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PRODUTOCOMISSAO')
            and   type = 'U')
   drop table INFM_PRODUTOCOMISSAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PRODUTOCST')
            and   type = 'U')
   drop table INFM_PRODUTOCST
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PRODUTODERIVACAO')
            and   type = 'U')
   drop table INFM_PRODUTODERIVACAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PRODUTOFILIAL')
            and   type = 'U')
   drop table INFM_PRODUTOFILIAL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PRODUTOMARCA')
            and   type = 'U')
   drop table INFM_PRODUTOMARCA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PRODUTONCM')
            and   type = 'U')
   drop table INFM_PRODUTONCM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PRODUTOPROMOCAO')
            and   type = 'U')
   drop table INFM_PRODUTOPROMOCAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PRODUTOPROMOCAOPRODF')
            and   type = 'U')
   drop table INFM_PRODUTOPROMOCAOPRODF
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PRODUTOSERVICO')
            and   type = 'U')
   drop table INFM_PRODUTOSERVICO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_PUBLICIDADE')
            and   type = 'U')
   drop table INFM_PUBLICIDADE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_SALDOFILIAL')
            and   type = 'U')
   drop table INFM_SALDOFILIAL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_SALDOPESSOA')
            and   type = 'U')
   drop table INFM_SALDOPESSOA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_SEGMENTOCOMERCIAL')
            and   type = 'U')
   drop table INFM_SEGMENTOCOMERCIAL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_SESSAO')
            and   type = 'U')
   drop table INFM_SESSAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_SITUACAO_PESSOA')
            and   type = 'U')
   drop table INFM_SITUACAO_PESSOA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_TIPODOCUMENTO')
            and   type = 'U')
   drop table INFM_TIPODOCUMENTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_TIPOPESSOA')
            and   type = 'U')
   drop table INFM_TIPOPESSOA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_TIPOPESSOA_PESSOA')
            and   type = 'U')
   drop table INFM_TIPOPESSOA_PESSOA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_TIPOPRODUTO')
            and   type = 'U')
   drop table INFM_TIPOPRODUTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_TRANSACOES')
            and   type = 'U')
   drop table INFM_TRANSACOES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_UNIDADEMEDIDA')
            and   type = 'U')
   drop table INFM_UNIDADEMEDIDA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_UNIDADEMEDPRODUTO')
            and   type = 'U')
   drop table INFM_UNIDADEMEDPRODUTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFM_USUPERMISSAOACAO')
            and   type = 'U')
   drop table INFM_USUPERMISSAOACAO
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

if exists(select 1 from systypes where name='IMAGEM')
   drop type IMAGEM
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
/* Domain: IMAGEM                                               */
/*==============================================================*/
create type IMAGEM
   from image
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
/* Table: INFM_ACAO                                             */
/*==============================================================*/
create table INFM_ACAO (
   IDACAO               OBJETOID             not null,
   CODACAO              CODIGO20             not null,
   DESACAO              DESCRICAO50          not null,
   constraint PK_INFM_ACAO primary key (IDACAO)
)
go

/*==============================================================*/
/* Table: INFM_ADMINISTRADORA                                   */
/*==============================================================*/
create table INFM_ADMINISTRADORA (
   IDADMINISTRADORA     OBJETO_ID            not null,
   IDEMPRESA            OBJETOID             not null,
   CODADMINISTRADORA    INTEIROSEQ           identity,
   DESADMINISTRADORA    DESCRICAO50          not null,
   DESTELADMINISTRADORA DESCRICAO50          null,
   OBSREFADMINISTRADORA OBSERVACAOLONGA      null,
   NUMTARIFAPERCENT     DECIMAL1             null,
   NUMTARIFAVALOR       DECIMAL1             null,
   NUMTARIFAANTPERCENT  DECIMAL1             null,
   NUMTARIFAANTVALOR    DECIMAL1             null,
   NUMDESCONTPERCENT    DECIMAL1             null,
   NUMDESCONTVALOR      DECIMAL1             null,
   BITIMGADMINISTRADORA IMAGEM               null,
   constraint PK_INFM_ADMINISTRADORA primary key (IDADMINISTRADORA)
)
go

/*==============================================================*/
/* Table: INFM_BAIRRO                                           */
/*==============================================================*/
create table INFM_BAIRRO (
   IDBAIRRO             OBJETOID             not null,
   IDCIDADE             OBJETO_ID            null,
   DESBAIRRO            DESCRICAO50          not null,
   CODBAIRRO            INTEIROSEQ           identity,
   constraint PK_INFM_BAIRRO primary key (IDBAIRRO)
)
go

/*==============================================================*/
/* Table: INFM_CIDADE                                           */
/*==============================================================*/
create table INFM_CIDADE (
   IDCIDADE             OBJETO_ID            not null,
   IDESTADO             OBJETOID             null,
   DESCIDADE            DESCRICAO50          not null,
   CODCIDADE            INTEIROSEQ           identity,
   CODDDD               CODIGO20             null,
   CODIBGE              CODIGO20             null,
   constraint PK_INFM_CIDADE primary key (IDCIDADE)
)
go

/*==============================================================*/
/* Table: INFM_COR                                              */
/*==============================================================*/
create table INFM_COR (
   IDCOR                OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODCOR               INTEIROSEQ           identity,
   CODCORRGB            DESCRICAO50          not null,
   DESCOR               DESCRICAO50          not null,
   constraint PK_INFM_COR primary key (IDCOR)
)
go

/*==============================================================*/
/* Table: INFM_CRM                                              */
/*==============================================================*/
create table INFM_CRM (
   IDCRM                OBJETO_ID            not null,
   IDEMPRESA            OBJETOID             null,
   IDGRUPOCOMPROMISSO   OBJETO_ID            null,
   IDPESSOACADASTRO     OBJETOID             null,
   IDPESSOACLIENTE      OBJETOID             null,
   CODCRM               INTEIROSEQ           identity,
   OBSCOMPROMISSO       OBSERVACAOLONGA      not null,
   constraint PK_INFM_CRM primary key (IDCRM)
)
go

/*==============================================================*/
/* Table: INFM_DATOSCOMPRAPROD                                  */
/*==============================================================*/
create table INFM_DATOSCOMPRAPROD (
   IDDATOSCOMPRAPROD    OBJETOID             not null,
   IDPESSOA             OBJETOID             null,
   IDUNIDADEMEDIDA      OBJETOID             null,
   IDPRODUTOFILIAL      OBJETOID             null,
   DTHCOMPRA            DATAHORA             not null,
   NUMUNIDADECOMPRA     DECIMAL1             not null,
   NUMUNIDADEVENDA      DECIMAL1             null,
   NUMVALORCOMPRA       NUMERO_DECIMAL       not null,
   NUMVENDA1            NUMERO_DECIMAL       null,
   NUMVENDA2            NUMERO_DECIMAL       null,
   NUMVENDA3            NUMERO_DECIMAL       null,
   NUMESTOQUE           DECIMAL1             not null,
   constraint PK_INFM_DATOSCOMPRAPROD primary key (IDDATOSCOMPRAPROD)
)
go

/*==============================================================*/
/* Table: INFM_DOCUMENTO                                        */
/*==============================================================*/
create table INFM_DOCUMENTO (
   IDDOCUMENTO          OBJETO_ID            not null,
   IDFILIAL             OBJETOID             not null,
   IDPESSOA             OBJETOID             null,
   IDTIPODOCUMENTO      OBJETO_ID            null,
   IDLOCALDOCUMENTO     OBJETO_ID            null,
   IDFORMAPAGAMENTO     OBJETO_ID            null,
   IDADMINISTRADORA     OBJETO_ID            null,
   IDDOCUMENTOPAI       OBJETO_ID            null,
   CODTRANSACAO         DESCRICAO100         not null,
   DESNUMBOLETOBANCARIO DESCRICAO200         null,
   DTHEMISSAO           DATAHORA             not null,
   DTHVENCORIGINAL      DATAHORA             not null,
   DTHVENCATUAL         DATAHORA             not null,
   NUMVALORORIGINAL     NUMERO_DECIMAL       not null,
   BOLPARCELADO         LOGICO               not null,
   OBSDOCUMENTO         OBSERVACAOLONGA      null,
   constraint PK_INFM_DOCUMENTO primary key (IDDOCUMENTO)
)
go

/*==============================================================*/
/* Table: INFM_EMPRESA                                          */
/*==============================================================*/
create table INFM_EMPRESA (
   IDEMPRESA            OBJETOID             not null,
   IDLICENCA            OBJETO_ID            null,
   IDPUBLICIDADE        OBJETO_ID            null,
   IDPESSOA             OBJETOID             null,
   CODEMPRESA           INTEIROSEQ           identity,
   DESEMPRESA           DESCRICAO50          not null,
   DESCNPJ              DESCRICAO50          null,
   DESINSCRICAOESTADUAL DESCRICAO50          null,
   CODACESSO            CODIGO20             not null,
   CODLICENCA           DESCRICAO200         null,
   NUMQUANTIDADESESSOES INTEIRO              null,
   NUMQUANTIDADEACESSADA INTEIRO              null,
   NUMQUANTIDADEACESSO  INTEIRO              null,
   SESSOSILIMITADAS     LOGICO               null,
   VALIDADEILIMITADA    LOGICO               null,
   BOLEMPRESAMESTE      BOLEANO              null,
   DESAMIGO             DESCRICAO100         null,
   constraint PK_INFM_EMPRESA primary key (IDEMPRESA)
)
go

/*==============================================================*/
/* Table: INFM_ENDERECO                                         */
/*==============================================================*/
create table INFM_ENDERECO (
   IDENDERECO           OBJETOID             not null,
   IDBAIRRO             OBJETOID             null,
   CODENDERECO          INTEIROSEQ           identity,
   DESRUA               DESCRICAO200         not null,
   CODCEP               CODIGO20             null,
   constraint PK_INFM_ENDERECO primary key (IDENDERECO)
)
go

/*==============================================================*/
/* Table: INFM_ESTADO                                           */
/*==============================================================*/
create table INFM_ESTADO (
   IDESTADO             OBJETOID             not null,
   CODESTADO            CODIGO20             not null,
   DESESTADO            DESCRICAO50          not null,
   NUMICMS              NUMERO_DECIMAL       null,
   CODIBGE              CODIGO20             null,
   constraint PK_INFM_ESTADO primary key (IDESTADO)
)
go

/*==============================================================*/
/* Table: INFM_FILIAL                                           */
/*==============================================================*/
create table INFM_FILIAL (
   IDFILIAL             OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   IDENDERECO           OBJETOID             null,
   IDPESSOA             OBJETOID             null,
   CODFILIAL            INTEIROSEQ           identity,
   DESFILIAL            DESCRICAO50          not null,
   BOLMATRIZ            LOGICO               not null,
   NUMENDERECO          INTEIRO              null,
   DESCOMPENDERECO      DESCRICAO200         null,
   DESPONTREFENDERECO   DESCRICAO200         null,
   DTHABERTURA          DATAHORA             null,
   DESTELEFONEFIXO      DESCRICAO50          null,
   DESTELEFONEFAX       DESCRICAO50          null,
   DESTELEFONECEL       DESCRICAO50          null,
   OBSFILIAL            OBSERVACAOMIN        null,
   DESEMAIL             DESCRICAO100         null,
   NUMPISPER            NUMERO_DECIMAL       null,
   NUMCONFINSPER        NUMERO_DECIMAL       null,
   NUMOUTDESPPER        NUMERO_DECIMAL       null,
   NUMCONTSOCPER        NUMERO_DECIMAL       null,
   CODTABMERCADORIA     INTEIRO              null,
   BOLATIVA             LOGICO               not null,
   constraint PK_INFM_FILIAL primary key (IDFILIAL)
)
go

/*==============================================================*/
/* Table: INFM_FILIALBAIRRO                                     */
/*==============================================================*/
create table INFM_FILIALBAIRRO (
   IDFILIALBAIRRO       OBJETOID             not null,
   IDFILIAL             OBJETOID             null,
   IDBAIRRO             OBJETOID             null,
   constraint PK_INFM_FILIALBAIRRO primary key (IDFILIALBAIRRO)
)
go

/*==============================================================*/
/* Table: INFM_FILIALPESSOA                                     */
/*==============================================================*/
create table INFM_FILIALPESSOA (
   IDFILIALPESSOA       OBJETOID             not null,
   IDFILIAL             OBJETOID             null,
   IDPESSOA             OBJETOID             null,
   constraint PK_INFM_FILIALPESSOA primary key (IDFILIALPESSOA)
)
go

/*==============================================================*/
/* Table: INFM_FORMAPAGAMENTO                                   */
/*==============================================================*/
create table INFM_FORMAPAGAMENTO (
   IDFORMAPAGAMENTO     OBJETO_ID            not null,
   DESFORMAPAGAMENTO    DESCRICAO50          not null,
   CODFORMAPAGAMENTO    CODIGO20             not null,
   constraint PK_INFM_FORMAPAGAMENTO primary key (IDFORMAPAGAMENTO)
)
go

/*==============================================================*/
/* Table: INFM_GRUPOCOMPROMISSO                                 */
/*==============================================================*/
create table INFM_GRUPOCOMPROMISSO (
   IDGRUPOCOMPROMISSO   OBJETO_ID            not null,
   CODGRUPOCOMPROMISSO  INTEIROSEQ           identity,
   DESGRUPOCOMPROMISSO  DESCRICAO50          not null,
   IDEMPRESA            OBJETOID             null,
   constraint PK_INFM_GRUPOCOMPROMISSO primary key (IDGRUPOCOMPROMISSO)
)
go

/*==============================================================*/
/* Table: INFM_GRUPOCOMPROMISSOSUBGRUPO                         */
/*==============================================================*/
create table INFM_GRUPOCOMPROMISSOSUBGRUPO (
   IDGRUPOCOMPROMISSOSUBGRUPO OBJETO_ID            not null,
   IDGRUPOCOMPROMISSOPAI OBJETO_ID            null,
   IDGRUPOCOMPROMISSO   OBJETO_ID            null,
   constraint PK_INFM_GRUPOCOMPROMISSOSUBGRU primary key (IDGRUPOCOMPROMISSOSUBGRUPO)
)
go

/*==============================================================*/
/* Table: INFM_GRUPOPERMISSAO                                   */
/*==============================================================*/
create table INFM_GRUPOPERMISSAO (
   IDGRUPOPERMISSAO     OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   DESGRUPO             DESCRICAO50          not null,
   constraint PK_INFM_GRUPOPERMISSAO primary key (IDGRUPOPERMISSAO)
)
go

/*==============================================================*/
/* Table: INFM_GRUPOPERMISSAOACAO                               */
/*==============================================================*/
create table INFM_GRUPOPERMISSAOACAO (
   IDGRUPOPERMISSAOACAO OBJETOID             not null,
   IDPERMISSAO          OBJETOID             null,
   IDACAO               OBJETOID             null,
   IDGRUPOPERMISSAO     OBJETOID             null,
   constraint PK_INFM_GRUPOPERMISSAOACAO primary key (IDGRUPOPERMISSAOACAO)
)
go

/*==============================================================*/
/* Table: INFM_GRUPOPRODUTO                                     */
/*==============================================================*/
create table INFM_GRUPOPRODUTO (
   IDGRUPOPRODUTO       OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODGRUPOPRODUTO      INTEIROSEQ           identity,
   DESGRUPOPRODUTO      DESCRICAO50          not null,
   constraint PK_INFM_GRUPOPRODUTO primary key (IDGRUPOPRODUTO)
)
go

/*==============================================================*/
/* Table: INFM_GRUPOPRODUTOSUBGRUPO                             */
/*==============================================================*/
create table INFM_GRUPOPRODUTOSUBGRUPO (
   IDGRUPOPRODUTOSUBGRUPO OBJETOID             not null,
   IDGRUPOPRODUTOPAI    OBJETOID             not null,
   IDGRUPOPRODUTO       OBJETOID             not null,
   constraint PK_INFM_GRUPOPRODUTOSUBGRUPO primary key (IDGRUPOPRODUTOSUBGRUPO)
)
go

/*==============================================================*/
/* Table: INFM_HORATRABALHO                                     */
/*==============================================================*/
create table INFM_HORATRABALHO (
   IDHORATRABALHO       OBJETOID             not null,
   IDPESSOA             OBJETOID             null,
   CODDIASEMANA         INTEIRO              not null,
   DTHINICIO            CODIGO20             not null,
   DTHFIM               CODIGO20             not null,
   constraint PK_INFM_HORATRABALHO primary key (IDHORATRABALHO)
)
go

/*==============================================================*/
/* Table: INFM_LICENCA                                          */
/*==============================================================*/
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
   constraint PK_INFM_LICENCA primary key (IDLICENCA)
)
go

/*==============================================================*/
/* Table: INFM_LOCALDOCUMENTO                                   */
/*==============================================================*/
create table INFM_LOCALDOCUMENTO (
   IDLOCALDOCUMENTO     OBJETO_ID            not null,
   CODLOCALDOCUMENTO    CODIGO20             not null,
   DESLOCALDOCUMENTO    DESCRICAO50          not null,
   constraint PK_INFM_LOCALDOCUMENTO primary key (IDLOCALDOCUMENTO)
)
go

/*==============================================================*/
/* Table: INFM_LOGERROR                                         */
/*==============================================================*/
create table INFM_LOGERROR (
   IDLOGERROR           OBJETOID             not null,
   DESERROR             OBSERVACAOLONGA      not null,
   DESPESSOA            DESCRICAO50          null,
   DTHERROR             DATAHORA             not null,
   constraint PK_INFM_LOGERROR primary key (IDLOGERROR)
)
go

/*==============================================================*/
/* Table: INFM_PARAMETROS                                       */
/*==============================================================*/
create table INFM_PARAMETROS (
   IDPARAMETRO          OBJETOID             not null,
   CODPARAMETRO         DESCRICAO50          not null,
   DESPARAMETRO         DESCRICAO100         not null,
   TIPOCOMPONENTE       INTEIRO              not null,
   BOLNIVELFILIAL       LOGICO               not null,
   constraint PK_INFM_PARAMETROS primary key (IDPARAMETRO)
)
go

/*==============================================================*/
/* Table: INFM_PARAMETROVALOR                                   */
/*==============================================================*/
create table INFM_PARAMETROVALOR (
   IDPARAMETROVALOR     OBJETO_ID            not null,
   IDPARAMETRO          OBJETOID             null,
   IDFILIAL             OBJETOID             null,
   DESVALORPARAMETRO    DESCRICAO200         null,
   constraint PK_INFM_PARAMETROVALOR primary key (IDPARAMETROVALOR)
)
go

/*==============================================================*/
/* Table: INFM_PARCELAMENTO                                     */
/*==============================================================*/
create table INFM_PARCELAMENTO (
   IDPARCELAMENTO       OBJETO_ID            not null,
   IDDOCUMENTO          OBJETO_ID            null,
   DTHVENCATUAL         DATAHORA             not null,
   DTHVENCORIGINAL      DATAHORA             not null,
   NUMVALORORIGINAL     DECIMAL1             not null,
   NUMPARCELA           INTEIRO              not null,
   constraint PK_INFM_PARCELAMENTO primary key (IDPARCELAMENTO)
)
go

/*==============================================================*/
/* Table: INFM_PERMISSAO                                        */
/*==============================================================*/
create table INFM_PERMISSAO (
   IDPERMISSAO          OBJETOID             not null,
   CODPERMISSAO         CODIGO20             not null,
   DESPERMISSAO         DESCRICAO100         not null,
   BOLOBRIGATORIA       BOLEANO              not null,
   constraint PK_INFM_PERMISSAO primary key (IDPERMISSAO)
)
go

/*==============================================================*/
/* Table: INFM_PERMISSAOACAO                                    */
/*==============================================================*/
create table INFM_PERMISSAOACAO (
   IDPERMISSAOACAO      OBJETOID             not null,
   IDPERMISSAO          OBJETOID             null,
   IDACAO               OBJETOID             null,
   constraint PK_INFM_PERMISSAOACAO primary key (IDPERMISSAOACAO)
)
go

/*==============================================================*/
/* Table: INFM_PESSOA                                           */
/*==============================================================*/
create table INFM_PESSOA (
   IDENDERECO           OBJETOID             null,
   IDPESSOA             OBJETOID             not null,
   IDSITUACAOPESSOA     OBJETOID             null,
   IDPESSOARESPONSAVEL  OBJETOID             null,
   IDSEGMENTOCOMERCIAL  OBJETOID             null,
   IDENDERECOEMPRESA    OBJETOID             null,
   IDEMPRESA            OBJETOID             null,
   CODPESSOA            INTEIROSEQ           identity,
   DESNOME              DESCRICAO100         not null,
   DESNOMEFANTASIA      DESCRICAO100         null,
   DESRG                DESCRICAO50          null,
   DTHNASCIMENTO        DATAHORA             null,
   DESCPF               DESCRICAO50          null,
   DESCNPJ              DESCRICAO50          null,
   DTHCADASTRO          DATAHORA             null,
   DESINSCRICAOESTADUAL DESCRICAO50          null,
   DESTELEFONEFIXO      DESCRICAO50          null,
   DESTELEFONEFAX       DESCRICAO50          null,
   DESTELEFONECELULAR   DESCRICAO50          null,
   DESHABILITACAO       DESCRICAO50          null,
   NUMCOMISSAO          NUMERO_DECIMAL       null,
   NUMSALARIO           NUMERO_DECIMAL       null,
   DTHADMISSAO          DATAHORA             null,
   DESCONTATO           DESCRICAO100         null,
   OBSPESSOA            OBSERVACAOMIN        null,
   NUMLIMITE            NUMERO_DECIMAL       null,
   DESEMAIL             DESCRICAO100         null,
   DESNOMEPAI           DESCRICAO100         null,
   DESNOMEMAE           DESCRICAO100         null,
   DESEMPRESA           DESCRICAO100         null,
   DESFONEEMPRESA       DESCRICAO50          null,
   DESCARGO             DESCRICAO50          null,
   OBSREFPESSOAL        OBSERVACAOMIN        null,
   DTHALMOCOINICIO      CODIGO20             null,
   DTHALMOCOFIM         CODIGO20             null,
   CODLOGIN             CODIGO20             null,
   DESSENHA             DESCRICAO200         null,
   CODTABMERCADORIA     INTEIRO              null,
   BOLALTERARSENHA      LOGICO               not null,
   BOLFUNICIONARIOATIVO LOGICO               null,
   BOLFORNECEDORATIVO   LOGICO               not null,
   NUMENDERECO          INTEIRO              null,
   DESCOMPLEMENTOENDER  DESCRICAO100         null,
   DESPONTOREFERENCIA   OBSERVACAOMIN        null,
   CODTABELAMERCADORIA  INTEIRO              null,
   NUMENDERECOEMP       INTEIRO              null,
   DESCOMPLEMENTOENDEREMP DESCRICAO100         null,
   DESPONTOREFERENCIAEMP OBSERVACAOMIN        null,
   BOLCONSULTOR         BOLEANO              null,
   constraint PK_INFM_PESSOA primary key (IDPESSOA)
)
go

/*==============================================================*/
/* Table: INFM_PESSOACRM                                        */
/*==============================================================*/
create table INFM_PESSOACRM (
   IDPESSOACRM          OBJETO_ID            not null,
   IDCRM                OBJETO_ID            null,
   IDPESSOA             OBJETOID             null,
   DTHPROXAGENDAMENTO   DATAHORA             not null,
   constraint PK_INFM_PESSOACRM primary key (IDPESSOACRM)
)
go

/*==============================================================*/
/* Table: INFM_PRODCATEGORIA                                    */
/*==============================================================*/
create table INFM_PRODCATEGORIA (
   IDPRODCATEGORIA      OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODPRODCATEGORIA     INTEIROSEQ           identity,
   DESPRODCATEGORIA     DESCRICAO50          not null,
   constraint PK_INFM_PRODCATEGORIA primary key (IDPRODCATEGORIA)
)
go

/*==============================================================*/
/* Table: INFM_PRODUTOCFOP                                      */
/*==============================================================*/
create table INFM_PRODUTOCFOP (
   IDPRODUTOCFOP        OBJETO_ID            not null,
   IDEMPRESA            OBJETOID             null,
   CODPRODUTOCFOP       INTEIROSEQ           identity,
   DESPRODUTOCFOP       DESCRICAO100         not null,
   CODCFOP              INTEIRO              null,
   constraint PK_INFM_PRODUTOCFOP primary key (IDPRODUTOCFOP)
)
go

/*==============================================================*/
/* Table: INFM_PRODUTOCOMISSAO                                  */
/*==============================================================*/
create table INFM_PRODUTOCOMISSAO (
   IDPRODUTOCOMISSAO    OBJETOID             not null,
   IDFILIAL             OBJETOID             null,
   CODPRODUTOCOMISSAO   INTEIROSEQ           identity,
   DESPRODUTOCOMISSAO   DESCRICAO100         not null,
   NUMCOMISSAOPER       NUMERO_DECIMAL       null,
   NUMCOMISSAOVALOR     NUMERO_DECIMAL       null,
   BOLHABILITADA        BOLEANO              null,
   constraint PK_INFM_PRODUTOCOMISSAO primary key (IDPRODUTOCOMISSAO)
)
go

/*==============================================================*/
/* Table: INFM_PRODUTOCST                                       */
/*==============================================================*/
create table INFM_PRODUTOCST (
   IDPRODUTOCST         OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODPRODUTOCST        INTEIROSEQ           identity,
   DESPRODUTOCST        DESCRICAO100         not null,
   CODCST               INTEIRO              null,
   BOLTEMST             BOLEANO              null,
   OBSMSGNOTAFISCAL     OBSERVACAOLONGA      null,
   constraint PK_INFM_PRODUTOCST primary key (IDPRODUTOCST)
)
go

/*==============================================================*/
/* Table: INFM_PRODUTODERIVACAO                                 */
/*==============================================================*/
create table INFM_PRODUTODERIVACAO (
   IDPRODUTODERIVACAO   OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODPRODUTODERIVACAO  INTEIROSEQ           identity,
   DESPRODUTODERIVACAO  DESCRICAO50          not null,
   constraint PK_INFM_PRODUTODERIVACAO primary key (IDPRODUTODERIVACAO)
)
go

/*==============================================================*/
/* Table: INFM_PRODUTOFILIAL                                    */
/*==============================================================*/
create table INFM_PRODUTOFILIAL (
   IDPRODUTOFILIAL      OBJETOID             not null,
   IDPRODUTOSERVICO     OBJETOID             not null,
   IDFILIAL             OBJETOID             not null,
   IDPRODUTOCOMISSAO    OBJETOID             null,
   IDUNIDADEMEDIDAESTOQUE OBJETOID             null,
   IDUNIDADEMEDIDAVENDA OBJETOID             null,
   DESPRATELEIRA        DESCRICAO50          null,
   NUMESTOQUEMINIMO     DECIMAL1             null,
   NUMMINIMOVENDA       DECIMAL1             null,
   NUMIPIPER            NUMERO_DECIMAL       null,
   NUMEMBALAGEMPER      NUMERO_DECIMAL       null,
   NUMFRETEPER          NUMERO_DECIMAL       null,
   NUMOUTDESPPER        NUMERO_DECIMAL       null,
   constraint PK_INFM_PRODUTOFILIAL primary key (IDPRODUTOFILIAL)
)
go

/*==============================================================*/
/* Table: INFM_PRODUTOMARCA                                     */
/*==============================================================*/
create table INFM_PRODUTOMARCA (
   IDPRODUTOMARCA       OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODPRODUTOMARCA      INTEIROSEQ           identity,
   DESPRODUTOMARCA      DESCRICAO50          not null,
   constraint PK_INFM_PRODUTOMARCA primary key (IDPRODUTOMARCA)
)
go

/*==============================================================*/
/* Table: INFM_PRODUTONCM                                       */
/*==============================================================*/
create table INFM_PRODUTONCM (
   IDPRODUTONCM         OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODPRODUTONCM        INTEIROSEQ           identity,
   CODNCM               INTEIRO              null,
   NUMMVAPER            NUMERO_DECIMAL       null,
   DESPRODUTONCM        DESCRICAO100         not null,
   constraint PK_INFM_PRODUTONCM primary key (IDPRODUTONCM)
)
go

/*==============================================================*/
/* Table: INFM_PRODUTOPROMOCAO                                  */
/*==============================================================*/
create table INFM_PRODUTOPROMOCAO (
   IDPRODUTOPROMOCAO    OBJETOID             not null,
   CODPRODUTOPROMOCAO   INTEIROSEQ           identity,
   DESPRODUTOPROMOCAO   DESCRICAO100         not null,
   NUMPROMOCAOPER       NUMERO_DECIMAL       null,
   NUMPROMOCAOVALOR     NUMERO_DECIMAL       null,
   BOLHABILITADA        BOLEANO              not null,
   DTHINICIO            DATAHORA             not null,
   DTHFIM               DATAHORA             not null,
   CODTIPOPROMOCAO      CODIGO20             not null,
   constraint PK_INFM_PRODUTOPROMOCAO primary key (IDPRODUTOPROMOCAO)
)
go

/*==============================================================*/
/* Table: INFM_PRODUTOPROMOCAOPRODF                             */
/*==============================================================*/
create table INFM_PRODUTOPROMOCAOPRODF (
   IDPRODUTOPROMOCAOPRODF OBJETOID             not null,
   IDPRODUTOPROMOCAO    OBJETOID             null,
   IDPRODUTOFILIAL      OBJETOID             null,
   IDDATOSCOMPRAPROD    OBJETOID             null,
   IDPRODUTOSERVICO     OBJETOID             null,
   constraint PK_INFM_PRODUTOPROMOCAOPRODF primary key (IDPRODUTOPROMOCAOPRODF)
)
go

/*==============================================================*/
/* Table: INFM_PRODUTOSERVICO                                   */
/*==============================================================*/
create table INFM_PRODUTOSERVICO (
   IDPRODUTOSERVICO     OBJETOID             not null,
   IDTIPOPRODUTO        OBJETO_ID            null,
   IDGRUPOPRODUTO       OBJETOID             null,
   IDCOR                OBJETOID             null,
   IDPRODUTODERIVACAO   OBJETOID             null,
   IDPRODCATEGORIA      OBJETOID             null,
   IDPRODUTOMARCA       OBJETOID             null,
   IDEMPRESA            OBJETOID             null,
   IDPRODUTONCM         OBJETOID             null,
   IDPRODUTOCST         OBJETOID             null,
   IDPRODUTOCFOP        OBJETO_ID            null,
   CODPRODUTO           INTEIROSEQ           identity,
   DESPRODUTO           DESCRICAO100         not null,
   DESCODBARRAS         DESCRICAO50          null,
   OBSPRODUTO           OBSERVACAOMIN        null,
   NUMPESOPRODUTO       NUMERO_DECIMAL       null,
   BITIMGPRODUTO        OBJETO_IMAGEM        null,
   constraint PK_INFM_PRODUTOSERVICO primary key (IDPRODUTOSERVICO)
)
go

/*==============================================================*/
/* Table: INFM_PUBLICIDADE                                      */
/*==============================================================*/
create table INFM_PUBLICIDADE (
   IDPUBLICIDADE        OBJETO_ID            not null,
   DESPUBLICIDADE       DESCRICAO200         not null,
   CODPUBLICIDADE       INTEIRO              not null,
   constraint PK_INFM_PUBLICIDADE primary key (IDPUBLICIDADE)
)
go

/*==============================================================*/
/* Table: INFM_SALDOFILIAL                                      */
/*==============================================================*/
create table INFM_SALDOFILIAL (
   IDSALDOFILIAL        OBJETO_ID            not null,
   IDFILIAL             OBJETOID             not null,
   NUMSALDO             DECIMAL1             not null,
   constraint PK_INFM_SALDOFILIAL primary key (IDSALDOFILIAL)
)
go

/*==============================================================*/
/* Table: INFM_SALDOPESSOA                                      */
/*==============================================================*/
create table INFM_SALDOPESSOA (
   IDSALDOPESSOA        OBJETO_ID            not null,
   IDDOCUMENTO          OBJETO_ID            null,
   IDPESSOA             OBJETOID             null,
   NUMVALORSALDO        DECIMAL1             not null,
   constraint PK_INFM_SALDOPESSOA primary key (IDSALDOPESSOA)
)
go

/*==============================================================*/
/* Table: INFM_SEGMENTOCOMERCIAL                                */
/*==============================================================*/
create table INFM_SEGMENTOCOMERCIAL (
   IDSEGMENTOCOMERCIAL  OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODSEGMENTOCOMERCIAL INTEIROSEQ           identity,
   DESSEGMENTOCOMERCIAL DESCRICAO100         not null,
   constraint PK_INFM_SEGMENTOCOMERCIAL primary key (IDSEGMENTOCOMERCIAL)
)
go

/*==============================================================*/
/* Table: INFM_SESSAO                                           */
/*==============================================================*/
create table INFM_SESSAO (
   IDSESSAO             OBJETO_ID            not null,
   IDPESSOA             OBJETOID             null,
   IDFILIAL             OBJETOID             null,
   DTHINICIO            DATAHORA             not null,
   DTHFIM               DATAHORA             null,
   DTHULTIMOUSO         DATAHORA             not null,
   constraint PK_INFM_SESSAO primary key (IDSESSAO)
)
go

/*==============================================================*/
/* Table: INFM_SITUACAO_PESSOA                                  */
/*==============================================================*/
create table INFM_SITUACAO_PESSOA (
   IDSITUACAOPESSOA     OBJETOID             not null,
   DESSITUACAO          DESCRICAO50          not null,
   CODSITUACAO          CODIGO20             not null,
   constraint PK_INFM_SITUACAO_PESSOA primary key (IDSITUACAOPESSOA)
)
go

/*==============================================================*/
/* Table: INFM_TIPODOCUMENTO                                    */
/*==============================================================*/
create table INFM_TIPODOCUMENTO (
   IDTIPODOCUMENTO      OBJETO_ID            not null,
   CODTIPODOCUMENTO     CODIGO20             not null,
   DESTIPODOCUMENTO     DESCRICAO50          not null,
   constraint PK_INFM_TIPODOCUMENTO primary key (IDTIPODOCUMENTO)
)
go

/*==============================================================*/
/* Table: INFM_TIPOPESSOA                                       */
/*==============================================================*/
create table INFM_TIPOPESSOA (
   IDTIPOPESSOA         OBJETOID             not null,
   DESTIPOPESSOA        DESCRICAO50          not null,
   CODTIPOPESSOA        INTEIRO              not null,
   constraint PK_INFM_TIPOPESSOA primary key (IDTIPOPESSOA)
)
go

/*==============================================================*/
/* Table: INFM_TIPOPESSOA_PESSOA                                */
/*==============================================================*/
create table INFM_TIPOPESSOA_PESSOA (
   IDTIPOPESSOAPESSOA   OBJETOID             not null,
   IDTIPOPESSOA         OBJETOID             null,
   IDPESSOA             OBJETOID             null,
   constraint PK_INFM_TIPOPESSOA_PESSOA primary key (IDTIPOPESSOAPESSOA)
)
go

/*==============================================================*/
/* Table: INFM_TIPOPRODUTO                                      */
/*==============================================================*/
create table INFM_TIPOPRODUTO (
   IDTIPOPRODUTO        OBJETO_ID            not null,
   CODTIPOPRODUTO       CODIGO20             not null,
   DESTIPOPRODUTO       DESCRICAO50          not null,
   constraint PK_INFM_TIPOPRODUTO primary key (IDTIPOPRODUTO)
)
go

/*==============================================================*/
/* Table: INFM_TRANSACOES                                       */
/*==============================================================*/
create table INFM_TRANSACOES (
   IDTRANSACAO          OBJETO_ID            not null,
   IDDOCUMENTO          OBJETO_ID            null,
   IDPARCELAMENTO       OBJETO_ID            null,
   NUMVALORACRESCIMO    DECIMAL1             null,
   NUMVALORDESCONTO     DECIMAL1             null,
   NUMVALORTRANSACAO    DECIMAL1             not null,
   DTHTRANSACAO         DATAHORA             not null,
   constraint PK_INFM_TRANSACOES primary key (IDTRANSACAO)
)
go

/*==============================================================*/
/* Table: INFM_UNIDADEMEDIDA                                    */
/*==============================================================*/
create table INFM_UNIDADEMEDIDA (
   IDUNIDADEMEDIDA      OBJETOID             not null,
   IDUNIDADEMEDIDAPAI   OBJETOID             null,
   IDEMPRESA            OBJETOID             null,
   CODUNIDADEMEDIDA     CODIGO20             not null,
   NUMUNIDADEPAI        NUMERO_DECIMAL       null,
   DESUNIDADEMEDIDA     DESCRICAO100         not null,
   constraint PK_INFM_UNIDADEMEDIDA primary key (IDUNIDADEMEDIDA)
)
go

/*==============================================================*/
/* Table: INFM_UNIDADEMEDPRODUTO                                */
/*==============================================================*/
create table INFM_UNIDADEMEDPRODUTO (
   IDUNIDADEMEDPRODUTO  OBJETO_ID            not null,
   IDUNIDADEMEDIDA      OBJETOID             null,
   IDPRODUTOSERVICO     OBJETOID             null,
   constraint PK_INFM_UNIDADEMEDPRODUTO primary key (IDUNIDADEMEDPRODUTO)
)
go

/*==============================================================*/
/* Table: INFM_USUPERMISSAOACAO                                 */
/*==============================================================*/
create table INFM_USUPERMISSAOACAO (
   IDUSUPERMISSAOACAO   OBJETOID             not null,
   IDPERMISSAO          OBJETOID             null,
   IDACAO               OBJETOID             null,
   IDPESSOA             OBJETOID             null,
   IDGRUPOPERMISSAO     OBJETOID             null,
   constraint PK_INFM_USUPERMISSAOACAO primary key (IDUSUPERMISSAOACAO)
)
go

alter table INFM_ADMINISTRADORA
   add constraint FK_INFM_ADM_REFERENCE_INFM_EMP foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_BAIRRO
   add constraint FK_INFM_BAI_REFERENCE_INFM_CID foreign key (IDCIDADE)
      references INFM_CIDADE (IDCIDADE)
go

alter table INFM_CIDADE
   add constraint FK_INFM_CID_REFERENCE_INFM_EST foreign key (IDESTADO)
      references INFM_ESTADO (IDESTADO)
go

alter table INFM_COR
   add constraint FK_INFM_COR_REFERENCE_INFM_EMP foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_CRM
   add constraint FK_INFM_CRM_REFERENCE_INFM_EMP foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_CRM
   add constraint FK_INFM_CRM_REFERENCE_INFM_GRU foreign key (IDGRUPOCOMPROMISSO)
      references INFM_GRUPOCOMPROMISSO (IDGRUPOCOMPROMISSO)
go

alter table INFM_CRM
   add constraint FK_INFM_CRM_REF_INFM_PES2 foreign key (IDPESSOACADASTRO)
      references INFM_PESSOA (IDPESSOA)
go

alter table INFM_CRM
   add constraint FK_INFM_CRM_REFERENCE_INFM_PES foreign key (IDPESSOACLIENTE)
      references INFM_PESSOA (IDPESSOA)
go

alter table INFM_DATOSCOMPRAPROD
   add constraint FK_INFM_DAT_REFERENCE_INFM_PES foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)
go

alter table INFM_DATOSCOMPRAPROD
   add constraint FK_INFM_DAT_REFERENCE_INFM_UNI foreign key (IDUNIDADEMEDIDA)
      references INFM_UNIDADEMEDIDA (IDUNIDADEMEDIDA)
go

alter table INFM_DATOSCOMPRAPROD
   add constraint FK_INFM_DAT_REFERENCE_INFM_PRO foreign key (IDPRODUTOFILIAL)
      references INFM_PRODUTOFILIAL (IDPRODUTOFILIAL)
go

alter table INFM_DOCUMENTO
   add constraint FK_INFM_DOC_REFERENCE_INFM_FIL foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)
go

alter table INFM_DOCUMENTO
   add constraint FK_INFM_DOC_REFERENCE_INFM_PES foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)
go

alter table INFM_DOCUMENTO
   add constraint FK_INFM_DOC_REFERENCE_INFM_TIP foreign key (IDTIPODOCUMENTO)
      references INFM_TIPODOCUMENTO (IDTIPODOCUMENTO)
go

alter table INFM_DOCUMENTO
   add constraint FK_INFM_DOC_REFERENCE_INFM_LOC foreign key (IDLOCALDOCUMENTO)
      references INFM_LOCALDOCUMENTO (IDLOCALDOCUMENTO)
go

alter table INFM_DOCUMENTO
   add constraint FK_INFM_DOC_REFERENCE_INFM_FOR foreign key (IDFORMAPAGAMENTO)
      references INFM_FORMAPAGAMENTO (IDFORMAPAGAMENTO)
go

alter table INFM_DOCUMENTO
   add constraint FK_INFM_DOC_REFERENCE_INFM_ADM foreign key (IDADMINISTRADORA)
      references INFM_ADMINISTRADORA (IDADMINISTRADORA)
go

alter table INFM_DOCUMENTO
   add constraint FK_INFM_DOC_REFERENCE_INFM_DOC foreign key (IDDOCUMENTOPAI)
      references INFM_DOCUMENTO (IDDOCUMENTO)
go

alter table INFM_EMPRESA
   add constraint FK_INFM_EMP_REFERENCE_INFM_LIC foreign key (IDLICENCA)
      references INFM_LICENCA (IDLICENCA)
go

alter table INFM_EMPRESA
   add constraint FK_INFM_EMP_REFERENCE_INFM_PUB foreign key (IDPUBLICIDADE)
      references INFM_PUBLICIDADE (IDPUBLICIDADE)
go

alter table INFM_EMPRESA
   add constraint FK_INFM_EMP_REFERENCE_INFM_PES foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)
go

alter table INFM_ENDERECO
   add constraint FK_INFM_END_REFERENCE_INFM_BAI foreign key (IDBAIRRO)
      references INFM_BAIRRO (IDBAIRRO)
go

alter table INFM_FILIAL
   add constraint FK_INFM_FIL_FK_PESSOA_INFM_PES1 foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)
go

alter table INFM_FILIAL
   add constraint FK_INFM_FIL_REFERENCE_INFM_EMP foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_FILIAL
   add constraint FK_INFM_FIL_REFERENCE_INFM_END foreign key (IDENDERECO)
      references INFM_ENDERECO (IDENDERECO)
go

alter table INFM_FILIALBAIRRO
   add constraint FK_INFM_FIL_FK_FILIAL_INFM_FIL1 foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)
go

alter table INFM_FILIALBAIRRO
   add constraint FK_INFM_FIL_REFERENCE_INFM_BAI foreign key (IDBAIRRO)
      references INFM_BAIRRO (IDBAIRRO)
go

alter table INFM_FILIALPESSOA
   add constraint FK_INFM_FIL_FK_FILIAL_INFM_FIL2 foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)
go

alter table INFM_FILIALPESSOA
   add constraint FK_INFM_FIL_FK_PESSOA_INFM_PES foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)
go

alter table INFM_GRUPOCOMPROMISSO
   add constraint FK_INFM_GRU_REFERENCE_INFM_EMP foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_GRUPOCOMPROMISSOSUBGRUPO
   add constraint FK_INFM_GRU_REFERENCE_INFM_GRU foreign key (IDGRUPOCOMPROMISSOPAI)
      references INFM_GRUPOCOMPROMISSO (IDGRUPOCOMPROMISSO)
go

alter table INFM_GRUPOCOMPROMISSOSUBGRUPO
   add constraint FK_INFM_GRU_REF_INFM_GRU_1 foreign key (IDGRUPOCOMPROMISSO)
      references INFM_GRUPOCOMPROMISSO (IDGRUPOCOMPROMISSO)
go

alter table INFM_GRUPOPERMISSAO
   add constraint FK_EMPRESA_GRUPOPERM foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_GRUPOPERMISSAOACAO
   add constraint FK_INFM_GRUPOPER_GRUPOPA foreign key (IDGRUPOPERMISSAO)
      references INFM_GRUPOPERMISSAO (IDGRUPOPERMISSAO)
go

alter table INFM_GRUPOPERMISSAOACAO
   add constraint FK_INFM_GRU_REFERENCE_INFM_PER foreign key (IDPERMISSAO)
      references INFM_PERMISSAO (IDPERMISSAO)
go

alter table INFM_GRUPOPERMISSAOACAO
   add constraint FK_INFM_GRU_REFERENCE_INFM_ACA foreign key (IDACAO)
      references INFM_ACAO (IDACAO)
go

alter table INFM_GRUPOPRODUTO
   add constraint FK_EMPRESA_GRUPPROD foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_GRUPOPRODUTOSUBGRUPO
   add constraint FK_INFM_GRUPROD_GRUPRODPROD foreign key (IDGRUPOPRODUTO)
      references INFM_GRUPOPRODUTO (IDGRUPOPRODUTO)
go

alter table INFM_GRUPOPRODUTOSUBGRUPO
   add constraint FK_INFM_GRUPROD_PROD2 foreign key (IDGRUPOPRODUTOPAI)
      references INFM_GRUPOPRODUTO (IDGRUPOPRODUTO)
go

alter table INFM_HORATRABALHO
   add constraint FK_INFM_HOR_REFERENCE_INFM_PES foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)
go

alter table INFM_PARAMETROVALOR
   add constraint FK_INFM_PAR_REFERENCE_INFM_PAR foreign key (IDPARAMETRO)
      references INFM_PARAMETROS (IDPARAMETRO)
go

alter table INFM_PARAMETROVALOR
   add constraint FK_INFM_PAR_REFERENCE_INFM_FIL foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)
go

alter table INFM_PARCELAMENTO
   add constraint FK_INFM_PAR_REFERENCE_INFM_DOC foreign key (IDDOCUMENTO)
      references INFM_DOCUMENTO (IDDOCUMENTO)
go

alter table INFM_PERMISSAOACAO
   add constraint FK_INFM_PER_REFERENCE_INFM_PER foreign key (IDPERMISSAO)
      references INFM_PERMISSAO (IDPERMISSAO)
go

alter table INFM_PERMISSAOACAO
   add constraint FK_INFM_PER_REFERENCE_INFM_ACA foreign key (IDACAO)
      references INFM_ACAO (IDACAO)
go

alter table INFM_PESSOA
   add constraint FK_INFM_PES_PK_ENDERE_INFM_END foreign key (IDENDERECO)
      references INFM_ENDERECO (IDENDERECO)
go

alter table INFM_PESSOA
   add constraint FK_INFM_PES_REFERENCE_INFM_SIT foreign key (IDSITUACAOPESSOA)
      references INFM_SITUACAO_PESSOA (IDSITUACAOPESSOA)
go

alter table INFM_PESSOA
   add constraint FK_INFM_PES_REFERENCE_INFM_PES foreign key (IDPESSOARESPONSAVEL)
      references INFM_PESSOA (IDPESSOA)
go

alter table INFM_PESSOA
   add constraint FK_INFM_PES_REFERENCE_INFM_SEG foreign key (IDSEGMENTOCOMERCIAL)
      references INFM_SEGMENTOCOMERCIAL (IDSEGMENTOCOMERCIAL)
go

alter table INFM_PESSOA
   add constraint FK_INFM_PES_REFERENCE_INFM_END foreign key (IDENDERECOEMPRESA)
      references INFM_ENDERECO (IDENDERECO)
go

alter table INFM_PESSOA
   add constraint FK_INFM_PES_REFERENCE_INFM_EMP foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_PESSOACRM
   add constraint FK_INFM_PES_REF_INFM_CRM3 foreign key (IDCRM)
      references INFM_CRM (IDCRM)
go

alter table INFM_PESSOACRM
   add constraint FK_INFM_PES_REF_INFM_PES2 foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)
go

alter table INFM_PRODCATEGORIA
   add constraint FK_EMPRESA_PRODCAT foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_PRODUTOCFOP
   add constraint FKEMPRESAPRODCFOP foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_PRODUTOCOMISSAO
   add constraint FK_FILIAL_PRODCOMIS foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)
go

alter table INFM_PRODUTOCST
   add constraint FKEMPESAPRODCST foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_PRODUTODERIVACAO
   add constraint FK_EMPRESA_PRODDER foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_PRODUTOFILIAL
   add constraint FKUNIDADEMEDPRODFIL1 foreign key (IDUNIDADEMEDIDAVENDA)
      references INFM_UNIDADEMEDIDA (IDUNIDADEMEDIDA)
go

alter table INFM_PRODUTOFILIAL
   add constraint FKUNIDADEMEDPRODFIL2 foreign key (IDUNIDADEMEDIDAESTOQUE)
      references INFM_UNIDADEMEDIDA (IDUNIDADEMEDIDA)
go

alter table INFM_PRODUTOFILIAL
   add constraint FK_FILIAL_PRDFIL foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)
go

alter table INFM_PRODUTOFILIAL
   add constraint FK_INFM_PRO_FK_PRODCO_INFM_PRO foreign key (IDPRODUTOCOMISSAO)
      references INFM_PRODUTOCOMISSAO (IDPRODUTOCOMISSAO)
go

alter table INFM_PRODUTOFILIAL
   add constraint FK_INFM_PRO_FK_PRODSE_INFM_PRO foreign key (IDPRODUTOSERVICO)
      references INFM_PRODUTOSERVICO (IDPRODUTOSERVICO)
go

alter table INFM_PRODUTOMARCA
   add constraint FK_EMPRESA_PRDMARC foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_PRODUTONCM
   add constraint FK_INFM_PRO_REFERENCE_INFM_EMP foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_PRODUTOPROMOCAOPRODF
   add constraint FKPRODFILIALPRODPROMPROD foreign key (IDPRODUTOFILIAL)
      references INFM_PRODUTOFILIAL (IDPRODUTOFILIAL)
go

alter table INFM_PRODUTOPROMOCAOPRODF
   add constraint FKPRODPROMOCAOPROD foreign key (IDPRODUTOPROMOCAO)
      references INFM_PRODUTOPROMOCAO (IDPRODUTOPROMOCAO)
go

alter table INFM_PRODUTOPROMOCAOPRODF
   add constraint FK_INFM_PRO_REFERENCE_INFM_DAT foreign key (IDDATOSCOMPRAPROD)
      references INFM_DATOSCOMPRAPROD (IDDATOSCOMPRAPROD)
go

alter table INFM_PRODUTOPROMOCAOPRODF
   add constraint FK_INFM_PRO_REFERENCE_INFM_PRO foreign key (IDPRODUTOSERVICO)
      references INFM_PRODUTOSERVICO (IDPRODUTOSERVICO)
go

alter table INFM_PRODUTOSERVICO
   add constraint FKPRODCSTPRODSERVICO foreign key (IDPRODUTOCST)
      references INFM_PRODUTOCST (IDPRODUTOCST)
go

alter table INFM_PRODUTOSERVICO
   add constraint FK_INFM_PRO_FKPRODNCM_INFM_PRO foreign key (IDPRODUTONCM)
      references INFM_PRODUTONCM (IDPRODUTONCM)
go

alter table INFM_PRODUTOSERVICO
   add constraint FKPRODUTOCFOPPRODSERV foreign key (IDPRODUTOCFOP)
      references INFM_PRODUTOCFOP (IDPRODUTOCFOP)
go

alter table INFM_PRODUTOSERVICO
   add constraint FK_EMPRESA_PRODEMP foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_PRODUTOSERVICO
   add constraint FK_INFM_PRO_FK_PRODCA_INFM_PRO foreign key (IDPRODCATEGORIA)
      references INFM_PRODCATEGORIA (IDPRODCATEGORIA)
go

alter table INFM_PRODUTOSERVICO
   add constraint FK_INFM_PRO_FK_PRODDE_INFM_PRO foreign key (IDPRODUTODERIVACAO)
      references INFM_PRODUTODERIVACAO (IDPRODUTODERIVACAO)
go

alter table INFM_PRODUTOSERVICO
   add constraint FK_INFM_PRO_FK_PRODMA_INFM_PRO foreign key (IDPRODUTOMARCA)
      references INFM_PRODUTOMARCA (IDPRODUTOMARCA)
go

alter table INFM_PRODUTOSERVICO
   add constraint FK_INFM_PRO_REFERENCE_INFM_TIP foreign key (IDTIPOPRODUTO)
      references INFM_TIPOPRODUTO (IDTIPOPRODUTO)
go

alter table INFM_PRODUTOSERVICO
   add constraint FK_INFM_PRO_REFERENCE_INFM_GRU foreign key (IDGRUPOPRODUTO)
      references INFM_GRUPOPRODUTO (IDGRUPOPRODUTO)
go

alter table INFM_PRODUTOSERVICO
   add constraint FK_INFM_PRO_REFERENCE_INFM_COR foreign key (IDCOR)
      references INFM_COR (IDCOR)
go

alter table INFM_SALDOFILIAL
   add constraint FK_INFM_SAL_REFERENCE_INFM_FIL foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)
go

alter table INFM_SALDOPESSOA
   add constraint FK_INFM_SAL_REFERENCE_INFM_DOC foreign key (IDDOCUMENTO)
      references INFM_DOCUMENTO (IDDOCUMENTO)
go

alter table INFM_SALDOPESSOA
   add constraint FK_INFM_SAL_REFERENCE_INFM_PES foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)
go

alter table INFM_SEGMENTOCOMERCIAL
   add constraint FK_INFM_SEG_REFERENCE_INFM_EMP foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_SESSAO
   add constraint FK_INFM_SES_REFERENCE_INFM_PES foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)
go

alter table INFM_SESSAO
   add constraint FK_INFM_SES_REFERENCE_INFM_FIL foreign key (IDFILIAL)
      references INFM_FILIAL (IDFILIAL)
go

alter table INFM_TIPOPESSOA_PESSOA
   add constraint FK_INFM_TIP_REFERENCE_INFM_TIP foreign key (IDTIPOPESSOA)
      references INFM_TIPOPESSOA (IDTIPOPESSOA)
go

alter table INFM_TIPOPESSOA_PESSOA
   add constraint FK_INFM_TIP_REFERENCE_INFM_PES foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)
go

alter table INFM_TRANSACOES
   add constraint FK_INFM_TRA_REFERENCE_INFM_DOC foreign key (IDDOCUMENTO)
      references INFM_DOCUMENTO (IDDOCUMENTO)
go

alter table INFM_TRANSACOES
   add constraint FK_INFM_TRA_REFERENCE_INFM_PAR foreign key (IDPARCELAMENTO)
      references INFM_PARCELAMENTO (IDPARCELAMENTO)
go

alter table INFM_UNIDADEMEDIDA
   add constraint FKUNIDADMEDPROD foreign key (IDUNIDADEMEDIDAPAI)
      references INFM_UNIDADEMEDIDA (IDUNIDADEMEDIDA)
go

alter table INFM_UNIDADEMEDIDA
   add constraint FK_INFM_UNI_REFERENCE_INFM_EMP foreign key (IDEMPRESA)
      references INFM_EMPRESA (IDEMPRESA)
go

alter table INFM_UNIDADEMEDPRODUTO
   add constraint FK_INFM_UNI_FKUNIDADE_INFM_UNI foreign key (IDUNIDADEMEDIDA)
      references INFM_UNIDADEMEDIDA (IDUNIDADEMEDIDA)
go

alter table INFM_UNIDADEMEDPRODUTO
   add constraint FK_INFM_UNI_REFERENCE_INFM_PRO foreign key (IDPRODUTOSERVICO)
      references INFM_PRODUTOSERVICO (IDPRODUTOSERVICO)
go

alter table INFM_USUPERMISSAOACAO
   add constraint FK_INFM_USU_REFERENCE_INFM_PER foreign key (IDPERMISSAO)
      references INFM_PERMISSAO (IDPERMISSAO)
go

alter table INFM_USUPERMISSAOACAO
   add constraint FK_INFM_USU_REFERENCE_INFM_ACA foreign key (IDACAO)
      references INFM_ACAO (IDACAO)
go

alter table INFM_USUPERMISSAOACAO
   add constraint FK_INFM_USU_REFERENCE_INFM_PES foreign key (IDPESSOA)
      references INFM_PESSOA (IDPESSOA)
go

alter table INFM_USUPERMISSAOACAO
   add constraint FK_INFM_USU_REFERENCE_INFM_GRU foreign key (IDGRUPOPERMISSAO)
      references INFM_GRUPOPERMISSAO (IDGRUPOPERMISSAO)
go

