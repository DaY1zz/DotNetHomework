using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeWork5;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HomeWork5.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        static Client client1 = new Client("xyf", "VIP");
        static Client client2 = new Client("zzx");
        static Client client3 = new Client("lbr", "VIP");

        static Goods goods1 = new Goods("1", "哈利波特 1", 12);
        static Goods goods2 = new Goods("2", "理想国", 15);
        static Goods goods3 = new Goods("3", "百年孤独", 18);

        static Order order1 = new Order("001", client1, DateTime.Now, "北京", new OrderDetail(goods1, 2));
        static Order order2 = new Order("002", client1, new DateTime(2021, 3, 27, 18, 00, 13), "武汉", new OrderDetail(goods2, 3));
        static Order order3 = new Order("003", client2, DateTime.UtcNow, "天津", new OrderDetail(goods3, 1));
        static Order order4 = new Order("004", client2, DateTime.Now, "上海", new OrderDetail(goods3, 1), new OrderDetail(goods1, 2));
        static Order order5 = new Order("005", client3, DateTime.Today, "广州", new OrderDetail(goods1, 2),
                new OrderDetail(goods2, 2), new OrderDetail(goods3, 1));


        [TestInitialize]
        public void initialize()
        {
            OrderService.AddOrder(order1);
            OrderService.AddOrder(order2);
            OrderService.AddOrder(order3);
            OrderService.AddOrder(order4);
            OrderService.AddOrder(order5);
        }

        [TestMethod()]

        public void AddOrderTest()
        {
            OrderService.AddOrder(new Order("006", client2, DateTime.Now, "上海", new OrderDetail(goods3, 1), new OrderDetail(goods1, 2)));
            OrderService.AddOrder(new Order("001", client3, DateTime.Today, "广州", new OrderDetail(goods1, 2),
                new OrderDetail(goods2, 2), new OrderDetail(goods3, 1)));
        }

        [TestMethod()]
        public void DelOrderTest()
        {
            OrderService.DelOrder("002");
            OrderService.DelOrder("100");
        }

        [TestMethod()]
        public void ModifyOrderTest()
        {
            OrderService.ModifyOrder(new Order("001", client2, DateTime.Now, "北京", new OrderDetail(goods1, 2)));
            Order o = OrderService.QueryById("001");
            Assert.AreEqual(o, new Order("001", client2, DateTime.Now, "北京", new OrderDetail(goods1, 2)));
        }

        [TestMethod()]
        public void QueryByIdTest()
        {
            Order o = OrderService.QueryById("004");
            Assert.IsNotNull(o);
            Assert.AreEqual(o, new Order("004", client2, DateTime.Now, "上海", new OrderDetail(goods3, 1), new OrderDetail(goods1, 2)));
            //Assert.IsNull("009");
        }

        [TestMethod()]
        public void QueryByClientNameTest()
        {
            var orders = OrderService.QueryByClientName("xyf");
            Assert.IsNotNull(orders);

            foreach (var order in orders)
                Assert.IsTrue(order.OrderClient.Name == "xyf");
        }

        [TestMethod()]
        public void QueryByAddressTest()
        {
            var orders = OrderService.QueryByAddress("北京");
            Assert.IsNotNull(orders);

            foreach (var order in orders)
                Assert.IsTrue(order.DeliveryAddress == "北京");
        }

        [TestMethod()]
        public void SortTest()
        {
            OrderService.Sort();
            var orders = OrderService.QueryAll().ToArray();
            Order[] target = { order1, order2, order3, order4, order5 };
            for (int i = 0; i < orders.Length; i++)
                Assert.AreEqual(orders[i], target[i]);

            OrderService.Sort((Order o1, Order o2) => o1.TotalMoney.CompareTo(o2.TotalMoney));
            orders = OrderService.QueryAll().ToArray();
            Order[] target2 = { order3, order1, order4, order2, order5 };
            for (int i = 0; i < orders.Length; i++)
                Assert.AreEqual(orders[i], target2[i]);
        }

        [TestMethod()]
        public void ExportTest()
        {
            OrderService.Export("D:\\VS2019\\Project\\DotNetHomeWork\\HomeWork6\\HomeWork6\\bin\\Debug\\netcoreapp3.1", "Orders");
            Assert.IsTrue(File.Exists("D:\\VS2019\\Project\\DotNetHomeWork\\HomeWork6\\HomeWork6\\bin\\Debug\\netcoreapp3.1\\Orders.xml"));



        }

        [TestMethod()]
        public void ImportTest()
        {
            OrderService.DelOrder("001");
            OrderService.DelOrder("002");
            OrderService.DelOrder("003");
            OrderService.DelOrder("004");
            OrderService.DelOrder("005");
            OrderService.Import("D:\\VS2019\\Project\\DotNetHomeWork\\HomeWork6\\HomeWork6\\bin\\Debug\\netcoreapp3.1\\Orders.xml");
            //测试不存在的文件
            Assert.ThrowsException<ApplicationException>(()=>OrderService.Import("D:\\Orders.xml"));
            //测试错误文件
            Assert.ThrowsException<InvalidOperationException>(()=>OrderService.Import("D:\\VS2019\\Project\\DotNetHomeWork\\HomeWork6\\HomeWork6\\bin\\Debug\\netcoreapp3.1\\Orders2.xml"));
            //测试空文件
            Assert.ThrowsException<InvalidOperationException>(() => OrderService.Import("D:\\VS2019\\Project\\DotNetHomeWork\\HomeWork6\\HomeWork6\\bin\\Debug\\netcoreapp3.1\\Orders2.xml"));

        }
    }
}