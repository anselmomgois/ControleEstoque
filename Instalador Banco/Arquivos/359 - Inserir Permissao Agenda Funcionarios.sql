QUERYVALIDACAO select 1 FROM INFM_PERMISSAO WHERE CODPERMISSAO = 'VERAGENDATODOS'
BANCODEDADOS INFORMATIZ
INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('27'
           ,'VERAGENDATODOS'
           ,'Visualizar Agenda de Todos Funcion�rios'
		   ,0)