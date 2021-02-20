QUERYVALIDACAO select 1 FROM INFM_PARAMETROS WHERE CODPARAMETRO = 'IntervaloExecucaoAPI'
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
           ,'IntervaloExecucaoAPI'
           ,'Intervalo Execução das Integrações por API em Minutos'
           ,5
           ,1
           ,(select IDGRUPOPARAMETRO FROM INFM_GRUPOPARAMETRO WHERE CODGRUPOPARAMETRO = 'SERVER'))