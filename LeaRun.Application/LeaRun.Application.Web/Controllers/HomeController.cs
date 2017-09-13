using LeaRun.Application.Busines;
using LeaRun.Application.Busines.BaseManage;
using LeaRun.Application.Busines.SystemManage;
using LeaRun.Application.Code;
using LeaRun.Application.Entity;
using LeaRun.Application.Entity.SystemManage;
using LeaRun.Util;
using LeaRun.Util.Attributes;
using LeaRun.Util.Log;
using LeaRun.Util.Offices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaRun.Application.Busines.PublicInfoManage;
using LeaRun.Application.Entity.PublicInfoManage;
using LeaRun.Util.WebControl;
using LeaRun.Application.Busines.AuthorizeManage;
using LeaRun.Application.Entity.AuthorizeManage;

namespace LeaRun.Application.Web.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创建人：J&M
    /// 日 期：2015.09.01 13:32
    /// 描 述：系统首页
    /// </summary>
    [HandlerLogin(LoginMode.Enforce)]
    public class HomeController : Controller
    {
        UserBLL user = new UserBLL();
        DepartmentBLL department = new DepartmentBLL();

        #region 视图功能

        public ActionResult Index()
        {
            string cookie = WebHelper.GetCookie("learn_UItheme");
            string a;
            if ((a = cookie) != null)
            {
                if (a == "1")
                {
                    return base.RedirectToAction("AdminDefault", "Home");
                }
                if (a == "2")
                {
                    return base.RedirectToAction("AdminLTE", "Home");
                }
                if (a == "3")
                {
                    return base.RedirectToAction("AdminWindos", "Home");
                }
            }
            return base.RedirectToAction("AdminDefault", "Home");
        }
        

        /// <summary>
        /// 后台框架页
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminDefault()
        {
            return View();
        }
        /// <summary>
        /// 后台框架页
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminBeyond()
        {
            return View();
        }
        /// <summary>
        /// 我的桌面
        /// </summary>
        /// <returns></returns>
        public ActionResult Desktop()
        {
            return View();
        }


        public ActionResult AdminDefaultDesktop()
        {
            return base.View();
        }

        public ActionResult AdminLTE()
        {
            return base.View();
        }

        //[HttpGet]
        public ActionResult AdminLTEDesktop()
        {
            NewsBLL newsBLL = new NewsBLL();
            Pagination pagination = new Pagination();
            pagination.page = 1;
            pagination.rows = 10;
            pagination.sidx = "ReleaseTime";
            pagination.sord = "desc";
            var data1 = newsBLL.GetPageList(pagination, null);
            ViewBag.NewsList1 = data1;

            NoticeBLL noticeBLL = new NoticeBLL();
            //pagination = new Pagination();
            //pagination.page = 1;
            //pagination.rows = 10;
            //pagination.sidx = "ReleaseTime";
            //pagination.sord = "desc";
            var data2 = noticeBLL.GetPageList(pagination, null);
            ViewBag.NewsList2 = data2;

            FileInfoBLL fileBLL = new FileInfoBLL();
            var dataf = fileBLL.GetOthersShareList(LeaRun.Application.Code.OperatorProvider.Provider.Current().UserId);
            ViewBag.SharedList = dataf;

           
            return base.View();
        }

        public ActionResult AdminWindos()
        {
            return base.View();
        }

        public ActionResult AdminWindosDesktop()
        {
            return base.View();
        }

        public ActionResult ToView1(string url)
        {
            //url=Request.QueryString["url"];
            ViewBag.Url = url;
            return base.View();
        }

        public ActionResult ToView2(string url)
        {
            //url=Request.QueryString["url"];
            ViewBag.Url = url;
            return base.View();
        }

        #region 各种流程导向图
        /// <summary>
        /// 学籍管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Flow(string parentid="0")
        {
            ModuleBLL moduleBLL = new ModuleBLL();
            var data = moduleBLL.GetList(parentid);//EnabledMark       
            ViewBag.jsondata = data.ToJson();
            return View();
        }

        #endregion 各种流程导向图

        /// <summary>
        /// 公告实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult NewsLookDetail(string keyValue)
        {
            ViewBag.keyValue = keyValue;// Request.QueryString["keyValue"];
            return base.View();
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 访问功能
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <param name="moduleName">功能模块</param>
        /// <param name="moduleUrl">访问路径</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult VisitModule_O(string moduleId, string moduleName, string moduleUrl)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.CategoryId = 2;
            logEntity.OperateTypeId = ((int)OperationType.Visit).ToString();
            logEntity.OperateType = EnumAttribute.GetDescription(OperationType.Visit);
            logEntity.OperateAccount = OperatorProvider.Provider.Current().Account;
            logEntity.OperateUserId = OperatorProvider.Provider.Current().UserId;
            logEntity.ModuleId = moduleId;
            logEntity.Module = moduleName;
            logEntity.ExecuteResult = 1;
            logEntity.ExecuteResultJson = "访问地址：" + moduleUrl;
            logEntity.WriteLog();
            return Content(moduleId);
        }

        [HttpPost]
        public ActionResult VisitModule(string moduleId, string moduleName, string moduleUrl)
        {
            new LogEntity
            {
                CategoryId = new int?(2),
                OperateTypeId = 3.ToString(),
                OperateType = EnumAttribute.GetDescription(OperationType.Visit),
                OperateAccount = OperatorProvider.Provider.Current().Account,
                OperateUserId = OperatorProvider.Provider.Current().UserId,
                ModuleId = moduleId,
                Module = moduleName,
                ExecuteResult = new int?(1),
                ExecuteResultJson = "访问地址：" + moduleUrl
            }.WriteLog();
            return base.Content(moduleId);
        }

        /// <summary>
        /// 离开功能
        /// </summary>
        /// <param name="moduleId">功能模块Id</param>
        /// <returns></returns>
        public ActionResult LeaveModule(string moduleId)
        {
            return null;
        }
        #endregion
    }
}
