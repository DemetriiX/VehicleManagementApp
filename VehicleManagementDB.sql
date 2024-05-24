use db_aa599a_workprojectdb;
go

create table VehicleMake 
(
    Id int primary key identity,
    Name nvarchar(100) not null,
    Abrv nvarchar(50) not null
);

create table VehicleModel 
(
    Id int primary key identity,
    Name nvarchar(100) not null,
    Abrv nvarchar(50) not null,
    MakeId int not null,
    foreign key (MakeId) references VehicleMake(Id)
);