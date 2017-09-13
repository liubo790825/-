using LeaRun.Application.Entity.SystemManage;
using LeaRun.Application.Busines.SystemManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-12 11:00
    /// 描 述：数据导入
    /// </summary>
    public class ExcelImportController : MvcControllerBase
    {
        private ExcelImportBLL excelimportbll = new ExcelImportBLL();
        private Busines.AuthorizeManage.ModuleButtonBLL btnbll = new Busines.AuthorizeManage.ModuleButtonBLL();
        //private excelimportbll excelimportbll = new excelimportbll();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SetFieldForm()
        {
            return View();
        }
        

        #endregion

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = excelimportbll.GetPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = excelimportbll.GetEntity(keyValue);
            var childData = excelimportbll.GetDetails(keyValue);
            var jsonData = new
            {
                templateInfo = data,
                filedsInfo = childData
            };
            return ToJsonResult(jsonData);
        }

        public ActionResult GetFormJsonByModuleId_old()
        {
            string moduleId = WebHelper.GetCookie("currentmoduleId");
            ExcelImportEntity model = excelimportbll.GetEntityByModuleId(moduleId);
            if (model == null)
            {
                return null;
            }

            var data = excelimportbll.GetEntity(model.F_Id);
            var childData = excelimportbll.GetDetails(model.F_Id);
            var jsonData = new
            {
                templateInfo = data,
                filedsInfo = childData
            };
            return ToJsonResult(jsonData);
        }
        public ActionResult GetFormJsonByModuleId(string moduleId,string btnId)
        {
            Dictionary<string, object> dicentitys = new Dictionary<string, object>();
            Dictionary<string, object> dicdatachild = new Dictionary<string, object>();
            ExcelImportEntity model = excelimportbll.GetEntityByModuleId(moduleId);
            if (model!=null)
            {
                var templateInfo = excelimportbll.GetDetails(model.F_Id);
                var btnentity = btnbll.GetEntity(model.F_ModuleBtnId);//得到按钮的数据
                var datachild = new
                {
                    filedsInfo = templateInfo,
                    templateInfo = model
                };
                dicdatachild.Add("0", datachild);
                var entitysItem = new
                {
                    btn = btnentity,
                    data = dicdatachild
                };
                dicentitys.Add(btnentity.EnCode, entitysItem);
            }
            return ToJsonResult(dicdatachild);
        }

        /// <summary>
        /// 获取子表详细信息 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetDetailsJson(string keyValue)
        {
            var data = excelimportbll.GetDetails(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            excelimportbll.RemoveForm(keyValue);
            return Success("删除成功。");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="F_EnabledMark"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult UpdateState(string keyValue,int F_EnabledMark)
        {
            var entity = excelimportbll.GetEntity(keyValue);
            if (entity!=null)
            {
                entity.F_EnabledMark = F_EnabledMark;
            }
            excelimportbll.UpdateState(keyValue, F_EnabledMark);
            return Success("操作成功。");
        }


        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, string strEntity,string strChildEntitys)
        {
            var entity = strEntity.ToObject<ExcelImportEntity>();
            var childEntitys = strChildEntitys.ToList<ExcelImportFiledEntity>();
            excelimportbll.SaveForm(keyValue, entity, childEntitys);
            return Success("操作成功。");
        }
        #endregion
    }
}
