﻿INSERT INTO INFM_PRODUTOPROMOCAO
           (IDPRODUTOPROMOCAO
           ,DESPRODUTOPROMOCAO
           ,NUMPROMOCAOPER
           ,NUMPROMOCAOVALOR
           ,BOLHABILITADA
           ,DTHINICIO
           ,DTHFIM
		   ,CODTIPOPROMOCAO
		   ,IDEMPRESA
		   ,IDFILIAL
		   ,BOL_POR_HORARIO)
     VALUES
           (@IDPRODUTOPROMOCAO
           ,@DESPRODUTOPROMOCAO
           ,@NUMPROMOCAOPER
           ,@NUMPROMOCAOVALOR
           ,@BOLHABILITADA
           ,@DTHINICIO
           ,@DTHFIM
		   ,@CODTIPOPROMOCAO
		   ,@IDEMPRESA
		   ,@IDFILIAL
		   ,@BOL_POR_HORARIO)