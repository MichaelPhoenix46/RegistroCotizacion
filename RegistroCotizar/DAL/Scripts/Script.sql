Create database CotizarDb
go
use CotizarDb
go
create table Articulos
(
	Articuloid int primary key identity(1,1),
	FechaVencimiento datetime,
	Descripcion varchar(30),
	Precio money,
	Existencia int,
	CantidadCotizada int

);