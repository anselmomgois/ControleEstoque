﻿UPDATE INFM_ADMINISTRADORA
   SET DESADMINISTRADORA = @DESADMINISTRADORA
      ,DESTELADMINISTRADORA = @DESTELADMINISTRADORA
      ,OBSREFADMINISTRADORA = @OBSREFADMINISTRADORA
      ,NUMTARIFAPERCENT = @NUMTARIFAPERCENT
      ,NUMTARIFAVALOR = @NUMTARIFAVALOR
      ,NUMTARIFAANTPERCENT = @NUMTARIFAANTPERCENT
      ,NUMTARIFAANTVALOR = @NUMTARIFAANTVALOR
      ,NUMDESCONTPERCENT = @NUMDESCONTPERCENT
      ,NUMDESCONTVALOR = @NUMDESCONTVALOR
      ,BITIMGADMINISTRADORA = @BITIMGADMINISTRADORA
 WHERE IDADMINISTRADORA = @IDADMINISTRADORA