create table Brand
(
	Id int not null constraint PK_Brand primary key identity(1,1),
	[Name] nvarchar(100) not null,
	DeletedAt datetime2(2) null,
	CreatedAt datetime2(2) not null
)

create table Product
(
	Id int not null constraint PK_Product primary key identity(1,1),
	[Name] nvarchar(100) not null,
	[Description] nvarchar(1000) null,
	Color nvarchar(50) null,
	Size decimal not null,
	Price decimal not null,
	Rating int null,
	ImageUrl nvarchar(1000) null,
	BrandId int not null constraint FK_Product_Brand foreign key references Brand(Id),
	DeletedAt datetime2(2) null,
	CreatedAt datetime2(2) not null
)

create table [User] 
(
	Id int not null constraint PK_User primary key identity(1,1),
	Email nvarchar(50) not null,
	PasswordHash nvarchar(64) not null,
	PasswordSalt nvarchar(8) not null,
	FullName nvarchar(100) not null,
	DeletedAt datetime2(2) null,
	CreatedAt datetime2(2) not null
)

create table Cart 
(
	Id int not null constraint PK_Cart primary key identity(1,1),
	UserId int not null constraint FK_Cart_User foreign key references [User](Id),
	DeletedAt datetime2(2) null,
	CreatedAt datetime2(2) not null
)

create table Product_Cart 
(
	Id int not null constraint PK_Product_Cart primary key identity(1,1),
	ProductID int not null constraint FK_Product_Cart_Product foreign key references Product(Id),
	CartId int not null constraint FK_Product_Cart_Cart foreign key references Cart(Id),
	Units int not null constraint DF_Product_Cart_Units default(1)
)