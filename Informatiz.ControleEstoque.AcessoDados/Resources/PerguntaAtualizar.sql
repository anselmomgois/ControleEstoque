﻿UPDATE INFM_PERGUNTAS
   SET DESPERGUNTA = @DESPERGUNTA
      ,BOLOBRIGATORIA = @BOLOBRIGATORIA
      ,CODTIPOCOMPONENTE = @CODTIPOCOMPONENTE
      ,BOLNUMERICO = @BOLNUMERICO
 WHERE IDPERGUNTA = @IDPERGUNTA