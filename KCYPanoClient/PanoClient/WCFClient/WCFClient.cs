using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PanoClient
{
    public class WCFClient
    {
        // 关键字
        // NameValueCollection
        // MediaTypeWithQualityHeaderValue
        // MultipartFormDataContent

        /// <summary>
        /// POST提交数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="vars"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        private string Post(string url, Dictionary<string, string> vars, Dictionary<string, string> files)
        {
            using (HttpClient client = new HttpClient()) {
                // 设定要响应的数据格式 text/json 或者 text/xml
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
                // 表明是通过multipart/form-data的方式上传数据
                using (var content = new MultipartFormDataContent()) {
                    // 获取键值集合对应的ByteArrayContent集合
                    List<ByteArrayContent> formDatas = GetFormDataByteArrayContent(vars);
                    // 获取文件集合对应的ByteArrayContent集合
                    List<ByteArrayContent> formFiles = GetFileByteArrayContent(files);

                    // 声明一个委托，该委托的作用就是将ByteArrayContent集合加入到MultipartFormDataContent中
                    Action<List<ByteArrayContent>> act = (dataContents) => {
                        foreach (var byteArrayContent in dataContents) {
                            content.Add(byteArrayContent);
                        }
                    };
                    act(formDatas);     // 执行act
                    act(formFiles);     // 执行act
                    try {
                        var result = client.PostAsync(url, content).Result;   // POST请求
                        var html = result.Content.ReadAsStringAsync().Result;   // 将响应结果显示在文本框内
                        return html;
                    }
                    catch (Exception ex) {
                        string result = ex.ToString();  // 将异常信息显示在文本框内
                        return result;
                    }
                }
            }
        }
        /// <summary>
        /// 上传一张全景图
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public string Add(string file)
        {
            Dictionary<string, string> vars = new Dictionary<string,string>();
            Dictionary<string, string> files = new Dictionary<string,string>();
            files.Add("filedata", file);
            string url = ConfigurationManager.AppSettings["panoaddurl"];
            string result = Post(url, vars, files);
            return result;
        }
        /// <summary>
        /// 制作全景图
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <param name="date"></param>
        /// <param name="heading"></param>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="author">作者</param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public string Build(string uid, string name, string category, long date, int heading, double lat, double lng, string author, string remark)
        {
            Dictionary<string, string> vars = new Dictionary<string, string>();
            Dictionary<string, string> files = new Dictionary<string, string>();
            vars["uid"] = uid;
            vars["name"] = name;
            vars["category"] = category;
            vars["date"] = date.ToString();
            vars["heading"] = heading.ToString();
            vars["lat"] = lat.ToString();
            vars["lng"] = lng.ToString();
            vars["author"] = author;
            vars["remark"] = remark;
            string url = ConfigurationManager.AppSettings["panobuildurl"];
            string result = Post(url, vars, files);
            return result;
        }
        

        public void test()
        {
            return;
            using (HttpClient client = new HttpClient()) {
                // 关键字 NameValueCollection MediaTypeWithQualityHeaderValue MultipartFormDataContent
                // 设定要响应的数据格式 text/json 或者 text/xml
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
                //  表明是通过multipart/form-data的方式上传数据
                using (var content = new MultipartFormDataContent()) {
                    // 
                    Dictionary<string, string> vars = new Dictionary<string, string>();
                    vars.Add("name1", "value1");
                    vars.Add("name2", "value2");
                    Dictionary<string, string> files = new Dictionary<string, string>();
                    files.Add("filedata", "d:\\temp\\panos.db");


                    List<ByteArrayContent> formDatas = GetFormDataByteArrayContent(vars);   //获取键值集合对应的ByteArrayContent集合
                    List<ByteArrayContent> formFiles = GetFileByteArrayContent(files);      //获取文件集合对应的ByteArrayContent集合

                    // 声明一个委托，该委托的作用就是将ByteArrayContent集合加入到MultipartFormDataContent中
                    Action<List<ByteArrayContent>> act = (dataContents) => {
                        foreach (var byteArrayContent in dataContents) {
                            content.Add(byteArrayContent);
                        }
                    };
                    act(formDatas);     // 执行act
                    act(formFiles);     // 执行act
                    try {
                        var result = client.PostAsync("url", content).Result;   // post请求
                        var html = result.Content.ReadAsStringAsync().Result;   // 将响应结果显示在文本框内
                    }
                    catch (Exception ex)
                    {
                        string result = ex.ToString();// 将异常信息显示在文本框内
                    }
                }
            }
        }
        /// <summary>
        /// 获取文件集合对应的ByteArrayContent集合
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        private List<ByteArrayContent> GetFileByteArrayContent(Dictionary<string, string> datas)
        {
            List<ByteArrayContent> list = new List<ByteArrayContent>();
            foreach (KeyValuePair<string, string> item in datas) {
                string name = item.Key;
                string file = item.Value;
                var fileContent = new ByteArrayContent(File.ReadAllBytes(file));
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") {
                    FileName = Path.GetFileName(file),
                    Name = name
                };
                list.Add(fileContent);
            }
            return list;
        }
        /// <summary>
        /// 获取键值集合对应的ByteArrayContent集合
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private List<ByteArrayContent> GetFormDataByteArrayContent(Dictionary<string, string> collection)
        {
            List<ByteArrayContent> list = new List<ByteArrayContent>();
            foreach (KeyValuePair<string, string> item in collection) {
                var dataContent = new ByteArrayContent(Encoding.UTF8.GetBytes(item.Value));
                dataContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") {
                    Name = item.Key
                };
                list.Add(dataContent);
            }
            return list;
        }


    }


}
