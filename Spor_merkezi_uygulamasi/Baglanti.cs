using System.Data.SqlClient;


namespace Spor_merkezi_uygulamasi
{
    class Baglanti
    {
        public SqlConnection baglan()
        {
            SqlConnection baglan = new SqlConnection("Data Source=PUDDI\\SQLEXPRESS;Initial Catalog=Spormerkezi;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
