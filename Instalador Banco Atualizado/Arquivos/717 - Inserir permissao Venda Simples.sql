QUERYVALIDACAO select 1 FROM INFM_PERMISSAO WHERE CODPERMISSAO = 'VENDASIMPLES'
BANCODEDADOS IGERENCE
INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           (NEWID()
           ,'VENDASIMPLES'
           ,'Tela Venda Simples'
		   ,0)