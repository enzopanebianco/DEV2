using Senai.Produtos.WebApi.Tarde.Domains;
using Senai.Produtos.WebApi.Tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Produtos.WebApi.Tarde.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private string StringConexao = @"Data Source=.\SqlExpress; initial catalog=SENAI_PRODUTOS_TARDE;user:sa;password:132";
        public void Cadastrar(ProdutoDomain produto)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryInsert = "Insert into Produtos (NOME_PRODUTO,DESCRICAO) Values(@nomeproduto,@descricao)";
                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeproduto", produto.Nome);
                    cmd.Parameters.AddWithValue("@descricao", produto.Descricao);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ProdutoDomain> Listar()
        {
            List<ProdutoDomain> lsProdutos = new List<ProdutoDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "Select ID,NOME_PRODUTO,DESCRICAO where ID = @ID";
                using (SqlCommand cmd = new SqlCommand(QuerySelect,con))
                {
                    con.Open();

                    SqlDataReader rdr =  cmd.ExecuteReader();
                while (rdr.Read())
                {
                        ProdutoDomain produto = new ProdutoDomain
                        {
                            ID = Convert.ToInt32(rdr["ID"]),
                            Nome = rdr["NOME_PRODUTO"].ToString(),
                            Descricao = rdr["DESCRICAO"].ToString(),
                    };

                }
                }
            }
            return lsProdutos;
        }
        
    }
}
