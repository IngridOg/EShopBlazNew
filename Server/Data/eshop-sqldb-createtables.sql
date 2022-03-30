CREATE TABLE Customers (
	Id int not null identity(1,1) primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email varchar(100) not null,
	PhoneNr varchar(16),
	CareOffAddress nvarchar(100),
	StreetAddress nvarchar(100) not null,
	ZipCode char(5) not null,
	City nvarchar(50) not null
)
GO
CREATE TABLE Products (
	Id int not null identity(1,1) primary key,
	Name nvarchar(100) not null,
	Description nvarchar(1024),
	Material nvarchar(200),
	Care nvarchar(200),
	Brand nvarchar(50),
	Supplier nvarchar(50),
	Category tinyint not null default 0,
	SubCategory tinyint not null default 0,
	Season tinyint not null default 0
)
GO
CREATE TABLE ProductVariants (
	Id int not null identity(1,1) primary key,
	ProductId int not null foreign key REFERENCES Products(Id) ON DELETE CASCADE,
	ListPrice decimal not null default 0,
	Price decimal not null default 0,
	ImageUrl varchar(150),
	Size tinyint not null default 0,
	Color tinyint not null default 0,
	NumberInStock int not null default 0,
	OnSale bit not null default 0
)
CREATE TABLE ShoppingCarts (
	Id int not null identity(1,1) primary key,
	CustomerId int not null foreign key REFERENCES Customers(Id) ON DELETE CASCADE,
	CouponCode nvarchar(8),
	ShippingType tinyint not null default 0
)
GO
CREATE TABLE Details (
	ShoppingCartId int not null foreign key REFERENCES ShoppingCarts(Id) ON DELETE CASCADE,
	RowNr int not null,
	Quantity int not null default 0,
	ProductVariantId int not null,
	CONSTRAINT PK_Details primary key (ShoppingCartId, RowNr)
)
GO
CREATE TABLE Invoices (
	Id int not null identity(1,1) primary key,
	CustomerId int,
	OrderDate datetime not null,
	Total decimal not null default 0,
	CouponCode nvarchar(8),
	ShippingType tinyint not null default 0,
	PaymentType tinyint not null default 0,
	PayedFor bit not null default 0,
	CustomerFirstName nvarchar(50) not null,
	CustomerLastName nvarchar(50) not null,
	CustomerCareOffAddress nvarchar(100),
	CustomerStreetAddress nvarchar(100) not null,
	CustomerZipCode char(5) not null,
	CustomerCity nvarchar(50) not null
)
GO
CREATE TABLE InvoiceLines (
	InvoiceId int not null foreign key REFERENCES Invoices(Id) ON DELETE CASCADE,
	InvoiceLineNr int not null default 0,
	Quantity int not null default 0,
	ProductVariantId int not null,
	ProductName nvarchar(100) not null,
	Price decimal not null default 0
	CONSTRAINT PK_InvoiceLine primary key (InvoiceId, InvoiceLineNr)
)
GO