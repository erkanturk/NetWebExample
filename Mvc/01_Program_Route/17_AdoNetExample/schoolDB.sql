Create Database SchoolDB
use SchoolDB
Create Table Students 
(
FirstName varchar(50),
LastName Varchar (50),
Age int 
)

Select * from Students

create proc sp_Students
as
begin
set nocount on;
	select FirstName,LastName,Age from Students
end

