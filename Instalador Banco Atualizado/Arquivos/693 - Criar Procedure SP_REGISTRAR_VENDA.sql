QUERYVALIDACAO select 1 from sys.sysobjects o  where o.name = 'SP_REGISTRAR_VENDA'
BANCODEDADOS IGERENCE
CREATE PROCEDURE  [dbo].[SP_REGISTRAR_VENDA]  @IDVENDA VARCHAR(36),
											  @CODESTADOVENDA VARCHAR(20),
											  @IDPESSOACANCELAMENTO VARCHAR(36),
											  @CODCOMANDA VARCHAR(20),
											  @IDEMPRESA VARCHAR(36),
											  @IDENDERECOENTREGA VARCHAR(36),
											  @IDFILIAL VARCHAR(36),
											  @IDRESPONSAVELCAIXA VARCHAR(36),
											  @NUMQUANTIDADEPESSOAS INTEGER,
											  @IDPESSOACLIENTE VARCHAR(36),
											  @IDPESSOAENTREGADOR VARCHAR(36),
											  @OBSVENDA VARCHAR(500),
											  @NUMVALORSERVICO DECIMAL(10,2),
											  @NUMVALORTAXAENTREGA DECIMAL(10,2),
											  @IDPRODUTOSERVICO VARCHAR(36),
											  @QUANTIDADE DECIMAL(10,3),
											  @IDPESSOAVENDAITEM VARCHAR(36),
											  @NUMSEQUENCIA INTEGER, 
											  @NUMVALORACRESCIMO DECIMAL(10,2), 
											  @NUMVALORDESCONTO DECIMAL(10,2), 
											  @NUMVALORITEM DECIMAL(10,2), 
											  @NUMVALORTOTAL DECIMAL(10,2),
											  @BOLCOMANDA BIT,
											  @IDPRODUTOACRESCIMO VARCHAR(MAX),
											  @NUMQUANTIDADEACRESCIMO VARCHAR(MAX),
											  @NUMVALORPRODACRESCIMO VARCHAR(MAX),
											  @NUMVALORTOTALPRODACRESCIMO VARCHAR(MAX),
											  @IDOBSERVACAO VARCHAR(MAX),
											  @IDMESA VARCHAR(MAX),
											  @IDPESSOAVENDA VARCHAR(36)
											  
AS BEGIN

BEGIN TRANSACTION;
--SAVE TRANSACTION MYTRANSACTION;
DECLARE @MESAOCUPADA AS INTEGER
DECLARE @EXISTE AS INTEGER
DECLARE @EXISTEACRESCIMO AS INTEGER
DECLARE @EXISTEOBSERVACAO AS INTEGER
DECLARE @EXISTEMESA AS INTEGER
DECLARE @IDPRODUTOFILIAL AS VARCHAR(36)
DECLARE @IDITEMVENDA AS VARCHAR(36)
DECLARE @NUMESTOQUEFILIAL AS DECIMAL(10,3)
DECLARE @NUMESTOQUECOMPRA AS DECIMAL(10,3)
DECLARE @IDDATOSCOMPRAPROD AS VARCHAR(36)
DECLARE @NUMVALORTOTALCALCULADO AS DECIMAL(10,2) = 0
DECLARE @ERROR AS VARCHAR(MAX)
DECLARE @DESCRICAOPRODUTO AS VARCHAR(200)
DECLARE @MENSAGEM AS VARCHAR(MAX)
DECLARE @CODIGOCOMANDA AS INTEGER
DECLARE @NUMVALORTOTALACRESCIMOS AS DECIMAL(10,2) = 0

DECLARE CURSOR_ACRESCIMOS CURSOR FOR
SELECT VALUE
FROM STRING_SPLIT(@IDPRODUTOACRESCIMO, '|')

DECLARE CURSOR_CANT_ACRESCIMOS CURSOR FOR
SELECT VALUE
FROM STRING_SPLIT(@NUMQUANTIDADEACRESCIMO, '|')

DECLARE CURSOR_VALOR_ACRESCIMOS CURSOR FOR
SELECT VALUE
FROM STRING_SPLIT(@NUMVALORPRODACRESCIMO, '|')

DECLARE CURSOR_VALOR_T_ACRESCIMOS CURSOR FOR
SELECT VALUE
FROM STRING_SPLIT(@NUMVALORTOTALPRODACRESCIMO, '|')

DECLARE CURSOR_ITEMVENDA CURSOR FOR  
SELECT IV.IDITEMVENDA
FROM INFM_ITEMVENDA IV
WHERE IV.IDVENDA = @IDVENDA; 

BEGIN TRY

 --ROLLBACK TRANSACTION MYTRANSACTION;
SELECT @EXISTE = COUNT(*)
FROM INFM_VENDA V
WHERE V.IDVENDA = @IDVENDA;

IF (@CODESTADOVENDA = 'CA')

	IF (@EXISTE > 0)
	 BEGIN	 	 

	    SELECT @EXISTE = COUNT(*)
		FROM INFM_PAGAMENTO P
		WHERE P.IDVENDA = @IDVENDA
		
		IF(@EXISTE > 0)
		THROW 99001, 'Não é possivel cancelar a venda, pois existem items pagamentos.', 1;

		UPDATE INFM_VENDA
		SET
		COD_ESTADO = 'CA',
		CODESTADOVENDA = 'CA',
		IDPESSOACANCELAMENTO = @IDPESSOACANCELAMENTO,
		NUMDESCONTO = 0,
		NUMVALORSERVICO = 0,
		NUMVALORTAXAENTREGA = 0,
		NUMVALORTOTAL = 0,
		NUMVALORVENDA = 0
		WHERE
		IDVENDA = @IDVENDA

		
	OPEN CURSOR_ITEMVENDA 	
	 DECLARE @tempEstoque DECIMAL(10,3)
     DECLARE @tempID VARCHAR(36)
	 DECLARE @tempIDPF VARCHAR(36)
	 DECLARE @tempDadosCompra VARCHAR(36)
     FETCH NEXT FROM CURSOR_ITEMVENDA INTO @tempID
		 
	WHILE ( @@FETCH_STATUS = 0 )
    BEGIN
       

         SELECT  @tempIDPF = PF.IDPRODUTOFILIAL, @tempEstoque = IV.NUMQUANTIDADE
		 FROM INFM_PRODUTOFILIAL PF 
		 INNER JOIN INFM_ITEMVENDA IV ON IV.IDPRODUTOSERVICO = PF.IDPRODUTOSERVICO
		 INNER JOIN INFM_VENDA V ON V.IDVENDA = IV.IDVENDA AND PF.IDFILIAL = V.IDFILIAL
		 WHERE IV.IDITEMVENDA = @tempID

		 SELECT @tempDadosCompra = DC.IDDATOSCOMPRAPROD
		 FROM INFM_DATOSCOMPRAPROD DC
		 WHERE DC.IDPRODUTOFILIAL  = @tempIDPF AND DC.BOLESTOQUEATUAL = 1

		UPDATE INFM_PRODUTOFILIAL 
		SET
		NUMESTOQUE = NUMESTOQUE + @tempEstoque
		WHERE
		IDPRODUTOFILIAL = @tempIDPF

		UPDATE INFM_DATOSCOMPRAPROD
		SET
		NUMESTOQUE = NUMESTOQUE + @tempEstoque
		WHERE
		IDDATOSCOMPRAPROD = @tempDadosCompra

		FETCH NEXT FROM CURSOR_ITEMVENDA INTO @tempID
       END

		CLOSE CURSOR_ITEMVENDA 
		DEALLOCATE CURSOR_ITEMVENDA  
		--THROW 99001, 'teste', 1
	  END
	ELSE
	   -- SET @ERROR = 'Venda não encontrada para cancelamento.'
		THROW 99001, 'Venda não encontrada para cancelamento', 1;
ELSE

 BEGIN

 
if (object_id('tempdb..#ACRESCIMOS') is not null) drop table #ACRESCIMOS

CREATE TABLE #ACRESCIMOS (IDPRODUTOSERVICO VARCHAR(36),
						  NUMQUANTIDADEACRESCIMO DECIMAL(10,3),
						  NUMVALORPRODACRESCIMO DECIMAL(10,2),
						  NUMVALORTOTALPRODACRESCIMO DECIMAL(10,2));

SELECT @EXISTEACRESCIMO = COUNT(*)
FROM STRING_SPLIT(@IDPRODUTOACRESCIMO, '|');

IF @EXISTEACRESCIMO > 0
BEGIN

OPEN CURSOR_ACRESCIMOS
OPEN CURSOR_CANT_ACRESCIMOS
OPEN CURSOR_VALOR_ACRESCIMOS
OPEN CURSOR_VALOR_T_ACRESCIMOS

DECLARE @tempIDAcrescimos VARCHAR(MAX)
DECLARE @tempCantAcrescimo VARCHAR(20)
DECLARE @tempValorAcrescimo VARCHAR(20)
DECLARE @tempValorTotAcrescimo VARCHAR(20)
FETCH NEXT FROM CURSOR_ACRESCIMOS INTO @tempIDAcrescimos
FETCH NEXT FROM CURSOR_CANT_ACRESCIMOS INTO @tempCantAcrescimo
FETCH NEXT FROM CURSOR_VALOR_ACRESCIMOS INTO @tempValorAcrescimo
FETCH NEXT FROM CURSOR_VALOR_T_ACRESCIMOS INTO @tempValorTotAcrescimo

WHILE ( @@FETCH_STATUS = 0 )
BEGIN

INSERT INTO #ACRESCIMOS (IDPRODUTOSERVICO, NUMQUANTIDADEACRESCIMO, NUMVALORPRODACRESCIMO, NUMVALORTOTALPRODACRESCIMO)
VALUES
(@tempIDAcrescimos, CAST(REPLACE(@tempCantAcrescimo,',','.') AS DECIMAL(10,3)), 
CAST(REPLACE(@tempValorAcrescimo,',','.') AS DECIMAL(10,2)),CAST(REPLACE(@tempValorTotAcrescimo,',','.')  AS DECIMAL(10,2)))

FETCH NEXT FROM CURSOR_ACRESCIMOS INTO @tempIDAcrescimos
FETCH NEXT FROM CURSOR_CANT_ACRESCIMOS INTO @tempCantAcrescimo
FETCH NEXT FROM CURSOR_VALOR_ACRESCIMOS INTO @tempValorAcrescimo
FETCH NEXT FROM CURSOR_VALOR_T_ACRESCIMOS INTO @tempValorTotAcrescimo
END

CLOSE CURSOR_ACRESCIMOS 
CLOSE CURSOR_CANT_ACRESCIMOS
CLOSE CURSOR_VALOR_ACRESCIMOS
CLOSE CURSOR_VALOR_T_ACRESCIMOS
DEALLOCATE CURSOR_ACRESCIMOS
DEALLOCATE CURSOR_CANT_ACRESCIMOS
DEALLOCATE CURSOR_VALOR_ACRESCIMOS
DEALLOCATE CURSOR_VALOR_T_ACRESCIMOS

SELECT @EXISTEACRESCIMO = COUNT(*)
FROM #ACRESCIMOS;

SELECT @NUMVALORTOTALACRESCIMOS = SUM(NUMVALORTOTALPRODACRESCIMO)
FROM #ACRESCIMOS;

END;

            IF @NUMVALORTOTAL IS NOT NULL
			SET @NUMVALORTOTALCALCULADO = @NUMVALORTOTAL + @NUMVALORTOTALACRESCIMOS;

			IF @NUMVALORSERVICO IS NOT NULL
			 SET @NUMVALORTOTALCALCULADO = @NUMVALORTOTALCALCULADO + @NUMVALORSERVICO;

			 IF @NUMVALORTAXAENTREGA IS NOT NULL
			 SET @NUMVALORTOTALCALCULADO = @NUMVALORTOTALCALCULADO + @NUMVALORTAXAENTREGA;
			 			 
		IF (@EXISTE > 0)		
		  BEGIN
		 
		  UPDATE INFM_VENDA
		  SET
		  NUMVALORVENDA = (NUMVALORVENDA + @NUMVALORTOTAL + @NUMVALORTOTALACRESCIMOS),
		  NUMVALORSERVICO = @NUMVALORSERVICO, 
		  NUMVALORTAXAENTREGA = @NUMVALORTAXAENTREGA, 
		  NUMVALORTOTAL = (NUMVALORVENDA + @NUMVALORTOTALCALCULADO),
		  COD_ESTADO = @CODESTADOVENDA,
		  CODESTADOVENDA = @CODESTADOVENDA,
		  IDPESSOACLIENTE = @IDPESSOACLIENTE,
		  IDENDERECOENTREGA = @IDENDERECOENTREGA,
		  IDPESSOAENTREGADOR = @IDPESSOAENTREGADOR
		  WHERE
		  IDVENDA = @IDVENDA	
		  	
        END
  		ELSE
		 BEGIN
		   SET @IDVENDA = NEWID()			  

		   IF(@BOLCOMANDA = 1 AND (@CODCOMANDA IS NULL OR @CODCOMANDA = ''))
		   BEGIN
			 SELECT @CODIGOCOMANDA = NEXT VALUE FOR INFM_SEQ_COMANDA;
		   END
		   ELSE
		   BEGIN
		   SET @CODIGOCOMANDA = @CODCOMANDA;
		   END;

			INSERT INTO INFM_VENDA (COD_ESTADO,
									CODCOMANDA,
									CODESTADOVENDA,
									DTHVENDAINICIO,
									IDEMPRESA,
									IDENDERECOENTREGA,
									IDFILIAL,
									IDRESPONSAVELCAIXA,
									IDVENDA,
									NUMQUANTIDADEPESSOAS,
									OBSVENDA,
									NUMVALORVENDA,
									NUMVALORSERVICO,
									NUMVALORTAXAENTREGA,
									NUMVALORTOTAL,
									IDPESSOACLIENTE,
									IDPESSOAENTREGADOR,
									IDPESSOAVENDA)
						VALUES     ('EC',
									@CODIGOCOMANDA,
									'EC',
									GETDATE(),
									@IDEMPRESA,
									@IDENDERECOENTREGA,
									@IDFILIAL,
									@IDRESPONSAVELCAIXA,
									@IDVENDA,
									@NUMQUANTIDADEPESSOAS,
									@OBSVENDA,
									@NUMVALORTOTAL + @NUMVALORTOTALACRESCIMOS,
									@NUMVALORSERVICO,
									@NUMVALORTAXAENTREGA,
									@NUMVALORTOTALCALCULADO,
									@IDPESSOACLIENTE,
									@IDPESSOAENTREGADOR,
									@IDPESSOAVENDA);

				SELECT @EXISTEMESA = COUNT(1)
				FROM STRING_SPLIT(@IDMESA, '|')

				IF(@EXISTEMESA > 0)
				BEGIN

				SELECT @MESAOCUPADA = COUNT(1)
				FROM INFM_MESA M
				INNER JOIN STRING_SPLIT(@IDMESA, '|') I ON I.value = M.IDMESA 
				WHERE CODESTADO <> 'LI' AND CODESTADO <> 'RE'

				IF @MESAOCUPADA > 0
					THROW 99001, 'A mesa selecionada está ocupada.', 1;

				INSERT INTO INFM_MESAVENDA(IDMESAVENDA,IDMESA,IDVENDA)
				SELECT NEWID(), VALUE, @IDVENDA
				FROM STRING_SPLIT(@IDMESA, '|')

				UPDATE INFM_MESA
				SET
				CODESTADO = 'OC'
				WHERE
				IDMESA IN (SELECT  VALUE
				FROM STRING_SPLIT(@IDMESA, '|'))

				END;

        END;
					
					SELECT @IDPRODUTOFILIAL = PF.IDPRODUTOFILIAL,
						   @NUMESTOQUEFILIAL = PF.NUMESTOQUE,
						   @DESCRICAOPRODUTO = PS.DESPRODUTO
					FROM INFM_PRODUTOFILIAL PF
					INNER JOIN INFM_PRODUTOSERVICO PS ON PS.IDPRODUTOSERVICO = PF.IDPRODUTOSERVICO
					WHERE PS.IDPRODUTOSERVICO = @IDPRODUTOSERVICO AND
						  PF.IDFILIAL = @IDFILIAL
	
	                SET @MENSAGEM = 'Produto ' + @DESCRICAOPRODUTO + ' sem estoque'
					IF @NUMESTOQUEFILIAL < @QUANTIDADE
					THROW 99001, @MENSAGEM, 1;					
					ELSE
						UPDATE INFM_PRODUTOFILIAL
						SET
						NUMESTOQUE = (@NUMESTOQUEFILIAL - @QUANTIDADE)
						WHERE
						IDPRODUTOFILIAL = @IDPRODUTOFILIAL;

					SELECT  @IDDATOSCOMPRAPROD = IDDATOSCOMPRAPROD,
						   @NUMESTOQUECOMPRA = NUMESTOQUE
					FROM INFM_DATOSCOMPRAPROD
					WHERE IDPRODUTOFILIAL = @IDPRODUTOFILIAL AND BOLESTOQUEATUAL = 1
										

					IF @IDDATOSCOMPRAPROD IS NOT NULL 
			            
						 IF @NUMESTOQUECOMPRA > @QUANTIDADE
						 BEGIN
						 UPDATE INFM_DATOSCOMPRAPROD
						  SET
						  NUMESTOQUE = (@NUMESTOQUECOMPRA - @QUANTIDADE)
						  WHERE
						  IDDATOSCOMPRAPROD = @IDDATOSCOMPRAPROD
						  END
						 ELSE
						 BEGIN
						 EXEC SP_ATUALIZARESTOQUECOMPRA @IDPRODUTOFILIAL, @QUANTIDADE
						 END;
					ELSE
					THROW 99001, 'Estoque atual não definido', 1;			        			
	                
					SET @IDITEMVENDA = NEWID()

					INSERT INTO INFM_ITEMVENDA (BOLCANCELADO, 
												CODESTADO, 
												IDITEMVENDA, 
												IDPESSOAVENDA, 
												IDPRODUTOSERVICO, 
												IDVENDA, 
												NUMQUANTIDADE, 
												NUMSEQUENCIA, 
												NUMVALORACRESCIMO, 
												NUMVALORDESCONTO, 
												NUMVALORITEM, 
												NUMVALORTOTAL)
										VALUES (0,
												'RE',
												@IDITEMVENDA,
												@IDPESSOAVENDAITEM,
												@IDPRODUTOSERVICO,
												@IDVENDA,
												@QUANTIDADE,
												@NUMSEQUENCIA,
												@NUMVALORACRESCIMO,
												@NUMVALORDESCONTO,
												@NUMVALORITEM,
												@NUMVALORTOTAL)

        IF (@EXISTEACRESCIMO > 0)
		BEGIN
		
		INSERT INTO INFM_ITEMVENDAACRESCIMO(IDACRESCIMO, IDITEMVENDA, IDITEMVENDAACRESCIMO, NUMQUANTIDADE, NUMVALOR, NUMVALORTOTAL)
		SELECT A.IDPRODUTOSERVICO, @IDITEMVENDA, NEWID(), A.NUMQUANTIDADEACRESCIMO, A.NUMVALORPRODACRESCIMO,A.NUMVALORTOTALPRODACRESCIMO
		FROM #ACRESCIMOS A
	
		END;
	    
		SELECT @EXISTEOBSERVACAO = COUNT(1)
		FROM STRING_SPLIT(@IDOBSERVACAO, '|')

		IF(@EXISTEOBSERVACAO > 0)
		BEGIN
		INSERT INTO INFM_ITEMVENDAOBSERVACAO(IDITEMVENDAOBSERVACAO,IDOBSERVACAO,IDITEMVENDA)
		SELECT NEWID(), VALUE, @IDITEMVENDA
		FROM STRING_SPLIT(@IDOBSERVACAO, '|')

		END;
				SELECT V.CODCOMANDA
				FROM INFM_VENDA V
				WHERE V.IDVENDA = @IDVENDA
			

END
	COMMIT TRANSACTION 
 END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
		   ROLLBACK TRANSACTION; -- rollback to MySavePoint
        END
		 SELECT @ERROR = ERROR_MESSAGE(); 
		THROW 99001, @ERROR, 1;
    END CATCH
   --INSERT INTO INFM_DEBUG(DES_ERRO) VALUES (@ERROR)
END;