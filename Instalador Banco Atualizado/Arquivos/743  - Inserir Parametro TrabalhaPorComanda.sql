QUERYVALIDACAO select 1 FROM INFM_PARAMETROS WHERE CODPARAMETRO = 'TrabalhaPorComanda'
BANCODEDADOS IGERENCE
INSERT INTO INFM_PARAMETROS
           (IDPARAMETRO
           ,CODPARAMETRO
           ,DESPARAMETRO
           ,TIPOCOMPONENTE
           ,BOLNIVELFILIAL
           ,IDGRUPOPARAMETRO)
     VALUES
           (NEWID()
           ,'TrabalhaPorComanda'
           ,'Define se o estabelecimento trabalha por comanda'
           ,3
           ,1
           ,(select IDGRUPOPARAMETRO FROM INFM_GRUPOPARAMETRO WHERE CODGRUPOPARAMETRO = 'OPERATIVO'))