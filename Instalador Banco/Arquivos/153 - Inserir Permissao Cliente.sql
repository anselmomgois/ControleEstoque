QUERYVALIDACAO select 1 FROM INFM_PERMISSAO WHERE CODPERMISSAO = 'CLIENTE'
BANCODEDADOS INFORMATIZ
INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('3'
           ,'CLIENTE'
           ,'Tela de Clientes'
		   ,0)