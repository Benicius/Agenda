select p.Id as IdPessoa, p.Nome, p.CPF, t.Numero, 
e.Id as EnderecoId, e.Logradouro, e.Numero, e.CEP, e.Bairro, e.Cidade, e.Estado, 
t.IdTelefone, t.DDD, t.Numero, tipo.Tipo 
from Pessoa p 
left join Pessoa_Telefone pt on p.Id = pt.Id_Pessoa 
inner join Endereco e on e.Id = p.Endereco 
inner join Telefone t on t.IdTelefone = pt.Id_Telefone 
inner join TipoTelefone tipo on tipo.IdTipoTelefone = t.Tipo 
where p.CPF = 222;

select * from Telefone;

select * from TipoTelefone;

insert into Pessoa_Telefone(Id_Pessoa, Id_Telefone) values(13, 22);

insert into Telefone(DDD, Numero, Tipo) values(010, 964839696, 2);