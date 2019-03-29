using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


public partial class Json_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string flag = "";
        flag = Request["flag"];
        switch (flag)
        {
            case "load":
                load();
                break;
            case "add":
                add();
                break;
            case "edt":
                edt();
                break;
            case "del":
                del();
                break;
            case "getUser":
                getUser();
                break;
            default:
                break;
        }
        Response.End();
    }

    private void load()
    {

       

    }

    private void add()
    {
        try
        {
            string userName = Request["userName"];
            string Chinese = Request["Chinese"];
            string Math = Request["Math"];
            string English = Request["English"];
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("~/Index.xml"));

            bool existsName = false;
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("root").ChildNodes;//获取root节点的所有子节点 
            foreach (XmlNode node in nodeList)
            {
                foreach (XmlNode node1 in node.ChildNodes)
                {
                    XmlElement xe2 = (XmlElement)node1;
                    if (xe2.InnerText == userName)
                    {
                        existsName = true;
                        break;
                    }
                }
            }

            if (existsName)
            {
                Response.Write("{\"cnt\":\"1\",\"msg\":\"该用户名已存在!\"}");
            }
            else
            {
                XmlNode root = xmlDoc.SelectSingleNode("root");//查找<root> 

                XmlElement xe1 = xmlDoc.CreateElement("list");//创建一个<list>节点 

                XmlElement xesub1 = xmlDoc.CreateElement("userName");
                xesub1.InnerText = userName;
                xe1.AppendChild(xesub1);

                XmlElement xesub2 = xmlDoc.CreateElement("Chinese");
                xesub2.InnerText = Chinese;
                xe1.AppendChild(xesub2);

                XmlElement xesub3 = xmlDoc.CreateElement("Math");
                xesub3.InnerText = Math;
                xe1.AppendChild(xesub3);

                XmlElement xesub4 = xmlDoc.CreateElement("English");
                xesub4.InnerText = English;
                xe1.AppendChild(xesub4);

                root.AppendChild(xe1);
                xmlDoc.Save(Server.MapPath("~/Index.xml"));
                Response.Write("{\"cnt\":\"1\",\"msg\":\"添加成功!\"}");
            }
        }
        catch (Exception e)
        {
            Response.Write("{\"cnt\":\"0\",\"msg\":\"" + e.Message + "\"}");
        }
    }


    private void edt()
    {
        try
        {
            string userName = Request["userName"];
            string Chinese = Request["Chinese"];
            string Math = Request["Math"];
            string English = Request["English"];
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("~/Index.xml"));
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("root").ChildNodes;//获取root节点的所有子节点 
            foreach (XmlNode node in nodeList)
            {

                foreach (XmlNode node1 in node.ChildNodes)
                {
                    XmlElement xe2 = (XmlElement)node1;

                    if (xe2.InnerText == userName)//如果找到 
                    {
                        foreach (XmlNode node2 in xe2.ParentNode.ChildNodes)
                        {
                            XmlElement xe3 = (XmlElement)node2;
                            if (xe3.Name == "Chinese")
                            {
                                xe3.InnerText = Chinese;
                            }
                            if (xe3.Name == "Math")
                            {
                                xe3.InnerText = Math;
                            }
                            if (xe3.Name == "English")
                            {
                                xe3.InnerText = English;
                            }
                        }
                    }

                }
            }

            xmlDoc.Save(Server.MapPath("~/Index.xml"));
            Response.Write("{\"cnt\":\"1\",\"msg\":\"修改成功!\"}");
        }
        catch (Exception e)
        {
            Response.Write("{\"cnt\":\"0\",\"msg\":\"" + e.Message + "\"}");
        }
    }


    private void getUser()
    {
        string userName = Request["userName"];
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Server.MapPath("~/Index.xml"));

        XmlNodeList nodeList = xmlDoc.SelectSingleNode("root").ChildNodes;//获取root节点的所有子节点 
        string ret = "{";
        foreach (XmlNode node in nodeList)
        {

            foreach (XmlNode node1 in node.ChildNodes)
            {
                XmlElement xe2 = (XmlElement)node1;

                if (xe2.InnerText == userName)//如果找到 
                {
                    foreach (XmlNode node2 in xe2.ParentNode.ChildNodes)
                    {
                        XmlElement xe3 = (XmlElement)node2;
                        if (xe3.Name == "userName")//如果找到 
                        {
                            ret += "\"userName\":\"" + xe3.InnerText + "\",";
                        }
                        if (xe3.Name == "Chinese")//如果找到 
                        {
                            ret += "\"Chinese\":\"" + xe3.InnerText + "\",";
                        }
                        if (xe3.Name == "Math")//如果找到 
                        {
                            ret += "\"Math\":\"" + xe3.InnerText + "\",";
                        }
                        if (xe3.Name == "English")//如果找到 
                        {
                            ret += "\"English\":\"" + xe3.InnerText + "\"";
                        }
                    }
                }
            }
        }
        ret += "}";
        Response.Write(ret);
    }

    private void del()
    {
        string userName = Request["userName"];
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Server.MapPath("~/Index.xml"));
        XmlNodeList nodeList = xmlDoc.SelectSingleNode("root").ChildNodes;//获取root节点的所有子节点 
        foreach (XmlNode node in nodeList)
        {
            XmlElement xe1 = (XmlElement)node;
            foreach (XmlNode node1 in node.ChildNodes)
            {
                XmlElement xe2 = (XmlElement)node1;
                if (xe2.InnerText == userName)//如果找到 
                {
                    node.ParentNode.RemoveChild(xe1);
                }

            }
        }

        xmlDoc.Save(Server.MapPath("~/Index.xml"));
        Response.Write("{\"cnt\":\"1\",\"msg\":\"删除成功!\"}");
    }
}