﻿SELECT PS.IDPRODUTOSERVICO
      ,PS.IDTIPOPRODUTO
      ,PS.IDGRUPOPRODUTO
      ,PS.IDCOR
      ,PS.IDPRODUTODERIVACAO
      ,PS.IDPRODCATEGORIA
      ,PS.IDPRODUTOMARCA
      ,PS.IDEMPRESA
      ,PS.CODPRODUTO
      ,PS.DESPRODUTO
      ,PS.OBSPRODUTO
      ,PS.NUMPESOPRODUTO
      ,PS.BITIMGPRODUTO
	  ,PS.IDPRODUTONCM
	  ,PS.IDPRODUTOCST
	  ,PS.IDPRODUTOCFOP
	  ,PS.BOLVENDAAGRANEL    
	  ,PS.BOLINTERNO         
	  ,PS.BOLACRESCIMO       
	  ,PS.BOLVENDANUMEROSERIE
	  ,CB.DESCODBARRAS
	  ,CB.IDCODIGOBARRASPRODSERV
	  ,ACPR.IDACRESCIMO
	  ,O.IDOBSERVACAO
  FROM INFM_PRODUTOSERVICO PS
  LEFT JOIN INFM_CODIGOBARRASPRODSERV CB ON CB.IDPRODUTOSERVICO = PS.IDPRODUTOSERVICO
  LEFT JOIN INFM_ACRESCIMOPRODUTO ACPR ON ACPR.IDPRODUTOSERVICO = PS.IDPRODUTOSERVICO
  LEFT JOIN INFM_OBSERVACAOPRODUTO O ON O.IDPRODUTOSERVICO = PS.IDPRODUTOSERVICO
  WHERE PS.IDPRODUTOSERVICO = @IDPRODUTOSERVICO