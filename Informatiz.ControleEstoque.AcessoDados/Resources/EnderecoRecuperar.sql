﻿SELECT EST.IDESTADO,
	   EST.CODESTADO,
       EST.DESESTADO,
       EST.NUMICMS,
	   EST.CODIBGE,
       C.IDCIDADE,
       C.DESCIDADE,
       C.CODCIDADE,
	   C.CODDDD,
       C.CODIBGE,
       B.IDBAIRRO,
       B.DESBAIRRO,
       B.CODBAIRRO,
       E.IDENDERECO,
       E.CODENDERECO,
       E.DESRUA,
       E.CODCEP
FROM INFM_ENDERECO E
INNER JOIN INFM_BAIRRO B ON B.IDBAIRRO = E.IDBAIRRO
INNER JOIN INFM_CIDADE C ON C.IDCIDADE = B.IDCIDADE
INNER JOIN INFM_ESTADO EST ON EST.IDESTADO = C.IDESTADO
{0}