using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace demoXML
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlElement _xml = new XmlElement();
            //XmlDocument _doc = new XmlDocument();
            // _doc.LoadXml("~/Config/table.xml");
            //_doc.Load("~/Config/table.xml");
            //string path = Path.GetFullPath("E:\\wangwei\\student\\demoXML\\demoXML\\bin\\Debug\\table.xml");
            //Console.WriteLine(Read(path, "root/table", null));

            //DataSet thisDataSet = new DataSet();
            //thisDataSet.ReadXml(path); 
            //DataRelation custRel = thisDataSet.Relations.Add("Cust", thisDataSet.Tables[0].Columns["ID"], thisDataSet.Tables[2].Columns["TabID"]);
            //foreach (DataRow custRow in thisDataSet.Tables["Tab"].Rows)
            //{
            //    Console.WriteLine("ID:{0} \t Name:{1}", custRow["ID"], custRow["Name"]);
            //    foreach (DataRow detailRow in custRow.GetChildRows(custRel))
            //    {
            //        Console.WriteLine("\t ID:{0}\tTabID:{1}\t Name2:{2};\t{3}", detailRow["ID"], detailRow["TabID"], detailRow[2], detailRow.GetParentRow(custRel)["ID"]);
            //    }
            //}
            //Console.WriteLine("Table created by ChildTable:{0}", thisDataSet.Tables[2].TableName);
            //Console.WriteLine("Table created by ReadXml is called {0}", thisDataSet.Tables[0].TableName);
            //Console.Write("Program finished,press Enter/Return to continue:");
            //Console.ReadKey();
            //string[] cc = { "a", "b", "c", "d", "e", "f" };
            //List<peopel> list = new List<peopel>();
            //for (int i = 0; i < 4; i++)
            //{
            //    list.Add(new peopel
            //    {
            //        name = "wangwei" + i,
            //        sex = i % 2 == 0 ? "男" : "女",
            //        age = i * 6,
            //        tel = "1860288587" + i
            //    });
            //}

            //string st = string.Format("a:{0},b:{1},c:{2}", list.ToArray());
            //Console.WriteLine(st);

            //foreach (var item in list)
            //{
            //    Type type = item.GetType();
            //    PropertyInfo[] propertyInfos = type.GetProperties();
            //    List<string> strList = new List<string>();
            //    foreach (PropertyInfo info in propertyInfos)
            //    {
            //        //Console.WriteLine(info.Name + ":" + ((extArr)info.GetCustomAttribute(typeof(extArr))).NoRead);
            //        extArr _extattr = (extArr)info.GetCustomAttribute(typeof(extArr));
            //        if (_extattr == null || !_extattr.NoRead)
            //        {
            //            object ccc = info.GetValue(item, null) == null ? "" : info.GetValue(item, null);
            //            strList.Add(ccc.ToString());
            //        }
            //    }
            //    var _attr = type.GetCustomAttributes();

            //    string st = string.Format("a:{0},b:{1},c:{2}", strList.ToArray());
            //    Console.WriteLine(st);

            //}



            //if(!File.Exists("tableUpate.xml"))
            //    createXML();

            //XmlDocument doc = new XmlDocument();
            //doc.Load("tableUpate.xml");

            //XmlElement elem = doc.CreateElement("table");
            //elem.InnerText = DateTime.Now.ToString();
            ////XmlText text = doc.CreateTextNode(DateTime.Now.ToString());

            //doc.DocumentElement.AppendChild(elem);
            ////doc.DocumentElement.LastChild.AppendChild(text);
            //elem.SetAttribute("ID", "User");
            ////elem.InnerText = DateTime.Now.ToString();
            ////doc.AppendChild.LastChild(elem);

            //XmlElement elem1 = doc.CreateElement("table");
            //elem1.InnerText = DateTime.Now.ToString();
            //doc.DocumentElement.AppendChild(elem1);
            //elem1.SetAttribute("ID", "stutent");

            //doc.Save("tableUpate.xml");


            #region 读取
            XmlDocument doc = new XmlDocument();
            doc.Load("tableUpate.xml");

            //int c= doc.SelectNodes("root/table").Count;
            string val= doc.SelectSingleNode("root/table").Attributes["ID"].Value;
            XmlElement elem = doc.GetElementById("Teacher");

            XmlNode node = doc.SelectSingleNode("root/table");
            #endregion
            XmlAttributeCollection att = node.Attributes;



            XmlNodeList nodelist = doc.SelectNodes("root/table");
            foreach (XmlNode item in nodelist)
            {
                foreach (XmlAttribute attr in item.Attributes)
                {
                    if (attr.Value == "Teacher")
                        Console.WriteLine(item.InnerText);
                    else
                        Console.WriteLine(false);
                }
            }

            Console.WriteLine(elem);

            Console.ReadKey();

        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时返回该属性值，否则返回串联值</param>
        /// <returns>string</returns>
        public static string Read(string path, string node, string attribute)
        {
            var value = "";
            try
            {

                var doc = new XmlDocument();
                doc.Load(path);
                var xn = doc.SelectSingleNode(node);
                if (xn != null && xn.Attributes != null)
                    value = (attribute.Equals("") ? xn.InnerText : xn.Attributes[attribute].Value);
            }
            catch (Exception er)
            {
                throw new Exception(er.ToString());
            }
            return value;
        }


        private static void createXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declara = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(declara);

            XmlElement root = doc.CreateElement("root");
            doc.AppendChild(root);
            doc.Save("tableUpate.xml");
        }

    }





    public class peopel
    {
        public string name { get; set; }

        public string sex { get; set; }
        [extArr(true)]
        public int age { get; set; }
        public string tel { get; set; }
    }


    public class extArr : Attribute
    {
        public extArr(bool remark)
        {
            this.NoRead = remark;
        }
        public bool NoRead { get; set; }
    }
}
