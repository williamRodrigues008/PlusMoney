create table Movimentacao (
Id int primary key identity not null,
Descricao varchar(100),
TipoMovimentacao varchar(15) not null,
Valor decimal not null
)