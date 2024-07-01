alter table Product add
Discount decimal(3,2) null

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
( 'Bata' , 'assets/img/bata.png', GETDATE()),
( 'Azaleia' , 's/img/azaleia.png',  GETDATE()),
( 'Call it Spring' , 'assets/img/call-it-spring.png',  GETDATE()),
( 'Ciara' , 'assets/img/ciara.png',  GETDATE()),
( 'Viale' , 'assets/img/viale.png',  GETDATE()),
( 'Vizzano' , 'assets/img/vizzano.png',  GETDATE())

insert into Product 
(
	[Name], [Description], Color, Price, Rating, ImageUrl, BrandId, CreatedAt, Discount
)
values
( 'Botas Camila', 'Botas de cuero con detalle único, su diseño aporta elegancia y mucho estilo','Negro', 350, 5, 'assets/img/product/Bata1.jpg', 1, GETDATE(), 0.3),
( 'Botas Barbara', 'Botas de cuero para dama, con taco N7, material PU, siente comodidad sin perder el estilo','Negro', 233.91, 5, 'assets/img/product/Bata21.png', 1, GETDATE(),0.3),
( 'Botines Barbara Off white', 'Botines  de cuero con taco cuadrado que ofrecen mayor estabilidad y comodidad en cada paso, ','Blanco', 191.90, 5, 'assets/img/product/Bata31.png', 1, GETDATE(), 0.5),
( 'Zapatos Saya Off white Chanel', 'Zapatos de vestir modelo Chanel, sigue el estilo Old Money, ','Beige', 149.50, 5, 'assets/img/product/Bata41.png', 1, GETDATE(), 0.05),
( 'Botines Tatiana', 'Botines de cuero en punta estilo vaquero, con taco N5 para mayor comodidad , ','Negro', 149.50, 5, 'assets/img/product/Bata51.jpg', 1, GETDATE(),0.25),
( 'Zapato elegante Caramelo', 'Zapatos elegante de dama con aplicaciones doradas y cuero importado taco N12', 'Nude',189.90, 5, 'assets/img/product/Azaleia.jpg', 2, GETDATE(), 0.2),
( 'Botas Larisa', 'Bota de color Negro, con un diseño clásico y de tiro largo para darle al usuario más comodidad durante el uso del calzado', 'Negro',499.90, 5, 'assets/img/product/Azaleia21.png', 2, GETDATE(), 0.5),
( 'Botines Samara', 'Botin de diseño moderno y audaz, de corte cerrado con entrada fácil para meter y aberturas en ambos lados', 'Beige',139.95, 5, 'assets/img/product/Azaleia31.jpg', 2, GETDATE(),0.1),
( 'Stiletto Elia', 'Tacon elegante tipo destalonado, con detalle de pedrería en la parte delantera.', 'Jeans',289.9, 5, 'assets/img/product/Azaleia41.png', 2, GETDATE(),0.40),
( 'Stiletto Analy', 'Tacon de diseño moderno, con colores mixtos combinables y taco en punta de corte elegante, con tiras delgadas que rodean el tobillo.', 'Beige',169.9, 5, 'assets/img/product/Azaleia51.png', 2, GETDATE(), 0.3),

( 'Zapato Slingbling Nude', 'Zapatos de vestir con taco N5, capellada PU, forro de cuero', 'Nude', 199.99, 5, 'assets/img/product/CallSpring12.jpg', 3, GETDATE(),0.60),
( 'Calzado Noelia', 'Zapatos de vestir elegantes y comodos con taco N9', 'Nude', 149.90, 5, 'assets/img/product/CallSpring1.png', 3, GETDATE(), 0.1),
( 'Botines Casuales Mujer Outlaw', 'Botines de cuero sintético estilo cowboy, con diseño único y moderno.', 'Marrón', 174.93, 3, 'assets/img/product/CallSpring31.png', 3, GETDATE(),0.1),
( 'Zapato Disney colecction', 'Zapato de vestir colección ensueño Disney con aplicaciones en pedreria.', 'Blanco', 272.95, 4, 'assets/img/product/CallSpring21.png', 3, GETDATE(), 0.3),
( 'Zapatos Dress Jolie', 'Zapato de vestir modelo Jolie, con taco N12, sensualidad al caminar.', 'Rojo', 249.90, 5, 'assets/img/product/CallSpring51.png', 3, GETDATE(), 0.5),
( 'Botines Casuales Wildwest', 'Botines estilo cowboy negro con blanco.', 'Negro', 167.94, 5, 'assets/img/product/CallSpring41.png', 3, GETDATE(),0.05),

( 'Zapato casual Coleccion Free', 'Zapatos casuales para dama en cuero con taco N3 para mayor comodidad', 'Negro', 209.95, 4, 'assets/img/product/Ciara1.png', 4, GETDATE(), 0.3),
( 'Bota Texana Rondini', 'Bota estilo Texana en cuero Rondini color negro con taco 70 forrado en suela, diseño de monograma en color blanco y suela de caucho con medio cerco.', 'Negro', 699.99, 5, 'assets/img/product/Ciara31.png', 4, GETDATE(),0.50),
( 'Bota Casual Crust Toffe', 'Bota Casual Elaborado en cuero vacuno Crust Toffe con Planta de TR antideslizante. taco 5 cm, con correas', 'Toffe', 559.99, 5, 'assets/img/product/Ciara21.png', 4, GETDATE(), 0.6),

( 'Zapato Collecion Princes', 'Zapatos elegante de vestir con taco N7, y aplicaciones en piedras', 'Azul', 259.95, 5, 'assets/img/product/Viale1.png', 5, GETDATE(),0.3),
( 'Zapato Tati-2431', 'Zapato de cuero sintético', 'Beige', 239.90, 5, 'assets/img/product/Viale21.png', 5, GETDATE(), null),
( 'Bota Alta Davi-2401', 'Bota de cuero taco N5, con taco cuadrado para mayor comodidad', 'Marrón', 207.90, 5, 'assets/img/product/Viale31.png', 5, GETDATE(),0.40),

( 'Botas  Beira', 'Calzado cálido para lucir el invierno, gracias a la caña, que se extiende por la pierna.', 'Negro', 139.90, 5, 'assets/img/product/Vizano51.png', 6, GETDATE(),0.10),
( 'Zapato de Novia', 'Calzado de novia con tacón aguja te dará elegancia y sensualidad al caminar', 'Blanco', 189.90, 5, 'assets/img/product/Vizano.png', 6, GETDATE(), 0.2),
( 'Stilettos Blue', 'Es el calzado más sexy y glamouroso, te dará elegancia y sensualidad.', 'Azul', 169.90, 5, 'assets/img/product/Vizano61.png', 6, GETDATE(), 0.1)


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