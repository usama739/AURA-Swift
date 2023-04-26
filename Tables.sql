create database DBProject
Go
use DBProject
create table [user]
(
  userID int primary key IDENTITY(1,1),
  Fname varchar(20)Not Null,
  Lname varchar(20)Not Null,
  userName varchar(20)Not Null unique,
  city varchar(20)Not Null check(len(city)<=20),
  postalcode varchar(16) Not Null,
  Gender varchar(7),
  country varchar(20) Not Null check(len(country)<=20),
  phone varchar(20)Not Null,
  email varchar(50) Not Null unique,
  [password] char(50) not null check(len([password])>7 And len([password])<=50),
 )



insert into [user]
values ('Muhammad', 'Usama' , 'usama', 'Lahore', '2100', 'Male', 'Pakistan', '03043573644', 'usama@lhr', 'usama123')

insert into [user]
values ('Muhammad', 'Ramzan' , 'ramzan', 'Lahore', '2300', 'Male', 'Pakistan', '03043672644', 'ramzan@lhr', 'ramzan123')

insert into [user]
values ('Muhammad', 'Amish' , 'amish', 'Lahore', '2400', 'Male', 'Pakistan', '03047623644', 'amish@lhr', 'amish123')

insert into [user]
values ('Muhammad', 'Ahmad' , 'ahmad', 'Lahore', '2600', 'Male', 'Pakistan', '03047665644', 'ahmad@lhr', 'ahmad123')


select* from [user]

---------------------------///////////////////////////////////////////-----------------------------------


 create table supplier (
  supplierID int primary key IDENTITY(1,1),
  userID int FOREIGN KEY REFERENCES [user](userID) ON DELETE Cascade On update Cascade,
  companyName varchar(50) Not Null ,
  shopAddress char(50) Not null
 )

 Insert into supplier values(2, 'AURA SWIFT', 'Garden Town, Lahore')
 select* from supplier


 ---------------------------///////////////////////////////////////////-----------------------------------

create table customers
(
  CustomerId int primary key IDENTITY(1,1),
  userID int FOREIGN KEY REFERENCES [user](userID) ON DELETE Cascade On update Cascade,
  CreditID varchar(30) Not null,
  [Address] char(50) Not null
)

insert into customers values (1, '123456789', 'Green Town, Lahore')
insert into customers values (3, '987654321', 'Garden Town, Lahore')
insert into customers values (4, '123454321', 'Badshahi Mosque, Lahore')
 drop table customers

select* from customers


 ---------------------------///////////////////////////////////////////-----------------------------------


create table category(
	categoryID int primary key IDENTITY(1,1),
	categoryName varchar(50) Not Null,
)

insert into category
values ('Grocery'), ('Fruits'), ('Vegetables'), ('Junk Food'), ('Meat')

select* from category


 ---------------------------///////////////////////////////////////////-----------------------------------



create table product(
 ProductID int primary key IDENTITY(1,1),
 ProductName varchar(50) Not Null,
 ProductDescription varchar(500)Not Null,
 supplierID int FOREIGN KEY REFERENCES supplier(supplierID) ,
 categoryID int FOREIGN KEY REFERENCES category(categoryID) ,
 UnitPrice int Not Null ,
 AvailableColors varchar(20) Not Null,
 UnitWeight int Not Null,
 picture varchar(200) ,
 AvailableUnit int Not Null
)


Insert into product 
values('Candies', 'Joy for Children', 1, 1, 5, 'Green, Red', 0.75, NULL, 90)

Insert into product 
values('CupCakes', 'Sweet in Taste', 1, 1, 10, 'Grey, Brown', 0.9, NULL, 80)

Insert into product 
values('Bananas', 'Beneficial for every human', 1, 2, 16, 'Yellow', 1.23, NULL, 78)

Insert into product 
values('Shawarma', 'A delicious Fast Food', 1, 4, 70, 'White', 1.56, NULL, 54)

 
select* from product



---------------------------///////////////////////////////////////////-----------------------------------


create table cart(
	cartID int primary key IDENTITY(1,1),
	CustomerID int FOREIGN KEY REFERENCES customers(CustomerID) NOT NULL,
	ProductID int FOREIGN KEY REFERENCES product(ProductID)  NOT NULL,
	Quantity int 
)


insert into cart
values (1, 2, 20),(1, 4, 10), (2, 3, 10),(3, 4, 18), (1, 4, 10)


select * from cart


 ---------------------------///////////////////////////////////////////-----------------------------------


CREATE TABLE [Status](
	StatusId int primary key IDENTITY(1,1) NOT NULL,
	[Statement] varchar(50) NULL
)


insert into [Status] values ('onWay') 

select* from [Status]



 ---------------------------///////////////////////////////////////////-----------------------------------


create table [order](
	orderID int primary key IDENTITY(1,1),
	CustomerID int FOREIGN KEY REFERENCES customers(CustomerID) NOT NULL,
	order_date date Not null
)

insert into [order]
values(1, '2021-06-14'), (2, '2021-08-17'), (3, '2021-08-21')


select* from [order]


 ---------------------------///////////////////////////////////////////-----------------------------------


create table Order_Details(
	OrderDetail_ID int primary key IDENTITY(1,1),
	orderID int FOREIGN KEY REFERENCES [order](orderID) ,
	ProductID int FOREIGN KEY REFERENCES product(ProductID) NOT NULL,
	StatusId int FOREIGN KEY REFERENCES [Status](StatusId) NOT NULL,
	price int,
	Quantity int 
)


insert into Order_Details
values (1, 2, 1, 5, 20), (1, 2, 1, 70, 10), (1, 4, 1, 16, 10), (2, 3, 1, 10, 10), (3, 4 ,1, 18, 16)

select* from Order_Details

update Order_Details set price = 16,  Quantity = 18
where OrderDetail_ID = 5

 ---------------------------///////////////////////////////////////////-----------------------------------



 CREATE TABLE [Review]
(
	ReviewID int primary key IDENTITY(1,1) NOT NULL,
	CustomerID int FOREIGN KEY REFERENCES customers(CustomerID) NOT NULL,
    ProductID int FOREIGN KEY REFERENCES product(ProductID) NOT NULL,
	Rating int NULL,
)



---------------------------///////////////////////////////////////////-----------------------------------



--SEARCHING THE USERNAME AND PASSWORD FROM THE TABLE BUYER

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
@Username='usama',
@Password='usama123',
@found=@out output
select @out




 ---------------------------///////////////////////////////////////////-----------------------------------


 --SEARCHING USERNAME AND PASSWORD FROM SUPPLIER

Create Procedure Search_Username_fromSupplier
@Username varchar(20),
@Password varchar(50),
@found int output
as
begin
select userName
		 from [user] join supplier on [user].userID=supplier.userID
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




 ---------------------------///////////////////////////////////////////-----------------------------------



Create Procedure Buyer_SignupProcedure
  
  @Fname varchar(20),
  @Lname varchar(20),
  @userName varchar(20),
  @city varchar(20),
  @postalcode varchar(16) ,
  @Gender varchar(7),
  @country varchar(20),
  @phone varchar(20),
  @email varchar(50) ,
  @password char(50),
  @CreditID varchar(30),
  @Address char(50), 
  @found int output,
  @email_Exists int output,
  @userName_Exists int output

as
begin
set  @email_Exists=0
set    @userName_Exists=0
if exists(select [user].userID
                from [user]
				 where  [user].email=@email )
		begin
			set  @email_Exists=1
			
		end
if exists(select [user].userID
                from [user]
				 where [user].userName=@userName  )
		begin
			set    @userName_Exists=1
		
		end


if(@userName_Exists =0 AND @email_Exists=0 )
begin
Insert into [user]
Values( @Fname ,
  @Lname ,
  @userName ,
  @city ,
  @postalcode  ,
  @Gender ,
  @country ,
  @phone ,
  @email  ,
  @password)
  Declare @user_id int
  set @user_id=(select [user].userID
                 from [user]
				 where [user].userName=@userName)

  Insert into customers values (@user_id , @CreditID ,@Address )

end

if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end
end



 ---------------------------///////////////////////////////////////////-----------------------------------




Create Procedure supplier_SignupProcedure
  
  @Fname varchar(20),
  @Lname varchar(20),
  @userName varchar(20),
  @city varchar(20),
  @postalcode varchar(16) ,
  @Gender varchar(7),
  @country varchar(20),
  @phone varchar(20),
  @email varchar(50) ,
  @password char(50),
  @companyName varchar(50)  ,
  @shopAddress char(50), 
  @found int output,
  @email_Exists int output,
  @userName_Exists int output

as
begin
	set  @email_Exists=0
	set    @userName_Exists=0
	if exists(select [user].userID
                from [user]
				 where  [user].email=@email )
		begin
			set  @email_Exists=1
		end
	if exists(select [user].userID
                from [user]
				 where [user].userName=@userName  )
		begin
			set    @userName_Exists=1
		
		end


if(@userName_Exists =0 AND @email_Exists=0 )
	begin
		Insert into [user]
		Values( @Fname ,
		  @Lname ,
		 @userName ,
		  @city ,
		  @postalcode  ,
		 @Gender ,
		 @country ,
		 @phone ,
		  @email  ,
		  @password )
  Declare @user_id int
  set @user_id=(select [user].userID
                 from [user]
				 where [user].userName=@userName)

  Insert into supplier values (@user_id , @companyName ,@shopAddress )

	end

if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end
end



 ---------------------------///////////////////////////////////////////-----------------------------------



Create Procedure ProfilePage_Procedure
  @userName varchar(20), 
  @Fname varchar(20) output,
  @Lname varchar(20)output
as
begin
set @Fname=(select Fname
			from [user] 
			where (userName=@Username) )
set @Lname=(select Lname
			from [user] 
			where (userName=@Username) )

end



 ---------------------------///////////////////////////////////////////-----------------------------------


 create Procedure ProfilePage_Procedure_seller
  @userName varchar(20), 
  @Fname varchar(20) output,
  @Lname varchar(20)output,
  @Orders int output,
  @sale int output
  
  
as
begin


set @Orders=0
set @sale=0
declare @sid int
set @sid=(select s.supplierID from [user] u join supplier s on s.userID=u.userID)

set @Fname=(select Fname
			from [user] 
			where (userName=@Username) )
set @Lname=(select Lname
			from [user] 
			where (userName=@Username) )
if(exists(select *
		from Order_Details o join product p on p.ProductID =o.ProductID 
		where p.supplierID=@sid
		group by p.supplierID))
begin
			
(select @Orders=count(*),@sale= sum(p.UnitPrice*o.Quantity)
from Order_Details o join product p on p.ProductID =o.ProductID 
where p.supplierID=@sid
group by p.supplierID)
end

end




 ---------------------------///////////////////////////////////////////-----------------------------------


Create Procedure forget_password
   @email varchar(50), 
    @userName varchar(20),
  
@found int output
as
begin


			select *
			from [user] 
			where email=@email And userName=@userName
if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end	

end



 ---------------------------///////////////////////////////////////////-----------------------------------



 Create Procedure Change_password
   @password varchar(50), 
    @userName varchar(20),
  
@found int output
as
begin


			update [user]
			set [password]=@password
			where  userName=@userName
if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end	

end



 ---------------------------///////////////////////////////////////////-----------------------------------


 Create Procedure BuyerProfile_input_Procedure
  
  @Fname varchar(20)output,
  @Lname varchar(20)output,
  @userName varchar(20),
  @city varchar(20)output,
  @postalcode varchar(16) output,
  @Gender varchar(7)output,
  @country varchar(20)output,
  @phone varchar(20)output,
  @email varchar(50) output,
  @CreditID varchar(30)output,
  @Address char(50)output

as
begin

set @Fname=(select Fname
			from [user] 
			where (userName=@userName) )
set @Lname=(select Lname
			from [user] 
			where (userName=@userName) )
set @city=(select city
			from [user] 
			where (userName=@userName) )
set @postalcode=(select postalcode
			from [user] 
			where (userName=@userName) )
set @Gender=(select Gender
			from [user] 
			where (userName=@userName) )
set @country=(select country
			from [user] 
			where (userName=@userName) )
set @phone=(select phone
			from [user] 
			where (userName=@userName) )
set @CreditID=(select CreditID 
			from [user] join customers on [user].userID=customers.userID
			where (userName=@userName) )
set @email=(select email
			from [user] 
			where (userName=@userName) )
set @Address=(select [Address]
			from [user] join customers on [user].userID=customers.userID
			where (userName=@userName) )
end






 ---------------------------///////////////////////////////////////////-----------------------------------



 Create Procedure SupplierProfile_input_Procedure
  
  @Fname varchar(20)output,
  @Lname varchar(20)output,
  @userName varchar(20),
  @city varchar(20)output,
  @postalcode varchar(16) output,
  @Gender varchar(7)output,
  @country varchar(20)output,
  @phone varchar(20)output,
  @email varchar(50) output,
  @companyName varchar(50)output,
  @shopAddress char(50)output

as
begin

set @Fname=(select Fname
			from [user] 
			where (userName=@userName) )
set @Lname=(select Lname
			from [user] 
			where (userName=@userName) )
set @city=(select city
			from [user] 
			where (userName=@userName) )
set @postalcode=(select postalcode
			from [user] 
			where (userName=@userName) )
set @Gender=(select Gender
			from [user] 
			where (userName=@userName) )
set @country=(select country
			from [user] 
			where (userName=@userName) )
set @phone=(select phone
			from [user] 
			where (userName=@userName) )
set @companyName=(select  companyName
			from [user] join supplier on [user].userID=supplier.userID
			where (userName=@userName) )
set @email=(select email
			from [user] 
			where (userName=@userName) )
set @shopAddress=(select shopAddress
			from [user] join supplier on [user].userID=supplier.userID
			where (userName=@userName) )
end






 ---------------------------///////////////////////////////////////////-----------------------------------


 Create Procedure supplierProfile_update_Procedure
  
  @Fname varchar(20),
  @Lname varchar(20),
  @userName varchar(20),
  @olduserName varchar(20),
  @city varchar(20),
  @postalcode varchar(16) ,
  @Gender varchar(7),
  @country varchar(20),
  @phone varchar(20),
  @email varchar(50) ,

  @companyName varchar(50)  ,
  @shopAddress char(50), 
  @found int output,
  @email_Exists int output,
  @userName_Exists int output

as
begin
	set  @email_Exists=0
	set    @userName_Exists=0
	if exists(select [user].userID
                from [user]
				 where  [user].email=@email and [user].userName!=@olduserName)
		begin
			set  @email_Exists=1
		end
	if exists(select [user].userID
                from [user]
				 where [user].userName=@userName and [user].userName!=@olduserName )
		begin
			set    @userName_Exists=1
		
		end


if(@userName_Exists =0 AND @email_Exists=0 )
	begin
		update [user]
		set Fname= @Fname ,
		 Lname= @Lname ,
		 userName= @userName,
		 city= @city ,
		 postalcode=  @postalcode ,
		 Gender= @Gender,
		 country=  @country,
		 phone = @phone,
		  email= @email
		  where userName =@olduserName
  Declare @user_id int
  set @user_id=(select [user].userID
                 from [user]
				 where [user].userName=@userName)

  update supplier 
  set  companyName =@companyName,shopAddress= @shopAddress
  where supplier.userID =@user_id 
	end

if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end
end




 ---------------------------///////////////////////////////////////////-----------------------------------



 Create Procedure buyerProfile_update_Procedure
  
  @Fname varchar(20),
  @Lname varchar(20),
  @userName varchar(20),
  @olduserName varchar(20),
  @city varchar(20),
  @postalcode varchar(16) ,
  @Gender varchar(7),
  @country varchar(20),
  @phone varchar(20),
  @email varchar(50) ,
  @CreditID varchar(30)  ,
  @Address char(50), 
  @found int output,
  @email_Exists int output,
  @userName_Exists int output

as
begin
	set  @email_Exists=0
	set    @userName_Exists=0
	if exists(select [user].userID
                from [user]
				 where  [user].email=@email and [user].userName!=@olduserName)
		begin
			set  @email_Exists=1
		end
	if exists(select [user].userID
                from [user]
				 where [user].userName=@userName and [user].userName!=@olduserName )
		begin
			set    @userName_Exists=1
		
		end


if(@userName_Exists =0 AND @email_Exists=0 )
	begin
		update [user]
		set Fname= @Fname ,
		 Lname= @Lname ,
		 userName= @userName,
		 city= @city ,
		 postalcode=  @postalcode ,
		 Gender= @Gender,
		 country=  @country,
		 phone = @phone,
		  email= @email
		  where userName =@olduserName
  Declare @user_id int
  set @user_id=(select [user].userID
                 from [user]
				 where [user].userName=@userName)

  update customers 
  set  CreditID =@CreditID,[Address]= @Address
  where customers.userID =@user_id 
	end

if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end
end




---------------------------///////////////////////////////////////////-----------------------------------


Create Procedure check_userType
  
@userName varchar(20),
  
@found int output
as
begin
 declare @userid int
 set @userid=(select userID from [user] where userName=@userName)

if(exists(	select *
			from  customers  c
			where  c.userID =@userid))
	begin
		set @found=1
	end

else
	begin
		set @found=0
	end	

end




---------------------------///////////////////////////////////////////-----------------------------------


create Procedure add_product
  
  @ProductName varchar(50) ,
 @ProductDescription varchar(500),
 @userName varchar(20) ,
 @categorytype  varchar(50),
 @UnitPrice int ,
 @AvailableColors varchar(20) ,
 @UnitWeight int ,
 @picture varchar(200) ,
 @AvailableUnit int ,
  @found int output
 

as
begin
declare @supplierID int,@categoryID int
set @supplierID=(select supplier.supplierID from [user] u join supplier on u.userID=supplier.userID where u.userName=@userName )
set @categoryID=(select categoryID from category where categoryName=@categorytype)

	insert into  product values 
(@ProductName,@ProductDescription,@supplierID,@categoryID,@UnitPrice,@AvailableColors,@UnitWeight ,@picture,@AvailableUnit)
if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end
end




---------------------------///////////////////////////////////////////-----------------------------------



create Procedure Show_product_Attributes
  @ProdutID int,
  @ProductName varchar(50) output,
 @ProductDescription varchar(500)output,
 @categorytype  varchar(50)output,
 @UnitPrice int output,
 @AvailableColors varchar(20) output,
 @UnitWeight int output,
 @picture varchar(200) output,
 @AvailableUnit int output
as
begin

select @ProductName=ProductName,@ProductDescription=ProductDescription,@categorytype=category.categoryName,@UnitPrice=UnitPrice,@AvailableColors=AvailableColors,@UnitWeight=UnitWeight,@picture=picture,@AvailableUnit=AvailableUnit
from product join category on product.categoryID=category.categoryID
where ProductID=@ProdutID

select *from product join category on product.categoryID=category.categoryID
where ProductID=@ProdutID

end




---------------------------///////////////////////////////////////////-----------------------------------


create Procedure update_products
 @ProdutID int,
 @ProductName varchar(50) ,
 @ProductDescription varchar(500),
 @categorytype  varchar(50),
 @UnitPrice int ,
 @AvailableColors varchar(20) ,
 @UnitWeight int ,
 @picture varchar(200) ,
 @AvailableUnit int ,
 @found int output
 

as
begin
declare @categoryID int
set @categoryID=(select categoryID from category where categoryName=@categorytype)

update  product  
set ProductName= @ProductName,ProductDescription=@ProductDescription,categoryID=@categoryID,UnitPrice=@UnitPrice,AvailableColors=@AvailableColors,UnitWeight=@UnitWeight ,picture=@picture,AvailableUnit=@AvailableUnit
where ProductID=@ProdutID

if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end
end





---------------------------///////////////////////////////////////////-----------------------------------



create Procedure Delete_products
 @ProdutID int,
 @found int output
as
begin

delete from Order_Details where ProductID=@ProdutID
delete from cart where ProductID=@ProdutID
delete from Review where ProductID=@ProdutID
delete from product where ProductID=@ProdutID
if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end
end




---------------------------///////////////////////////////////////////-----------------------------------




CREATE Procedure add_To_cart
@username varchar(20),
 @ProductID int,
 @found int output
 as
begin
declare @userid int
set @userid=(select c.CustomerId from [user] u join customers c on u.userID=c.userID where u.userName=@username)

if(exists(select * from cart join product on product.ProductID=cart.ProductID where cart.ProductID=@ProductID and cart.CustomerId=@userid and AvailableUnit>0))
begin
update cart 
set Quantity =Quantity+1
where ProductID=@ProductID and CustomerId=@userid
end
else if(exists(select *from product where ProductID=@ProductID and AvailableUnit>0))
begin
insert into  cart  values (@userid,@ProductID,1);
end
if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end

end



---------------------------///////////////////////////////////////////-----------------------------------


create Procedure update_productUnits_cart
@username varchar(20),
 @ProductID int,
 @Quantity int,
 @found int output
 as
begin

declare @userid int
set @userid=(select c.CustomerId from [user] u join customers c on u.userID=c.userID where u.userName=@username)


if(exists(select *from product where ProductID=@ProductID and AvailableUnit>@Quantity))
begin

update cart
set Quantity=@Quantity
where CustomerId=@userid and ProductID=@ProductID

end
if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end

end




---------------------------///////////////////////////////////////////-----------------------------------



create Procedure Remove_product_cart
@username varchar(20),
 @ProductID int,
 
 @found int output
 as
begin

declare @userid int
set @userid=(select c.CustomerId from [user] u join customers c on u.userID=c.userID where u.userName=@username)


delete from cart 
where CustomerId=@userid and ProductID=@ProductID
if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end

end



---------------------------///////////////////////////////////////////-----------------------------------



create Procedure cart_price
@username varchar(20),
 @Tprice int output,
 
 @found int output
 as
begin
set @Tprice=0
declare @userid int
set @userid=(select c.CustomerId from [user] u join customers c on u.userID=c.userID where u.userName=@username)


select @Tprice=sum(product.UnitPrice*cart.Quantity) 
from cart join product on product.ProductID=cart.ProductID
where CustomerId=@userid 
group by CustomerId
if(@Tprice=Null)
begin
set @Tprice=0
end

if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end

end



---------------------------///////////////////////////////////////////-----------------------------------


create Procedure rating_product
@username varchar(20),
@ProductID int,
 @stars int ,
 
 @found int output
 as
begin

declare @userid int
set @userid=(select c.CustomerId from [user] u join customers c on u.userID=c.userID where u.userName=@username)
if(exists(select *from Review where CustomerID=@userid and ProductID=@ProductID))
begin
update Review
set Rating=@stars
where CustomerID=@userid
end
else
begin
insert into  Review  values(@userid,@ProductID,@stars)
end

if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end

end





---------------------------///////////////////////////////////////////-----------------------------------



create Procedure show_Rating

@ProductID int,
 @stars int output,
 @found int output

 as
begin
set @stars=0
set @stars=(select sum(Rating)/count(*)
from Review 
where ProductID=@ProductID
group by ProductID
)

if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end

end



---------------------------///////////////////////////////////////////-----------------------------------


create FUNCTION show_RatingUDF(@ProductID int)
RETURNS int
AS
BEGIN
Declare @stars int
set @stars=0
if(exists(select*from Review where ProductID=@ProductID))
begin
set @stars=(select sum(Rating)/count(*)
from Review 
where ProductID=@ProductID
group by ProductID
)
end
else
begin
set @stars=0
end
RETURN @stars
END



---------------------------///////////////////////////////////////////-----------------------------------



create Procedure SellerBuyer_order

@userName varchar(20),
@found int output
 as
begin
declare @userid int
set @userid=(select c.CustomerId from [user] u join customers c on u.userID=c.userID where u.userName=@username)
if(exists(select *from cart where CustomerId=@userid))
begin
   declare @orderid int
	 insert into [order] values ( @userid,GETDATE() )
	 set @orderid=( select top(1) orderID from [order] where CustomerID=@userid order by orderID desc)
	 insert into Order_Details select  @orderid as orderID, c.ProductID ,1 as Statusid ,product.UnitPrice* c.Quantity,c.Quantity from cart c  join product on product.ProductID=c.ProductID where CustomerID=@userid
	delete from cart where CustomerID=@userid
	
end
if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end

end




---------------------------///////////////////////////////////////////-----------------------------------



CREATE  TRIGGER updateUnits_available
ON Order_Details
after insert   
AS 
begin
declare @Quantity int,
@stars int, @ProductID int,  @found int 
set @Quantity=(select i.Quantity from inserted i)
update product
set AvailableUnit=AvailableUnit-@Quantity
where ProductID=(select i.ProductID from inserted i)

--end
set @stars=(select sum(Rating)/count(*)
from Review 
where ProductID=@ProductID
group by ProductID
)

if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end

end



---------------------------///////////////////////////////////////////-----------------------------------




CREATE FUNCTION FILTERED(
@KEYWORD VARCHAR (40)=NULL,
@CITY VARCHAR (40)=NULL,
@TYPE VARCHAR (40)=NULL,
@STARTINGPRICE INT=0,
@ENDINGPRICE INT=0)
RETURNS @OUTPUT TABLE 
(
PRODUCTID INT
)
AS
BEGIN
if(@STARTINGPRICE=0 AND @ENDINGPRICE=0)
BEGIN
INSERT INTO @OUTPUT 
select P.ProductID from [user] u join supplier s on u.userID=s.userID join product p on s.supplierID=p.supplierID  join category c on p.categoryID=c.categoryID
where UPPER(u.city) like UPPER('%'+ @CITY +'%') and (p.ProductName) like UPPER('%'+ @KEYWORD +'%') 
and (c.categoryName) like UPPER('%'+ @TYPE +'%') 
END
ELSE
BEGIN
INSERT INTO @OUTPUT 
select P.ProductID from [user] u join supplier s on u.userID=s.userID join product p on s.supplierID=p.supplierID  join category c on p.categoryID=c.categoryID
where UPPER(u.city) like UPPER('%'+ @CITY +'%') and (p.ProductName) like UPPER('%'+ @KEYWORD +'%') 
and (c.categoryName) like UPPER('%'+ @TYPE +'%') and p.UnitPrice between @STARTINGPRICE and @ENDINGPRICE
END
RETURN
END


---------------------------///////////////////////////////////////////-----------------------------------

create Procedure sFILTERED
@KEYWORD VARCHAR (40),
@CITY VARCHAR (40),
@TYPE VARCHAR (40),
@STARTINGPRICE INT,
@ENDINGPRICE INT,
@found int output

AS
BEGIN
select product.*,dbo.show_RatingUDF(ProductID) as Rating from product where product.ProductID in(
SELECT*
FROM dbo.FILTERED(@KEYWORD,@CITY,@TYPE,@STARTINGPRICE,@ENDINGPRICE))
if(@@ROWCOUNT>0)
	begin
		set @found=1
	end
else
	begin
		set @found=0
	end
END



---------------------------///////////////////////////////////////////-----------------------------------


CREATE PROCEDURE get_products
AS
BEGIN
	SELECT * FROM [product]
END



---------------------------///////////////////////////////////////////-----------------------------------


create PROCEDURE get_product_pic
@ProductID int,
@Picture varchar(200) output
AS
BEGIN
	set @Picture=(SELECT picture FROM [product] WHERE ProductID=@ProductID)
END



--------------------------///////////////////////////////////////////-----------------------------------


create PROCEDURE get_cart
@input_username varchar(20)
AS 
BEGIN
	SELECT [product].*,cart.Quantity FROM [cart] JOIN [Customers] ON [cart].CustomerID = [Customers].CustomerId
	JOIN [user] ON [user].userID = [customers].userID
	JOIN [product] ON [product].ProductID = [cart].ProductID
	WHERE [user].userName = @input_username
END



--------------------------///////////////////////////////////////////-----------------------------------


create PROCEDURE get_searched_products
@input_searchedword varchar(200)
AS
BEGIN
	SELECT product.*,dbo.show_RatingUDF(ProductID) as Rating FROM [product]  
	WHERE  [product].ProductName LIKE '%'+@input_searchedword+'%' OR [product].ProductName LIKE @input_searchedword+'%' OR [product].ProductName LIKE '%'+@input_searchedword OR [product].ProductDescription LIKE '%'+@input_searchedword+'%' 
END




--------------------------///////////////////////////////////////////-----------------------------------


CREATE PROCEDURE get_supplier_products
@input_username varchar (20)
AS
BEGIN
	SELECT * FROM [product] WHERE [product].supplierID = (	select [supplier].supplierID from [supplier]
															JOIN [user] ON [user].userID = [supplier].userID 
															WHERE [user].userName=@input_username)
END



-------------------------///////////////////////////////////////////-----------------------------------


CREATE PROCEDURE get_product
@input_productid int
AS
BEGIN
	SELECT * FROM [product] WHERE product.ProductID=@input_productid
END



-------------------------///////////////////////////////////////////-----------------------------------

CREATE PROCEDURE get_products_of_category
@input_categoryid int
AS
BEGIN
	SELECT * FROM [product] WHERE product.categoryID=@input_categoryid
END


-------------------------///////////////////////////////////////////-----------------------------------


create PROCEDURE get_seller_orders
@input_username varchar(20)
AS
BEGIN
	SELECT Order_Details.OrderDetail_ID as orderID, [product].ProductID, [Status].[Statement], [order].CustomerID, [product].UnitPrice*[Order_Details].Quantity as total_price  FROM [order]
	JOIN [Order_Details] ON [Order_Details].orderID = [order].orderID 
	JOIN [product] ON [product].ProductID = [Order_Details].ProductID
	JOIN [supplier] ON [supplier].supplierID = [product].supplierID
	JOIN [user] ON [user].userID = [supplier].userID
	JOIN [Status] ON [Status].StatusId=[Order_Details].StatusId
	WHERE [user].userName = @input_username
END



-------------------------///////////////////////////////////////////-----------------------------------


CREATE PROCEDURE get_buyer_orders
@input_username varchar(20)
AS
BEGIN
	Select [order].orderID, [Status].[Statement], SUM([Order_Details].price) as total_price from [order] JOIN [customers] ON [customers].CustomerId = [order].CustomerID
	JOIN [user] on [user].userID = [customers].userID
	JOIN [Order_Details] ON [Order_Details].orderID = [order].orderID
	JOIN [Status] ON [Status].StatusId = [Order_Details].StatusId
	WHERE [user].userName = @input_username
	GROUP BY [order].orderID, [Status].[Statement]
END



-------------------------///////////////////////////////////////////-----------------------------------

CREATE PROCEDURE get_category_products
@input_keyword varchar(50)
AS
BEGIN
	SELECT [product].*, dbo.show_RatingUDF([product].ProductID) as Rating FROM [product] JOIN [category] ON [category].categoryID = [product].categoryID
	WHERE [category].categoryName = @input_keyword
END



-------------------------///////////////////////////////////////////-----------------------------------

CREATE PROCEDURE update_status
@orderID int,
@status varchar(50)

AS
BEGIN
	declare @id int
	set @id=(select StatusId from [Status] where [Status].Statement=@status)
	update Order_Details
	set StatusId=@id
	where OrderDetail_ID=@orderID
END
