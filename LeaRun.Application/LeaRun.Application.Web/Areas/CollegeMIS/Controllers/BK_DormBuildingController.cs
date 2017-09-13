using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.Busines.CollegeMIS;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.CollegeMIS.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 16:41
    /// �� ��������¥��Ϣ
    /// </summary>
    public class BK_DormBuildingController : MvcControllerBase
    {
        private BK_DormBuildingBLL bk_dormbuildingbll = new BK_DormBuildingBLL();

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
        public ActionResult Form_old()
        {
            return View();
        }


        #endregion

        #region ��ȡ����

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var data = bk_dormbuildingbll.GetPageList(null,queryJson);
            var temp = ToJsonResult(data);
            return temp;
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
            var data = bk_dormbuildingbll.GetPageList(pagination, queryJson);
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
            var data = bk_dormbuildingbll.GetEntity(keyValue);
            var childData = bk_dormbuildingbll.GetDetails(keyValue);
            var jsonData = new
            {
                entity = data,
                childEntity = childData
            };
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetDetailsJson(string keyValue)
        {
            var data = bk_dormbuildingbll.GetDetails(keyValue);
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
            bk_dormbuildingbll.RemoveForm(keyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ� 
       /// [ValidateAntiForgeryToken]
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [ValidateInput(false)]
        public ActionResult SaveForm(string keyValue, string strEntity,string strChildEntitys)
        {
            var entity = strEntity.ToObject<BK_DormBuildingEntity>();
            var childEntitys = strChildEntitys.ToList<BK_DormUnitEntity>();
                bk_dormbuildingbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
