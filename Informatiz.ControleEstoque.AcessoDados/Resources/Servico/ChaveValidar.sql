﻿SELECT 1
FROM INFM_LICENCA AS L
INNER JOIN INFM_EMPRESA AS E ON E.IDLICENCA = L.IDLICENCA
WHERE E.CODEMPRESA = @CODEMPRESA AND L.CODLICENCA = @CODLICENCA AND L.CHAVEATIVA = @CHAVEATIVA

