QUERYVALIDACAO select 1 FROM INFM_PERMISSAO WHERE CODPERMISSAO = 'RELATORIOPESSOAS'
BANCODEDADOS INFORMATIZ
INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('22'
           ,'RELATORIOPESSOAS'
           ,'Relatório de Pessoas'
		   ,0)