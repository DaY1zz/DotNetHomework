using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork10

{
    public partial class Form1 : Form
    {
        private Stopwatch sw = new Stopwatch();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void showCrawlInfo(string url,string info)
        {
            if (this.rtbCrawlInfo.InvokeRequired)
            {
                Action<string, string> action = this.AddInfo;
                this.Invoke(action, new object[] { url, info });
            }
            else
            {
                AddInfo(url, info);
            }
        }

        private void AddInfo(string url, string info)
        {
            rtbCrawlInfo.AppendText($"网址：{url}  {info}\n");
        }

        private void crawlEnd()
        {
           
            Action action = new Action(() =>
            {
                sw.Stop();
                rtbCrawlInfo.AppendText($"持续时间：{sw.ElapsedMilliseconds}\n");
                rtbCrawlInfo.AppendText("爬行结束\n");
            });

            if (rtbCrawlInfo.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }

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
            crawler.CrawlEnd += this.crawlEnd;

            rtbCrawlInfo.Clear();
            rtbCrawlInfo.AppendText("开始爬行了....\n");

            sw.Start();
            new Thread(crawler.Crawl).Start();


        }



    }
}
