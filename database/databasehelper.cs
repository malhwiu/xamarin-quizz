using Microsoft.Data.Sqlite;
using System.Reflection;

namespace xamarin_tietovisa5.database
{
    internal class Databasehelper
    {

        private string connectionString;
        private string databaseName;
        private Assembly path;
        private readonly string databasePath;
        private readonly string dbResource;
        private const string
        selectQuery =
$"SELECT {question}, {firstAns}, {secondAns}, {thirdAns}, {rightAns} FROM tbl_aineisto1";

        private const string firstAns = "vastaus1",
                             secondAns = "vastaus2",
                             thirdAns = "vastaus3",
                             rightAns = "oikea_vastaus_nro",
                             question = "kysymys";


        public string GetDatabasePath()
        {
            return connectionString;
        }

        // creates the path to a database. the database must be in the root of the Resources file using the given name
        public Databasehelper(string dbName)
        {

            databaseName = dbName;
            path = GetType().GetTypeInfo().Assembly;

            dbResource =
            path.GetManifestResourceNames().FirstOrDefault(name => name.EndsWith(databaseName));

            databasePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, databaseName);

            connectionString = $"Data Source={databasePath};Mode=ReadOnly";

        }

        // TODO: check if database already exists
        public void CreateDatabase()
        {

            using (var dbPath = path.GetManifestResourceStream(dbResource))
            using (var fStream = new FileStream(databasePath, FileMode.Create, FileAccess.Write))
            {
                dbPath.CopyTo(fStream);
            }

        }

        private SqliteConnection Connect()
        {
            return new SqliteConnection(connectionString);
        }

        public List<models.Itemquestion> GetData()
        {

            List<models.Itemquestion> data = new List<models.Itemquestion>();
            using (var dbConnection = Connect())
            {
                dbConnection.Open();

                var command = new SqliteCommand(selectQuery, dbConnection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new
                            //models.Itemquestion(question: reader["Kysymys"].ToString(),
                            models.Itemquestion(question: reader[question].ToString(),
                                                answers: new
                                                         models.Answers(reader[firstAns].ToString(),
                                                                        reader[secondAns].ToString(),
                                                                        reader[thirdAns].ToString()),
                                                                        reader[rightAns].ToString()));
                }
            }

            return data;
        }

        // returns true if database exists else returns false
        private bool DataBaseExists()
        {
            return databasePath != null;
        }

    }
}
