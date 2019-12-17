using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace meetingdemo_csharp
{
    struct AppConfig
    {
        public String appUserDefine;
        public String appId;
        public String appSecret;
        public String userAppId;
        public String userAppSecret;
        public String serverUserDefine;
        public String serverAddr;
        public String userServerAddr;
    };

    static class ConfigParser
    {
        public static AppConfig appConfig;

        public static void LoadConfig()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("appinfo.xml");

            XmlNode root = xml.SelectSingleNode("Root");

            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == "AppUserDefine")
                {
                    appConfig.appUserDefine = node.InnerText;
                }
                else if (node.Name == "AppId")
                {
                    appConfig.appId = node.InnerText;
                }
                else if (node.Name == "AppSecret")
                {
                    appConfig.appSecret = node.InnerText;
                }
                else if (node.Name == "UserAppId")
                {
                    appConfig.userAppId = node.InnerText;
                }
                else if (node.Name == "UserAppSecret")
                {
                    appConfig.userAppSecret = node.InnerText;
                }
                else if (node.Name == "ServerUserDefine")
                {
                    appConfig.serverUserDefine = node.InnerText;
                }
                else if (node.Name == "ServerAddr")
                {
                    appConfig.serverAddr = node.InnerText;
                }
                else if (node.Name == "UserServerAddr")
                {
                    appConfig.userServerAddr = node.InnerText;
                }
            }
        }

        public static void SerializeConfig()
        {
            XmlDocument xml = new XmlDocument();

            XmlDeclaration decl = xml.CreateXmlDeclaration("1.0", "UTF-8", "");
            xml.AppendChild(decl);

            XmlElement root = xml.CreateElement("Root");

            root.AppendChild(xml.CreateComment("Whether use user-defined app"));
            XmlElement appUserDefineNOde = xml.CreateElement("AppUserDefine");
            appUserDefineNOde.InnerText = appConfig.appUserDefine;
            root.AppendChild(appUserDefineNOde);

            root.AppendChild(xml.CreateComment("Default app ID"));
            XmlElement appIdNode = xml.CreateElement("AppId");
            appIdNode.InnerText = appConfig.appId;
            root.AppendChild(appIdNode);

            root.AppendChild(xml.CreateComment("Default app secret"));
            XmlElement appSecretNode = xml.CreateElement("AppSecret");
            appSecretNode.InnerText = appConfig.appSecret;
            root.AppendChild(appSecretNode);

            root.AppendChild(xml.CreateComment("User-defined app ID"));
            XmlElement userAppIdNode = xml.CreateElement("UserAppId");
            userAppIdNode.InnerText = appConfig.userAppId;
            root.AppendChild(userAppIdNode);

            root.AppendChild(xml.CreateComment("User-defined app secret"));
            XmlElement userAppSecretNode = xml.CreateElement("UserAppSecret");
            userAppSecretNode.InnerText = appConfig.userAppSecret;
            root.AppendChild(userAppSecretNode);

            root.AppendChild(xml.CreateComment("Whether use user-defined server"));
            XmlElement serverUserDefineNode = xml.CreateElement("ServerUserDefine");
            serverUserDefineNode.InnerText = appConfig.serverUserDefine;
            root.AppendChild(serverUserDefineNode);

            root.AppendChild(xml.CreateComment("Access service address"));
            XmlElement serverAddrNode = xml.CreateElement("ServerAddr");
            serverAddrNode.InnerText = appConfig.serverAddr;
            root.AppendChild(serverAddrNode);

            root.AppendChild(xml.CreateComment("User-defined access service address"));
            XmlElement userServerAddrNode = xml.CreateElement("UserServerAddr");
            userServerAddrNode.InnerText = appConfig.userServerAddr;
            root.AppendChild(userServerAddrNode);

            xml.AppendChild(root);

            xml.Save("appinfo.xml");
        }
    }
}
