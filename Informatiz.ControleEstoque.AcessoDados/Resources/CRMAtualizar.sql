﻿UPDATE INFM_CRM
   SET IDPESSOACADASTRO = @IDPESSOACADASTRO
      ,IDPESSOACLIENTE = @IDPESSOACLIENTE
      ,OBSCOMPROMISSO = @OBSCOMPROMISSO
      ,DESCRM = @DESCRM
      ,BOLATIVO = @BOLATIVO
	  ,IDSTATUSCRM = @IDSTATUSCRM
	  ,IDTIPOCRM = @IDTIPOCRM
 WHERE IDCRM = @IDCRM