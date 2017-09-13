using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaRun.Application.Code;
using LeaRun.Util.Offices;
using LeaRun.Util;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Net;
using System.IO;
using System.Text;


namespace LeaRun.Application.Web.Areas.CollegeMIS.Controllers
{
    public class GJTableDemoController : MvcControllerBase
    {
        //
        // GET: /CollegeMIS/GJTableDemo/
        #region 视图
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ScholarshipAppTable()
        {
            return View();
        }

        /// <summary>
        /// 高基941报表
        /// </summary>
        /// <returns></returns>
        public ActionResult GJ941()
        {
            return View();
        }

        /// <summary>
        /// 高基943报表
        /// </summary>
        /// <returns></returns>
        public ActionResult GJ943()
        {
            return View();
        }
        /// <summary>
        /// 高基312报表
        /// </summary>
        /// <returns></returns>
        public ActionResult GJ312()
        {
            return View();
        }

        /// <summary>
        /// 高基321报表
        /// </summary>
        /// <returns></returns>
        public ActionResult GJ321()
        {
            return View();
        }
        /// <summary>
        /// 高基322报表
        /// </summary>
        /// <returns></returns>
        public ActionResult GJ322()
        {
            return View();
        }
        /// <summary>
        /// 高基331报表
        /// </summary>
        /// <returns></returns>
        public ActionResult GJ331()
        {
            return View();
        }
        #endregion
        #region 读取数据
        /// <summary>
        /// 读取高基表941的数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetGJ941Json()
        {
            var data = ExcelHelper.ExcelImport(Server.MapPath("~/Areas/CollegeMIS/Views/GJTableDemo/TableData/GJ941.xlsx"));
            return Content(data.ToJson());
        }

        /// <summary>
        /// 读取高基表的数据
        /// </summary>
        /// <param name="tablename">文件名称</param>
        /// <returns></returns>
        public ActionResult GetGJTableJson(string tablename)
        {
            var data = ExcelHelper.ExcelImport(Server.MapPath("~/Areas/CollegeMIS/Views/GJTableDemo/TableData/"+ tablename + ".xlsx"));
            return Content(data.ToJson());
        }
        #endregion

        // <summary>
        /// 执行此Url，下载PDF档案
        /// </summary>
        /// <returns></returns>
        public ActionResult DownloadPdf(string htmlText)
        {
            //WebClient wc = new WebClient();
            //从网址下载Html字串
            //htmlText = wc.DownloadString(Server.MapPath("/Areas/CollegeMIS/test.html"));
            //byte[] pdfFile = this.ConvertHtmlTextToPDF(htmlText);

            return File(Server.MapPath("/Areas/CollegeMIS/cm.pdf"), "application/pdf", "国家奖学金申请审批表.pdf");
        }

        /// <summary>
        /// 将Html文字 输出到PDF档里
        /// </summary>
        /// <param name="htmlText"></param>
        /// <returns></returns>
        public byte[] ConvertHtmlTextToPDF(string htmlText)
        {
            if (string.IsNullOrEmpty(htmlText))
            {
                return null;
            }
            //避免当htmlText无任何html tag标签的纯文字时，转PDF时会挂掉，所以一律加上<p>标签
            htmlText = "<p>" + htmlText + "</p>";

            MemoryStream outputStream = new MemoryStream();//要把PDF写到哪个串流
            byte[] data = Encoding.UTF8.GetBytes(htmlText);//字串转成byte[]
            MemoryStream msInput = new MemoryStream(data);
            Document doc = new Document();//要写PDF的文件，建构子没填的话预设直式A4
            PdfWriter writer = PdfWriter.GetInstance(doc, outputStream);
            //指定文件预设开档时的缩放为100%
            PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, doc.PageSize.Height, 1f);
            //开启Document文件 
            doc.Open();
            //使用XMLWorkerHelper把Html parse到PDF档里
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msInput, null, Encoding.UTF8, new UnicodeFontFactory());
            //将pdfDest设定的资料写到PDF档
            PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, writer);
            writer.SetOpenAction(action);
            doc.Close();
            msInput.Close();
            outputStream.Close();
            //回传PDF档案 
            return outputStream.ToArray();

        }
    }
}
