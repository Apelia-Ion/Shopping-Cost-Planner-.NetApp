--Drop table Users;
--Drop table Categories;
--Drop table Stores;
--Drop table ShoppingLists;
--Drop table Items;

select * from Users;
select * from Categories;
select * from Stores;
select * from ShoppingLists;
select * from Items;
select * from ItemShoppingList;

rollback;
SET IDENTITY_INSERT Users OFF;
SET IDENTITY_INSERT Users ON;

DELETE FROM ItemShoppingList
WHERE ItemId =3;