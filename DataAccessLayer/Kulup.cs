using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class Kulup
    {
        public static int Add(EntityKulup entityKulup)
        {
            SqlCommand komut = new SqlCommand("KulupEkle",SqlBaglantisi.Baglanti);

            komut.CommandType = CommandType.StoredProcedure;

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KulupAd",entityKulup.KulupAd);
            return komut.ExecuteNonQuery();
        }

        public static bool Delete(int id)
        {
            SqlCommand komut = new SqlCommand("KulupSil",SqlBaglantisi.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KulupID",id);
            return komut.ExecuteNonQuery()>0;
        }

        public static bool Update(EntityKulup entityKulup)
        {
            SqlCommand komut = new SqlCommand("KulupGuncelle",SqlBaglantisi.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KulupAd",entityKulup.KulupAd);
            komut.Parameters.AddWithValue("KulupID",entityKulup.KulupID);
            return komut.ExecuteNonQuery()>0;
        }

        public static  List<EntityKulup> GetAll()
        {
            List<EntityKulup> Kulupler = new List<EntityKulup>();
            SqlCommand komut = new SqlCommand("KulupListesi",SqlBaglantisi.Baglanti);

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityKulup entityKulup = new EntityKulup();
                entityKulup.KulupID =Convert.ToInt16( dr["KulupID"]);
                entityKulup.KulupAd = dr["KulupAd"].ToString();
                Kulupler.Add(entityKulup);
            }
            dr.Close();

            return Kulupler;

        }
    }
}
