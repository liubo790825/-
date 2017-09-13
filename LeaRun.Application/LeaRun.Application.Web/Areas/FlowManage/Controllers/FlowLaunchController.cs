using LeaRun.Application.Busines.FlowManage;
using LeaRun.Application.Entity.FlowManage;
using System;
using System.Collections.Generic;
using LeaRun.Util;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaRun.Application.Code;
using LeaRun.Application.Busines.FormManage;
using LeaRun.Util.Extension;



namespace LeaRun.Application.Web.Areas.FlowManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创建人：L&B
    /// 日 期：2016.03.19 14:27
    /// 描 述：流程发起
    /// </summary>
    public class FlowLaunchController : MvcControllerBase
    {
        private WFRuntimeBLL wfProcessBll = new WFRuntimeBLL();
        private WFSchemeInfoBLL infobll = new WFSchemeInfoBLL();
        private Form_ModuleBLL mbll = new Form_ModuleBLL();
        #region 视图功能
        //
        // GET: /FlowManage/FlowLaunch/
        /// <summary>
        /// 管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 预览
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PreviewIndex()
        {
            return View();
        }
        /// <summary>
        /// 创建流程实例
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FlowProcessNewForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        public ActionResult GetFlowJson(string keyValue)
        {
            var data = infobll.GetEntity(keyValue);
            var formeneity = mbll.GetEntity(data.FormList);
            var jsondata = new
            {
                formEntity = formeneity,
                schemeInfo = data
            };
            return Content(jsondata.ToJson());
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 创建流程实例
        /// </summary>
        /// <param name="wfSchemeInfoId">流程模板信息Id</param>
        /// <param name="frmData">表单数据</param>
        /// <param name="type">0发起，3草稿</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult CreateProcess(string wfSchemeInfoId, string wfProcessInstanceJson, string frmData)
        {
            WFProcessInstanceEntity wfProcessInstanceEntity = wfProcessInstanceJson.ToObject<WFProcessInstanceEntity>();
            wfProcessBll.CreateProcess(wfSchemeInfoId,wfProcessInstanceEntity, frmData);
            string text = "创建成功";
            if (wfProcessInstanceEntity.EnabledMark != 1)
            {
                text = "草稿保存成功";
            }
            return Success(text);
        }

        /// <summary>
        /// 创建流程实例
        /// </summary>
        /// <param name="wfCPParameterModel">流程模板信息Id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult CreateProcessInstance(object wfCPParameterModel)
        {
            

            /*WNewRuntimeInitModel 
            WFProcessInstanceEntity wfProcessInstanceEntity = new WFProcessInstanceEntity();
            wfProcessInstanceEntity.ProcessSchemeId = wfCPParameterModel.processId;
            wfProcessInstanceEntity.CustomName = wfCPParameterModel.processName;
            wfProcessInstanceEntity.wfLevel = wfCPParameterModel.level;
            wfProcessInstanceEntity.Description = wfCPParameterModel.description;
            
            wfProcessBll.CreateProcess(wfCPParameterModel.schemeId, wfProcessInstanceEntity, wfCPParameterModel.formData);

            
            //WFProcessInstanceEntity wfProcessInstanceEntity = wfCPParameterModel.ToObject<WFProcessInstanceEntity>();
            if (!param["schemeId"].IsEmpty())
            {
                wfProcessInstanceEntity.ProcessSchemeId = param["schemeId"].ToString();
            }
            wfProcessBll.CreateProcess(wfCPParameterModel.ProcessSchemeId, wfCPParameterModel, wfCPParameterModel.Description);
            string text = "创建成功";
            if (wfCPParameterModel.EnabledMark != 1)
            {
                text = "草稿保存成功";
            }*/
            string text = "创建成功";
            return Success(text);
        }

        #endregion
    }
}
