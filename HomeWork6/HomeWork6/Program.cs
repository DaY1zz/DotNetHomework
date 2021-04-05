using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client("xyf", "VIP");
            Client client2 = new Client("zzx");
            Client client3 = new Client("lbr", "VIP");

            Goods goods1 = new Goods("1", "哈利波特 1", 12);
            Goods goods2 = new Goods("2", "理想国", 15);
            Goods goods3 = new Goods("3", "百年孤独", 18);
            try
            {
                OrderService.AddOrder(new Order("001", client1, DateTime.Now, "北京", new OrderDetail(goods1, 2)));
                OrderService.AddOrder(new Order("002", client1, new DateTime(2021, 3, 27, 18, 00, 13), "武汉", new OrderDetail(goods2, 3)));
                OrderService.AddOrder(new Order("003", client2, DateTime.UtcNow, "天津", new OrderDetail(goods3, 1)));
                OrderService.AddOrder(new Order("004", client2, DateTime.Now, "上海", new OrderDetail(goods3, 1), new OrderDetail(goods1, 2)));
                OrderService.AddOrder(new Order("005", client3, DateTime.Today, "广州", new OrderDetail(goods1, 2),
                    new OrderDetail(goods2, 2), new OrderDetail(goods3, 1)));

                Print(OrderService.QueryByClientName("xyf"));

                OrderService.DelOrder("002");
                //OrderService.DelOrder("006");

                OrderService.ModifyOrder(new Order("001", client2, DateTime.Now, "北京", new OrderDetail(goods1, 2)));

                OrderService.Sort();

                Print(OrderService.QueryAll());

                OrderService.Sort((Order o1 , Order o2) => o1.TotalMoney.CompareTo(o2.TotalMoney));

                Print(OrderService.QueryAll());
                OrderService.Export("D:\\VS2019\\Project\\DotNetHomeWork\\HomeWork6\\HomeWork6\\bin\\Debug", "Orders");
                

            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e);
            }


            Console.ReadKey();

        }
        public static void Print(IEnumerable<Order> orders)
        {
            foreach (var item in orders)
            {
                Console.WriteLine(item.ToString()+"\n");
                
            }
        }
    }
}
