﻿SELECT IDUNIDADEMEDIDA
      ,IDUNIDADEMEDIDAPAI
      ,CODUNIDADEMEDIDA
      ,NUMUNIDADEPAI
      ,DESUNIDADEMEDIDA
FROM INFM_UNIDADEMEDIDA
WHERE IDEMPRESA = @IDEMPRESA