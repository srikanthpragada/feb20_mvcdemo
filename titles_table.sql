create table Titles
(  TitleId int identity (1,1) Primary key,
   Title   varchar(50),
   Author  varchar(100),
   Price   int
);

insert into Titles values('Asp.Net MVC','Stephen Walther',550);
insert into Titles values('Entity Framework','Julien',450);
insert into Titles values('jQuery in Action','Krudha',350);
