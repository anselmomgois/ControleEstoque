﻿SELECT 1
FROM INFM_PRODUTOSERVICO AS PS
INNER JOIN INFM_COR AS C ON C.IDCOR = PS.IDCOR
WHERE C.IDCOR = @IDCOR