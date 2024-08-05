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

namespace Interfeisai_CSV.Repositories
{
    public class AutomobiliaiDbRepository : IAutomobiliaiRepository
    {

        private readonly string _dbConnectionString;
        public AutomobiliaiDbRepository(string connectionString)
        {

            _dbConnectionString = connectionString;

        }

        public List<Elektromobilis> GautiVisusElektromobilius()
        {

            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            List<Elektromobilis> result = dbConnection.
                Query<Elektromobilis>(@"SELECT [id]
           ,[Marke]
           ,[Modelis]
           ,[NuonosKaina] AS NuomosKaina  
           ,[BaterijosTalpa]
           ,[Krovimolaikas] AS IKrovimolaikas FROM [dbo].[Elektromobiliai]").ToList();
            dbConnection.Close();
            return result;
        }

        public List<NaftosKuroAutomobilis> GautiVisusNaftosKuroAutomobilius()
        {

            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            List<NaftosKuroAutomobilis> result = dbConnection.
                Query<NaftosKuroAutomobilis>(@"SELECT [id]
           ,[Marke]
           ,[Modelis]
           ,[NuomosKaina] 
           ,[Sanaudos] AS  degalusanaudos 
            FROM [dbo].[NaftosKuroAutomobiliams]").ToList();
            dbConnection.Close();
            return result;
        }

        public void IrasytiAutomobilius()
        {

            throw new NotImplementedException();

        }

        public void IrasytiElektromobili(Elektromobilis elektromobilis)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            string query = @"INSERT INTO Elektromobiliai (Marke, Modelis, NuonosKaina, BaterijosTalpa, KrovimoLaikas)
                     VALUES (@Marke, @Modelis, @NuomosKaina, @BaterijosTalpa, @IkrovimoLaikas)";
            dbConnection.Execute(query, elektromobilis);
            dbConnection.Close();
        }


        public void IrasytiNaftosKuroAutomobilis(NaftosKuroAutomobilis automobilis)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            string query = @"INSERT INTO NaftosKuroAutomobiliams (Marke, Modelis, NuomosKaina, Sanaudos)
                     VALUES (@Marke, @Modelis, @NuomosKaina, @DegaluSanaudos)";
            dbConnection.Execute(query, automobilis);
            dbConnection.Close();
        }

        public List<Elektromobilis> NuskaitytiAutomobilius()
        {

            throw new NotImplementedException();

        }


        List<Automobilis> IAutomobiliaiRepository.NuskaitytiAutomobilius()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            List<Automobilis> result = dbConnection.Query<Automobilis>(@"SELECT [Id], [Marke], [Modelis], [NuonosKaina] FROM [dbo].[Elektromobiliai] ").ToList();
            dbConnection.Close();
            return result;
        }
   
        public void AtnaujintiAutomobili(Automobilis automobilis)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            dbConnection.Execute(@"UPDATE [dbo].[Automobiliai] SET [Marke] = @Marke, [Modelis] = @Modelis, [Metai] = @Metai WHERE [Id] = @Id", automobilis);
            dbConnection.Close();
        }
        public void IstrintiAutomobili(int automobilisId)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            dbConnection.Execute(@"DELETE FROM [dbo].[Automobiliai] WHERE [Id] = @Id", new { Id = automobilisId });
            dbConnection.Close();
        }

    }
}
