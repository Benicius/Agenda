using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebApplication.Models;
using WebApplication.Persistence;
using System.Text;
using System.Data;

namespace WebApplication.Models.PessoaDAO
{
    public class PessoaDAO : Conexao
    {

        public void Salvar(Pessoa p)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("insert into Pessoa(Nome, CPF, Endereco) output inserted.Id " +
                    "values(@v1, @v2, @v3)", Con);

                var CmdEndereco = new SqlCommand("insert into Endereco(Logradouro, Numero, CEP, Bairro, Cidade, Estado) output inserted.Id " +
                     "values(@v4, @v5, @v6, @v7, @v8, @v9)", Con);

                Cmd.Parameters.AddWithValue("@v1", p.Nome);
                Cmd.Parameters.AddWithValue("@v2", p.CPF);

                CmdEndereco.Parameters.AddWithValue("@v4", p.Endereco.Logradouro);
                CmdEndereco.Parameters.AddWithValue("@v5", p.Endereco.Numero);
                CmdEndereco.Parameters.AddWithValue("@v6", p.Endereco.CEP);
                CmdEndereco.Parameters.AddWithValue("@v7", p.Endereco.Bairro);
                CmdEndereco.Parameters.AddWithValue("@v8", p.Endereco.Cidade);
                CmdEndereco.Parameters.AddWithValue("@v9", p.Endereco.Estado);

                var enderecoId = (Int32)CmdEndereco.ExecuteScalar();
                Cmd.Parameters.AddWithValue("@v3", enderecoId);

                var pessoaId = (Int32)Cmd.ExecuteScalar();
               
                foreach (var tel in p.Telefones)
                {

                    var CmdTelefone = new SqlCommand("insert into Telefone(DDD, Numero, Tipo) output inserted.IdTelefone " +
                    "values(@v10, @v11, @v12)", Con);
                    
                    var CmdPessoaTelefone = new SqlCommand("insert into Pessoa_Telefone(Id_Pessoa, Id_Telefone) " +
                        "values(@v13, @v14)", Con);

                    CmdTelefone.Parameters.AddWithValue("@v10", tel.DDD);
                    CmdTelefone.Parameters.AddWithValue("@v11", tel.Numero);
                    
                    CmdTelefone.Parameters.AddWithValue("@v12", tel.TipoTelefone.IdTipoTelefone);

                    CmdPessoaTelefone.Parameters.AddWithValue("@v13", pessoaId);

                    var telefoneId = (Int32)CmdTelefone.ExecuteScalar();
                    CmdPessoaTelefone.Parameters.AddWithValue("@v14", telefoneId);

                    CmdPessoaTelefone.ExecuteNonQuery();
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
            foreach (var tel in p.Telefones)
            {
                AtualizarTelefone(tel);
                AtualizarTelefone(tel.TipoTelefone);
            }
            AtualizarPessoa(p);
            AtualizarEndereco(p.Endereco);
        }

        private void AtualizarEndereco(Endereco endereco)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand(
                    "update Endereco " +
                    "set Logradouro=@v4, Numero=@v5, CEP=@v6, Bairro=@v7, Cidade=@v8, Estado=@v9 " +
                    "where Id=@v10", Con);

                Cmd.Parameters.AddWithValue("@v4", endereco.Logradouro);
                Cmd.Parameters.AddWithValue("@v5", endereco.Numero);
                Cmd.Parameters.AddWithValue("@v6", endereco.CEP);
                Cmd.Parameters.AddWithValue("@v7", endereco.Bairro);
                Cmd.Parameters.AddWithValue("@v8", endereco.Cidade);
                Cmd.Parameters.AddWithValue("@v9", endereco.Estado);
                Cmd.Parameters.AddWithValue("@v10", endereco.IdEndereco);


                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Atualizar Endereço:" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        private void AtualizarPessoa(Pessoa p)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand(
                    "update Pessoa " +
                    "set Nome=@v1, CPF=@v2 " +
                    "where Id=@v3", Con);

                Cmd.Parameters.AddWithValue("@v1", p.Nome);
                Cmd.Parameters.AddWithValue("@v2", p.CPF);
                Cmd.Parameters.AddWithValue("@v3", p.IdPessoa);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Atualizar Pessoa:" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        private void AtualizarTelefone(Telefone tel)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand(
                    "update Telefone " +
                    "set DDD=@v1, Numero=@v2, Tipo=@v3 " +
                    "where Id=@v4", Con);

                Cmd.Parameters.AddWithValue("@v1", tel.DDD);
                Cmd.Parameters.AddWithValue("@v2", tel.Numero);
                Cmd.Parameters.AddWithValue("@v3", tel.Tipo);
                Cmd.Parameters.AddWithValue("@v4", tel.IdTelefone);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Atualizar Telefone:" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        private void AtualizarTelefone(TipoTelefone tipo)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand(
                    "update TipoTelefone " +
                    "set Tipo=@v1 " +
                    "where Id=@v2", Con);

                Cmd.Parameters.AddWithValue("@v1", tipo.Tipo);
                Cmd.Parameters.AddWithValue("@v2", tipo.IdTipoTelefone);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Atualizar Tipo de Telefone:" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Excluir(Pessoa p)
        {
            foreach(var tel in p.Telefones)
            {
                ExcluirPessoaTelefone(p.IdPessoa, tel.IdTelefone);
                ExcluirTelefone(tel.IdTelefone);
            }
            ExcluirPessoa(p.IdPessoa);
            ExcluirEndereco(p.Endereco.IdEndereco);
        } 

        private void ExcluirPessoa(int Id)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("delete from Pessoa where Id=@v1", Con);

                Cmd.Parameters.AddWithValue("@v1", Id);
                Cmd.ExecuteNonQuery();
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

        private void ExcluirPessoaTelefone(int Id_Pessoa, int Id_Telefone)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("delete from Pessoa_Telefone where Id_Telefone=@v1 and Id_Pessoa=@v2", Con);

                Cmd.Parameters.AddWithValue("@v1", Id_Telefone);
                Cmd.Parameters.AddWithValue("@v2", Id_Pessoa);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir a telefone: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        private void ExcluirTelefone(int Id)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("delete from Telefone where IdTelefone=@v1", Con);

                Cmd.Parameters.AddWithValue("@v1", Id);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir a telefone: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        private void ExcluirEndereco(int Id)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("delete from Endereco where Id=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", Id);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir a endereco: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public Pessoa PesquisarId(int Id)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select p.Id as IdPessoa, p.Nome, p.CPF, t.Numero, " +
                    "e.Id as EnderecoId, e.Logradouro, e.Numero, e.CEP, e.Bairro, e.Cidade, e.Estado, " +
                    "t.IdTelefone, t.DDD, t.Numero, tipo.Tipo " +
                    "from Pessoa_Telefone pt " +
                    "inner join Pessoa p on p.Id = pt.Id_Pessoa " +
                    "inner join Endereco e on e.Id = p.Endereco " +
                    "inner join Telefone t on t.IdTelefone = pt.Id_Telefone " +
                    "inner join TipoTelefone tipo on tipo.IdTipoTelefone = t.Tipo " +
                    "where p.Id = @v1", Con);

                Cmd.Parameters.AddWithValue("@v1", Id);

                Dr = Cmd.ExecuteReader();

                Pessoa p = new Pessoa();
                p.Telefones = new List<Telefone>();
                p.Endereco = new Endereco();
                if (Dr.HasRows)
                {
                    while (Dr.Read())
                    {
                        p.IdPessoa = Convert.ToInt32(Dr["IdPessoa"]);
                        p.Nome = Convert.ToString(Dr["Nome"]);
                        p.CPF = Convert.ToInt64(Dr["CPF"]);

                        p.Endereco.IdEndereco = Convert.ToInt32(Dr["EnderecoId"]);
                        p.Endereco.Logradouro = Convert.ToString(Dr["Logradouro"]);
                        p.Endereco.Numero = Convert.ToInt32(Dr["Numero"]);
                        p.Endereco.CEP = Convert.ToInt32(Dr["CEP"]);
                        p.Endereco.Bairro = Convert.ToString(Dr["Bairro"]);
                        p.Endereco.Cidade = Convert.ToString(Dr["Cidade"]);
                        p.Endereco.Estado = Convert.ToString(Dr["Estado"]);


                        Telefone tel = new Telefone();
                        tel.IdTelefone = Convert.ToInt32(Dr["IdTelefone"].ToString());
                        tel.DDD = Convert.ToInt32(Dr["DDD"].ToString());
                        tel.Numero = Convert.ToInt32(Dr["Numero"].ToString());
                        tel.Tipo = Convert.ToString(Dr["Tipo"].ToString());
                        p.Telefones.Add(tel);


                    }
                    return p;
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

        public Pessoa PesquisarCpf(long CPF)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select p.Id as IdPessoa, p.Nome, p.CPF, t.Numero, " +
                    "e.Id as EnderecoId, e.Logradouro, e.Numero, e.CEP, e.Bairro, e.Cidade, e.Estado, " +
                    "t.IdTelefone, t.DDD, t.Numero, tipo.Tipo " +
                    "from Pessoa p " +
                    "left join Pessoa_Telefone pt on p.Id = pt.Id_Pessoa " +
                    "inner join Endereco e on e.Id = p.Endereco " +
                    "inner join Telefone t on t.IdTelefone = pt.Id_Telefone " +
                    "inner join TipoTelefone tipo on tipo.IdTipoTelefone = t.Tipo " +
                    "where p.CPF = @v1", Con);

                Cmd.Parameters.AddWithValue("@v1", CPF);

                Dr = Cmd.ExecuteReader();

                Pessoa p = new Pessoa();
                p.Telefones = new List<Telefone>();
                p.Endereco = new Endereco();
                if (Dr.HasRows)
                {
                    while (Dr.Read())
                    {
                        p.IdPessoa = Convert.ToInt32(Dr["IdPessoa"]);
                        p.Nome = Convert.ToString(Dr["Nome"]);
                        p.CPF = Convert.ToInt64(Dr["CPF"]);

                        p.Endereco.IdEndereco = Convert.ToInt32(Dr["EnderecoId"]);
                        p.Endereco.Logradouro = Convert.ToString(Dr["Logradouro"]);
                        p.Endereco.Numero = Convert.ToInt32(Dr["Numero"]);
                        p.Endereco.CEP = Convert.ToInt32(Dr["CEP"]);
                        p.Endereco.Bairro = Convert.ToString(Dr["Bairro"]);
                        p.Endereco.Cidade = Convert.ToString(Dr["Cidade"]);
                        p.Endereco.Estado = Convert.ToString(Dr["Estado"]);

                        
                        Telefone tel = new Telefone();
                        tel.IdTelefone = Convert.ToInt32(Dr["IdTelefone"].ToString());
                        tel.DDD = Convert.ToInt32(Dr["DDD"].ToString());
                        tel.Numero = Convert.ToInt32(Dr["Numero"].ToString());
                        tel.Tipo = Convert.ToString(Dr["Tipo"].ToString());
                        p.Telefones.Add(tel);
                        

                    }
                    return p;
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

        public DataTable ListarPessoa()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select p.Nome, p.CPF, t.Numero, e.Logradouro " +
                    "from Pessoa_Telefone pt " +
                    "inner join Pessoa p on p.Id = pt.Id_Pessoa " +
                    "inner join Endereco e on e.Id = p.Endereco " +
                    "inner join Telefone t on t.IdTelefone = pt.Id_Telefone ", Con);

                Dr = Cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(Dr);

                return dt;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar as pessoas: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}