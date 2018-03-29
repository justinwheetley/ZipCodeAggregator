using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.IO;

namespace ZipCodeAggregator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            // MessageBox.Show("Loaded");

            HtmlDocument doc = webBrowser1.Document;
            HtmlElement elem = doc.GetElementsByTagName("form")[0];
            elem.SetAttribute("target", "_self");
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            //HtmlDocument doc = webBrowser1.Document;
            //HtmlElement elem = doc.GetElementsByTagName("NewDataSet")[0];
            //string content = elem.InnerHtml;
            //XmlDocument doc1 = new XmlDocument();
            //doc1.LoadXml(webBrowser1.DocumentText.ToString().Replace("&nbsp;", " "));
            // doc1.LoadXml(content);
            //Save the document to a file.
            //doc1.Save(@"C:\Users\Pale\Desktop\GetInfoByZIP.xml");
            //string path = @"C:\Users\Pale\Desktop\GetInfoByZIP.xml";


            // string path = webBrowser1.Url.ToString();
            //WebClient client = new WebClient();
            //string downloadString = client.DownloadString(path);
            //File.WriteAllText("C:/Users/GetInfoByZIP.xml", downloadString);



            webBrowser1.ShowSaveAsDialog();
            string path = @"C:\Users\jwheetley\Desktop\GetInfoByZIP.xml";
            MessageBox.Show(path);
            
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(path, settings);

            if (reader.ReadToDescendant("Table"))
            {

                reader.ReadStartElement("Table");

                string strCity = reader.ReadElementContentAsString();

                // reader.ReadToDescendant("STATE");
                string strState = reader.ReadElementContentAsString();

                // reader.ReadToDescendant("ZIP");
                int intZip = reader.ReadElementContentAsInt();

                // reader.ReadToDescendant("AREA_CODE");
                int intAreaCode = reader.ReadElementContentAsInt();

                // reader.ReadToDescendant("TIME_ZONE");
                string strTimeZone = reader.ReadElementContentAsString();

                ZipCode zipCode = new ZipCode
                {
                    City = strCity,
                    State = strState,
                    ZipC = intZip,
                    AreaCode = intAreaCode,
                    TimeZone = strTimeZone
                };
                ZipCodeDB.AddZipInfo(zipCode);
                Close();
            }
        }
    }
}
