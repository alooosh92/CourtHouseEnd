using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Data.Repository
{
    public interface IRepository<T>
    {
        IList<T> All();
        T Find(string val);
        IList<T> Search(string val);
        IList<T> Search(string val1, string val2);
        void Add(T entety);
        void Delete(T entety);
        void Update(T entety);
        void Save();
    }
}
