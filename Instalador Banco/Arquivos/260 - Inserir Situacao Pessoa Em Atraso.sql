QUERYVALIDACAO select 1 FROM INFM_SITUACAO_PESSOA WHERE CODSITUACAO = 'N'
BANCODEDADOS INFORMATIZ
INSERT INTO INFM_SITUACAO_PESSOA
            (IDSITUACAOPESSOA,
			 DESSITUACAO,
			 CODSITUACAO)
	  VALUES
	        ('2',
			 'Em Atraso',
			 'N')