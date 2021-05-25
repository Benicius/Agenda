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

        private int validarTipo(int Tipo)
        {
            DataTable dt = new DataTable();
            

            SqlDataReader reader;
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select * from TipoTelefone where IdTipoTelefone = @v1", Con);
                
                Cmd.Parameters.AddWithValue("@v1", Tipo);
                reader = Cmd.ExecuteReader();
                dt.Load(reader);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    string tipo = "Residencia";
                    var CmdTipoTelefone = new SqlCommand("insert into TipoTelefone(Tipo) output inserted.IdTipoTelefone " +
                        "values(@v2)", Con);
                    CmdTipoTelefone.Parameters.AddWithValue("@v2", tipo);
                    
                    Tipo = (Int32)CmdTipoTelefone.ExecuteScalar();

                    return Tipo;

                }
                return Tipo;
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                FecharConexao();
            }
        }

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
                int tipoTelefone = validarTipo(10);
                AbrirConexao();
                foreach (var tel in p.Telefones)
                {
                    var CmdTelefone = new SqlCommand("insert into Telefone(DDD, Numero, Tipo) output inserted.IdTelefone " +
                    "values(@v10, @v11, @v12)", Con);
                    
                    var CmdPessoaTelefone = new SqlCommand("insert into Pessoa_Telefone(Id_Pessoa, Id_Telefone) " +
                        "values(@v13, @v14)", Con);

                    CmdTelefone.Parameters.AddWithValue("@v10", tel.DDD);
                    CmdTelefone.Parameters.AddWithValue("@v11", tel.Numero);
                    
                    CmdTelefone.Parameters.AddWithValue("@v12", tipoTelefone);

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

        public Pessoa PesquisarCpf(long CPF)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select p.Nome, p.CPF, t.Numero, e.Logradouro, e.Numero, e.CEP, e.Bairro, e.Cidade, e.Estado " +
                    "from Pessoa_Telefone pt " +
                    "inner join Pessoa p on p.Id = pt.Id_Pessoa " +
                    "inner join Endereco e on e.Id = p.Endereco " +
                    "inner join Telefone t on t.IdTelefone = pt.Id_Telefone " +
                    "where p.CPF = @v1", Con);

                Cmd.Parameters.AddWithValue("@v1", CPF);

                Dr = Cmd.ExecuteReader();

                Pessoa p = null;

                if (Dr.Read())
                {
                    p = new Pessoa();
                    p.Nome = Convert.ToString(Dr["Nome"]);
                    p.CPF = Convert.ToInt64(Dr["CPF"]);

                    p.Endereco = new Endereco();
                    p.Endereco.Logradouro = Convert.ToString(Dr["Logradouro"]);
                    p.Endereco.Numero = Convert.ToInt32(Dr["Numero"]);
                    p.Endereco.CEP = Convert.ToInt32(Dr["CEP"]);
                    p.Endereco.Bairro = Convert.ToString(Dr["Bairro"]);
                    p.Endereco.Cidade = Convert.ToString(Dr["Cidade"]);
                    p.Endereco.Estado = Convert.ToString(Dr["Estado"]);

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

        public List<Pessoa> ListarPessoa()
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

                List<Pessoa> lista = new List<Pessoa>();

                while (Dr.Read())
                {
                    Pessoa p = new Pessoa();
                    p.Nome = Convert.ToString(Dr["Nome"]);
                    p.CPF = Convert.ToInt64(Dr["CPF"]);

                    p.Endereco = new Endereco();
                    p.Endereco.Logradouro = Convert.ToString(Dr["Logradouro"]);

                    p.Telefones = new List<Telefone>();
                    foreach(Telefone tel in p.Telefones)
                    {
                        tel.Numero = Convert.ToInt32(Dr["Numero"]);
                        p.Telefones.Add(tel);
                    }

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