﻿UPDATE INFM_PRODUTOCST
   SET DESPRODUTOCST = @DESPRODUTOCST
      ,CODCST = @CODCST
      ,BOLTEMST = @BOLTEMST
      ,OBSMSGNOTAFISCAL = @OBSMSGNOTAFISCAL
 WHERE IDPRODUTOCST = @IDPRODUTOCST