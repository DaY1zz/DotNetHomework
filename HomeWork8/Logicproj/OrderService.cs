using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace HomeWork5
{
    public class OrderService
    {
        private  List<Order> orders = new List<Order>();

        public  void AddOrder(Order newOrder)
        {
            if (newOrder == null || newOrder.OrderDetails.Count == 0)
                throw new ArgumentException("This order is illegal.");

            if ((from o in orders where o.OrderID == newOrder.OrderID select o).Any())
            {
                throw new ArgumentException("The order has been exist.");
            }
            else
            {
                orders.Add(newOrder);
                Console.WriteLine("Successfully add!");
            }

        }

        public  void DelOrder(string delID)
        {
            var target = orders.Where(o => o.OrderID == delID).FirstOrDefault();
            if (target == null)
                throw new ArgumentException("There is no such order.");

            orders.Remove(target);
            Console.WriteLine("Successfully delete!");
        }

        public  void ModifyOrder(Order modifyOrder)
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

        public  List<Order> QueryAll()
        {
            return orders;
        }

        public  Order QueryById(string id)
        {
            var target = orders.Where(o => o.OrderID == id).FirstOrDefault();
            if (target==null)
                throw new ArgumentException("There is no such order.");
            return target;
        }

        public  List<Order> QueryByClientName(string clientName)
        {
            var target = orders.Where(o => o.OrderClient.Name == clientName).OrderBy(o => o.TotalMoney);
            if (target.Count() == 0)
                throw new ArgumentException("There is no such order.");
            return target.ToList<Order>();
        }

        public  List<Order> QueryByAddress(string address)
        {
            var target = orders.Where(o => o.DeliveryAddress == address).OrderBy(o => o.TotalMoney);
            if (target.Count() == 0)
                throw new ArgumentException("There is no such order.");
            return target.ToList<Order>();
        }

        public  List<Order> QueryByTotalMoney(double money)
        {
            var target = orders.Where(o => o.TotalMoney == money).OrderBy(o => o.OrderID);
            if (target.Count() == 0)
                throw new ArgumentException("There is no such order.");
            return target.ToList<Order>();
        }

        public  void Sort()
        {
            orders.Sort();
        }

        public  void Sort(Comparison<Order> comparison)
        {
            orders.Sort(comparison);
        }
        
        /// <summary>
        /// 将当前的所有订单信息导出为xml文件
        /// </summary>
        /// <param name="saveDir">存储文件夹路径 </param> 
        /// <param name="fileName">xml文件名</param>
        public  void Export(string saveDir,string fileName)
        {
            Order[] orderArray = orders.ToArray<Order>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));

            string dstPath = (saveDir.EndsWith("\\") ? saveDir : saveDir + "\\") + fileName + ".xml";
            using (FileStream fs = new FileStream(dstPath, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, orderArray);
            }

        }

        /// <summary>
        /// 将关于订单的xml文件导入到系统中
        /// </summary>
        /// <param name="xmlPath">xml文件路径</param>
        public  void Import(string xmlPath) 
        {
            if (!File.Exists(xmlPath))
                throw new ApplicationException("文件不存在");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
            using(FileStream fs = new FileStream(xmlPath, FileMode.Open))
            {
                Order[] orderArray = xmlSerializer.Deserialize(fs) as Order[];

                if (orderArray == null)
                    throw new ApplicationException("文件内容为空");

                foreach (Order o in orderArray)
                    AddOrder(o);
            }    
        }

    }
}
