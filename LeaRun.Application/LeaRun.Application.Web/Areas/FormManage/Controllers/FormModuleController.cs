using LeaRun.Application.Busines.FlowManage;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.FlowManage;

using LeaRun.Application.Entity.FormManage;
using LeaRun.Application.Busines.FormManage;

using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using LeaRun.Application.Cache;
using LeaRun.Application.Entity.SystemManage.ViewModel;
using LeaRun.Application.Entity.AuthorizeManage;

namespace LeaRun.Application.Web.Areas.FormManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创建人：L&B
    /// 日 期：2015.11.02 14:27
    /// 描 述：表单管理
    /// </summary>
    public class FormModuleController : MvcControllerBase
    {
       // private WFFrmMainBLL wfFrmMainBLL = new WFFrmMainBLL();
        private Form_ModuleBLL frmModulBLL = new Form_ModuleBLL();
        private Form_ModuleRelationBLL formmodulerelationbll = new Form_ModuleRelationBLL();
        private Form_ModuleContentBLL formcontentbll = new Form_ModuleContentBLL();
        private Form_ModuleInstanceBLL instancebll = new Form_ModuleInstanceBLL();
        #region 视图功能
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
        /// 设计器
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ManageIndex()
        {
            return View();

        }

        /// <summary>
        /// 设计器
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FormLayout()
        {
            return View();
        }
        /// <summary>
        /// 预览表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FormPreview()
        {
            return View();
        }
        /// <summary>
        /// 创建表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FormBuider()
        {
            return View();
        }
        /// <summary>
        /// 表单关联
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FormReleaseer()
        {
            return View();
        }

        /// <summary>
        /// 表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FlowSchemeDesigner()
        {
            return View();
        }

        /// <summary>
        /// 节点编辑器
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FlowNodeForm()
        {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 表单列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = frmModulBLL.GetPageList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(JsonData.ToJson());
        }
        
        /// <summary>
        /// 获取表单数据all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllListJson()
        {
            var data = frmModulBLL.GetAllList();// wfFrmMainBLL.GetAllList();
            return Content(data.ToJson());
        }
        /// <summary>
        /// 表单树 
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson_old()
        {
            var data = frmModulBLL.GetAllList();// wfFrmMainBLL.GetAllList();
            var treeList = new List<TreeEntity>();
            string FrmType = "";
            foreach (DataRow item in data.Rows)
            {
                TreeEntity tree = new TreeEntity();
                if (FrmType != item["FrmType"].ToString())
                {
                    TreeEntity tree1 = new TreeEntity();
                    FrmType = item["FrmType"].ToString();
                    tree1.id = FrmType;
                    tree1.text = item["FrmTypeName"].ToString();
                    tree1.value = FrmType;
                    tree1.isexpand = true;
                    tree1.complete = true;
                    tree1.hasChildren = true;
                    tree1.parentId = "0";
                    tree1.img = "fa fa-list-alt";
                    tree1.Attribute = "Sort";
                    tree1.AttributeValue = "FrmType";
                    treeList.Add(tree1);
                }
                tree.id = item["FrmMainId"].ToString();
                tree.text = item["FrmName"].ToString();
                tree.value = item["FrmMainId"].ToString();
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = false;
                tree.parentId = FrmType;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Frm";
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 表单树 
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetFormTreeJson()
        {
            var data = frmModulBLL.GetAllList();
            var treeList = new List<TreeEntity>();
            string FrmType = "";
            foreach (DataRow item in data.Rows)
            {
                TreeEntity tree = new TreeEntity();
                if (FrmType != item["FrmCategory"].ToString())
                {
                    TreeEntity tree1 = new TreeEntity();
                    FrmType = item["FrmCategory"].ToString();
                    tree1.id = FrmType;
                    tree1.text = item["FrmTypeName"].ToString();
                    tree1.value = FrmType;
                    tree1.isexpand = true;
                    tree1.complete = true;
                    tree1.hasChildren = true;
                    tree1.parentId = "0";
                    tree1.img = "fa fa-list-alt";
                    tree1.Attribute = "Sort";
                    tree1.AttributeValue = "FrmType";
                    treeList.Add(tree1);
                }
                tree.id = item["FrmId"].ToString();
                tree.text = item["FrmName"].ToString();
                tree.value = item["FrmId"].ToString();
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = false;
                tree.parentId = FrmType;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Frm";
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }
        public ActionResult GetTreeJson(string queryJson)
        {
            DataItemCache dataItemCache = new DataItemCache();
            var formModuleData = frmModulBLL.GetList();
            var data = dataItemCache.GetDataItemList("FormSort");
            var treeList = new List<TreeEntity>();
            foreach (DataItemModel item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = true;//此处做下判断
                tree.id = item.ItemDetailId;
                tree.text = item.ItemName;
                tree.value = item.ItemValue;
                tree.parentId = item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                tree.AttributeValue = "formCategory";
                treeList.Add(tree);
            }
            foreach (Form_ModuleEntity item in formModuleData)
            {
                #region 部门
                TreeEntity tree = new TreeEntity();
                bool hasChildren = false;
                tree.id = item.FrmId;
                tree.text = item.FrmName;
                tree.value = item.FrmId;

                tree.parentId = item.FrmCategory;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                tree.AttributeValue = "form";
                tree.AttributeA = "version";
                tree.AttributeValueA = item.Version;
                treeList.Add(tree);
                #endregion
            }
            //if (!string.IsNullOrEmpty(queryJson))
            //{
            //    treeList = treeList.TreeWhere(t => t.text.Contains(keyword), "id", "parentId");
            //}
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetEntityJson(string keyValue)
        {
            var data = frmModulBLL.GetEntity(keyValue);
            return ToJsonResult(data);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除表单模板
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            frmModulBLL.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存用户表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userEntity">用户实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, Form_ModuleEntity userEntity)
        {
            frmModulBLL.SaveForm(keyValue, userEntity);
            return Success("操作成功。");
        }
        /// <summary>
        /// （启用、禁用）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="flag">状态：1-启动；0-禁用</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult EnableOrDisableForm(string keyValue, int flag)
        {
            frmModulBLL.UpdateState(keyValue, flag);
            return Success("操作成功。");
        }

        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="baseInfo">实体对象</param>
        /// <param name="moduleInfo">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveRelationForm(string keyValue, string baseInfo, string moduleInfo)
        {
            Form_ModuleRelationEntity entity = baseInfo.ToObject<Form_ModuleRelationEntity>();
            ModuleEntity module = null;
            if (entity.FrmKind == 0)
            {
                module = moduleInfo.ToObject<ModuleEntity>();
                entity.ObjectName = module.FullName;
            }

            formmodulerelationbll.SaveForm(keyValue, entity, module);
            return Success("操作成功。");
        }



        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="folderId">文件夹Id</param>
        /// <param name="Filedata">文件对象</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadifyFile(string folderId, HttpPostedFileBase Filedata)
        {
            try
            {
                if (string.IsNullOrEmpty(folderId))
                {
                    return Success("虚拟上传文件成功。");
                }

                Thread.Sleep(500);////延迟500毫秒
                //没有文件上传，直接返回
                if (Filedata == null || string.IsNullOrEmpty(Filedata.FileName) || Filedata.ContentLength == 0)
                {
                    return HttpNotFound();
                }
                //获取文件完整文件名(包含绝对路径)
                //文件存放路径格式：/Resource/ResourceFile/{userId}{data}/{guid}.{后缀名}
                string userId = OperatorProvider.Provider.Current().UserId;
                string fileGuid = Guid.NewGuid().ToString();
                long filesize = Filedata.ContentLength;
                string FileEextension = Path.GetExtension(Filedata.FileName);
                string uploadDate = DateTime.Now.ToString("yyyyMMdd");
                string virtualPath = string.Format("~/Resource/DocumentFile/{0}/{1}/{2}{3}", userId, uploadDate, fileGuid, FileEextension);
                string fullFileName = this.Server.MapPath(virtualPath);
                //创建文件夹
                string path = Path.GetDirectoryName(fullFileName);
                Directory.CreateDirectory(path);
                if (!System.IO.File.Exists(fullFileName))
                {
                    //保存文件
                    Filedata.SaveAs(fullFileName);
                }
                return Success("上传成功。");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion
    }
}
