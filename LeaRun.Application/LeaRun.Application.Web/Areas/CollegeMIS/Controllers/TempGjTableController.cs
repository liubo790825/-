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
    /// �� �ڣ�2016-11-28 15:57
    /// �� ����TempGjTable
    /// </summary>

    public class resultData
    {
        /// <summary>
        /// רҵ����
        /// </summary>
        public string MajorName { get; set; }
        /// <summary>
        /// רҵ����
        /// </summary>
        public string MajorNo { get; set; }//

        /// <summary>
        /// ��ҵ������
        /// </summary>
        public int outStuCount { get; set; }//

        /// <summary>
        /// �ƻ�������
        /// </summary>                                 
        public int newStuCount { get; set; }//

        /// <summary>
        /// �ϼ���У������
        /// </summary>
        public int StuCountTotal { get; set; }//

        /// <summary>
        /// 1�꼶����
        /// </summary>
        public int StuCount1 { get; set; }//

        /// <summary>
        /// 2�꼶����
        /// </summary>
        public int StuCount2 { get; set; }//

        /// <summary>
        /// 3�꼶����
        /// </summary>
        public int StuCount3 { get; set; }//

        /// <summary>
        /// 4�꼶��������
        /// </summary>
        public int StuCount4 { get; set; }//
    }
    public class TempGjTableController : MvcControllerBase
    {
        private TempGjTableBLL tempgjtablebll = new TempGjTableBLL();

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
                int newStuCount = 0;//�������˵���
                int outStuCount = 0;//��ҵ����
                int StuCountTotal = 0;
                int StuCount1 = 0;
                int StuCount2 = 0;
                int StuCount3 = 0;
                int StuCount4 = 0;
                foreach (var sec in data)
                {                    
                    if (sec.MajorNo.Equals(item.MajorNo))
                    {
                        if (sec.Grade.Equals("stunew")) //��������
                        {
                            newStuCount += sec.StuCount!=null? sec.StuCount.Value:0;//��¼��������
                        }
                        if (sec.Grade.Equals("outSchool"))//��ҵ������
                        {
                            outStuCount+= sec.StuCount != null ? sec.StuCount.Value : 0;
                        }
                        if (sec.Grade.Equals("1"))
                        {
                            StuCount1+= sec.StuCount != null ? sec.StuCount.Value : 0;
                            StuCountTotal += sec.StuCount != null ? sec.StuCount.Value : 0;//������
                        }
                        if (sec.Grade.Equals("2"))
                        {
                            StuCount2 += sec.StuCount != null ? sec.StuCount.Value : 0;
                            StuCountTotal += sec.StuCount != null ? sec.StuCount.Value : 0;//������
                        }
                        if (sec.Grade.Equals("3"))
                        {
                            StuCount3 += sec.StuCount != null ? sec.StuCount.Value : 0;
                            StuCountTotal += sec.StuCount != null ? sec.StuCount.Value : 0;//������
                        }
                        if (!sec.Grade.Equals("stunew") && !sec.Grade.Equals("outSchool") && !sec.Grade.Equals("1") && !sec.Grade.Equals("2") && !sec.Grade.Equals("3"))
                        {
                            StuCount4 += sec.StuCount != null ? sec.StuCount.Value : 0;
                            StuCountTotal += sec.StuCount != null ? sec.StuCount.Value : 0;//������
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
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tempgjtablebll.GetList(queryJson);
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
            var data = tempgjtablebll.GetEntity(keyValue);
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
            tempgjtablebll.RemoveForm(keyValue);
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
        public ActionResult SaveForm(string keyValue, TempGjTableEntity entity)
        {
            tempgjtablebll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
