﻿SELECT IDLICENCA
      ,CODLICENCA
      ,SESSOESINFINITAS
      ,NUMQUANTIDADESESSOES
      ,NUMVALIDADE
      ,VALIDADEINFINITA
      ,CHAVEATIVA
	  ,NUMQUANTIDADEACESSOS
	  ,DATAATIVACAO
FROM INFM_LICENCA
WHERE IDLICENCA = @IDLICENCA