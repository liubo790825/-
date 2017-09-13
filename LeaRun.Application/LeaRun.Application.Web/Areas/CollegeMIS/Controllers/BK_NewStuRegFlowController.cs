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
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-07-19 16:28
    /// �� ���������������̱�
    /// </summary>
    public class BK_NewStuRegFlowController : MvcControllerBase
    {
        private BK_NewStuRegFlowBLL bk_newsturegflowbll = new BK_NewStuRegFlowBLL();
        private BK_AuthorizeNewStuRegFlowBLL authorbll = new BK_AuthorizeNewStuRegFlowBLL();
        private UserBLL userBLL = new UserBLL();
        private OrganizeCache organizeCache = new OrganizeCache();
        private DepartmentBLL departmentBLL = new DepartmentBLL();
        private DepartmentCache departmentCache = new DepartmentCache();
        

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        /// <summary>
        /// ��Ȩҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AuthorForm()
        {
            return View();
        }

        #endregion

        #region ��ȡ����

        /// <summary>
        /// �û��б�
        /// </summary>
        /// <param name="flowId">����Id</param>
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
        /// �����б� 
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <param name="keyword">�ؼ���</param>
        /// <returns>���������б�Json</returns>
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
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
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
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var data = bk_newsturegflowbll.GetList(queryJson);
            return ToJsonResult(data);
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = bk_newsturegflowbll.GetEntity(keyValue);
            return ToJsonResult(data);
        }

        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            bk_newsturegflowbll.RemoveForm(keyValue);
            return Success("ɾ���ɹ���");
        }

        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
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
                    msg = "���óɹ�";
                }
                if (enabledMark.Equals("off"))
                {
                    flow.EnabledMark = 0;
                    msg = "ͣ�óɹ�";
                }
                bk_newsturegflowbll.SaveForm(keyValue, flow);
                return Success(msg);
            }
            return Error("���ò���Ϊ��");
        }

        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
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
            return Success("�����ɹ���");
        }


       /// <summary>
       /// ��������������޸ģ�
       /// </summary>
       /// <param name="keyValue">����ֵ</param>
      /// <param name="entity">ʵ�����</param>
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
            return Success("�����ɹ���");
        }
        #endregion
    }
}
