using LeaRun.Application.Entity.SystemManage;
using LeaRun.Application.Busines.SystemManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.SystemManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-12 11:00
    /// �� �������ݵ���
    /// </summary>
    public class ExcelImportController : MvcControllerBase
    {
        private ExcelImportBLL excelimportbll = new ExcelImportBLL();
        private Busines.AuthorizeManage.ModuleButtonBLL btnbll = new Busines.AuthorizeManage.ModuleButtonBLL();
        //private excelimportbll excelimportbll = new excelimportbll();

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
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SetFieldForm()
        {
            return View();
        }
        

        #endregion

        #region ��ȡ����
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
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
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
                var btnentity = btnbll.GetEntity(model.F_ModuleBtnId);//�õ���ť������
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
        /// ��ȡ�ӱ���ϸ��Ϣ 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetDetailsJson(string keyValue)
        {
            var data = excelimportbll.GetDetails(keyValue);
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
            excelimportbll.RemoveForm(keyValue);
            return Success("ɾ���ɹ���");
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
        public ActionResult SaveForm(string keyValue, string strEntity,string strChildEntitys)
        {
            var entity = strEntity.ToObject<ExcelImportEntity>();
            var childEntitys = strChildEntitys.ToList<ExcelImportFiledEntity>();
            excelimportbll.SaveForm(keyValue, entity, childEntitys);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
