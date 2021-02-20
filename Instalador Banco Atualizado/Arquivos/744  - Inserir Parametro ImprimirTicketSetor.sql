QUERYVALIDACAO select 1 FROM INFM_PARAMETROS WHERE CODPARAMETRO = 'ImprimirTicketSetor'
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
           ,'ImprimirTicketSetor'
           ,'Define se imprime o pedido no setor responsável'
           ,3
           ,1
           ,(select IDGRUPOPARAMETRO FROM INFM_GRUPOPARAMETRO WHERE CODGRUPOPARAMETRO = 'OPERATIVO'))