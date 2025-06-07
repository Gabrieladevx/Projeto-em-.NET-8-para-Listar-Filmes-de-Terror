using System;
using System.Data.SQLite;
using System.IO;

class CriaViewFilmesDetalhes
{
    static void Main()
    {
        string sql = File.ReadAllText("Scripts/vw_FilmesDetalhes.sql");
        using var conn = new SQLiteConnection("Data Source=filmes.db");
        conn.Open();
        using var cmd = new SQLiteCommand(sql, conn);
        cmd.ExecuteNonQuery();
        Console.WriteLine("View vw_FilmesDetalhes criada com sucesso!");
    }
}
