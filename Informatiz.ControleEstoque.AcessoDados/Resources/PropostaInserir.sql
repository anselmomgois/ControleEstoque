﻿INSERT INTO INFM_PROPOSTA
           (IDPROPOSTA
           ,IDCRM
           ,IDEMPRESA
           ,DESPROPOSTA
           ,NUMPROPOSTAVENDA
           ,NUMPROPOSTAMANUTENCAO
           ,NUMCONTRAPROPOSTAVENDA
           ,NUMCONTRAPROPOSTAMANUT
           ,DESOPNIAO
           ,DESDUVIDA
           ,BOLATENDENECESSIDADE
           ,DTINSTALACAO
           ,BOLATIVA
           ,IDPESSOA
           ,IDPESSOACLIENTE)
     VALUES
           (@IDPROPOSTA
           ,@IDCRM
           ,@IDEMPRESA
           ,@DESPROPOSTA
           ,@NUMPROPOSTAVENDA
           ,@NUMPROPOSTAMANUTENCAO
           ,@NUMCONTRAPROPOSTAVENDA
           ,@NUMCONTRAPROPOSTAMANUT
           ,@DESOPNIAO
           ,@DESDUVIDA
           ,@BOLATENDENECESSIDADE
           ,@DTINSTALACAO
           ,@BOLATIVA
           ,@IDPESSOA
           ,@IDPESSOACLIENTE)