--Create new admin
INSERT INTO [pizza_restaurant_ver_8].[dbo].[account] (e_mail, login, password, name, surname, account_creation_date, phone_number, role)
VALUES ('root@root.pl','root','1234','Admin','szef', GETDATE(), '123654789', 'Admin');

INSERT INTO pizza_restaurant_ver_8.dbo.client (points,address,account_id_account)
VALUES (0,'Fryderyka Chopina 9', (SELECT COUNT(*) FROM pizza_restaurant_ver_8.dbo.account));

--Create new Admin
INSERT INTO [pizza_restaurant_ver_8].[dbo].[account] (e_mail, login, password, name, surname, account_creation_date, phone_number, role)
VALUES ('random@o2.pl','borubar4321','1234','Fidol','P�penek', GETDATE(), '123654789', 'Client');

INSERT INTO pizza_restaurant_ver_8.dbo.client (points,address,account_id_account)
VALUES (0,'Zwyci�stwa 2', (SELECT COUNT(*) FROM pizza_restaurant_ver_8.dbo.account));

--Create new Manager
INSERT INTO [pizza_restaurant_ver_8].[dbo].[account] (e_mail, login, password, name, surname, account_creation_date, phone_number, role)
VALUES ('kowalski@o2.pl','Kowal','1234','Janek','Kowalski', GETDATE(), '123654789', 'Manager');

INSERT INTO pizza_restaurant_ver_8.dbo.client (points,address,account_id_account)
VALUES (0,'Amarantowa 1', (SELECT COUNT(*) FROM pizza_restaurant_ver_8.dbo.account));

--Create new pizza type
INSERT INTO pizza_restaurant_ver_8.dbo.pizza (price, cost, isAvailable, type, size, points)
VALUES (16, 14, 1, 'Margherita', 32, 0);

INSERT INTO pizza_restaurant_ver_8.dbo.pizza (price, cost, isAvailable, type, size, points)
VALUES (18, 15, 1, 'Funghi', 32, 0);

INSERT INTO pizza_restaurant_ver_8.dbo.pizza (price, cost, isAvailable, type, size, points)
VALUES (21, 17, 1, 'Capriciosa', 32, 1);


INSERT INTO pizza_restaurant_ver_8.dbo.pizza (price, cost, isAvailable, type, size, points)
VALUES (21, 16, 1, 'Pepperoni', 32, 2);

INSERT INTO pizza_restaurant_ver_8.dbo.pizza (price, cost, isAvailable, type, size, points)
VALUES (22, 17, 1, 'Roma', 32, 2);

INSERT INTO pizza_restaurant_ver_8.dbo.pizza (price, cost, isAvailable, type, size, points)
VALUES (22, 16, 1, 'Capo', 32, 2);

INSERT INTO pizza_restaurant_ver_8.dbo.pizza (price, cost, isAvailable, type, size, points)
VALUES (28, 22, 1, 'Quattro formaggi', 32, 5);

--create new restaurats
INSERT INTO pizza_restaurant_ver_8.dbo.restaurant (address, phone_number, e_mail)
VALUES ('Konarskiego 13', '1293848576', 'galakPizzaK@gmail.com');

INSERT INTO pizza_restaurant_ver_8.dbo.restaurant (address, phone_number, e_mail)
VALUES ('Akademicka 16', '322371310', 'galakPizzaA@gmail.com');

INSERT INTO pizza_restaurant_ver_8.dbo.restaurant (address, phone_number, e_mail)
VALUES ('Chorzowska 23', '123654798', 'galakPizzaC@gmail.com');