QUERYVALIDACAO select 1 FROM INFM_PARAMETROS WHERE CODPARAMETRO = 'NUMPORTA'
BANCODEDADOS IGERENCE
INSERT INTO INFM_PARAMETROS
          (IDPARAMETRO
           ,CODPARAMETRO
           ,DESPARAMETRO
		   ,TIPOCOMPONENTE
		   ,BOLNIVELFILIAL)
     VALUES
           (NEWID()
           ,'NUMPORTA'
           ,'Numero Porta Servidor'
		   ,1
		   ,1)