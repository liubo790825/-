using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.Busines.CollegeMIS;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Web.Mvc;
using System.Collections.Generic;

namespace LeaRun.Application.Web.Areas.CollegeMIS.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-07 16:20
    /// �� ����ѧ���ۺ����ʼ�¼��
    /// </summary>
    public class BK_StuQualityScoreController : MvcControllerBase
    {
        private BK_StuQualityScoreBLL bk_stuqualityscorebll = new BK_StuQualityScoreBLL();
        private BK_StuQSBLL qsbll = new BK_StuQSBLL();

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
            //var data = bk_stuqualityscorebll.GetPageListByDataSet(pagination, queryJson).Rows;
            var data = qsbll.GetPageList(pagination, queryJson);
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
            var data = bk_stuqualityscorebll.GetList(queryJson);
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
            var data = bk_stuqualityscorebll.GetEntity(keyValue);
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
            bk_stuqualityscorebll.RemoveForm(keyValue);
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
        public ActionResult SaveForm(string keyValue, BK_StuQualityScoreEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {//���KEYVALUEΪ�յ�����¾�Ҫȥ��ѯ���Ƿ��ظ���ͬһ�������ظ�
                BK_StuQualityScoreEntity oldModel = bk_stuqualityscorebll.GetEntity(new {StuId=entity.StuId, QualityId =entity.QualityId}.ToJson());
                if (oldModel!=null)
                {
                    return Error("�ⳡѧ��ר���Ѿ��ǹ��ˣ�����ʧ�ܡ�");
                }
            }

            bk_stuqualityscorebll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
