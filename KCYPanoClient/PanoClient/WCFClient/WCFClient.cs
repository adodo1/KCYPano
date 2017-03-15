using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PanoClient
{
    public class WCFClient
    {
        string baseurl = "http://localhost:8987/Service.svc";
        WebClient client = new WebClient();

        public void test()
        {
            //string param = "{\"uid\":\"246534824\",\"sid\":\"906508525\",\"choice\":\"yes\",\"a\":\"GenerateQuestionHandler\",\"questfd\":\"0\"}";
            //Encoding myEncode = Encoding.GetEncoding("UTF-8");
            //byte[] postBytes = Encoding.UTF8.GetBytes(param);
            //HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8987/Service.svc/Speak");
            //req.Method = "POST";
            //req.ContentType = "application/json;charset=UTF-8";
            //req.ContentLength = postBytes.Length;
            //try {
            //    using (Stream reqStream = req.GetRequestStream()) {
            //        reqStream.Write(postBytes, 0, postBytes.Length);
            //    }
            //    using (WebResponse res = req.GetResponse()) {
            //        using (StreamReader sr = new StreamReader(res.GetResponseStream(), myEncode)) {
            //            string strResult = sr.ReadToEnd();
                        
            //        }
            //    }
            //}
            //catch (WebException ex) {
            //    //return "无法连接到服务器\r\n错误信息：" + ex.Message;
            //}



            //var client = new WcfClient.Service.Service1Client();
            //using (var file = File.OpenRead(@"R:\client\1.jpg")) {
            //    client.UploadFile(file);
            //}
            //Console.WriteLine("finished");



            //Dim binding As BasicHttpBinding = New BasicHttpBinding()
 
            //Dim address As New EndpointAddress(New Uri(Application.Current.Host.Source, "你的SVC地址"))
 
            //Dim client As New DataServiceClient(binding, address)
            //AddHandler client.GetValuesCompleted, AddressOf client_GetValuesCompleted
            //        client.GetValuesAsync(ID)


            //ServiceClient client = new ServiceClient("http://localhost:8987/Service.svc?");
            //using (var file = File.OpenRead(@"d:\\temp\\1.json")) {
            //    string result = client.Speak(file);
            //}
            //client.Close();

            //ServiceReference.ServiceClient client = new ServiceReference.ServiceClient("http://localhost:8987/Service.svc/Speak");
            //using (var file = File.OpenRead(@"d:\\temp\\1.json")) {
            //    string result = client.Speak(file);
            //}
            //client.Close();

            //var httpClient = new HttpClient();
            //var strPostUrl = "http://localhost:8987/Service.svc/Speak";
            //FileStream fs = new FileStream("d:\\temp\\1.json", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //Task<HttpResponseMessage> response = httpClient.PostAsync(strPostUrl, new StreamContent(fs));
            //fs.Dispose();
            //Console.WriteLine("上传成功");

            //4.0才有
            //MultipartFormDataContent

            WebClient cc = new WebClient();
            byte[] rrr = cc.UploadData("http://localhost:8987/Service.svc/Speak?name=abc", new byte[] { 97, 98 });

            byte[] eee = cc.UploadFile("http://localhost:8987/Service.svc/Speak?name=abc", "d:\\temp\\1.json");
            //byte[] result = cc.UploadFile("http://localhost:8987/Service.svc/Speak", "D:\\TEMP\\1.json");


            WebClient webClient = new WebClient();
            //webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + "aa");

            byte[] responseBytes;
            byte[] bytes = new byte[] { 243, 98, 99 };


            string data = @"a/b/\c\d\:'{}'~#@$%^&*()-_+=";
            string newurl = string.Format("http://localhost:8987/Service.svc/Speak?name={0}", System.Web.HttpUtility.UrlEncode(data));

            responseBytes = webClient.UploadData(newurl, bytes);
            string responseText = System.Text.Encoding.UTF8.GetString(responseBytes);
            Console.Write(responseText);


            try {
                string strPost = "中文";
                byte[] buffer = Encoding.UTF8.GetBytes(strPost);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8987/Service.svc/Speak");
                request.Method = "POST";
                request.ContentType = "text/plain";

                request.ContentLength = buffer.Length;
                Stream requestStram = request.GetRequestStream();
                requestStram.Write(buffer, 0, buffer.Length);
                requestStram.Close();

                Stream getStream = request.GetResponse().GetResponseStream();

                byte[] resultByte = new byte[200];
                getStream.Read(resultByte, 0, resultByte.Length);

                Console.WriteLine(Encoding.UTF8.GetString(resultByte));
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();




        }


    }


}
