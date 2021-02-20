QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_ITEMVENDA_NUMSERIE') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_ITEMVENDA_NUMSERIE (
   IDITEMVENDA          OBJETO_ID            null,
   IDITEMVENDA_NUMSERIE OBJETO_ID            not null,
   IDPRODUTONUMEROSERIE OBJETO_ID            null,
   constraint PK_INFM_ITEMVENDA_NUMSERIE primary key (IDITEMVENDA_NUMSERIE))