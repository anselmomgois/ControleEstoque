QUERYVALIDACAO select 1 FROM INFM_PERMISSAO WHERE CODPERMISSAO = 'PERMISSOESUSUARIO'
BANCODEDADOS IGERENCE
INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('6'
           ,'PERMISSOESUSUARIO'
           ,'Tela Permiss�es do Usu�rio'
		   ,0)