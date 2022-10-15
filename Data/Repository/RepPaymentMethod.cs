using CourtHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourtHouse.Data.Repository
{
    public class RepPaymentMethod : IRepository<PaymentMethod>
    {
        public RepPaymentMethod(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public ApplicationDbContext DB { get; }
        public void Add(PaymentMethod entety)
        {
            DB.paymentMethods.Add(entety);
        }

        public IList<PaymentMethod> All()
        {
            return DB.paymentMethods.ToList();
        }

        public void Delete(PaymentMethod entety)
        {
            DB.paymentMethods.Remove(entety);
        }

        public PaymentMethod Find(string val)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public IList<PaymentMethod> Search(string val)
        {
            throw new NotImplementedException();
        }

        public IList<PaymentMethod> Search(string val1, string val2)
        {
            throw new NotImplementedException();
        }

        public void Update(PaymentMethod entety)
        {
            DB.paymentMethods.Update(entety);
        }
    }
}
