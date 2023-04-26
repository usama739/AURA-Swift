create database Project
go
use Project
go

insert into [Customer] values(1, 'Muhammad', 'Ramzan','Ramzan','Lahore','2270','M','Pakistan','0333-1234567','l192270@lhr.nu.edu.pk','Ramzan123' );

-- Group 2 E-Commerce
create table [Customer]
(
	C_userID int primary key,
	Fname varchar(20)Not Null,
	Lname varchar(20)Not Null,
	userName varchar(20)Not Null unique,
	city varchar(20)Not Null check(len(city)<=20),
	postalcode varchar(16) Not Null,
	Gender varchar(7),
	country varchar(20) Not Null check(len(country)<=20),
	phone varchar(20)Not Null,
	email varchar(50) Not Null unique,
	[password] char(50) not null check(len([password])>6 And len([password])<=20), 
)

 
 CREATE TABLE [Store]
(	
	ShopID int primary key,
	[shop name] [varchar](100) NULL,
	Fname varchar(20)Not Null,
	Lname varchar(20)Not Null,
	userName varchar(20)Not Null unique,
	[Phone Number] [char](11) NULL,
	[Address] [varchar](100) NULL,	
	email varchar(50) Not Null unique,
	[password] char(50) not null check(len([password])>6 And len([password])<=20),
	Gender varchar(7),
)

create table Category
( 
	CategoryID int primary key,
	CategoryName varchar(50) Not Null, 
)

create table [Product]
(
	ProductID int primary key,
	PName   nvarchar(MAX) not null,
	P_Description nvarchar(MAX),
	ShopID int FOREIGN KEY REFERENCES Store(ShopID) ON DELETE Cascade On update Cascade,
	CategoryID int FOREIGN KEY REFERENCES Category(CategoryID) ON DELETE Cascade On update Cascade,
	UnitPrice money,
	UnitWeight int Not Null,
	--picture varchar(200) ,
	AvailableUnit int Not Null,
)

create table [Order]
(
	OrderID int primary key,
	CustomerID int FOREIGN KEY REFERENCES Customer(C_userID) ON DELETE Cascade On update Cascade,
	Order_date date Not null,
	ProductID int FOREIGN KEY REFERENCES Product(ProductID) ON DELETE Cascade On update Cascade,
	CartAmount money NULL,
	CartDiscount money NULL,
	TotalPaid money NULL,
	PaymentType nvarchar(50) NULL,
	PaymentStatus nvarchar(50) NULL,
	DateOfPurchase datetime NULL,
	OrderStatus nvarchar(50) NULL,
)

create table Cart
(
	cartID int primary key IDENTITY(1,1),
	CustomerID  int FOREIGN KEY REFERENCES Customer(C_userID)  ON DELETE Cascade On update Cascade,
	ProductID int FOREIGN KEY REFERENCES Product(ProductID) ON DELETE Cascade On update Cascade,
	Quantity int NOT NULL, 
	PName nvarchar(max) NULL,
	PPrice money NULL,
	PSelPrice money NULL,
	SubPAmount  AS (PPrice*Quantity),
	SubSAmount  AS (PSelPrice*Quantity),
)

CREATE TABLE Review
(
	ReviewID int primary key IDENTITY(1,1) NOT NULL,
	CustomerID  int FOREIGN KEY REFERENCES Customer(C_userID) ON DELETE Cascade On update Cascade,
	ProductID int FOREIGN KEY REFERENCES Product(ProductID) ON DELETE Cascade On update Cascade,
	Rating int NULL,
)



--SEARCHING THE USERNAME AND PASSWORD FROM THE TABLE BUYER
select *
from [user]
drop procedure Search_Username_fromBuyer
Create Procedure Search_Username_fromBuyer
@Username varchar(20),
@Password varchar(50),
@found int output
as
begin
select userName
		 from [user] join customers on [user].userID=customers.userID
		 where (userName=@Username) and ([Password]=@Password)
if @@rowcount>0
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end
end
Declare @out int
exec Search_Username_fromBuyer
@Username='Ramzan',
@Password='Ramzan123',
@found=@out output
select @out