QUERYVALIDACAO select 1 FROM INFM_PARAMETROS WHERE CODPARAMETRO = 'FormaPagamentoPadrao'
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
           ,'FormaPagamentoPadrao'
           ,'Forma Pagamento Padrão'
           ,1
           ,1
           ,(select IDGRUPOPARAMETRO FROM INFM_GRUPOPARAMETRO WHERE CODGRUPOPARAMETRO = 'OPERATIVO'))