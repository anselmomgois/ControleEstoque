﻿SELECT C.IDCIDADE
      ,E.IDESTADO
      ,C.DESCIDADE
      ,C.CODCIDADE
      ,C.CODDDD
      ,C.CODIBGE
  FROM INFM_CIDADE AS C
  INNER JOIN INFM_ESTADO AS E ON E.IDESTADO = C.IDESTADO