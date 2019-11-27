using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFP_Aplikacja.Controler
{
    public interface I_DB_Controler<T>
    {
         List<T> Get();

         T Get(int id);

         void Insert(T data);

        void Insert(List<T> data);

        void Update(T data);

         void Remove();

         void Remove(int ID);
    }
}
