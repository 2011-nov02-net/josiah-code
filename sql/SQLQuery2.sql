create schema Store;
go

create table Store.Department (
	ID int not null primary key,
	Name nvarchar(200),
	Location nvarchar(200)
)create

; table Store.EmployeeDetails (
	ID int primary key identity not null,
	EmployeeID int not null,
	salary money null,
	Address1 nvarchar(150) null,
	Address2 nvarchar(150) null,
	City nvarchar(150) null,
	State nvarchar(150) null,
	Country nvarchar(150) null
);

create table Store.Employee (
	ID int not null primary key identity,
	FirstName nvarchar(150) not null,
	LastName nvarchar(150) not null,
	SSN nvarchar(15) null,
	DeptID int not null
);

alter table Store.EmployeeDetails
	add constraint FK_EmployeeDetails_ID foreign key (EmployeeID) references Store.Employee(ID)

alter table Store.Employee
	add constraint FK_Employee_DeptID foreign key (DeptID) references Store.Department(ID)