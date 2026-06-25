CREATE TABLE ConfirmarReserva (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome_cliente VARCHAR(100) NOT NULL,
    regime_alimentar VARCHAR(50) NOT NULL,
    preco_diario DECIMAL(10,2) NOT NULL,
    numero_dias INT NOT NULL,
    preco_total DECIMAL(10,2) NOT NULL
);