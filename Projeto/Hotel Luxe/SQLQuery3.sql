CREATE TABLE Reservas (
    IdReserva INT IDENTITY(1,1) PRIMARY KEY,
    EmailCliente VARCHAR(100),
    IdQuarto INT,
    DataReserva DATETIME,
    FOREIGN KEY (IdQuarto) REFERENCES Quartos(IdQuarto)
);