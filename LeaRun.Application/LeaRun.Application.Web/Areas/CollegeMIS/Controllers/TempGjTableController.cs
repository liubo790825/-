using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.Busines.CollegeMIS;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Web.Mvc;
using System.Collections.Generic;

namespace LeaRun.Application.Web.Areas.CollegeMIS.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-11-28 15:57
    /// 描 述：TempGjTable
    /// </summary>

    public class resultData
    {
        /// <summary>
        /// 专业名称
        /// </summary>
        public string MajorName { get; set; }
        /// <summary>
        /// 专业代码
        /// </summary>
        public string MajorNo { get; set; }//

        /// <summary>
        /// 毕业生人数
        /// </summary>
        public int outStuCount { get; set; }//

        /// <summary>
        /// 计划招生数
        /// </summary>                                 
        public int newStuCount { get; set; }//

        /// <summary>
        /// 合计在校生人数
        /// </summary>
        public int StuCountTotal { get; set; }//

        /// <summary>
        /// 1年级人数
        /// </summary>
        public int StuCount1 { get; set; }//

        /// <summary>
        /// 2年级人数
        /// </summary>
        public int StuCount2 { get; set; }//

        /// <summary>
        /// 3年级人数
        /// </summary>
        public int StuCount3 { get; set; }//

        /// <summary>
        /// 4年级以上人数
        /// </summary>
        public int StuCount4 { get; set; }//
    }
    public class TempGjTableController : MvcControllerBase
    {
        private TempGjTableBLL tempgjtablebll = new TempGjTableBLL();

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
            //var data = tempgjtablebll.GetList(queryJson);
            var data = tempgjtablebll.GetPageList(pagination, queryJson);
            List<resultData> resultList = new List<resultData>();

            foreach (var item in data)
            {
                bool flag = false;
                foreach (var rec in resultList)
                {
                    if (rec.MajorNo.Equals(item.MajorNo))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    continue;
                }

                resultData rs = new resultData();
                rs.MajorName = item.MajorName;
                rs.MajorNo = item.MajorNo;
                int newStuCount = 0;//招收新人的数
                int outStuCount = 0;//毕业人数
                int StuCountTotal = 0;
                int StuCount1 = 0;
                int StuCount2 = 0;
                int StuCount3 = 0;
                int StuCount4 = 0;
                foreach (var sec in data)
                {                    
                    if (sec.MajorNo.Equals(item.MajorNo))
                    {
                        if (sec.Grade.Equals("stunew")) //新生数量
                        {
                            newStuCount += sec.StuCount!=null? sec.StuCount.Value:0;//记录新生数量
                        }
                        if (sec.Grade.Equals("outSchool"))//毕业人数量
                        {
                            outStuCount+= sec.StuCount != null ? sec.StuCount.Value : 0;
                        }
                        if (sec.Grade.Equals("1"))
                        {
                            StuCount1+= sec.StuCount != null ? sec.StuCount.Value : 0;
                            StuCountTotal += sec.StuCount != null ? sec.StuCount.Value : 0;//总人数
                        }
                        if (sec.Grade.Equals("2"))
                        {
                            StuCount2 += sec.StuCount != null ? sec.StuCount.Value : 0;
                            StuCountTotal += sec.StuCount != null ? sec.StuCount.Value : 0;//总人数
                        }
                        if (sec.Grade.Equals("3"))
                        {
                            StuCount3 += sec.StuCount != null ? sec.StuCount.Value : 0;
                            StuCountTotal += sec.StuCount != null ? sec.StuCount.Value : 0;//总人数
                        }
                        if (!sec.Grade.Equals("stunew") && !sec.Grade.Equals("outSchool") && !sec.Grade.Equals("1") && !sec.Grade.Equals("2") && !sec.Grade.Equals("3"))
                        {
                            StuCount4 += sec.StuCount != null ? sec.StuCount.Value : 0;
                            StuCountTotal += sec.StuCount != null ? sec.StuCount.Value : 0;//总人数
                        }
                    }
                }
                rs.newStuCount = newStuCount;
                rs.outStuCount = outStuCount;
                rs.StuCountTotal = StuCountTotal;
                rs.StuCount4 = StuCount4;
                rs.StuCount3 = StuCount3;
                rs.StuCount2 = StuCount2;
                rs.StuCount1 = StuCount1;
                resultList.Add(rs);
            }



            var jsonData = new
            {
                rows = resultList,
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
            var data = tempgjtablebll.GetList(queryJson);
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
            var data = tempgjtablebll.GetEntity(keyValue);
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
            tempgjtablebll.RemoveForm(keyValue);
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
        public ActionResult SaveForm(string keyValue, TempGjTableEntity entity)
        {
            tempgjtablebll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
