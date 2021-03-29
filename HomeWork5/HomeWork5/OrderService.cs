using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class OrderService
    {
        private static List<Order> orders = new List<Order>();

        public static void AddOrder(Order newOrder)
        {
            if (newOrder == null || newOrder.OrderDetails.Count == 0)
                throw new ArgumentException("This order is illegal.");

            if ((from o in orders where o.OrderID == newOrder.OrderID select o).Any())
            {
                Console.WriteLine("The order has been exist.");
            }
            else
            {
                orders.Add(newOrder);
                Console.WriteLine("Successfully add!");
            }

        }

        public static void DelOrder(string delID)
        {
            var target = orders.Where(o => o.OrderID == delID).FirstOrDefault();
            if (target == null)
                throw new ArgumentException("There is no such order.");

            orders.Remove(target);
            Console.WriteLine("Successfully delete！\n");
        }

        public static void ModifyOrder(Order modifyOrder)
        {
            if (modifyOrder == null || modifyOrder.OrderDetails.Count == 0)
                throw new ArgumentException("This order is illegal.");

            var target = orders.Where(o => o.OrderID == modifyOrder.OrderID).FirstOrDefault();

            if (target == null)
                throw new ArgumentException("There is no such order.");

            //只能修改客户、配送地址、订单明细
            if (modifyOrder.OrderClient != null)
                target.OrderClient = modifyOrder.OrderClient;
            if (modifyOrder.DeliveryAddress != null || modifyOrder.DeliveryAddress != "")
                target.DeliveryAddress = modifyOrder.DeliveryAddress;
            if (modifyOrder.OrderDetails != null || modifyOrder.OrderDetails.Count != 0)
                target.OrderDetails = modifyOrder.OrderDetails;
            Console.WriteLine("Successfully modify!\n");
        }

        public static IEnumerable<Order> QueryAll()
        {
            return orders.OrderBy(o=>o.TotalMoney);
        }

        public static Order QueryById(string id)
        {
            var target = orders.Where(o => o.OrderID == id).FirstOrDefault();
            if (target == null)
                throw new ArgumentException("There is no such order.");
            return target;
        }

        public static IEnumerable<Order> QueryByClientName(string clientName)
        {
            var target = orders.Where(o => o.OrderClient.Name == clientName).OrderBy(o => o.TotalMoney);
            if (target == null)
                throw new ArgumentException("There is no such order.");
            return target;
        }

        public static IEnumerable<Order> QueryByAddress(string address)
        {
            var target = orders.Where(o => o.DeliveryAddress == address).OrderBy(o => o.TotalMoney);
            if (target == null)
                throw new ArgumentException("There is no such order.");
            return target;
        }

        public static IEnumerable<Order> QueryByTotalMoney(double money)
        {
            var target = orders.Where(o => o.TotalMoney == money).OrderBy(o => o.OrderID);
            if (target == null)
                throw new ArgumentException("There is no such order.");
            return target;
        }

        public static void Sort()
        {
            orders.Sort();
        }

        public static void Sort(Comparison<Order> comparison)
        {
            orders.Sort(comparison);
        }
    }
}
