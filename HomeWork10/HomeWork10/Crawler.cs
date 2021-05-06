using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork10
{
    class Crawler
    {
        private ConcurrentDictionary<string,bool> urls = new ConcurrentDictionary<string, bool>();
        private int count = 0;
        /// <summary>
        /// 起始网址
        /// </summary>
        private string startUrl;

        /// <summary>
        /// 匹配起始网站的正则表达式
        /// </summary>
        public string HostFilterRegex 
        {
            get
            {
                Uri startUri = new Uri(startUrl);
                return "^" + startUri.Host + "$";
            }
            set { }
        }
        /// <summary>
        /// 显示爬取情况
        /// </summary>
        public event Action<string, string> ShowCrawlInfo;

        public event Action CrawlEnd;


        public Crawler(string startUrl)
        {
            this.startUrl = startUrl;
            urls.TryAdd(startUrl, false);
        }

        public async void Crawl()
        {
            List<Task> tasks = new List<Task>();

            while (true)
            {
                string current = null;
                string html = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;       //该网站已经爬取过则跳过
                    current = url;
                }
                if (current == null || count > 30) 
                    break;

                Task task = Task.Run(() =>
                {
                    try
                    {
                        html = DownLoad(current); // 下载网站内容
                        count++;
                        ShowCrawlInfo(current, "爬取成功！");

                    }
                    catch (Exception ex)
                    {
                        ShowCrawlInfo(current, "错误：" + ex.Message);
                    }

                    urls[current] = true;       //标记该网站已被爬取

                    Parse(html, current);//解析当前网站内容,并加入新的链接
                }
                );
                tasks.Add(task);
                
            }
            await Task.WhenAll(tasks);
            CrawlEnd();

        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;

                Task<string> downloadTask = Task.Run(()=>webClient.DownloadString(url));       
                string html = downloadTask.Result;
                string fileName = count.ToString();

                Task writeFileTask = Task.Run(()=>File.WriteAllText(fileName, html, Encoding.UTF8));

                return html;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Parse(string html,string currentUrl)
        {
            
            string herfRegx = @"(href|HREF)[]*=[]*[""'][^""'#>]+((html?|aspx|jsp)|^[^.]$)[""']";

            MatchCollection matches = new Regex(herfRegx).Matches(html);

            foreach (Match match in matches)
            {
                //获取html中htm / html / aspx / jsp等网址链接
                string link = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');

                if (link.Length == 0) continue;
                //将相对路径转换为绝对路径
                link = ConvertToAbsoluteUrl(link, currentUrl);

                //只会爬取起始网站内的网页
                if (Regex.IsMatch(new Uri(link).Host, HostFilterRegex) && urls.TryAdd(link,false))
                {
                    Console.WriteLine("成功添加到爬取集合中");
                }
            }
        }

        private string ConvertToAbsoluteUrl(string link, string currentUrl)
        {
            Uri currentUri = new Uri(currentUrl);
            Uri linkUri = null;
            try
            {            
                linkUri = new Uri(link);
                //如果link是绝对地址则直接返回,否则进行拼接
                if (linkUri.IsAbsoluteUri)
                    return link;
                else
                {
                    linkUri = new Uri(currentUri, link);
                    return linkUri.ToString();
                }

            }catch(UriFormatException e)  //构造Uri对象必须基于绝对Url
            {
                linkUri = new Uri(currentUri, link);
                return linkUri.ToString();
            }


        }
    }
}
