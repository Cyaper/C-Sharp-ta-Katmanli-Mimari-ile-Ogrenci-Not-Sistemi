using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BllNotlar
    {
        public static bool Update(EntityNotlar entityNotlar)
        {
            if (entityNotlar.OgrID != 0 && entityNotlar.OgrID != null && entityNotlar.Ortalama != null && entityNotlar.Ortalama >= 0 && entityNotlar.Ortalama <= 100 && entityNotlar.Sinav1 != null && entityNotlar.Sinav1 >= 0 && entityNotlar.Sinav1 <= 100 && entityNotlar.Sinav2 != null && entityNotlar.Sinav2 >= 0 && entityNotlar.Sinav2 <= 100 && entityNotlar.Sinav3 != null && entityNotlar.Sinav3 >= 0 && entityNotlar.Sinav3 <= 100 && entityNotlar.Proje != null && entityNotlar.Proje >= 0 && entityNotlar.Proje <= 100 && entityNotlar.Durum != null)
            {
                return Notlar.Update(entityNotlar);
            }
            return false;
        }

        public static List<EntityNotlar> GetAll()
        {
            return Notlar.GetAll();
        }
    }
}
