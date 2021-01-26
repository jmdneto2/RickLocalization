use RickLocalization

insert into Dimensao values('C-130');
GO
insert into Dimensao values('C-131');
GO
insert into Dimensao values('C-132');
GO
insert into Dimensao values('C-133');
GO
insert into Dimensao values('C-145');
GO
insert into Dimensao values('C-140');
GO
insert into Dimensao values('C-141');
GO
insert into Dimensao values('C-142');
GO
insert into Dimensao values('C-143');
GO
insert into Dimensao values('C-146');
GO
insert into Dimensao values('C-147');
GO
insert into Dimensao values('C-148');
GO
insert into Dimensao values('C-149');
GO
insert into Dimensao values('C-150');
GO
insert into Dimensao values('C-151');
GO
insert into Dimensao values('C-152');
GO
insert into Dimensao values('C-153');
GO
insert into Dimensao values('C-154');
GO
insert into Dimensao values('C-155');
GO
insert into Personagem 
select 'Rick',DimensaoId,'http://labcon.fafich.ufmg.br/wp-content/uploads/2018/06/5164749-940x429.jpg' from Dimensao
GO
insert into Personagem 
select 'Morty',DimensaoId,'http://labcon.fafich.ufmg.br/wp-content/uploads/2018/06/5164749-940x429.jpg' from Dimensao
GO

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

--select * from dimensao
--select * from personagem
--select * from viagem

--select per.*, dim.DimensaoNome from personagem per
--inner join Dimensao dim on per.PersonagemDimensaoDimensaoId = dim.DimensaoId
