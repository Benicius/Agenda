using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebApplication.Models;
using WebApplication.Persistence;
using System.Text;

namespace WebApplication.Models.PessoaDAO
{
    public class PessoaDAO : Conexao
    {
        public void Salvar(Pessoa p)
        {
            try
            {
                AbrirConexao();
                StringBuilder sqlComando = new StringBuilder();
                sqlComando.Append($"INSERT INTO Endereco(                           ");
                sqlComando.Append($"                     Logradouro,                ");
                sqlComando.Append($"                         Numero,                ");
                sqlComando.Append($"                            CEP,                ");
                sqlComando.Append($"                         Bairro,                ");
                sqlComando.Append($"                         Cidade,                ");
                sqlComando.Append($"                         Estado                 ");
                sqlComando.Append($"                    )                           ");
                sqlComando.Append($"              Values(                           ");
                sqlComando.Append($"                     '{p.Endereco.Logradouro}', ");
                sqlComando.Append($"                           {p.Endereco.Numero}, ");
                sqlComando.Append($"                              {p.Endereco.CEP}, ");
                sqlComando.Append($"                         '{p.Endereco.Bairro}', ");
                sqlComando.Append($"                         '{p.Endereco.Cidade}', ");
                sqlComando.Append($"                         '{p.Endereco.Estado}'  ");
                sqlComando.Append($"                    )                           ");
                sqlComando.Append($"SET @ID = @@IDENTITY                            ");
                sqlComando.Append($"RETURN @ID                                      ");
                Cmd = new SqlCommand(sqlComando.ToString(), Con);
                var idEndereco = Cmd.ExecuteScalar();
                Cmd = null; //Limpar para usar o mesmo objeto para o Endereço
                sqlComando.Clear();
                sqlComando.Append($"INSERT INTO Pessoa(               ");
                sqlComando.Append($"                   Nome,          ");
                sqlComando.Append($"                   CPF,           ");
                sqlComando.Append($"                   Endereco       ");
                sqlComando.Append($"                  )               ");
                sqlComando.Append($"            VALUES(               ");
                sqlComando.Append($"                   '{p.Nome}',    ");
                sqlComando.Append($"                   '{p.CPF}',     ");
                sqlComando.Append($"                    {idEndereco}  ");
                sqlComando.Append($"                  )               ");
                sqlComando.Append($"SET @ID = @@IDENTITY              ");
                sqlComando.Append($"RETURN @ID                        ");
                Cmd = new SqlCommand(sqlComando.ToString(), Con);
                var idPessoa = Cmd.ExecuteScalar();
                Cmd = null; //Limpar o Endereço para cadastrar outro objeto
                sqlComando.Clear();

                
                foreach(var telefone in p.Telefones)
                {
                    sqlComando.Append($"INSERT TIPO TipoTelefone(                               ");
                    sqlComando.Append($"                         Tipo                           ");
                    sqlComando.Append($"                        )                               ");
                    sqlComando.Append($"                  VALUES(                               ");
                    sqlComando.Append($"                         '{telefone.TipoTelefone.Tipo}' ");
                    sqlComando.Append($"                        )                               ");
                    sqlComando.Append($"SET @ID = @@IDENTITY                                    ");
                    sqlComando.Append($"RETURN @ID                                              ");
                    Cmd = new SqlCommand(sqlComando.ToString(), Con);
                    var idTipoTelefone = Cmd.ExecuteScalar();
                    Cmd = null; //Limpar o Tipo Telefone Cadastrado para Cadastrar o Telefone
                    sqlComando.Clear();
                    sqlComando.Append($"INSERT INTO Telefone(                   ");
                    sqlComando.Append($"                        DDD,            ");
                    sqlComando.Append($"                     Numero,            ");
                    sqlComando.Append($"                       Tipo             ");
                    sqlComando.Append($"                    )                   ");
                    sqlComando.Append($"              VALUES(                   ");
                    sqlComando.Append($"                        {telefone.DDD}, ");
                    sqlComando.Append($"                     {telefone.Numero}, ");
                    sqlComando.Append($"                      {idTipoTelefone}, ");
                    sqlComando.Append($"                    )                   ");
                    sqlComando.Append($"SET @ID = @@IDENTITY                    ");
                    sqlComando.Append($"RETURN @ID                              ");
                    Cmd = new SqlCommand(sqlComando.ToString(), Con);
                    var idTelefone = Cmd.ExecuteScalar();
                    Cmd = null; //Limpar o Tipo Telefone Cadastrado para Cadastrar o Telefone
                    sqlComando.Clear();
                    sqlComando.Append($"INSERT INTO Pessoa_Telefone(             ");
                    sqlComando.Append($"                            Id_Pessoa,   ");
                    sqlComando.Append($"                            Id_Telefone  ");
                    sqlComando.Append($"                           )             ");
                    sqlComando.Append($"                     VALUES(             ");
                    sqlComando.Append($"                            {idPessoa},  ");
                    sqlComando.Append($"                            {idTelefone} ");
                    sqlComando.Append($"                           )             ");
                    Cmd = new SqlCommand(sqlComando.ToString(), Con);
                    Cmd.ExecuteNonQuery();
                    Cmd = null; //Limpara para voltar todo o fluxo
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Gravar Pessoa: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Atualizar(Pessoa p)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("update Pessoa set nome=@v1, CPF=@v2, Endereco=@v3, Logradouro=@v4, Numero=@v5, " +
                    "CEP=@v6, Bairro=@v7, Cidade=@v8, Estado=@v9 where Id=@v10", Con);

                Cmd.Parameters.AddWithValue("@v1", p.Nome);
                Cmd.Parameters.AddWithValue("@v2", p.CPF);
                Cmd.Parameters.AddWithValue("@v3", p.Endereco);
                Cmd.Parameters.AddWithValue("@v4", p.Endereco.Logradouro);
                Cmd.Parameters.AddWithValue("@v5", p.Endereco.Numero);
                Cmd.Parameters.AddWithValue("@v6", p.Endereco.CEP);
                Cmd.Parameters.AddWithValue("@v7", p.Endereco.Bairro);
                Cmd.Parameters.AddWithValue("@v8", p.Endereco.Cidade);
                Cmd.Parameters.AddWithValue("@v9", p.Endereco.Estado);
                Cmd.Parameters.AddWithValue("@v10", p.IdPessoa);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Atualizar CLiente:" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Excluir(int Id)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("delete from Pessoa where Id=@v1", Con);

                Cmd.Parameters.AddWithValue("@v1", Id);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir a pessoa: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public Pessoa PesquisarCpf(string CPF)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select * from Pessoa where CPF=@v1", Con);

                Cmd.Parameters.AddWithValue("@v1", CPF);

                Pessoa p = null;

                if (Dr.Read())
                {
                    p = new Pessoa();
                    p.Nome = Convert.ToString(Dr["Nome"]);
                    p.CPF = Convert.ToInt64(Dr["CPF"]);
                }
                return p;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao pesquisar CPF: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Pessoa> ListarPessoa()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select p.id, end.id, p.Nome, p.CPF, end.Logradouro, end.Numero, end.CEP, end.Bairro, end.Cidade, end.Estado" +
                    "from Pessoa p " +
                    "inner join Endereco end on end.Id = Pessoa.Endereco" +
                    "where p.id=@v1 and end.id=@v2", Con);

                Dr = Cmd.ExecuteReader();

                List<Pessoa> lista = new List<Pessoa>();

                while (Dr.Read())
                {
                    Pessoa p = new Pessoa();
                    p.Nome = Convert.ToString(Dr["Nome"]);
                    p.CPF = Convert.ToInt64(Dr["CPF"]);

                    Endereco end = new Endereco();
                    end.Logradouro = Convert.ToString(Dr["Logradouro"]);
                    end.Numero = Convert.ToInt32(Dr["Numero"]);
                    end.CEP = Convert.ToInt32(Dr["CEP"]);
                    end.Bairro = Convert.ToString(Dr["Bairro"]);
                    end.Cidade = Convert.ToString(Dr["Cidade"]);
                    end.Estado = Convert.ToString(Dr["Estado"]);

                    p.Endereco.Logradouro = end.Logradouro;
                    p.Endereco.Numero = end.Numero;
                    p.Endereco.CEP = end.CEP;
                    p.Endereco.Bairro = end.Bairro;
                    p.Endereco.Cidade = end.Cidade;
                    p.Endereco.Estado = end.Estado;

                    lista.Add(p);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao pesquisar CPF: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}