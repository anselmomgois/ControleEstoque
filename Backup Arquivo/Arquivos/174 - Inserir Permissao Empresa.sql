QUERYVALIDACAO select 1 FROM INFM_PERMISSAO WHERE CODPERMISSAO = 'EMPRESA'
BANCODEDADOS INFORMATIZ
INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('21'
           ,'EMPRESA'
           ,'Tela de Informações da Empresa'
		   ,0)