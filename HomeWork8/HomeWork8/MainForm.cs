using HomeWork5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HomeWork8
{
    public partial class MainForm : Form
    {
        private OrderService orderService = new OrderService();

        public MainForm()
        {
            InitializeComponent();

            Client client1 = new Client("xyf", "VIP");
            Client client2 = new Client("zzx");
            Client client3 = new Client("lbr", "VIP");

            Goods goods1 = new Goods("1", "哈利波特", 12);
            Goods goods2 = new Goods("2", "理想国", 15);
            Goods goods3 = new Goods("3", "百年孤独", 18);

            orderService.AddOrder(new Order("001", client1, DateTime.Now, "北京", new OrderDetail(goods1, 2)));
            orderService.AddOrder(new Order("002", client1, new DateTime(2021, 3, 27, 18, 00, 13), "武汉", new OrderDetail(goods2, 3)));
            orderService.AddOrder(new Order("003", client2, DateTime.UtcNow, "天津", new OrderDetail(goods3, 1)));
            orderService.AddOrder(new Order("004", client2, DateTime.Now, "上海", new OrderDetail(goods3, 1), new OrderDetail(goods1, 2)));
            orderService.AddOrder(new Order("005", client3, DateTime.Today, "广州", new OrderDetail(goods1, 2),
                new OrderDetail(goods2, 2), new OrderDetail(goods3, 1)));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (QuerycomboBox.SelectedItem.ToString() == "全部")
                QuerytextBox.Visible = false;
            OrderdataGridView.DataSource = orderService.QueryAll();

        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (QuerycomboBox.SelectedItem.ToString() == "全部")
                {
                    OrderdataGridView.DataSource = orderService.QueryAll();
                }
                else if (QuerycomboBox.SelectedItem.ToString() == "订单号")
                {
                    OrderdataGridView.DataSource = new Order[] { orderService.QueryById(QuerytextBox.Text) };
                }
                else if (QuerycomboBox.SelectedItem.ToString() == "客户名")
                {
                    OrderdataGridView.DataSource = orderService.QueryByClientName(QuerytextBox.Text);
                }
                else if (QuerycomboBox.SelectedItem.ToString() == "配送地址")
                {
                    OrderdataGridView.DataSource = orderService.QueryByAddress(QuerytextBox.Text);
                }
                else if (QuerycomboBox.SelectedItem.ToString() == "总金额")
                {
                    OrderdataGridView.DataSource = orderService.QueryByTotalMoney(Convert.ToDouble(QuerytextBox.Text));
                }
            }catch(ArgumentException exception)
            {
                MessageBox.Show("没有该订单，请确认输入条件是否正确");
            }catch(FormatException exception)
            {
                MessageBox.Show("请输入正确的数字格式");
            }
           
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                orderService.DelOrder(DeletetextBox.Text);
            }catch(ArgumentException exption)
            {
                MessageBox.Show("没有该订单，请确认订单号是否正确");
            }
        }

        private void QuerycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuerytextBox.Visible = true;
            QuerytextBox.Clear();
            if (QuerycomboBox.SelectedItem.ToString() == "全部")
                QuerytextBox.Visible = false;
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderOperationForm addForm = new OrderOperationForm();
            
            addForm.setMainFormOrderValue += getOrderValueAndAdd;
            addForm.Show();
        }
        private void ModifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderOperationForm modifyForm = new OrderOperationForm();
            modifyForm.Text = "修改订单";
            modifyForm.operateOrderBtn.Text = "修改订单";

            modifyForm.setMainFormOrderValue += getOrderValueAndModify;
            modifyForm.Show();


        }

        public void getOrderValueAndAdd(string orderId, string clientname, bool vipShip, string deliveryAddress, OrderDetail orderDetails)
        {
            try
            {
                Order newOrder = new Order();
                newOrder.OrderID = orderId;
                if (vipShip)
                    newOrder.OrderClient = new Client(clientname, "VIP");
                else
                    newOrder.OrderClient = new Client(clientname);
                newOrder.DeliveryAddress = deliveryAddress;
                newOrder.OrderDetails.Add(orderDetails);
                newOrder.OrderTime = DateTime.Now;

                orderService.AddOrder(newOrder);
                MessageBox.Show("添加订单成功！");

            }catch(ArgumentException exception)
            {
                MessageBox.Show("该订单信息错误，请重新核对");
            }
        }

        public void getOrderValueAndModify(string orderId, string clientname, bool vipShip, string deliveryAddress, OrderDetail orderDetails)
        {
            try
            {
                Order newOrder = new Order();
                newOrder.OrderID = orderId;
                if (vipShip)
                    newOrder.OrderClient = new Client(clientname, "VIP");
                else
                    newOrder.OrderClient = new Client(clientname);
                newOrder.DeliveryAddress = deliveryAddress;
                newOrder.OrderDetails.Add(orderDetails);
                newOrder.OrderTime = DateTime.Now;

                orderService.ModifyOrder(newOrder);
                MessageBox.Show("修改订单成功！");

            }
            catch (ArgumentException exception)
            {
                MessageBox.Show("该订单信息错误，请重新核对");
            }
        }

        private void OrderdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string targetOrderId = OrderdataGridView.CurrentRow.Cells[0].Value as String;
            if (targetOrderId != null)
            {
                Order targetOrder = orderService.QueryById(targetOrderId);
                var targetList = targetOrder.OrderDetails.Select(
                    o => new
                    {
                        goodsID = o.OrderGoods.GoodsID,
                        goodsName = o.OrderGoods.Name,
                        goodsPrice = o.OrderGoods.Price,
                        o.Amount,
                        o.Money
                    });
                orderDetailDataGridView.DataSource = targetList.ToList();
            }

        }

        private void export_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取文件完整路径
                string localFilePath = saveFileDialog.FileName.ToString();

                //获取文件名
                string fileName = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);
                //获取文件夹路径
                string fileDirPath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));

                orderService.Export(fileDirPath, fileName);
            }
        }

        private void import_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取文件完整路径
                string localFilePath = openFileDialog.FileName.ToString();

                orderService.Import(localFilePath);
            }
        }
    }
}
