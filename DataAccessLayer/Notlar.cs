using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class Notlar
    {
        public static bool Update(EntityNotlar entityNotlar)
        {
            SqlCommand komut = new SqlCommand("NotGuncelle",SqlBaglantisi.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("Sinav1",entityNotlar.Sinav1);
            komut.Parameters.AddWithValue("Sinav2",entityNotlar.Sinav2);
            komut.Parameters.AddWithValue("Sinav3",entityNotlar.Sinav3);
            komut.Parameters.AddWithValue("Proje",entityNotlar.Proje);
            komut.Parameters.AddWithValue("Ortalama",entityNotlar.Ortalama);
            komut.Parameters.AddWithValue("Durum",entityNotlar.Durum);
            komut.Parameters.AddWithValue("OgrID",entityNotlar.OgrID);

            return komut.ExecuteNonQuery() > 0;
        }

        public static List<EntityNotlar> GetAll()
        {
            List<EntityNotlar> Notlar = new List<EntityNotlar>();
            SqlCommand komut = new SqlCommand("NotListesi",SqlBaglantisi.Baglanti);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityNotlar entityNotlar = new EntityNotlar();
                entityNotlar.OgrID =Convert.ToInt16( dr["OgrID"]);
                entityNotlar.Ad = dr["Ad"].ToString();
                entityNotlar.Soyad = dr["Soyad"].ToString() ;
                entityNotlar.Sinav1 =Convert.ToByte( dr["Sinav1"]);
                entityNotlar.Sinav2= Convert.ToByte(dr["Sinav2"]);
                entityNotlar.Sinav3= Convert.ToByte(dr["Sinav3"]);
                entityNotlar.Proje = Convert.ToByte(dr["Proje"]);
                entityNotlar.Ortalama =Convert.ToDouble( dr["Ortalama"]);
                entityNotlar.Durum = dr["Durum"].ToString();
                Notlar.Add(entityNotlar);

            }
            dr.Close();

            return Notlar;
            

        }
    }
}
