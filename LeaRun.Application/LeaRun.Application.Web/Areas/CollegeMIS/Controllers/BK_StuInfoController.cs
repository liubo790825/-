using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.Busines.CollegeMIS;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using LeaRun.Util.Extension;
using LeaRun.Application.Code;

namespace LeaRun.Application.Web.Areas.CollegeMIS.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-06 09:47
    /// �� �����������ݵ���      ����ȷ�Ϻ��ѧ�����ݵ��뵽�˱���      ͬʱ�ְࣨ�����ţ� ��ѧ��
    /// </summary>
    public class BK_StuInfoController : MvcControllerBase
    {
        private BK_StuInfoBLL bk_stuinfobll = new BK_StuInfoBLL();

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
        /// ���������б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BDIndex()
        {
            return View();
        }

        /// <summary>
        /// ��ӡ֪ͨ���б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PNoticeIndex()
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
        /// ��ӡѧ��֪ͨ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PrintForm()
        {
            return View();
        }
        /// <summary>
        /// ѧ���ִ�λ
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BedForm()
        {
            return View();
        }
        /// <summary>
        /// ��������ͳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult NewStuRegCountForMajorIndex()
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
            var data = bk_stuinfobll.GetPageList(pagination, queryJson);
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
        /// ��ȡһ��ʱ���ڵ����������б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public ActionResult GetStuCountList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bk_stuinfobll.GetNewStuCountPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            var temp = ToJsonResult(jsonData);
            return temp;
        }

        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = bk_stuinfobll.GetEntity(keyValue);
            var childData = bk_stuinfobll.GetDetails(keyValue);
            var jsonData = new
            {
                entity = data,
                childEntity = childData
            };
            return ToJsonResult(jsonData);
        }

        /// <summary>
        /// ��ȡʵ�� 
        /// ֻ��ȡѧ����Ϣ����
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetFormJson2(string keyValue)
        {
            var data = bk_stuinfobll.GetEntity(keyValue);            
            return ToJsonResult(data);
        }

        /// <summary>
        /// ��ȡʵ�� 
        /// ֻ��ȡѧ����Ϣ����
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetFormJsonByWhere(string queryJson)
        {
            var data = bk_stuinfobll.GetEntityByWhere(queryJson);
            return ToJsonResult(data);
        }

        /// <summary>
        /// ��ȡʵ�� 
        /// ֻ��ȡѧ����Ϣ����
        /// </summary>
        /// <param name="queryJson">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetEntityList(string queryJson)
        {
            var data = bk_stuinfobll.GetTablePageList(null, queryJson).Rows;//.GetList(queryJson);
            var temp = ToJsonResult(data);
            return temp;
        }


        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetDetailsJson(string keyValue)
        {
            var data = bk_stuinfobll.GetDetails(keyValue);
            return ToJsonResult(data);
        }

        /// <summary>
        /// ��ȡѧ����ϸ��Ϣ 
        /// </summary>
        /// <param name="stuids">ѧ��ID��</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetStuInfoListByStuIds(string stuids)
        {
            string[] stuidlist = stuids.Split(',');
            List<BK_StuInfoEntity> stulist = new List<BK_StuInfoEntity>();
            string uname = OperatorProvider.Provider.Current().UserName;
            foreach (var stuid in stuidlist)
            {
                var stuinfo = bk_stuinfobll.GetEntity(stuid);
                if (stuinfo!=null)
                {
                    if (stuinfo.PrintNotice != null)
                    {
                        stuinfo.PrintNotice += 1;
                    }
                    else
                    {
                        stuinfo.PrintNotice = 1;
                    }

                    stuinfo.LastPrintTime = DateTime.Now;
                    stuinfo.WhoPrint = uname;
                    bk_stuinfobll.SaveForm(stuinfo.stuInfoId, stuinfo, null);//�޸�֪ͨ���ӡ����Ϣ

                    stulist.Add(stuinfo);
                }
            }
            return ToJsonResult(stulist);
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
            bk_stuinfobll.RemoveForm(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity,string strChildEntitys)
        {
            strEntity = strEntity.Replace("&nbsp;", "");
            var entity = strEntity.ToObject<BK_StuInfoEntity>(); //
            if (string.IsNullOrEmpty(keyValue))
            {//��ʾΪ������ݣ��������ʱҪ���Ĭ������
                entity.StuOther = "δ�ְ�"; //�ְ��־
                entity.GuiDangMark = "δ�鵵";//ֻ��������û�й鵵
                entity.TransMark = "0";//ֻ��������û�й鵵
                if (!string.IsNullOrEmpty(entity.IdentityCardNo))
                {
                    string pwd = entity.IdentityCardNo.Substring(12);
                    entity.StuPwd = Md5Helper.MD5(pwd, 16);//����ѧ��Ĭ�����룬����Ϊ���֤�����6λ
                }
            }
            var childEntitys = strChildEntitys.ToList<BK_StuSocRelaEntity>();
            bk_stuinfobll.SaveForm(keyValue, entity, childEntitys);
            return Success("�����ɹ���");
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="keyValue">����ID��</param>
        /// <returns></returns>
        public ActionResult NewStuBaodao(string keyValue)
        {
            var student = bk_stuinfobll.GetEntity(keyValue);
            if (student!=null && student.NewStuReport==0)
            {
                student.NewStuReport = 1;
                student.GuiDangMark = "�ѹ鵵";
                student.TransMark = "1";//��ʾ�鵵
                student.NewStuReportDatetime = DateTime.Now;
                bk_stuinfobll.SaveForm(keyValue, student, null);
            }
            else
            {
                return Error("����ʧ�ܡ�");
            }

            return Success("�����ɹ���");
        }
            
        #endregion
    }
}
