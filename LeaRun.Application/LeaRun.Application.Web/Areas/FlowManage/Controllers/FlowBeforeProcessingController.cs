using LeaRun.Application.Busines.FlowManage;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.FlowManage;
using LeaRun.Application.Entity.FormManage;
using LeaRun.Application.Busines.FormManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.FlowManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创建人：L&B
    /// 日 期：2016.03.19 13:57
    /// 描 述:已办流程
    /// </summary>
    public class FlowBeforeProcessingController : MvcControllerBase
    {
        private WFRuntimeBLL wfProcessBll = new WFRuntimeBLL();
        private WFSchemeInfoBLL sibll = new WFSchemeInfoBLL();
        private Form_ModuleContentBLL mcbll = new Form_ModuleContentBLL();

        #region 视图功能
        //
        // GET: /FlowManage/FlowBeforeProcessing/
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 审核流程
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VerificationFrom()
        {
            return View();
        }
        #endregion

        #region 提取数据
        /// <summary>
        /// 获取代办的工作流程,运行中(分页)
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            pagination.page++;
            var data = wfProcessBll.GetToMeBeforePageList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
            };
            return Content(JsonData.ToJson());
        }

        public ActionResult GetProcessJson(string keyValue,string nodeId)
        {
            var processEntity = wfProcessBll.GetProcessInstanceEntity(keyValue);
            var processSchemeEntity = wfProcessBll.GetProcessSchemeEntity(processEntity.ProcessSchemeId);
            var queryJson = new { F_ProcessId = keyValue, F_NodeId = nodeId };
            var nodeList = wfProcessBll.ProcessNodesList(queryJson.ToJson());

            var  schemeInfoEntity = sibll.GetEntity(processSchemeEntity.WFSchemeInfoId);

            var formModuleIds = schemeInfoEntity.FormList.Trim(',').Split(',');
            List<Form_ModuleEntity> moduleList = new List<Form_ModuleEntity>();

            List<Form_ModuleInstanceEntity> instanceList = new List<Form_ModuleInstanceEntity>();

            Dictionary<string, Form_ModuleContentEntity> dFormData = new Dictionary<string, Form_ModuleContentEntity>();
            foreach (var moduleid in formModuleIds)
            {
                var modultEntity = wfProcessBll.GetModuleEntity(moduleid);
                if (modultEntity != null)
                {
                    moduleList.Add(modultEntity);
                    mcbll.GetEntity(modultEntity.FrmId);


                }
            }

            

            var jsonData = new
            {
                processEntity= processEntity,
                processSchemeEntity= processSchemeEntity,
                nodeList = nodeList,
                formEntityList = moduleList

            };

            return Content(jsonData.ToJson());

        }


        #endregion
    }
}
