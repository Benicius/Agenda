using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebApplication.Models;
using WebApplication.Persistence;

namespace WebApplication.Models.PessoaDAO
{
    public class PessoaDAO : Conexao
    {
        public void Salvar(Pessoa p)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("insert into Pessoa(Nome, CPF, Endereco) " +
                    "values(@v1, @v2, @v3) DECLARE @ID INT SET @ID = @@IDENTITY RETURN @ID", Con);

                var CmdEndereco = new SqlCommand("insert into Endereco(Logradouro, Numero, CEP, Bairro, Cidade, Estado) output inserted.Id " +
                     "values(@v4, @v5, @v6, @v7, @v8, @v9)", Con);

                var CmdTelefone = new SqlCommand("insert into Telefone(DDD, Numero, Tipo) output inserted.IdTelefone " +
                    "values(@v10, @v11, @v12)", Con);

                var CmdTipoTelefone = new SqlCommand("insert into TipoTelefone(Tipo) output inserted.IdTipoTelefone " +
                    "values(@v13)", Con);

                var CmdPessoaTelefone = new SqlCommand("insert into Pessoa_Telefone(Id_Pessoa, Id_Telefone) output inserted.Id_Pessoa, inserted.Id_Telefone " +
                    "values(@v14, @v15)", Con);

                Cmd.Parameters.AddWithValue("@v1", p.Nome);
                Cmd.Parameters.AddWithValue("@v2", p.CPF);

                SqlDataReader reader = Cmd.ExecuteReader();

                var IdPessoa = 0;

                while (reader.Read())
                {
                    IdPessoa = int.Parse( reader[0].ToString());
                }

                

                CmdEndereco.Parameters.AddWithValue("@v4", p.Endereco.Logradouro);
                CmdEndereco.Parameters.AddWithValue("@v5", p.Endereco.Numero);
                CmdEndereco.Parameters.AddWithValue("@v6", p.Endereco.CEP);
                CmdEndereco.Parameters.AddWithValue("@v7", p.Endereco.Bairro);
                CmdEndereco.Parameters.AddWithValue("@v8", p.Endereco.Cidade);
                CmdEndereco.Parameters.AddWithValue("@v9", p.Endereco.Estado);

                var enderecoId = (Int32)CmdEndereco.ExecuteScalar();
                Cmd.Parameters.AddWithValue("@v3", enderecoId);

                foreach(Telefone telefone in p.Telefones)
                {
                    CmdTelefone.Parameters.AddWithValue("@v10", telefone.Numero);
                    CmdTelefone.Parameters.AddWithValue("@v11", telefone.Numero);
                    CmdTelefone.Parameters.AddWithValue("@v13", telefone.TipoTelefone.Tipo);

                    var tipoTeledoneID = (Int32)CmdTipoTelefone.ExecuteScalar();
                    CmdTelefone.Parameters.AddWithValue("@v12", telefone.Numero);

                    p.Telefones.Add(telefone);
                }


                Cmd.ExecuteNonQuery();
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