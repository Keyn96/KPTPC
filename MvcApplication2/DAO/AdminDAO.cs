using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MvcApplication2.Models;
namespace MvcApplication2.DAO
{
    public class AdminDAO
    {
        WholesaleEntities we = new WholesaleEntities();
        public IEnumerable<Workers> selectAllWorkers()
        {
            return (from c in we.Workers.AsParallel() select c);
        }

        public Workers selectWorker(int id)
        {
            return (from c in we.Workers where c.IdWorker == id select c).FirstOrDefault();
        }

        public bool updateWorker(Workers worker)
        {
            try
            {
                we.Entry(worker).State = EntityState.Modified;
                we.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteWorker(int IdWorker)
        {
            Workers worker = selectWorker(IdWorker);
            try
            {
                we.Workers.Remove(worker);
                we.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool insertMaterial(Material material, ICollection<Operation> Operation, ICollection<Orders> Orders)
        {
            try
            {
                Material m = new Material
                {
                    IdMaterial = material.IdMaterial,
                    name = material.name,
                    weight = material.weight,
                    manufacturer = material.manufacturer,
                    cost = material.cost,
                    quantity = material.quantity,
                    Operation = Operation,
                    Orders = Orders
                };
                we.Material.Add(m);
                we.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

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

        public bool deleteMaterial(int IdMaterial)
        {
            Material material = selectMaterial(IdMaterial);
            try
            {
                we.Material.Remove(material);
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