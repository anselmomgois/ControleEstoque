QUERYVALIDACAO select 1 FROM INFM_PERMISSAO WHERE CODPERMISSAO = 'ENDERECO'
BANCODEDADOS IGERENCE
INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('7'
           ,'ENDERECO'
           ,'Tela Configuração de Endereço'
		   ,0)