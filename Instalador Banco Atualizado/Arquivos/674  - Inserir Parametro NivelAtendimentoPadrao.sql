QUERYVALIDACAO select 1 FROM INFM_PARAMETROS WHERE CODPARAMETRO = 'NivelAtendimentoPadrao'
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
           ,'NivelAtendimentoPadrao'
           ,'Nivel Atendimento Padrão'
           ,1
           ,1
           ,(select IDGRUPOPARAMETRO FROM INFM_GRUPOPARAMETRO WHERE CODGRUPOPARAMETRO = 'OPERATIVO'))