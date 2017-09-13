using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.Busines.CollegeMIS;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Web.Mvc;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System;

namespace LeaRun.Application.Web.Areas.CollegeMIS.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 15:59
    /// �� ������λ��Ϣ
    /// </summary>
    public class BK_DormBedController : MvcControllerBase
    {
        private BK_DormBedBLL bk_dormbedbll = new BK_DormBedBLL();
        private BK_DormBLL dormbll = new BK_DormBLL();
        private BK_StuBedDwellBLL dwellbll = new BK_StuBedDwellBLL();


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
        /// ��λ����ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SwapBedIndex()
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
            var data = bk_dormbedbll.GetPageList(pagination, queryJson);
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
            var data = bk_dormbedbll.GetList(queryJson);
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
            var data = bk_dormbedbll.GetEntity(keyValue);
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
            bk_dormbedbll.RemoveForm(keyValue);
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
        public ActionResult SaveForm(string keyValue, BK_DormBedEntity entity)
        {
            bk_dormbedbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        /// <summary>
        /// ����ѧ����ס
        /// </summary>
        /// <param name="strEntity"></param>
        /// <returns></returns>
        public ActionResult SaveStuToBed(string strEntity)
        {
            string bedids = "";//��λID��
            string stuinfoid = "";//ѧ��ID��
            var queryParam = strEntity.ToJObject();
            try
            {
                if (!queryParam["bedIds"].IsEmpty())
                {
                    bedids = queryParam["bedIds"].ToString();
                }
                if (!queryParam["stuinfoid"].IsEmpty())
                {
                    stuinfoid = queryParam["stuinfoid"].ToString();
                }
                BK_StuInfoBLL sbll = new BK_StuInfoBLL();
                BK_DormBLL dbll = new BK_DormBLL();
               
                lock (this)
                {
                    BK_StuInfoEntity student = sbll.GetEntity(stuinfoid);
                    List< BK_DormBedEntity> studormlist= bk_dormbedbll.GetList(new { StuId = stuinfoid }.ToJson());
                    if (studormlist.Count==0)
                    {
                    List<BK_DormBedEntity> bedlist = new List<BK_DormBedEntity>();
                    BK_DormBedEntity bedentity = bk_dormbedbll.GetEntity(bedids);
                    if (bedentity.IsUsed == 0) //ֻ����û��ʹ�õ�����²�����ס
                    {
                        bedentity.IsUsed = 1;
                        bedentity.StuId = stuinfoid;
                        bedentity.StuName = student.StuName;

                        BK_DormEntity dorm = dbll.GetEntity(bedentity.DormId);
                        dorm.UsedBeds += 1;//�޸���ʹ�ô�λ����
                        dorm.NotUseBeds -= 1;//�޸�δʹ�ô�λ����

                        string queryjson = new { StuId = stuinfoid, BedId = bedids }.ToJson();
                        BK_StuBedDwellEntity beddwell = dwellbll.GetEntityByWhere(queryjson);//��ѯ�Ƿ��Ѿ���ס�ˣ����û����ס��������ס
                        if (beddwell == null)
                        {
                            beddwell = new BK_StuBedDwellEntity();
                            beddwell.StuId = stuinfoid;
                            beddwell.BedId = bedids;
                        }
                        beddwell.EnterDate = DateTime.Now;
                        beddwell.EnterRemark = "������ס";

                        dwellbll.SaveForm(beddwell.ID, beddwell);
                        bedlist.Add(bedentity);
                        dbll.SaveForm(dorm.DormId, dorm, bedlist);
                    }
                    }
                    else
                    {
                        return Error("��ѧ���Ѿ�ѡ��������λ�������ٴ�ѡ��λ��");
                    }
                }
            }
            catch (System.Exception ex)
            {

                return Error("��סʧ�ܣ�");
            }
            return Success("��ס�ɹ���");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromBeds">Ҫ�����Ĵ�λID��</param>
        /// <param name="targetBeds">Ŀ�괲λID��</param>
        /// <returns></returns>
        public ActionResult ChangeBeds(string fromBeds, string targetBeds)
        {
            List<BK_DormBedEntity> fromBedList = new List<BK_DormBedEntity>();//Ҫ������λ�Ĵ�λ����
            List<BK_DormBedEntity> targetBedList = new List<BK_DormBedEntity>();//Ŀ�괲λ����
            if (!string.IsNullOrEmpty(fromBeds) && !string.IsNullOrEmpty(targetBeds))
            {
                string[] fbedids = fromBeds.Split(',');
                string[] tbedids = targetBeds.Split(',');

                foreach (var bedid in fbedids)
                {
                    fromBedList.Add(bk_dormbedbll.GetEntity(bedid));
                }
                foreach (var bedid in tbedids)
                {
                    targetBedList.Add(bk_dormbedbll.GetEntity(bedid));
                }

                try
                {
                    for (int i = 0; i < fromBedList.Count; i++)
                    {
                        List<BK_DormBedEntity> modirybedList = new List<BK_DormBedEntity>();
                        BK_DormBedEntity frombed = fromBedList[i];//Ҫ������ѧ����λ
                        BK_DormBedEntity targetbed = targetBedList[i];//Ŀ�괲λ

                        
                        int tempIsUsed = frombed.IsUsed;//��ʾΪ��ʹ��    
                        int tempIsDistribute= frombed.IsDistribute;
                        string tempIsDwell = frombed.IsDwell;
                        string tempMajorDetailId = frombed.MajorDetailId;
                        string tempMajorId = frombed.MajorId;
                        string tempStuId  = frombed.StuId;
                        string tempStuName = frombed.StuName;
                        string tempClassInfoId = frombed.ClassInfoId;


                        //��ʼ��������

                        #region �޸�ԭ��λ��Ϣ
                        //�ȸı�frombed����
                        frombed.IsUsed = targetbed.IsUsed;//��ʾΪ��ʹ��    
                        frombed.IsDistribute = targetbed.IsDistribute;
                        frombed.IsDwell = targetbed.IsDwell;
                        frombed.MajorDetailId = targetbed.MajorDetailId;
                        frombed.MajorId = targetbed.MajorId;
                        frombed.StuId = targetbed.StuId;
                        frombed.StuName = targetbed.StuName;
                        frombed.ClassInfoId = targetbed.ClassInfoId;

                        //����ı��Ĵ�λ��ı�֮ǰ�Ĵ�λ״̬��ͬ���Ͳ����������ݵĴ��������ͬ��Ҫ�����ݴ���
                        var fromdorm = dormbll.GetEntity(frombed.DormId);
                        if (frombed.IsUsed != tempIsUsed)
                        {//ԭ��λ��Ϣ���ִ�λ��Ϣ����ͬʱ��Ҫ�ı�����Ĵ�λ����
                            if (frombed.IsUsed == 0)//��ʾ�ִ�λΪ�մ�λ
                            {
                                fromdorm.UsedBeds--;//ʹ�õĴ�λ��Ҫ��1;
                                fromdorm.NotUseBeds++;//δʹ�ô�λ��Ҫ��1;
                            }
                            else
                            {
                                fromdorm.UsedBeds++;//ʹ�õĴ�λ��Ҫ��1;
                                fromdorm.NotUseBeds--;//δʹ�ô�λ��Ҫ��1;
                            }
                        }
                        if (frombed.IsDistribute != tempIsDistribute)
                        {
                            if (frombed.IsUsed == 0)//��ʾ�ִ�λΪ�մ�λ
                            {
                                fromdorm.DistributeBeds--;//ʹ�õĴ�λ��Ҫ��1;
                                fromdorm.NotDistributeBeds++;//δʹ�ô�λ��Ҫ��1;
                            }
                            else
                            {
                                fromdorm.DistributeBeds++;//ʹ�õĴ�λ��Ҫ��1;
                                fromdorm.NotDistributeBeds--;//δʹ�ô�λ��Ҫ��1;
                            }
                        }
                        modirybedList.Add(frombed);

                        //��ѯ�������������ס��Ϣ,ֻ����ѧ����ס������²���������
                        #region �˳�ԭ���ᴲλ
                        if (!string.IsNullOrEmpty(tempStuId))
                        {
                            string queryjson = new { StuId = tempStuId, BedId = frombed.BedId }.ToJson();
                            BK_StuBedDwellEntity beddwell = dwellbll.GetEntityByWhere(queryjson);//��ѯ�Ƿ��Ѿ���ס��Ϣ
                            if (beddwell == null)
                            {
                                beddwell = new BK_StuBedDwellEntity();
                                beddwell.StuId = tempStuId;
                                beddwell.BedId = frombed.BedId;                                
                            }
                            beddwell.QuitDate = DateTime.Now;
                            beddwell.QuitRemark = "�������ᴲλ";
                            dwellbll.SaveForm(beddwell.ID, beddwell);
                        }
                        #endregion

                        #region ��ס�����ᴲλ
                        if (!string.IsNullOrEmpty(tempStuId))
                        {
                            string queryjson = new { StuId = tempStuId, BedId = targetbed.BedId }.ToJson();
                            BK_StuBedDwellEntity beddwell = dwellbll.GetEntityByWhere(queryjson);//��ѯ�Ƿ��Ѿ���ס��Ϣ
                            if (beddwell == null)
                            {
                                beddwell = new BK_StuBedDwellEntity();
                                beddwell.StuId = tempStuId;
                                beddwell.BedId = targetbed.BedId;
                            }
                            beddwell.EnterDate = DateTime.Now;
                            beddwell.EnterRemark = "�������ᴲλ";
                            dwellbll.SaveForm(beddwell.ID, beddwell);
                        }
                        #endregion


                        dormbll.SaveForm(fromdorm.DormId, fromdorm, modirybedList);//�޸�ԭ��λ��Ϣ
                        #endregion

                        #region �޸�Ŀ�괲λ��Ϣ
                        int tempIsUsed2 = targetbed.IsUsed;//��ʾΪ��ʹ��    
                        int tempIsDistribute2 = targetbed.IsDistribute;
                        string tempIsDwell2 = targetbed.IsDwell;
                        string tempMajorDetailId2 = targetbed.MajorDetailId;
                        string tempMajorId2 = targetbed.MajorId;
                        string tempStuId2 = targetbed.StuId;
                        string tempStuName2 = targetbed.StuName;
                        string tempClassInfoId2 = targetbed.ClassInfoId;

                        //�ı�Ŀ������
                        targetbed.IsUsed = tempIsUsed;//��ʾΪ��ʹ��    
                        targetbed.IsDistribute = tempIsDistribute;
                        targetbed.IsDwell = tempIsDwell;
                        targetbed.MajorDetailId = tempMajorDetailId;
                        targetbed.MajorId = tempMajorId;
                        targetbed.StuId = tempStuId;
                        targetbed.StuName = tempStuName;
                        targetbed.ClassInfoId = tempClassInfoId;

                        var targetdorm = dormbll.GetEntity(targetbed.DormId);
                        if (targetbed.IsUsed != tempIsUsed2)
                        {//ԭ��λ��Ϣ���ִ�λ��Ϣ����ͬʱ��Ҫ�ı�����Ĵ�λ����
                            if (targetbed.IsUsed == 0)//��ʾ�ִ�λΪ�մ�λ
                            {
                                targetdorm.UsedBeds--;//ʹ�õĴ�λ��Ҫ��1;
                                targetdorm.NotUseBeds++;//δʹ�ô�λ��Ҫ��1;
                            }
                            else
                            {
                                targetdorm.UsedBeds++;//ʹ�õĴ�λ��Ҫ��1;
                                targetdorm.NotUseBeds--;//δʹ�ô�λ��Ҫ��1;
                            }
                        }
                        if (targetbed.IsDistribute != tempIsDistribute2)
                        {
                            if (targetbed.IsUsed == 0)//��ʾ�ִ�λΪ�մ�λ
                            {
                                targetdorm.DistributeBeds--;//ʹ�õĴ�λ��Ҫ��1;
                                targetdorm.NotDistributeBeds++;//δʹ�ô�λ��Ҫ��1;
                            }
                            else
                            {
                                targetdorm.DistributeBeds++;//ʹ�õĴ�λ��Ҫ��1;
                                targetdorm.NotDistributeBeds--;//δʹ�ô�λ��Ҫ��1;
                            }
                        }

                        //��ѯ�������������ס��Ϣ,ֻ����ѧ����ס������²���������
                        #region �˳�ԭ���ᴲλ
                        if (!string.IsNullOrEmpty(tempStuId2))
                        {
                            string queryjson = new { StuId = tempStuId2, BedId = targetbed.BedId }.ToJson();
                            BK_StuBedDwellEntity beddwell = dwellbll.GetEntityByWhere(queryjson);//��ѯ�Ƿ��Ѿ���ס��Ϣ
                            if (beddwell == null)
                            {
                                beddwell = new BK_StuBedDwellEntity();
                                beddwell.StuId = tempStuId2;
                                beddwell.BedId = targetbed.BedId;
                            }
                            beddwell.QuitDate = DateTime.Now;
                            beddwell.QuitRemark = "�������ᴲλ";
                            dwellbll.SaveForm(beddwell.ID, beddwell);
                        }
                        #endregion

                        #region ��ס�����ᴲλ
                        if (!string.IsNullOrEmpty(tempStuId2))
                        {
                            string queryjson = new { StuId = tempStuId2, BedId = frombed.BedId }.ToJson();
                            BK_StuBedDwellEntity beddwell = dwellbll.GetEntityByWhere(queryjson);//��ѯ�Ƿ��Ѿ���ס��Ϣ
                            if (beddwell == null)
                            {
                                beddwell = new BK_StuBedDwellEntity();
                                beddwell.StuId = tempStuId2;
                                beddwell.BedId = frombed.BedId;
                            }
                            beddwell.EnterDate = DateTime.Now;
                            beddwell.EnterRemark = "�������ᴲλ";
                            dwellbll.SaveForm(beddwell.ID, beddwell);
                        }
                        #endregion




                        modirybedList.Clear();//������е����ݣ�������װ��������
                        modirybedList.Add(targetbed);
                        dormbll.SaveForm(targetdorm.DormId, targetdorm, modirybedList);//�޸�Ŀ��ԭ��λ��Ϣ
                        #endregion
                    }
                }
                catch (System.Exception ex)
                {

                    return Error("������λʧ�ܣ�");
                }
                return Success("��λ�����ɹ���");
            }
            return Error("������λ����Ϊ�գ�");
        }

        #endregion
    }
}
