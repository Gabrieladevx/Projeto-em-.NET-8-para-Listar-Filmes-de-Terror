using System;
using System.IO;
using Microsoft.Data.Sqlite;

class ExportaViewParaCSV
{
    static void Main()
    {
        using var conn = new SqliteConnection("Data Source=filmes.db");
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM vw_FilmesDetalhes";
        using var reader = cmd.ExecuteReader();
        using var writer = new StreamWriter("vw_FilmesDetalhes.csv");
        // Cabeçalho
        for (int i = 0; i < reader.FieldCount; i++)
            writer.Write((i > 0 ? "," : "") + reader.GetName(i));
        writer.WriteLine();
        // Dados
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                var val = reader.IsDBNull(i) ? "" : reader.GetValue(i).ToString()?.Replace("\"", "''");
                writer.Write((i > 0 ? "," : "") + $"\"{val}\"");
            }
            writer.WriteLine();
        }
    }
}
