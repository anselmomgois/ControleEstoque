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
      ,PS.DESCODBARRAS
      ,PS.OBSPRODUTO
      ,PS.NUMPESOPRODUTO
      ,PS.BITIMGPRODUTO
	  ,PS.IDPRODUTONCM
	  ,PS.IDPRODUTOCST
	  ,PS.IDPRODUTOCFOP
	  ,PF.IDPRODUTOFILIAL
  FROM INFM_PRODUTOSERVICO AS PS
  INNER JOIN INFM_PRODUTOFILIAL AS PF ON PF.IDPRODUTOSERVICO = PS.IDPRODUTOSERVICO
  INNER JOIN INFM_DATOSCOMPRAPROD AS DCP ON DCP.IDPRODUTOFILIAL = PF.IDPRODUTOFILIAL
  WHERE DCP.IDDATOSCOMPRAPROD = @IDDATOSCOMPRAPROD