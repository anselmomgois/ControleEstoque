﻿SELECT IDGRUPOPERMISSAO
      ,DESGRUPO
FROM INFM_GRUPOPERMISSAO
WHERE IDEMPRESA = @IDEMPRESA AND DESGRUPO LIKE @DESGRUPO