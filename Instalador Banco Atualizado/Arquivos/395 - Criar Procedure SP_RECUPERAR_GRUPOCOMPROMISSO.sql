QUERYVALIDACAO select 1 from sys.sysobjects o  where o.name = 'SP_RECUPERAR_GRUPOCOMPROMISSO'
BANCODEDADOS IGERENCE
CREATE PROCEDURE SP_RECUPERAR_GRUPOCOMPROMISSO @NELNIVEL INTEGER
AS

DECLARE @EXISTE INTEGER
DECLARE @NELNIVELATUAL INTEGER

SELECT @EXISTE = COUNT(*)
FROM #GRUPOCRM GC
INNER JOIN INFM_GRUPOCOMPROMISSOSUBGRUPO GCSG ON GC.IDGRUPOCOMPROMISSO = GCSG.IDGRUPOCOMPROMISSOPAI
WHERE GC.NELNIVEL =  @NELNIVEL AND 	GCSG.IDGRUPOCOMPROMISSOPAI IS NOT NULL

IF (@EXISTE > 0 )

BEGIN
SET @NELNIVELATUAL = @NELNIVEL + 1

INSERT INTO #GRUPOCRM
SELECT DISTINCT GCA.CODGRUPOCOMPROMISSO,
                GCA.DESGRUPOCOMPROMISSO,
				GCA.IDGRUPOCOMPROMISSO,
				GCSG.IDGRUPOCOMPROMISSOPAI,
				@NELNIVELATUAL NELNIVEL
FROM #GRUPOCRM GC
INNER JOIN INFM_GRUPOCOMPROMISSOSUBGRUPO GCSG ON GC.IDGRUPOCOMPROMISSO = GCSG.IDGRUPOCOMPROMISSOPAI
INNER JOIN INFM_GRUPOCOMPROMISSO GCA ON GCA.IDGRUPOCOMPROMISSO =  GCSG.IDGRUPOCOMPROMISSO
WHERE GC.NELNIVEL =  @NELNIVEL AND 	GCSG.IDGRUPOCOMPROMISSOPAI IS NOT NULL

EXEC SP_RECUPERAR_GRUPOCOMPROMISSO @NELNIVELATUAL

END