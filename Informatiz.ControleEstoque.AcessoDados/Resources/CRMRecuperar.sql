﻿SELECT C.IDCRM
      ,C.IDPESSOACADASTRO
      ,C.IDPESSOACLIENTE
      ,C.CODCRM
      ,C.OBSCOMPROMISSO
      ,C.DESCRM
	  ,C.IDEMPRESA
      ,C.BOLATIVO
	  ,PC.DTHPROXAGENDAMENTO
	  ,PC.DTHPROXAGENDAMENTOFIN
	  ,PC.IDPESSOACRM
	  ,PC.IDGRUPOCOMPROMISSO
	  ,PC.DESAGENDAMENTO
FROM INFM_CRM C
INNER JOIN INFM_PESSOACRM PC ON PC.IDCRM = C.IDCRM
WHERE C.IDCRM = @IDCRM
ORDER BY PC.DESAGENDAMENTO
