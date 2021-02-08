using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntityLayer;

namespace DataAccessLayer
{
    public class Ogrenci
    {
        public static int Add(EntityOgrenci entityOgrenci)
        {
            SqlCommand komut = new SqlCommand("OgrenciEkle",SqlBaglantisi.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("Ad",entityOgrenci.Ad);
            komut.Parameters.AddWithValue("Soyad",entityOgrenci.Soyad);
            komut.Parameters.AddWithValue("Fotograf",entityOgrenci.Fotograf);
            komut.Parameters.AddWithValue("KulupID",entityOgrenci.KulupID);

            return komut.ExecuteNonQuery();
        }

        public static bool Delete(int id)
        {
            SqlCommand komut = new SqlCommand("OgrenciSil",SqlBaglantisi.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("ID",id);
            return komut.ExecuteNonQuery() > 0;
        }

        public static bool Update(EntityOgrenci entityOgrenci)
        {
            SqlCommand komut = new SqlCommand("OgrenciGuncelle",SqlBaglantisi.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("ID",entityOgrenci.ID);
            komut.Parameters.AddWithValue("Ad",entityOgrenci.Ad);
            komut.Parameters.AddWithValue("Soyad",entityOgrenci.Soyad);
            komut.Parameters.AddWithValue("Fotograf",entityOgrenci.Fotograf);
            komut.Parameters.AddWithValue("KulupID",entityOgrenci.KulupID);

            return komut.ExecuteNonQuery() > 0;
        }

        public static List<EntityOgrenci> GetAll()
        {
            List<EntityOgrenci> Ogrenciler = new List<EntityOgrenci>();
            SqlCommand komut = new SqlCommand("OgrenciListesi",SqlBaglantisi.Baglanti);


            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityOgrenci ogr = new EntityOgrenci();
                ogr.ID =Convert.ToInt16( dr["ID"]);
                ogr.Ad = dr["Ad"].ToString();
                ogr.Soyad = dr["Soyad"].ToString();
                ogr.Fotograf = dr["Fotograf"].ToString();
                ogr.KulupID = Convert.ToInt16(dr["KulupID"]);
                Ogrenciler.Add(ogr);
            }
            dr.Close();

            return Ogrenciler;
        }
    }
}
