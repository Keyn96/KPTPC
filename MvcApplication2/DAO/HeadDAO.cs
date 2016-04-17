using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MvcApplication2.Models;
namespace MvcApplication2.DAO
{
    public class HeadDAO
    {
        WholesaleEntities we = new WholesaleEntities();
        public IEnumerable<Orders> selectAllOrders()
        {
            return (from c in we.Orders select c);
        }

        public Orders selectOrders(int id)
        {
            return (from c in we.Orders where c.IdOrder == id select c).FirstOrDefault();
        }

        public bool updateOrders(Orders order)
        {
            try
            {
                we.Entry(order).State = EntityState.Modified;
                we.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Operation> selectAllOperation()
        {
            return (from c in we.Operation select c);
        }

        public Operation selectOperation(int id)
        {
            return (from c in we.Operation where c.IdOperation == id select c).FirstOrDefault();
        }
    }
}