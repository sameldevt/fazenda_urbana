CREATE TABLE fornecedores (
    pk_id int PRIMARY KEY IDENTITY(1,1),
    nome varchar(100) NOT NULL,
    contato varchar(100),
    telefone varchar(20),
    email varchar(100),
    endereco varchar(255)
);

CREATE TABLE produtos (
    pk_id int PRIMARY KEY IDENTITY(1,1),
    nome varchar(100) NOT NULL,
    categoria varchar(50),
    preco_unitario decimal(10, 2) NOT NULL,
    quantidade_estoque int NOT NULL
);

CREATE TABLE producao (
    pk_id int PRIMARY KEY IDENTITY(1,1),
    fk_produto_id int NOT NULL,
    fk_fornecedor_id int NOT NULL,
    quantidade int NOT NULL,
    data_producao datetime NOT NULL DEFAULT GETDATE(),
    data_prevista_colheita datetime,
    data_colheita datetime,
    status varchar(50) CHECK (Status IN ('Plantado', 'Crescendo', 'Colhido')),
    CONSTRAINT fk_producao_produtos FOREIGN KEY (fk_produto_id) REFERENCES produtos(pk_id),
    CONSTRAINT fk_producao_fornecedores FOREIGN KEY (fk_fornecedor_id) REFERENCES fornecedores(pk_id)
);

CREATE TABLE clientes (
    pk_id int PRIMARY KEY IDENTITY(1,1),
    nome varchar(100) NOT NULL,
    telefone varchar(20),
    email varchar(100),
    endereco varchar(255)
);

CREATE TABLE vendas (
    pk_id int PRIMARY KEY IDENTITY(1,1),
    fk_produto_id int NOT NULL,
    fk_cliente_id int NOT NULL,
    data_venda datetime NOT NULL DEFAULT GETDATE(),
    quantidade int NOT NULL,
    valor_total decimal(10, 2) NOT NULL,
    metodo_pagamento varchar(50) CHECK (metodo_pagamento IN ('Cartão de Crédito', 'Pix', 'Transferência Bancária')),
    CONSTRAINT fk_vendas_produtos FOREIGN KEY (fk_produto_id) REFERENCES produtos(pk_id),
    CONSTRAINT fk_vendas_clientes FOREIGN KEY (fk_cliente_id) REFERENCES clientes(pk_id)
);

CREATE TABLE relatorios (
    pk_id int PRIMARY KEY IDENTITY(1,1),
    tipo_relatorio varchar(50) NOT NULL CHECK (tipo_relatorio IN ('Producao', 'Vendas', 'Estoque', 'Fornecedores')),
    data_geracao datetime NOT NULL DEFAULT GETDATE(),
    dados_relatorio nvarchar(MAX)
);

CREATE TABLE inventario (
    pk_id int PRIMARY KEY IDENTITY(1,1),
    fk_produto_id int NOT NULL,
    quantidade int NOT NULL,
    data_ultima_atualizacao datetime NOT NULL DEFAULT GETDATE(),
    CONSTRAINT fk_inventario_produtos FOREIGN KEY (fk_produto_id) REFERENCES produtos(pk_id)
);

CREATE TABLE funcionarios (
    pk_id int PRIMARY KEY IDENTITY(1,1),
    nome varchar(100) NOT NULL,
    cargo varchar(50),
    data_contratacao datetime NOT NULL,
    telefone varchar(20),
    email varchar(100),
    endereco varchar(255)
);

CREATE TABLE transportes (
    pk_id int PRIMARY KEY IDENTITY(1,1),
    fk_venda_id int NOT NULL,
    data_envio datetime NOT NULL,
    data_entrega datetime,
    transportadora varchar(100),
    numero_rastreamento varchar(100),
    status varchar(50) CHECK (status IN ('Enviado', 'Em Trânsito', 'Entregue')),
    CONSTRAINT fk_transportes_vendas FOREIGN KEY (fk_venda_id) REFERENCES vendas(pk_id)
);

CREATE TABLE detalhes_vendas (
    pk_id int PRIMARY KEY IDENTITY(1,1),
    fk_venda_id int NOT NULL,
    fk_produto_id int NOT NULL,
    quantidade int NOT NULL,
    preco_unitario decimal(10, 2) NOT NULL,
    CONSTRAINT fk_detalhesvendas_vendas FOREIGN KEY (fk_venda_id) REFERENCES vendas(pk_id),
    CONSTRAINT fk_detalhesvendas_produtos FOREIGN KEY (fk_produto_id) REFERENCES produtos(pk_id)
);

CREATE TABLE pagamentos (
    pk_id int PRIMARY KEY IDENTITY(1,1),
    fk_venda_id int NOT NULL,
    data_pagamento datetime NOT NULL DEFAULT GETDATE(),
    valor_pagamento decimal(10, 2) NOT NULL,
    metodo_pagamento varchar(50),
    CONSTRAINT fk_pagamentos_vendas FOREIGN KEY (fk_venda_id) REFERENCES vendas(pk_id)
);

-- relatorio vendas
SELECT 
    v.pk_id ,
    c.nome,
    v.data_venda ,
    dv.fk_produto_id ,
    p.nome,
    dv.quantidade,
    dv.preco_unitario ,
    v.valor_total ,
    t.status AS status_transporte
FROM 
    Vendas v
JOIN 
    Clientes c ON v.fk_cliente_id = c.pk_id 
JOIN 
    detalhes_vendas dv ON v.pk_id  = dv.fk_venda_id 
JOIN 
    produtos p ON dv.fk_produto_id = p.pk_id 
LEFT JOIN 
    transportes t ON v.pk_id = t.fk_venda_id 
ORDER BY 
    v.data_venda DESC;
   
-- relatorio inventario
SELECT 
    i.pk_id,
    p.nome,
    i.quantidade,
    i.data_ultima_atualizacao
FROM 
    inventario i
JOIN 
    produtos p ON i.fk_produto_id = p.pk_id
ORDER BY 
    i.data_ultima_atualizacao DESC;

-- relatorio producao
SELECT 
    pr.pk_id ,
    p.nome,
    f.nome,
    pr.quantidade ,
    pr.data_producao ,
    pr.data_prevista_colheita ,
    pr.data_producao ,
    pr.status
FROM 
    producao pr
JOIN 
    produtos p ON pr.fk_produto_id  = p.pk_id 
JOIN 
    Fornecedores f ON pr.fk_produto_id = f.pk_id 
ORDER BY 
    pr.data_producao  DESC;
