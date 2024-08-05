using System.Data;
using System.Data.SqlClient;
using Dapper;
using Interfeisai_CSV.Models;

public class NuomaDbRepository
{
    private readonly string _dbConnectionString;

    public NuomaDbRepository(string dbConnectionString)
    {
        _dbConnectionString = dbConnectionString;
    }

    public void PridetiNuoma(NuomosUzsakymas uzsakymas)
    {
        using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
        dbConnection.Open();
        dbConnection.Execute(@"INSERT INTO [dbo].[Nuoma] ([AutomobilisId], [KlientasId], [NuomosPradzia], [NuomosPabaiga], [DarbuotojoId]) VALUES (@AutomobilisId, @KlientasId, @NuomosPradzia, @NuomosPabaiga, @DarbuotojoId)", uzsakymas);
        dbConnection.Close();
    }

    public void AtnaujintiNuoma(NuomosUzsakymas uzsakymas)
    {
        using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
        dbConnection.Open();
        dbConnection.Execute(@"UPDATE [dbo].[Nuoma] SET [AutomobilisId] = @AutomobilisId, [KlientasId] = @KlientasId, [NuomosPradzia] = @NuomosPradzia, [NuomosPabaiga] = @NuomosPabaiga, [DarbuotojoId] = @DarbuotojoId WHERE [Id] = @Id", uzsakymas);
        dbConnection.Close();
    }

    public void IstrintiNuoma(int uzsakymasId)
    {
        using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
        dbConnection.Open();
        dbConnection.Execute(@"DELETE FROM [dbo].[Nuoma] WHERE [Id] = @Id", new { Id = uzsakymasId });
        dbConnection.Close();
    }
}