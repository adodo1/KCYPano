using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        string baseurl = "http://localhost:8987/Service.svc";


        public void test()
        {
            using (HttpClient client = new HttpClient()) {
                //设定要响应的数据格式 text/json 或者 text/xml
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
                // 表明是通过multipart/form-data的方式上传数据
                using (var content = new MultipartFormDataContent()) {
                    // 
                    NameValueCollection vars = new NameValueCollection();
                    vars.Add("name1", "value1");
                    vars.Add("name2", "value2");
                    NameValueCollection files = new NameValueCollection();
                    files.Add("filedata", "d:\\temp\\panos.db");


                    var formDatas = GetFormDataByteArrayContent(vars);     //获取键值集合对应的ByteArrayContent集合
                    var formFiles = GetFileByteArrayContent(files);            //获取文件集合对应的ByteArrayContent集合

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
                        string result = ex.ToString();//将异常信息显示在文本框内
                    }
                }
            }
        }
        /// <summary>
        /// 获取文件集合对应的ByteArrayContent集合
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private List<ByteArrayContent> GetFileByteArrayContent(NameValueCollection files)
        {
            List<ByteArrayContent> list = new List<ByteArrayContent>();
            foreach (string name in files) {
                string file = files[name];
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
        private List<ByteArrayContent> GetFormDataByteArrayContent(NameValueCollection collection)
        {
            List<ByteArrayContent> list = new List<ByteArrayContent>();
            foreach (var key in collection.AllKeys) {
                var dataContent = new ByteArrayContent(Encoding.UTF8.GetBytes(collection[key]));
                dataContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") {
                    Name = key
                };
                list.Add(dataContent);
            }
            return list;
        }


    }


}
