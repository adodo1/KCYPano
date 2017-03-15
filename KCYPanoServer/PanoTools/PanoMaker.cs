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