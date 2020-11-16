create table [Product] (
	ID int primary key identity,
	Name nvarchar(200) not null,
	Price money not null check (Price >= 0)
	)

create table [Customer] (
	ID int primary key identity,
	FirstName nvarchar(200),
	LastName nvarchar(200),
	CardNumber nvarchar(16)
)

create table [Order] (
	ID int primary key identity,
	ProductID int not null foreign key references Product(ID),
	CustomerID int not null foreign key references Customer(ID)
)

insert into [Product] values
('Lollipop', 2.00),
('Microphone', 50.00),
('T-shirt', 10.00)

insert into [Customer] values
('Morty', 'Smith', '1234567891011121'),
('Jerry', 'Smith', '3923890584930284'),
('Rick', 'Sanchez', '0000000000000000')

insert into [Order] values
(2, 3),
(1, 1),
(3, 2)

insert into [Product] values
('iPhone', 200.00)

insert into [Customer] values
('Tina', 'Smith')

insert into [Order] values
((select top(1) ID from Customer where FirstName = 'Tina' and LastName = 'Smith'), (select top(1) ID from Product where Name = 'iPhone'))

select o.* from [Order] as o
inner join Customer as c on c.ID = o.CustomerID

select sum(p.Price) from [Order] as o
inner join [Product] as p on p.ID = o.ProductID
where p.Name = 'iPhone'

update [Product]
set Price = 250.00
where Name = 'iPhone'