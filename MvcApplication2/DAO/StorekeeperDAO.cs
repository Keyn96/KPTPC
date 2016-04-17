using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MvcApplication2.Models;
namespace MvcApplication2.DAO
{
    public class StorekeeperDAO
    {
        WholesaleEntities we = new WholesaleEntities();

        

        public IEnumerable<Material> selectAllMaterial()
        {
            return (from c in we.Material select c);
        }

        public Material selectMaterial(int id)
        {
            return (we.Material.Find(id));
        }

        public bool updateMaterial(Material material)
        {
            try
            {
                we.Entry(material).State = EntityState.Modified;
                we.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool insertOrders(Orders orders, int[] mat)
        {
            try
            {
                List<Material> m = new List<Material>();
                foreach (var c in mat)
                {
                    Material mater = selectMaterial(c);
                    m.Add(mater);
                }
                Orders or = new Orders
                {
                    IdOrder = orders.IdOrder,
                    dataCreate = orders.dataCreate,
                    status = orders.status,
                    idWorker = orders.idWorker,
                    Material = new List<Material>(m)
                };
                we.Orders.Add(or);
                we.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool insertOperation(Operation operation, int[] mat)
        {
            try
            {
                List<Material> m = new List<Material>();
                foreach (var c in mat)
                {
                    Material mater = selectMaterial(c);
                    m.Add(mater);
                }
                Operation op = new Operation
                {
                    IdOperation = operation.IdOperation,
                    type = operation.type,
                    numberInvoice = operation.numberInvoice,
                    cost = operation.cost,
                    idWorker = operation.idWorker,
                    Material = new List<Material>(m)
                };
                we.Operation.Add(op);
                we.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}