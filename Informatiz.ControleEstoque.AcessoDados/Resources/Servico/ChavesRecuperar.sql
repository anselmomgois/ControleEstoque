﻿SELECT IDLICENCA
      ,CODLICENCA
      ,SESSOESINFINITAS
      ,NUMQUANTIDADESESSOES
      ,NUMVALIDADE
      ,VALIDADEINFINITA
	  ,NUMQUANTIDADEACESSOS
	  ,DATAATIVACAO
  FROM INFM_LICENCA
  WHERE CHAVEATIVA = @CHAVEATIVA

