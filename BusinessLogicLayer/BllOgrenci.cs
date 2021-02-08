using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BllOgrenci
    {
        public static int Add(EntityOgrenci entityOgrenci)
        {
            if (entityOgrenci.Ad != null && entityOgrenci.Soyad != null && entityOgrenci.KulupID != 0 && entityOgrenci.Fotograf != null && entityOgrenci.KulupID > 0&&entityOgrenci.Fotograf.Length>0)
            {
                return Ogrenci.Add(entityOgrenci);
            }
            return -1;
        }

        public static bool Update(EntityOgrenci entityOgrenci)
        {
            if (entityOgrenci.Ad != null && entityOgrenci.Soyad != null && entityOgrenci.KulupID != 0 && entityOgrenci.Fotograf != null && entityOgrenci.KulupID > 0 && entityOgrenci.ID != 0)
            {
                return Ogrenci.Update(entityOgrenci);
            }
            return false;
        }

        public static bool Delete(int id)
        {
            if (id != 0 && id >= 1)
            {
                return Ogrenci.Delete(id);
            }
            return false;
        }

        public static List<EntityOgrenci> GetAll()
        {
            return Ogrenci.GetAll();
        }
    }
}
