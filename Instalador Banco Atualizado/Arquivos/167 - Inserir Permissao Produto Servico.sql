QUERYVALIDACAO select 1 FROM INFM_PERMISSAO WHERE CODPERMISSAO = 'PRODUTOSERVICO'
BANCODEDADOS IGERENCE
INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('14'
           ,'PRODUTOSERVICO'
           ,'Tela Cadastro de Produtos e Servi�os'
		   ,0)