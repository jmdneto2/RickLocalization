use RickLocalization

insert into Dimensao values('C-130');
insert into Dimensao values('C-131');
insert into Dimensao values('C-132');
insert into Dimensao values('C-133');
insert into Dimensao values('C-145');
insert into Dimensao values('C-140');
insert into Dimensao values('C-141');
insert into Dimensao values('C-142');
insert into Dimensao values('C-143');
insert into Dimensao values('C-145');
GO
--select * from dimensao
--select * from personagem
--select * from viagem

insert into Personagem 
select 'Rick',DimensaoId,'http://labcon.fafich.ufmg.br/wp-content/uploads/2018/06/5164749-940x429.jpg' from Dimensao
GO
insert into Personagem 
select 'Morty',DimensaoId,'http://labcon.fafich.ufmg.br/wp-content/uploads/2018/06/5164749-940x429.jpg' from Dimensao
GO
--delete from viagem
select * from Viagem

insert into Viagem
select 1,1,DimensaoId, getdate() from dimensao; 
GO
insert into Viagem
select 1,2,DimensaoId, getdate() from dimensao;
GO
insert into Viagem
select 1,3,DimensaoId, getdate() from dimensao;
GO
insert into Viagem
select 1,4,DimensaoId, getdate() from dimensao;
GO
insert into Viagem
select 1,5,DimensaoId, getdate() from dimensao;
