namespace Kingosoft.CL
{
    using System;
    using System.IO;
    using System.Net;
    using System.Web.UI;
    using System.Xml;

    public class CASAgent
    {
        public string CasAuth(Page Page, string CASHost)
        {
            string leftPart = Page.Request.Url.GetLeftPart(UriPartial.Path);
            return this.CasAuth(Page, CASHost, leftPart);
        }

        public string CasAuth(Page Page, string CASHost, string ServiceURL)
        {
            string str = "";
            string str2 = null;
            string str3 = "";
            string address = "";
            string str5 = CASHost.ToLower();
            string str6 = CASHost;
            if (Page.Session["KingoCAS_NetworkID"] != null)
            {
                str2 = Page.Session["KingoCAS_NetworkID"].ToString();
                return ("0|" + str2);
            }
            str3 = Page.Request.QueryString["ticket"];
            if ((str3 == null) || (str3.Length == 0))
            {
                string url = str5 + "login?service=" + ServiceURL;
                Page.Response.Redirect(url);
                return "1|Redirect to CAS-Login.";
            }
            try
            {
                address = str6 + "serviceValidate?ticket=" + str3 + "&service=" + ServiceURL;
                string xmlFragment = new StreamReader(new WebClient().OpenRead(address)).ReadToEnd();
                NameTable nameTable = new NameTable();
                XmlNamespaceManager nsMgr = new XmlNamespaceManager(nameTable);
                XmlParserContext context = new XmlParserContext(null, nsMgr, null, XmlSpace.None);
                XmlTextReader reader2 = new XmlTextReader(xmlFragment, XmlNodeType.Element, context);
                while (reader2.Read())
                {
                    if (reader2.IsStartElement() && (reader2.LocalName == "user"))
                    {
                        str2 = reader2.ReadString();
                    }
                }
                reader2.Close();
            }
            catch (WebException exception)
            {
                str = "-1|[CASAgent-ERROR] " + exception.Message;
            }
            if (str2 != null)
            {
                str = "0|" + str2;
                Page.Session["KingoCAS_NetworkID"] = str2;
            }
            else
            {
                str = "-2|无效的票据!";
            }
            return str;
        }
    }
}

