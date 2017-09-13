using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.FlowManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创建人：L&B
    /// 日 期：2016.03.19 13:57
    /// 描 述:我的流程
    /// </summary>
    public class FlowMyProcessController : MvcControllerBase
    {
        #region 视图功能
        //
        // GET: /FlowManage/FlowMyProcess/
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 进度查看
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProcessLookForm()
        {
            return View();
        }
        /// <summary>
        /// 进程再次提交
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProcessAgainNewForm()
        {
            return View();
        }
        #endregion

        #region 获取数据

        #endregion


    }
}
