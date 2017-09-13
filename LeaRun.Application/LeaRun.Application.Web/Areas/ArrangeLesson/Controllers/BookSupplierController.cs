using LeaRun.Application.Entity.ArrangeLesson;
using LeaRun.Application.Busines.ArrangeLesson;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Web.Mvc;
using System.Collections.Generic;

namespace LeaRun.Application.Web.Areas.ArrangeLesson.Controllers
{
    public class ClsAndTbInfo
    {
        /// <summary>
        /// 计划ID号
        /// </summary>
        public int PlanId { get; set; }
        /// <summary>
        /// 系部
        /// </summary>
        public string College { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        public string MajorName { get; set; }
        /// <summary>
        /// 班级
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 人数
        /// </summary>
        public int StuNum { get; set; }

        /// <summary>
        /// 教材ID号
        /// </summary>
        public int? TeachBookId { get; set; }
        /// <summary>
        /// 教材名称
        /// </summary>
        public string TeachBook { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 出版社
        /// </summary>
        public string PubCompany { get; set; }
        /// <summary>
        /// ISBN号
        /// </summary>
        public string ISBN { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BookSupplierController : MvcControllerBase
    {
        //
        // GET: /ArrangeLesson/BookSupplier/
        private OpenLessonPlanBLL openlessonplanbll = new OpenLessonPlanBLL();
        private LeaRun.Application.Busines.HVSMIS.TbBasicInfoBLL tbbibll = new LeaRun.Application.Busines.HVSMIS.TbBasicInfoBLL();


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
            var data = openlessonplanbll.GetPageList(pagination, queryJson);

            List<ClsAndTbInfo> clsAndTbInfoList = new List<ClsAndTbInfo>();
            foreach (var opelesn in data)
            {
                ClsAndTbInfo catb = new ClsAndTbInfo();
                catb.ClassName = opelesn.ClassName;
                catb.College = opelesn.College;
                catb.MajorName = opelesn.MajorName;
                catb.PlanId = opelesn.PlanId.Value;
                catb.StuNum = opelesn.StuNum.Value;
                catb.TeachBookId = opelesn.TeachBookId!=null?opelesn.TeachBookId.Value:0;
                if (opelesn.TeachBookId != null)
                {
                    LeaRun.Application.Entity.HVSMIS.TbBasicInfoEntity tbInfoModel = tbbibll.GetEntity(opelesn.TeachBookId.Value);// ("{\"TeachBookId\":\"" + opelesn.TeachBookId.Value+"\"}");
                    if (tbInfoModel != null)
                    {
                        catb.TeachBook = tbInfoModel.TeachBook;
                        catb.PubCompany = tbInfoModel.PubCompany;
                        catb.ISBN = tbInfoModel.ISBN;
                        catb.Author = tbInfoModel.Author;
                    }
                }
                clsAndTbInfoList.Add(catb);
            }


            var jsonData = new
            {
                rows = clsAndTbInfoList,// data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var data = openlessonplanbll.GetList(queryJson);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = openlessonplanbll.GetEntity(keyValue);
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
            openlessonplanbll.RemoveForm(keyValue);
            return Success("删除成功。");
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
        public ActionResult SaveForm(string keyValue, OpenLessonPlanEntity entity)
        {
            openlessonplanbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion


    }
}
