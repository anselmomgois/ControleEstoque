QUERYVALIDACAO select 1 FROM INFM_PARAMETROOPCAO WHERE CODPARAMETROOPCAO = '4POSICOES'
BANCODEDADOS IGERENCE
INSERT INTO INFM_PARAMETROOPCAO
           (IDPARAMETROOPCAO
           ,IDPARAMETRO
           ,CODPARAMETROOPCAO
           ,DESPARAMETROOPCAO)
     VALUES
           (NEWID()
           ,(SELECT IDPARAMETRO FROM INFM_PARAMETROS WHERE CODPARAMETRO = 'TipoCodigoBarras')
           ,'4POSICOES'
           ,'4 POSIÇÕES')