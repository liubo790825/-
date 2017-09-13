using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.Busines.CollegeMIS;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Web.Mvc;
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using LeaRun.Application.Cache;
using LeaRun.Application.Busines.BaseManage;
using LeaRun.Application.Entity.BaseManage;

namespace LeaRun.Application.Web.Areas.CollegeMIS.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-07-19 16:28
    /// 描 述：新生报到流程表
    /// </summary>
    public class BK_NewStuRegFlowController : MvcControllerBase
    {
        private BK_NewStuRegFlowBLL bk_newsturegflowbll = new BK_NewStuRegFlowBLL();
        private BK_AuthorizeNewStuRegFlowBLL authorbll = new BK_AuthorizeNewStuRegFlowBLL();
        private UserBLL userBLL = new UserBLL();
        private OrganizeCache organizeCache = new OrganizeCache();
        private DepartmentBLL departmentBLL = new DepartmentBLL();
        private DepartmentCache departmentCache = new DepartmentCache();
        

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
        /// 授权页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AuthorForm()
        {
            return View();
        }

        #endregion

        #region 获取数据

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="flowId">流程Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUserListJson(string flowId)
        {
            var existMember = bk_newsturegflowbll.GetDetails(flowId);
            var userdata = userBLL.GetTable();
            userdata.Columns.Add("ischeck", Type.GetType("System.Int32"));
            userdata.Columns.Add("isdefault", Type.GetType("System.Int32"));
            foreach (DataRow item in userdata.Rows)
            {
                string UserId = item["userid"].ToString();
                int ischeck = existMember.Count(t => t.UserId == UserId);
                item["ischeck"] = ischeck;
                if (ischeck > 0)
                {
                    item["isdefault"] = 1;
                }
                else
                {
                    item["isdefault"] = 0;
                }
            }
            userdata = DataHelper.DataFilter(userdata, "", "ischeck desc");
            return Content(userdata.ToJson());
        }

        /// <summary>
        /// 部门列表 
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetDeptTreeListJson()
        {
            var organizedata = organizeCache.GetList();
            var departmentdata = departmentBLL.GetList().ToList();
            var treeList = new List<TreeEntity>();
            foreach (OrganizeEntity item in organizedata)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = organizedata.Count(t => t.ParentId == item.OrganizeId) == 0 ? false : true;
                if (hasChildren == false)
                {
                    hasChildren = departmentdata.Count(t => t.OrganizeId == item.OrganizeId) == 0 ? false : true;
                    if (hasChildren == false)
                    {
                        continue;
                    }
                }
                tree.id = item.OrganizeId;
                tree.text = item.FullName;
                tree.value = item.OrganizeId;
                tree.hasChildren = hasChildren;
                tree.parentId = item.ParentId;
                tree.isexpand = true;
                tree.complete = false;
                treeList.Add(tree);
            }
            foreach (DepartmentEntity item in departmentdata)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = organizedata.Count(t => t.ParentId == item.DepartmentId) == 0 ? false : true;
                tree.id = item.DepartmentId;
                tree.text = item.FullName;
                tree.value = item.DepartmentId;

                if (item.ParentId == "0")
                {
                    tree.parentId = item.OrganizeId;
                }
                else
                {
                    tree.parentId = item.ParentId;
                }
                tree.hasChildren = hasChildren;
                tree.complete = true;
                tree.isexpand = true;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }


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
            var data = bk_newsturegflowbll.GetPageList(pagination, queryJson);
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
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var data = bk_newsturegflowbll.GetList(queryJson);
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
            var data = bk_newsturegflowbll.GetEntity(keyValue);
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
            bk_newsturegflowbll.RemoveForm(keyValue);
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
        public ActionResult SaveChange(string keyValue, string enabledMark)
        {
            BK_NewStuRegFlowEntity flow= bk_newsturegflowbll.GetEntity(keyValue);
            if (!string.IsNullOrEmpty(enabledMark))
            {
                string msg = "";
                if (enabledMark.Equals("on"))
                {
                    flow.EnabledMark = 1;
                    msg = "启用成功";
                }
                if (enabledMark.Equals("off"))
                {
                    flow.EnabledMark = 0;
                    msg = "停用成功";
                }
                bk_newsturegflowbll.SaveForm(keyValue, flow);
                return Success(msg);
            }
            return Error("启用不能为空");
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
        public ActionResult SaveForm(string keyValue, BK_NewStuRegFlowEntity entity)
        {
            if (entity.IsSort==null)
            {
                entity.IsSort = 0;
            }
            if (entity.SortCode == null)
            {
                entity.SortCode = 1;
            }
            bk_newsturegflowbll.SaveForm(keyValue, entity);
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
        public ActionResult SaveAuthor(string flowid, string userIds)
        {
            List<BK_AuthorizeNewStuRegFlowEntity> authorlist = new List<BK_AuthorizeNewStuRegFlowEntity>();
            if (!string.IsNullOrEmpty(flowid) && !string.IsNullOrEmpty(userIds))
            {
                string[] useridlist = userIds.Split(',');
                foreach (var userid in useridlist)
                {
                    BK_AuthorizeNewStuRegFlowEntity authFlow = new BK_AuthorizeNewStuRegFlowEntity();
                    authFlow.FlowId = flowid;
                    authFlow.UserId = userid;
                    authorlist.Add(authFlow);
                }
            }
            bk_newsturegflowbll.SaveChildList(flowid, authorlist);
            return Success("操作成功。");
        }
        #endregion
    }
}
