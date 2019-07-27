using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace AutoLaudCron
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
            catch (Exception )
            {

                throw new Exception("Connection BD unlocked!");
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
        
        public void SendInfoBD5minCron()
        {
            httpWWWadress httpWWWadress = new httpWWWadress();
            ConnectionTheBase(sqlConnection);
            SqlCommand command = new SqlCommand("INSERT INTO[crone5min](ButyKupFst5MinHTTP, CzasNaButyFst5MinHTTP, ModaPtakUpdate5MinHTTP, AllegroStartCronPtak, AllegroStartCronButy, DataTimeCrone)" +
                                                         "VALUES          (@ButyKupFst5MinHTTP, @CzasNaButyFst5MinHTTP, @ModaPtakUpdate5MinHTTP, @AllegroStartCronPtak, @AllegroStartCronButy, @DataTimeCrone)",
                                                     sqlConnection);
            command.Parameters.AddWithValue("ButyKupFst5MinHTTP", httpWWWadress.ButyKupFst5MinHTTP().ToString());
            command.Parameters.AddWithValue("CzasNaButyFst5MinHTTP", httpWWWadress.CzasNaButyFst5MinHTTP());
            command.Parameters.AddWithValue("ModaPtakUpdate5MinHTTP", httpWWWadress.ModaPtakUpdate5MinHTTP());
            command.Parameters.AddWithValue("AllegroStartCronPtak", httpWWWadress.AllegroStartCronPtak());
            command.Parameters.AddWithValue("AllegroStartCronButy", httpWWWadress.AllegroStartCronButy());
            command.Parameters.AddWithValue("DataTimeCrone", DateTime.Now);
            command.ExecuteNonQuery();
        }
        public void SendInfoBDFullCron()
        {
            httpWWWadress httpWWWadress = new httpWWWadress();
            ConnectionTheBase(sqlConnection);
            SqlCommand command = new SqlCommand("INSERT INTO[croneFull](ButyKupAjaksHTTP, ButyKupAllHTTP, CzasNaButyAjaksHTTP, CzasNaButyAllHTTP, ModaPtakFullHTTP, DataTimeCrone)" +
                                                         "VALUES          (@ButyKupAjaksHTTP, @ButyKupAllHTTP, @CzasNaButyAjaksHTTP, @CzasNaButyAllHTTP, @ModaPtakFullHTTP, @DataTimeCrone)",
                                                     sqlConnection);
            command.Parameters.AddWithValue("ButyKupAjaksHTTP", httpWWWadress.ButyKupAjaksHTTP().ToString());
            command.Parameters.AddWithValue("ButyKupAllHTTP", httpWWWadress.ButyKupAllHTTP());
            command.Parameters.AddWithValue("CzasNaButyAjaksHTTP", httpWWWadress.CzasNaButyAjaksHTTP());
            command.Parameters.AddWithValue("CzasNaButyAllHTTP", httpWWWadress.CzasNaButyAllHTTP());
            command.Parameters.AddWithValue("ModaPtakFullHTTP", httpWWWadress.ModaPtakFullHTTP());
            command.Parameters.AddWithValue("DataTimeCrone", DateTime.Now);
            command.ExecuteNonQuery();
        }
    }
}