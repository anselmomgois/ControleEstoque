QUERYVALIDACAO select 1 FROM INFM_SITUACAO_PESSOA WHERE CODSITUACAO = 'A'
BANCODEDADOS IGERENCE
INSERT INTO INFM_SITUACAO_PESSOA
            (IDSITUACAOPESSOA,
			 DESSITUACAO,
			 CODSITUACAO)
	  VALUES
	        ('1',
			 'Em Dia',
			 'A')