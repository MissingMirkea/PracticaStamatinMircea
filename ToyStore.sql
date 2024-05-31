create database Toystore;
Use Toystore;

Create table boss (
boss_id int Primary key identity(1,1),
boss_name varchar(100),
boss_password varchar(100));

insert into boss(boss_name,boss_password) values 
('1','2');
select *from boss;

create table toys(
toys_id int Primary Key identity(0,1),
toys_name varchar(100),
toy_type varchar(100),
toy_size varchar(100),
toy_color varchar(100),
toy_manufacturer varchar(100),
toy_country varchar(100),
toy_age int,
toy_cantity int,
toy_price float);

insert into toys(toys_name , toy_type ,toy_size,toy_color,toy_manufacturer,toy_country,toy_age,toy_cantity,toy_price) values
(null , null,null,null,null,null,null,null,null);

drop table toys;
delete from toys;
select *From toys;
delete from toys where toys_id = 1;

Select toys_id as Id , toys_name as Denumirea , toy_type as Tip , toy_size as Marimea , toy_color as Culoare , toy_manufacturer as Producator,toy_country as Tara , toy_age as Varsta ,toy_cantity as Stock, toy_price as Pret from toys where toys_id>0 and toy_cantity >0;

create table outofstock(
toys_id int Primary Key identity (1,1),
toys_name varchar(100),
toy_type varchar(100),
toy_size varchar(100),
toy_color varchar(100),
toy_manufacturer varchar(100),
toy_country varchar(100),
toy_age int,
toy_cantity int,
toy_price float);

insert into outofstock(toys_name , toy_type ,toy_size,toy_color,toy_manufacturer,toy_country,toy_age,toy_cantity,toy_price) select toys_name , toy_type ,toy_size,toy_color,toy_manufacturer,toy_country,toy_age,toy_cantity,toy_price From toys where toys_id >0 ;
select *from outofstock;
drop table outofstock;
INSERT INTO toys (toys_name, toy_type, toy_size, toy_color, toy_manufacturer, toy_country, toy_age, toy_cantity, toy_price)
VALUES
    ('Teddy Bear', 'Plush', 'Medium', 'Brown', 'ABC Toys', 'USA', 3, 0, 15.99);
    ('LEGO Set', 'Building Blocks', 'Large', 'Multi-color', 'LEGO', 'Denmark', 6, 100, 29.99),
    ('Barbie Doll', 'Fashion Doll', 'Small', 'Pink', 'Mattel', 'USA', 4, 80, 12.99),
    ('Remote Control Car', 'Toy Vehicle', 'Medium', 'Red', 'ToyZone', 'China', 5, 30, 39.99),
    ('Puzzle', 'Educational', 'Small', 'Various', 'PuzzleCo', 'Germany', 8, 60, 9.99);
Select toys_id as Id , toys_name as Denumirea , toy_type as Tip , toy_size as Marimea , toy_color as Culoare , toy_manufacturer as Producator,toy_country as Tara , toy_age as Varsta_Recomandata ,toy_cantity as Stock, toy_price as Pret from toys where toys_id>0  order by toy_price asc ;

create table vanzari(
transaction_number int Primary Key  Identity(1,1),
toys_name varchar(100),
toy_type varchar(100),
toy_size varchar(100),
toy_color varchar(100),
toy_manufacturer varchar(100),
toy_country varchar(100),
toy_age int,
toy_cantity int,
toy_price float,
);

drop table vanzari;
