using StazTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StazTestApp.DAL
{
    public class DBContext
    {
        private List<Przedmiot> przedmiots;
        public DBContext()
        {
            przedmiots = new List<Przedmiot>();
            AddToList(new Przedmiot { Name = "T-shirt", Price = 20.00, Quantity = 3, Description = "Koszulki na codzień." });
            AddToList(new Przedmiot { Name = "Skarpetki", Price = 15.00, Quantity = 2, Description = "Opakowanie po parze." });
            AddToList(new Przedmiot { Name = "Bluza", Price = 80.00, Quantity = 1, Description = "Bluza z kapturem." });
            AddToList(new Przedmiot { Name = "Spodnie", Price = 120.00, Quantity = 1, Description = "Jeansowe spodnie." });
        }

        public List<Przedmiot> GetList()
        {
            
            return przedmiots;
        }
        public void AddToList(Przedmiot tmp)
        {
            if (tmp.ItemID == 0)
            {
                if (przedmiots.Count == 0)
                    tmp.ItemID = 1;
                else
                    tmp.ItemID = przedmiots.OrderBy(x => x.ItemID).Last().ItemID + 1;
            }
            przedmiots.Add(tmp);
        }

        public void RemoveFromList(int tmpID)
        {
            if (przedmiots.Exists(x => x.ItemID == tmpID))
            {
                przedmiots.RemoveAll(x => x.ItemID == tmpID);
            }

        }

        public void UpdateExisting(Przedmiot tmp)
        {
            if (przedmiots.Exists(x => x.ItemID == tmp.ItemID))
            {
                var prev = przedmiots.Find(x => x.ItemID == tmp.ItemID);
                prev.Name = tmp.Name;
                prev.Price = tmp.Price;
                prev.Quantity = tmp.Quantity;
                prev.Description = tmp.Description;
            }

        }

    }
}