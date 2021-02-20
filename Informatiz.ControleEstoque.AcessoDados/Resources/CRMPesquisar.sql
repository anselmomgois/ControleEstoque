﻿SELECT DISTINCT C.IDCRM
      ,C.IDPESSOACADASTRO
      ,C.IDPESSOACLIENTE
      ,C.CODCRM
      ,C.OBSCOMPROMISSO
      ,C.DESCRM
      ,C.BOLATIVO
	  ,PC.DTHPROXAGENDAMENTO
	  ,PC.DTHPROXAGENDAMENTOFIN
	  ,PC.IDPESSOACRM
	  ,PC.IDGRUPOCOMPROMISSO
	  ,PC.DESAGENDAMENTO
FROM INFM_CRM C
INNER JOIN INFM_PESSOACRM PC ON PC.IDCRM = C.IDCRM
INNER JOIN INFM_PESSOACRM PC1 ON PC1.IDCRM = C.IDCRM
INNER JOIN INFM_PESSOACRMPESSOA PCP ON PCP.IDPESSOACRM = PC.IDPESSOACRM
WHERE C.IDEMPRESA = @IDEMPRESA {0}
ORDER BY PC.DTHPROXAGENDAMENTO

