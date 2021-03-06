INSERT INTO INFM_TIPOPESSOA
           (IDTIPOPESSOA
           ,DESTIPOPESSOA
           ,CODTIPOPESSOA)
     VALUES
           (1
           ,'Funcionario'
           ,1);

INSERT INTO INFM_TIPOPESSOA
           (IDTIPOPESSOA
           ,DESTIPOPESSOA
           ,CODTIPOPESSOA)
     VALUES
           (2
           ,'Cliente'
           ,2);

INSERT INTO INFM_TIPOPESSOA
           (IDTIPOPESSOA
           ,DESTIPOPESSOA
           ,CODTIPOPESSOA)
     VALUES
           (3
           ,'Fornecedor'
           ,3);

INSERT INTO INFM_EMPRESA
           (IDEMPRESA
           ,DESEMPRESA
           ,DESCNPJ
           ,DESINSCRICAOESTADUAL
           ,CODACESSO)
     VALUES
           (1
           ,'AMG SISTEMAS'
           ,NULL
           ,NULL
           ,'1');

INSERT INTO INFM_FILIAL
           (IDFILIAL
           ,IDEMPRESA
           ,IDENDERECO
           ,IDPESSOA
           ,DESFILIAL
           ,BOLMATRIZ
           ,NUMENDERECO
           ,DESCOMPENDERECO
           ,DESPONTREFENDERECO
           ,DTHABERTURA
           ,DESTELEFONEFIXO
           ,DESTELEFONEFAX
           ,DESTELEFONECEL
           ,OBSFILIAL
           ,DESEMAIL
           ,NUMPISPER
           ,NUMCONFINSPER
           ,NUMOUTDESPPER
           ,NUMCONTSOCPER
           ,CODTABMERCADORIA)
     VALUES
           (1
           ,1
           ,NULL
           ,NULL
           ,'MATRIZ'
           ,1
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL);

INSERT INTO INFM_FILIAL
           (IDFILIAL
           ,IDEMPRESA
           ,IDENDERECO
           ,IDPESSOA
           ,DESFILIAL
           ,BOLMATRIZ
           ,NUMENDERECO
           ,DESCOMPENDERECO
           ,DESPONTREFENDERECO
           ,DTHABERTURA
           ,DESTELEFONEFIXO
           ,DESTELEFONEFAX
           ,DESTELEFONECEL
           ,OBSFILIAL
           ,DESEMAIL
           ,NUMPISPER
           ,NUMCONFINSPER
           ,NUMOUTDESPPER
           ,NUMCONTSOCPER
           ,CODTABMERCADORIA)
     VALUES
           (2
           ,1
           ,NULL
           ,NULL
           ,'MATRIZ 1'
           ,0
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL);

INSERT INTO INFM_PESSOA
           (IDENDERECO
           ,IDPESSOA
           ,IDSITUACAOPESSOA
           ,IDPESSOARESPONSAVEL
           ,IDSEGMENTOCOMERCIAL
           ,IDENDERECOEMPRESA
           ,DESNOME
           ,DESNOMEFANTASIA
           ,DESRG
           ,DTHNASCIMENTO
           ,DESCPF
           ,DESCNPJ
           ,DTHCADASTRO
           ,DESINSCRICAOESTADUAL
           ,DESTELEFONEFIXO
           ,DESTELEFONEFAX
           ,DESTELEFONECELULAR
           ,DESHABILITACAO
           ,NUMCOMISSAO
           ,NUMSALARIO
           ,DTHADMISSAO
           ,DESCONTATO
           ,OBSPESSOA
           ,NUMLIMITE
           ,DESEMAIL
           ,DESNOMEPAI
           ,DESNOMEMAE
           ,DESEMPRESA
           ,DESFONEEMPRESA
           ,DESCARGO
           ,OBSREFPESSOAL
           ,DTHALMOCOINICIO
           ,DTHALMOCOFIM
           ,CODLOGIN
           ,DESSENHA
           ,CODTABMERCADORIA
           ,BOLALTERARSENHA
	   ,BOLFUNICIONARIOATIVO
	   ,BOLFORNECEDORATIVO
	   ,NUMENDERECO
	   ,DESCOMPLEMENTOENDER
	   ,DESPONTOREFERENCIA
	   ,CODTABELAMERCADORIA
	   ,NUMENDERECOEMP
	   ,DESCOMPLEMENTOENDEREMP
	   ,DESPONTOREFERENCIAEMP)
     VALUES
           (NULL
           ,'1'
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,'Administrador'
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,'administrador'
           ,'1'
           ,NULL
           ,1
	   ,1
           ,0
	   ,NULL
	   ,NULL
	   ,NULL
	   ,NULL
	   ,NULL
	   ,NULL
	   ,NULL);

INSERT INTO INFM_FILIALPESSOA
           (IDFILIALPESSOA
           ,IDFILIAL
           ,IDPESSOA)
     VALUES
           ('1'
           ,'1'
           ,'1');

INSERT INTO INFM_FILIALPESSOA
           (IDFILIALPESSOA
           ,IDFILIAL
           ,IDPESSOA)
     VALUES
           ('2'
           ,'2'
           ,'1');

INSERT INTO INFM_TIPOPESSOA_PESSOA
           (IDTIPOPESSOAPESSOA
           ,IDTIPOPESSOA
           ,IDPESSOA)
     VALUES
           ('1'
           ,'1'
           ,'1');

INSERT INTO INFM_ACAO
           (IDACAO
           ,CODACAO
           ,DESACAO)
     VALUES
           ('1'
           ,'1'
           ,'Inserir');

INSERT INTO INFM_ACAO
           (IDACAO
           ,CODACAO
           ,DESACAO)
     VALUES
           ('2'
           ,'2'
           ,'Modificar');

INSERT INTO INFM_ACAO
           (IDACAO
           ,CODACAO
           ,DESACAO)
     VALUES
           ('3'
           ,'3'
           ,'Consultar');

INSERT INTO INFM_ACAO
           (IDACAO
           ,CODACAO
           ,DESACAO)
     VALUES
           ('4'
           ,'4'
           ,'Excluir');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('1'
           ,'PRINCIPAL'
           ,'Tela Principal'
		   ,1);

INSERT INTO INFM_PERMISSAOACAO
           (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('1'
           ,'1'
           ,'3');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('2'
           ,'FUNCIONARIO'
           ,'Tela de Funcionários'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
           (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('2'
           ,'2'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('3'
           ,'2'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('4'
           ,'2'
           ,'3');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('5'
           ,'2'
           ,'4');
INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('3'
           ,'CLIENTE'
           ,'Tela de Clientes'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
           (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('6'
           ,'3'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('7'
           ,'3'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('8'
           ,'3'
           ,'3');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('4'
           ,'FORNECEDOR'
           ,'Tela de Fornecedor'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
           (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('9'
           ,'4'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('10'
           ,'4'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('11'
           ,'4'
           ,'3');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('12'
           ,'4'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('5'
           ,'GRUPOPERMISSAO'
           ,'Tela de Grupo de Permissões'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
           (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('13'
           ,'5'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('14'
           ,'5'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('15'
           ,'5'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('6'
           ,'PERMISSOUSUSUARIO'
           ,'Tela Permissões do Usuário'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('17'
           ,'6'
           ,'2');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('7'
           ,'ENDERECO'
           ,'Tela Configuração de Endereço'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('20'
           ,'7'
           ,'2');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('8'
           ,'COR'
           ,'Tela Cores'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('21'
           ,'8'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('22'
           ,'8'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('23'
           ,'8'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('9'
           ,'UNIDADEMEDIDA'
           ,'Tela Unidade de Medida'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('24'
           ,'9'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('25'
           ,'9'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('26'
           ,'9'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('10'
           ,'PRODUTOCATEGORIA'
           ,'Tela Categoria de Produtos e Serviços'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('27'
           ,'10'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('28'
           ,'10'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('29'
           ,'10'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('11'
           ,'PRODUTOMARCA'
           ,'Tela Cadastro de Marcas'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('30'
           ,'11'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('31'
           ,'11'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('32'
           ,'11'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('12'
           ,'PRODUTODERIVACAO'
           ,'Tela Cadastro de Derivações'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('33'
           ,'12'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('34'
           ,'12'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('35'
           ,'12'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('13'
           ,'GRUPOPRODUTO'
           ,'Tela Cadastro de Grupo de Produtos'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('36'
           ,'13'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('37'
           ,'13'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('38'
           ,'13'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('14'
           ,'PRODUTOSERVICO'
           ,'Tela Cadastro de Produtos e Serviços'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('39'
           ,'14'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('40'
           ,'14'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('41'
           ,'14'
           ,'3');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('42'
           ,'14'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('15'
           ,'PRODUTOCOMISSAO'
           ,'Tela Cadastro de Comissões'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('43'
           ,'15'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('44'
           ,'15'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('45'
           ,'15'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('16'
           ,'PRODUTOCST'
           ,'Tela Cadastro de Código Situação Tributária'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('46'
           ,'16'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('47'
           ,'16'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('48'
           ,'16'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('17'
           ,'PRODUTOCFOP'
           ,'Tela Cadastro de Operações e Prestações'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('49'
           ,'17'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('50'
           ,'17'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('51'
           ,'17'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('18'
           ,'PRODUTONCM'
           ,'Tela Cadastro de Código NCM'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('52'
           ,'18'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('53'
           ,'18'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('54'
           ,'18'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('19'
           ,'PRODUTOPROMOCAO'
           ,'Tela Cadastro de Promoções'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('55'
           ,'19'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('56'
           ,'19'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('57'
           ,'19'
           ,'3');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('58'
           ,'19'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('20'
           ,'RELATORIOESTOQUE'
           ,'Relatório de Estoque'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('59'
           ,'20'
           ,'3');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('21'
           ,'EMPRESA'
           ,'Tela de Informações da Empresa'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('60'
           ,'21'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('61'
           ,'21'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('63'
           ,'21'
           ,'3');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('64'
           ,'21'
           ,'4');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('22'
           ,'RELATORIOPESSOAS'
           ,'Relatório de Pessoas'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('65'
           ,'22'
           ,'3');

INSERT INTO INFM_PERMISSAO
           (IDPERMISSAO
           ,CODPERMISSAO
           ,DESPERMISSAO
		   ,BOLOBRIGATORIA)
     VALUES
           ('23'
           ,'SEGMENTOCOMERCIAL'
           ,'Tela Cadastro de Segmento Comercial'
		   ,0);

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('66'
           ,'23'
           ,'1');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('67'
           ,'23'
           ,'2');

INSERT INTO INFM_PERMISSAOACAO
          (IDPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO)
     VALUES
           ('68'
           ,'23'
           ,'4');

INSERT INTO INFM_USUPERMISSAOACAO
           (IDUSUPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO
           ,IDPESSOA
           ,IDGRUPOPERMISSAO)
     VALUES
           ('1'
           ,'1'
           ,'3'
           ,'1'
		   ,NULL);

INSERT INTO INFM_USUPERMISSAOACAO
           (IDUSUPERMISSAOACAO
           ,IDPERMISSAO
           ,IDACAO
           ,IDPESSOA
           ,IDGRUPOPERMISSAO)
     VALUES
           ('2'
           ,'6'
           ,'2'
           ,'1'
		   ,NULL);

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('1',
             'AC',
             'ACRE');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('2',
             'AC',
             'ACRE');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('3',
             'AL',
             'ALAGOAS');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('4',
             'AP',
             'AMAPA');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('5',
             'AM',
             'AMAZONAS');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('6',
             'BA',
             'BAHIA');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('7',
             'CE',
             'CEARÁ');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('8',
             'DF',
             'DISTRITO FEDERAL');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('9',
             'ES',
             'ESPIRITO SANTO');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('10',
             'GO',
             'GOIAS');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('11',
             'MA',
             'MARANHÃO');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('12',
             'MT',
             'MATO GROSSO');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('13',
             'MS',
             'MATO GROSSO DO SUL');
INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('14',
             'MG',
             'MINAS GERAIS');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('15',
             'PR',
             'PARANA');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('16',
             'PB',
             'PARAIBA');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('17',
             'PA',
             'PARÁ');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('18',
             'PE',
             'PERNAMBUCO');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('19',
             'PI',
             'PIAUÍ');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('20',
             'RJ',
             'RIO DE JANEIRO');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('21',
             'RN',
             'RIO GRANDE DO NORTE');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('22',
             'RS',
             'RIO GRANDE DO SUL');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('23',
             'RO',
             'RONDONIA');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('24',
             'RR',
             'RORAIMA');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('25',
             'SC',
             'SANTA CATARINA');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('26',
             'SE',
             'SERGIPE');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('27',
             'SP',
             'SÃO PAULO');

INSERT INTO INFM_ESTADO
			(IDESTADO,
             CODESTADO,
             DESESTADO)
VALUES
            ('28',
             'TO',
             'TOCANTINS');

INSERT INTO INFM_TIPOPRODUTO
			(IDTIPOPRODUTO,
			 CODTIPOPRODUTO,
			 DESTIPOPRODUTO)
VALUES
			('1',
			 'SERVICO',
			 'SERVICO');


INSERT INTO INFM_TIPOPRODUTO
			(IDTIPOPRODUTO,
			 CODTIPOPRODUTO,
			 DESTIPOPRODUTO)
VALUES
			('2',
			 'PRODUTO',
			 'PRODUTO');

INSERT INTO INFM_SITUACAO_PESSOA
            (IDSITUACAOPESSOA,
			 DESSITUACAO,
			 CODSITUACAO)
	  VALUES
	        ('1',
			 'Em Dia',
			 'A');

INSERT INTO INFM_SITUACAO_PESSOA
            (IDSITUACAOPESSOA,
			 DESSITUACAO,
			 CODSITUACAO)
	  VALUES
	        ('2',
			 'Em Atraso',
			 'N');

INSERT INTO INFM_SITUACAO_PESSOA
            (IDSITUACAOPESSOA,
			 DESSITUACAO,
			 CODSITUACAO)
	  VALUES
	        ('3',
			 'Devolução',
			 'D');


INSERT INTO INFM_SITUACAO_PESSOA
            (IDSITUACAOPESSOA,
			 DESSITUACAO,
			 CODSITUACAO)
	  VALUES
	        ('4',
			 'Cheque Devolvido',
			 'F');

INSERT INTO INFM_SITUACAO_PESSOA
            (IDSITUACAOPESSOA,
			 DESSITUACAO,
			 CODSITUACAO)
	  VALUES
	        ('5',
			 'Pagando',
			 'P');

INSERT INTO INFM_SITUACAO_PESSOA
            (IDSITUACAOPESSOA,
			 DESSITUACAO,
			 CODSITUACAO)
	  VALUES
	        ('6',
			 'SPC Bloqueado',
			 'B');