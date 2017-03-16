using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Xml;

namespace KCYPano.PanoTools
{
    public class PanoMaker
    {
        /// <summary>
        /// 注册全景工具
        /// </summary>
        /// <returns></returns>
        public bool Register(string toolfile)
        {
            byte[] key = new byte[] {
                0xAE,0xEC,0xDA,0xE2,0xD9,0x36,0x5F,0x83,0x1D,0x1E,0xE1,0x3B,0x76,0x32,0x50,0x1A,
                0xBF,0x50,0x4D,0xFB,0x4C,0x14,0x78,0x92,0x1F,0x66,0x9C,0xE6,0x39,0x08,0x94,0x58,
                0x06,0xA8,0x6D,0x0A,0xD0,0x85,0x50,0x9E,0x1E,0x6F,0x17,0xF7,0x22,0x70,0xBA,0x70,
                0x79,0xDB,0x14,0x44,0x8D,0x10,0x4E,0x0F,0x94,0x96,0xE1,0x20,0xCA,0xC4,0x4B,0x53,
                0x2B,0x69,0x79,0x51,0x72,0x05,0x3C,0x5D,0xC1,0x11,0x04,0x20,0x6A,0xAE,0x46,0x1D,
                0x47,0xA7,0x60,0x58,0xD8,0x4B,0x59,0xF2,0x47,0x4E,0xDA,0xBE,0x82,0x1C,0xB2,0x40,
                0x16,0x5C,0xD8,0xE7,0x0E,0x9A,0xBB,0x5A,0xE7,0x1F,0x04,0x61,0x25,0x78,0x1A,0x2B,
                0xC2,0x7B,0xE5,0x1C,0x0A,0xD4,0x36,0x1B,0xFC,0xE1,0x19,0xE2,0xD0,0xF6,0xA6,0x78,
                0x94,0xAE,0x73,0x2B,0xA4,0x5C,0x06,0x5B,0x07,0x0A,0x9F,0x11,0xB2,0x35,0x29,0x8C,
                0x92,0xDB,0x14,0xEA,0xA6,0x9D,0x16,0x32,0x9B,0x30,0x7D,0xC7,0x50,0xA3,0x57,0x6B,
                0xB6,0x39,0xF6,0x51,0x33,0x6C,0x36,0x49,0x6E,0xC4,0xEE,0x3F,0xE5,0x32,0x9F,0x0C,
                0x01,0x86,0x88,0x2F,0xF0,0xAF,0x9B,0xCA,0x3B,0x36,0x2C,0x3B,0xD4,0xE3,0xCB,0x31,
                0xE3,0xF0,0x8D,0x1D,0x68,0xB6,0xEA
            };
            //Convert.FromBase64String();
            //BitConverter.ToString()
            string base64 = Convert.ToBase64String(key);
            string outlines = "";
            Process cmd = new Process();                            // 创建进程对象
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = toolfile;                          // 设定需要执行的命令
            startInfo.Arguments = string.Format("register \"{0}\"", base64);     //
            startInfo.UseShellExecute = false;                      // 不使用系统外壳程序启动
            startInfo.RedirectStandardInput = true;                 // 重定向输入
            startInfo.RedirectStandardOutput = true;                // 重定向输出
            startInfo.CreateNoWindow = true;                        // 不创建窗口
            cmd.StartInfo = startInfo;
            //cmd.OutputDataReceived += (object sender, DataReceivedEventArgs e) => {
            //    outlines += e.Data + "\r\n";
            //};

            if (cmd.Start()) {
                cmd.WaitForExit();
                string result = cmd.StandardOutput.ReadToEnd();
                return result.Contains("Code registered");
            }
            return false;
        }

        /// <summary>
        /// 制作全景
        /// </summary>
        /// <param name="toolfile">工具文件</param>
        /// <param name="imagefile">图片文件</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <param name="message">返回消息</param>
        /// <param name="scenexml">返回场景xml</param>
        /// <param name="tiles">返回瓦片图片</param>
        /// <param name="root">返回瓦片根目录</param>
        /// <returns></returns>
        public bool MakeNormal(string toolfile, string imagefile, int timeout, out string message, out string scenexml, out string[] tiles, out string root)
        {
            string lockfile = imagefile + ".lock";
            string configfile = System.IO.Path.GetDirectoryName(toolfile) + "/templates/vtour-normal-auto.config";
            string outlines = "";

            try {
                if (System.IO.File.Exists(lockfile))
                    throw new Exception(string.Format("文件被锁定:", System.IO.Path.GetFileNameWithoutExtension(imagefile)));

                System.IO.File.Create(lockfile).Close();                // 创建锁文件
                Process cmd = new Process();                            // 创建进程对象
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = toolfile;                          // 设定需要执行的命令
                startInfo.Arguments = string.Format("makepano \"{0}\" \"{1}\"", configfile, imagefile);     //
                startInfo.UseShellExecute = false;                      // 不使用系统外壳程序启动
                startInfo.RedirectStandardInput = true;                 // 重定向输入
                startInfo.RedirectStandardOutput = true;                // 重定向输出
                startInfo.CreateNoWindow = true;                        // 不创建窗口
                cmd.StartInfo = startInfo;
                cmd.OutputDataReceived += (object sender, DataReceivedEventArgs e) => {
                    outlines += e.Data + "\r\n";
                };
                
                if (cmd.Start()) {
                    // 进程管理 可以用异步监听输出信息
                    // BeginOutputReadLine 和 OutputDataReceived
                    // 但是这个方法不怎么可靠
                    // while(cmd.WaitForExit(1000)==false) 可以不停的循环
                    // 
                    // 说明: www.cnblogs.com/angus332770349/archive/2012/06/15/2550247.html
                    // 出现的问题是程序运行到'm_BasicDataProc.WaitForExit();'这一行时就阴塞不动.
                    // 搞了两天，最后发现原因是出现了死锁。由于标准输出流被重定向，
                    // 而Process.StandardOutput的缓冲大小是有限制的（据说是 4k），
                    // 所以当缓冲满了的时候（执行上面的批处理文件有很多的输出），
                    // 子进程（cmd.exe）会等待主进程（C# App）读取并释放此缓冲，
                    // 而主进程由于调用了WaitForExit()方法，则会一进等待子进程退出，最后形成死锁。

                    // 执行并且等待程序退出
                    cmd.BeginOutputReadLine();
                    if (cmd.WaitForExit(timeout * 1000) == false) {
                        cmd.Kill();
                        cmd.Close();
                        cmd.Dispose();
                        throw new Exception(string.Format("生成全景超时({0}).", timeout));
                    }

                    // 检查生成的全景是否符合条件
                    string basename = System.IO.Path.GetFileNameWithoutExtension(imagefile);
                    string basepath = System.IO.Path.GetDirectoryName(imagefile);
                    string tourxml = string.Format("{0}\\{1}\\vtour\\tour.xml", basepath, basename);
                    string tilespath = string.Format("{0}\\{1}\\vtour\\panos\\", basepath, basename);
                    // 解析scene
                    if (System.IO.File.Exists(tourxml) == false) throw new Exception("未生成全景.");
                    XmlDocument doc = new XmlDocument();
                    doc.Load(tourxml);
                    XmlNodeList nodes = doc.SelectNodes("/krpano/scene");
                    scenexml = nodes[0].OuterXml;
                    // 瓦片图片
                    tiles = System.IO.Directory.GetFiles(tilespath, "*.*", System.IO.SearchOption.AllDirectories);
                    root = string.Format("{0}\\{1}\\vtour\\panos\\", basepath, basename);
                    // 
                    System.IO.File.Delete(lockfile);    // 删除锁文件
                    message = "全景生成成功.";
                    return true;
                }
                else {
                    throw new Exception("生成程序启动失败.");
                }
            }
            catch (Exception ex) {
                message = ex.Message;
                scenexml = "";
                tiles = new string[0];
                root = "";
                return false;
            }

        }

    }
}