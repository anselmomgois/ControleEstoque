﻿SELECT IDADMINISTRADORA
      ,CODADMINISTRADORA
      ,DESADMINISTRADORA
      ,DESTELADMINISTRADORA
      ,OBSREFADMINISTRADORA
      ,NUMTARIFAPERCENT
      ,NUMTARIFAVALOR
      ,NUMTARIFAANTPERCENT
      ,NUMTARIFAANTVALOR
      ,NUMDESCONTPERCENT
      ,NUMDESCONTVALOR
      ,BITIMGADMINISTRADORA
FROM INFM_ADMINISTRADORA
WHERE IDADMINISTRADORA = @IDADMINISTRADORA