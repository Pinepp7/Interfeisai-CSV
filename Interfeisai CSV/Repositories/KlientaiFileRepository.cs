using Dapper;
using Interfeisai_CSV.Contracts;
using Interfeisai_CSV.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Core.Repositories
{
    public class KlientaiFileRepository : IKlientaiRepository
    {
        private readonly string _filePath;
        public KlientaiFileRepository(string KlientuFilePath)
        {
            _filePath = KlientuFilePath;
        }
        public List<Klientas> GautiVisusKlientus()
        {
            using IDbConnection connection = new SqlConnection(_filePath);
            connection.Open();
            List<Klientas> klientas = connection.Query<Klientas>(@"SELECT [Id],[Vardas],[Pavarde],
             [GimimoMetai]  FROM [dbo].[Klientai]").ToList();
            connection.Close();
            return klientas;
        }

        public void IrasytiKlienta(Klientas klientas)
        {
            using IDbConnection dbConnection = new SqlConnection(_filePath);
            dbConnection.Open();
            string query = @"INSERT INTO Klientai (Vardas, Pavarde, GimimoMetai)
                     VALUES (@Vardas, @Pavarde, @GimimoMetai)";
            dbConnection.Execute(query, klientas);
            dbConnection.Close();
        }

        public void IrasytiKlientus(List<Klientas> klientai)
        {
            throw new NotImplementedException();
        }
    }
}

