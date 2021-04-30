using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork9
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void showCrawlInfo(string url, string info)
        {
            rtbCrawlInfo.AppendText($"网址：{url}  {info}\n");
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                Uri startUri = new Uri(tbStartUrl.Text);
            }catch(UriFormatException ex)
            {
                MessageBox.Show(ex.Message + "\n请输入正确的网址！");
                tbStartUrl.Clear();
                return;
            }

            Crawler crawler = new Crawler(tbStartUrl.Text);
            crawler.ShowCrawlInfo += this.showCrawlInfo;

            rtbCrawlInfo.Clear();
            rtbCrawlInfo.AppendText("开始爬行了....\n");

            crawler.Crawl();

            rtbCrawlInfo.AppendText("爬行结束\n");

        }

    }
}
