﻿UPDATE INFM_FILIAL
   SET IDENDERECO = @IDENDERECO
      ,IDPESSOA = @IDPESSOA
      ,DESFILIAL = @DESFILIAL
      ,BOLMATRIZ = @BOLMATRIZ
      ,NUMENDERECO = @NUMENDERECO
      ,DESCOMPENDERECO = @DESCOMPENDERECO
      ,DESPONTREFENDERECO = @DESPONTREFENDERECO
      ,DTHABERTURA = @DTHABERTURA
      ,DESTELEFONEFIXO = @DESTELEFONEFIXO
      ,DESTELEFONEFAX = @DESTELEFONEFAX
      ,DESTELEFONECEL = @DESTELEFONECEL
      ,OBSFILIAL = @OBSFILIAL
      ,DESEMAIL = @DESEMAIL
      ,NUMPISPER = @NUMPISPER
      ,NUMCONFINSPER = @NUMCONFINSPER
      ,NUMOUTDESPPER = @NUMOUTDESPPER
      ,NUMCONTSOCPER = @NUMCONTSOCPER
      ,CODTABMERCADORIA = @CODTABMERCADORIA
	  ,BOLATIVA = @BOLATIVA
 WHERE IDFILIAL = @IDFILIAL