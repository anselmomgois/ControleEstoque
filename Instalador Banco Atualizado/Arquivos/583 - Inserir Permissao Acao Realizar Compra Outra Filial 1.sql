QUERYVALIDACAO select 1 FROM INFM_PERMISSAOACAO PA INNER JOIN INFM_PERMISSAO P ON P.IDPERMISSAO = PA.IDPERMISSAO WHERE P.CODPERMISSAO = 'REALIZAR_COMPRA_OUTRA_FILIAL' AND IDACAO = '1'
BANCODEDADOS IGERENCE
INSERT INTO INFM_PERMISSAOACAO
           (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           (NEWID()
           ,(SELECT IDPERMISSAO FROM INFM_PERMISSAO WHERE CODPERMISSAO = 'REALIZAR_COMPRA_OUTRA_FILIAL')
           ,'1')