using Dapper;
using Interfeisai_CSV.Contracts;
using Interfeisai_CSV.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Interfeisai_CSV.Repositories
{
    public class KlientaiDbRepository : IKlientaiRepository
    {
        private readonly string _dbConnectionString;

        public KlientaiDbRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }

        public List<Klientas> GautiVisusKlientus()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            List<Klientas> klientai = dbConnection.Query<Klientas>(@"SELECT [Id], [Vardas], [Pavarde], [GimimoMetai] FROM [dbo].[Klientai]").ToList();
            dbConnection.Close();
            return klientai;
        }

        public void IrasytiKlientus(List<Klientas> klientai)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            foreach (var klientas in klientai)
            {
                dbConnection.Execute(@"INSERT INTO [dbo].[Klientai] ([Vardas], [Pavarde], [GimimoMetai]) VALUES (@Vardas, @Pavarde, @GimimoMetai)", klientas);
            }
            dbConnection.Close();
        }

        public void IrasytiKlienta(Klientas klientas)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            dbConnection.Execute(@"INSERT INTO [dbo].[Klientai] ([Vardas], [Pavarde], [GimimoMetai]) VALUES (@Vardas, @Pavarde, @GimimoMetai)", klientas);
            dbConnection.Close();
        }
        public void AtnaujintiKlienta(Klientas klientas)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            dbConnection.Execute(@"UPDATE [dbo].[Klientai] SET [Vardas] = @Vardas, [Pavarde] = @Pavarde, [GimimoMetai] = @GimimoMetai WHERE [Id] = @Id", klientas);
            dbConnection.Close();
        }
        public void IstrintiKlienta(int klientasId)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            dbConnection.Execute(@"DELETE FROM [dbo].[Klientai] WHERE [Id] = @Id", new { Id = klientasId });
            dbConnection.Close();
        }
    }
}