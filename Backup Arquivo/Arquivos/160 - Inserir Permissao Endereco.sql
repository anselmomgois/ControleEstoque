QUERYVALIDACAO select 1 FROM INFM_PERMISSAO WHERE CODPERMISSAO = 'ENDERECO'
BANCODEDADOS INFORMATIZ
INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('7'
           ,'ENDERECO'
           ,'Tela Configura��o de Endere�o'
		   ,0)