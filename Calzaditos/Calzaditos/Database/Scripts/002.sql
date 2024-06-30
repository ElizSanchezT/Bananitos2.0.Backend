alter table Product add
Discount decimal null

create table PromoCode(
	Id int not null constraint PK_PromoCode primary key identity(1,1),
	Amount decimal not null,
	Stock int not null,
	Code nvarchar(7) not null,
	DeletedAt datetime2(2) null,
	CreatedAt datetime2(2) not null

)

alter table Brand add
ImageUrl nvarchar(1000) null

alter table Product drop column Size


create table Product_Size
(
	Id int not null constraint PK_Product_Size primary key identity(1,1),
	ProductId int not null constraint FK_Product_Size_Product foreign key references Product(Id),
	Size int not null
)

alter table Product_Cart 
add SelectedSize int not null

go

insert into [User]
(
	Email, PasswordHash, PasswordSalt, FullName, CreatedAt
)
values
( 'developer@calzaditos.com', '', '', 'Developer', GETDATE())

insert into Brand(
	[Name],
	ImageUrl, 
	CreatedAt)
values
( 'Bata' , 'public/assets/img/bata.png', GETDATE()),
( 'Azaleia' , 'public/assets/img/azaleia.png',  GETDATE()),
( 'Call it Spring' , 'public/assets/img/call-it-spring.png',  GETDATE()),
( 'Ciara' , 'public/assets/img/ciara.png',  GETDATE()),
( 'Viale' , 'public/assets/img/viale.png',  GETDATE()),
( 'Vizzano' , 'public/assets/img/vizzano.png',  GETDATE())

insert into Product 
(
	[Name], [Description], Color, Price, Rating, ImageUrl, BrandId, CreatedAt
)
values
( 'Zapato de vestir Slingbling Nude', 'Zapatos de vestir con taco N5, capellada PU, forro de cuero', 'Nude', 99.99, 5, 'public/assets/img/product/Vizano.jpg', 6, GETDATE()),
( 'Botas de vestir Camila', 'Botas de cuero con detalle único, su diseño aporta elegancia y mucho estilo','Negro', 350, 5, 'public/assets/img/product/.jpg', 1, GETDATE()),
( 'Zapato de vestir CallSpring', 'Zapatos de vestir elegantes y comodos con taco N9', 'Nude', 149.90, 5, 'public/assets/img/product/callSpring1.png', 3, GETDATE()),
( 'Zapato elegante Caramelo', 'Zapatos elegante de dama con aplicaciones doradas y cuero importado taco N12', 'Nude',189.90, 5, 'public/assets/img/product/Azaleia.jpg', 2, GETDATE()),
( 'Zapato casual Coleccion Free ', 'Zapatos casuales para dama en cuero con taco N3 para mayor comodidad', 'Negro', 209.95, 4, 'public/assets/img/product/Vizano.png', 4, GETDATE()),
( 'Zapato elegante Collecion Princes', 'Zapatos elegante de vestir con taco N7, y aplicaciones en piedras', 'Azul', 259.95, 5, 'public/assets/img/product/Vizano.png', 5, GETDATE())

insert into Product_Size
(
	ProductId, Size
)
values
(1,35),(1,36),(1,37),(1,38),
(2,35),(2,36),(2,37),(2,38),
(3,35),(3,36),(3,37),(3,38),
(4,35),(4,36),(4,37),(4,38),
(5,35),(5,36),(5,37),(5,38),
(6,35),(6,36),(6,37),(6,38)