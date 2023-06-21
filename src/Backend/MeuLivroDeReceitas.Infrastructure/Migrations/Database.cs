using Dapper;
using MySqlConnector;
using System.Runtime.Intrinsics.X86;

namespace MeuLivroDeReceitas.Infrastructure.Migrations;

public static class Database
{
    public static void CriarDatabase(string conexaoBancoDeDados, string nomeDatabase) 
    {
        //criando uma instancia de conexao com o bd. Recebe o nome do bd
        //using vai liberar a variavel conexao da memoria apos sua exec
        using var conexao = new MySqlConnection(conexaoBancoDeDados);

        //Dapper fornece a classe DynamicParameters como uma forma conveniente de fornecer 
        //parâmetros dinamicamente para consultas SQL. Em vez de usar um objeto de parâmetros estáticos,
        //como SqlParameter no ADO.NET, a classe DynamicParameters permite adicionar e
        //acessar parâmetros de forma dinâmica.
        var parametros = new DynamicParameters();
        parametros.Add("nome", nomeDatabase); //add um parametro nome com o valor do nomeDatabase

        //query que vai buscar todos os registros do nosso bd
        var registros = conexao.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @nome", parametros);
        string query = $"CREATE DATABASE @nome";

        if (!registros.Any())
        {
            conexao.Execute(query, parametros);
        }
    }
}
