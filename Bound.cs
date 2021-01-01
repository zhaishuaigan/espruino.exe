using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Espruino
{
    public class Bound
    {
        public Form app;
        public Bound(Form app)
        {
            this.app = app;

        }

        public string SetTitle(string title)
        {
            this.app.Text = title;
            return title;
        }

        public Form GetForm()
        {
            return this.app;
        }

        public string FunctionForHtml(string msg)
        {
            // 将Html传递过来的数据设置到组件文本框中
            MessageBox.Show("收到Html的数据：" + msg);
            // 返回给Html的数据
            return "我已收到:" + msg;
        }

        public string[] GetPorts()
        {
            return SerialPort.GetPortNames();
        }

        public string GetRootPath()
        {
            return Directory.GetCurrentDirectory();
        }

        public string[] GetEspruinoBinList()
        {
            string binPath = GetRootPath() + "/bin/espruino/";
            FileInfo[] files = new DirectoryInfo(binPath).GetFiles();
            string[] result = new String[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                result[i] = files[i].Name;
            }
            return result;
        }

        public void DownloadEspruinoToEsp01s(string port)
        {
            var baud = "115200";
            var bin = "./espruino/espruino_2v08_esp8266_combined_512.bin";
            var flashSize = "512KB";
            var argument = "--port " + port + " --baud " + baud + " write_flash --flash_size " + flashSize + " 0x0000 " + bin;
            DownloadEspruino(argument);
        }

        public void DownloadEspruinoToEsp8266(string port)
        {
            var baud = "115200";
            var bin = "./espruino/espruino_2v08_esp8266_4mb_combined_4096.bin";
            var flashSize = "4MB";
            var argument = "--port " + port + " --baud " + baud + " write_flash --flash_size " + flashSize + " 0x0000 " + bin;
            DownloadEspruino(argument);
        }
        public void DownloadEspruino(string argument)
        {

            LaunchBat(Environment.CurrentDirectory + "/bin/espruino.bat", argument);
        }

        public void LaunchBat(string batName, string argument)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                FileName = batName,
                Arguments = argument
            };
            // startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
        }

        public void SendCode()
        {
        }






    }
}
