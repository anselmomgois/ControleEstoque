QUERYVALIDACAO select 1 FROM INFM_PERMISSAO WHERE CODPERMISSAO = 'GRUPOCOMPROMISSO'
BANCODEDADOS IGERENCE
INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('24'
           ,'GRUPOCOMPROMISSO'
           ,'Tela Grupo de Compromissos'
		   ,0)