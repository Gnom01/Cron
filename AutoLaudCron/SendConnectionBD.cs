using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace InfoDOM
{
    public class ConnectionBD
    {
        public SqlConnection sqlConnection;
        public SqlDataReader sqlReader = null;

        public void ConnectionTheBase(SqlConnection sqlConnection)
        {
            try
            {
                string connectionString = @"Data Source=GNOM-MINI1\SQLEXPRESS;Initial Catalog=Crone;Integrated Security=True";
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                this.sqlConnection = sqlConnection;
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                    sqlConnection.Close();
                }
            }
        }

        public void SendInfoBD()
        {

            foreach (Match m in parStringtParsingCode)
            {
                ConnectionBD connectionString = new ConnectionBD();
                ConnectionTheBase(sqlConnection);
                SqlCommand command = new SqlCommand("INSERT INTO[crone5min](ButyKupFst5MinHTTP, CzasNaButyFst5MinHTTP, ModaPtakUpdate5MinHTTP, AllegroStartCronPtak, AllegroStartCronButy)" +
                                                     "VALUES          (@ButyKupFst5MinHTTP, @CzasNaButyFst5MinHTTP, @ModaPtakUpdate5MinHTTP, @AllegroStartCronPtak, @AllegroStartCronButy)",
                                                     sqlConnection);

                string TitleString = $@"{textBloc1_1}(.*?){textBloc1_2}";
                Regex newTitleString = new Regex(TitleString, optionsRegex);
                Match titleSample = newTitleString.Match(Convert.ToString(parStringtParsingCode[numberCollectionString]));
                string title = titleSample.Groups[1].Value;
                command.Parameters.AddWithValue("Title1", title.ToString());
            }

        }
    }
}
