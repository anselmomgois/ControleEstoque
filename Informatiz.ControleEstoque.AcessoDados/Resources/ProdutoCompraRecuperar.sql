﻿SELECT IDDATOSCOMPRAPROD
      ,IDPESSOA
      ,IDUNIDADEMEDIDA
      ,IDPRODUTOFILIAL
      ,DTHCOMPRA
      ,NUMUNIDADECOMPRA
      ,NUMUNIDADEVENDA
      ,NUMVALORCOMPRA
      ,NUMVENDA1
      ,NUMVENDA2
      ,NUMVENDA3
      ,NUMESTOQUE
FROM INFM_DATOSCOMPRAPROD
WHERE IDDATOSCOMPRAPROD = @IDDATOSCOMPRAPROD