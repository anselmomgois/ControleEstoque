QUERYVALIDACAO select 1 FROM INFM_PERMISSAOACAO PA INNER JOIN INFM_PERMISSAO P ON P.IDPERMISSAO = PA.IDPERMISSAO WHERE P.CODPERMISSAO = 'PROCESSO' AND IDACAO = '4'
BANCODEDADOS IGERENCE
INSERT INTO INFM_PERMISSAOACAO
           (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           (NEWID()
           ,(SELECT IDPERMISSAO FROM INFM_PERMISSAO WHERE CODPERMISSAO = 'PROCESSO')
           ,'4')