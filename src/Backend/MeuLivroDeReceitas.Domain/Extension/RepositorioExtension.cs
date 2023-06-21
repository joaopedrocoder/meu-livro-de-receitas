namespace MeuLivroDeReceitas.Domain.Extension;
using Microsoft.Extensions.Configuration;


public static class RepositorioExtension
{
    public static string GetNomeDatabase(this IConfiguration configurationManager)
    {
        string nomeDatabase = configurationManager.GetConnectionString("NomeDatabase") ?? string.Empty;

        return nomeDatabase;
    }

    public static string GetConexao(this IConfiguration configurationManager)
    {
        string conexao = configurationManager.GetConnectionString("Conexao") ?? string.Empty;

        return conexao;
    }

    public static string GetConexaoCompleta(this IConfiguration configurationManager)
    {
        var conexao = configurationManager.GetConexao();
        var nomeDatabase = configurationManager.GetNomeDatabase();

        return $"{conexao}Database={nomeDatabase}";
    }
}
