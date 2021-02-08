using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BllKulup
    {
        public static int Add(EntityKulup entityKulup)
        {
            if (entityKulup.KulupAd != null)
            {
                return Kulup.Add(entityKulup);
            }
            return -1;
        }

        public static bool Update(EntityKulup entityKulup)
        {
            if(entityKulup.KulupAd!=null && entityKulup.KulupID!=0)
            {
                return Kulup.Update(entityKulup);
            }
            return false;
        }

        public static bool Delete(int id)
        {
            if (id != null)
            {
                return Kulup.Delete(id);
            }
            return false;
        }

        public static List<EntityKulup> GetAll()
        {
            return Kulup.GetAll();
        }
    }
}
