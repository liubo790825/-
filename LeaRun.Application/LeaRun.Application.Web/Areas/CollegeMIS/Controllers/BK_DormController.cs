using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.Busines.CollegeMIS;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Web.Mvc;
using LeaRun.Util.Extension;

namespace LeaRun.Application.Web.Areas.CollegeMIS.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 16:33
    /// �� ����������Ϣ
    /// </summary>
    public class BK_DormController : MvcControllerBase
    {
        private BK_DormBLL bk_dormbll = new BK_DormBLL();
        private BK_DormBuildingBLL buildbll = new BK_DormBuildingBLL();//¥
        private BK_DormUnitBLL ubll = new BK_DormUnitBLL();
        private BK_DormFloorsBLL fbll = new BK_DormFloorsBLL();//¥��
        private BK_DormBedBLL bedbll = new BK_DormBedBLL();

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
        /// ������ס�б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult StuChkDormIndex()
        {
            return View();
        }

        /// <summary>
        /// Ԥ������ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult YFIndex()
        {
            return View();
        }

        /// <summary>
        /// Ժϵרҵ��λͳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MajorBedsCountIndex()
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
        /// Ԥ��רҵѡ��ҳ���ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult YFForm()
        {
            return View();
        }

        /// <summary>
        /// Ԥ�ִ�λרҵѡ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult YFBedForm()
        {
            return View();
        }

        #endregion

        #region ��ȡ����
        /// <summary>
        /// �����б� 
        /// </summary>
        /// <param name="keyword">�ؼ���</param>
        /// <param name="usedrom">�Ƿ�ʹ��������</param>
        /// <returns>��������Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson(string keyword, string usedrom)
        {
            var data = buildbll.GetList();
            var treeList = new List<TreeEntity>();
            foreach (BK_DormBuildingEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                int hasChildren = 0;

                var unitList = buildbll.GetDetails(item.DormBuildingId);
                foreach (var unit in unitList)
                {
                    hasChildren++;
                    int hasChildren2 = 0;
                    var floorsList = ubll.GetDetails(unit.DormUnitId);
                    foreach (var floor in floorsList)
                    {
                        hasChildren2++;
                        int dormcount = 0;
                        if (!string.IsNullOrEmpty(usedrom))
                        {
                            var dormList = fbll.GetDetails(floor.DormFloorsId);
                            foreach (var dorm in dormList)
                            {
                                dormcount++;
                                tree = new TreeEntity();
                                tree.id = dorm.DormId;
                                tree.text = dorm.DormName+"(��"+dorm.Beds+"������"+dorm.NotUseBeds+"��)";
                                tree.value = dorm.DormId;
                                tree.isexpand = false;
                                tree.complete = true;
                                tree.hasChildren = false;
                                tree.parentId = floor.DormFloorsId;
                                tree.img = "";
                                tree.Attribute = "show";
                                tree.AttributeValue = "dorm";

                                treeList.Add(tree);
                            }
                        }

                        tree = new TreeEntity();
                        tree.id = floor.DormFloorsId;
                        tree.text = floor.DormFloorsName + "(" + floor.DormFloorsType + ")";
                        tree.value = floor.DormFloorsId;
                        tree.isexpand = true;
                        if (!string.IsNullOrEmpty(usedrom))
                        {
                            tree.complete = false;
                        }
                        else
                        {
                            tree.complete = true;
                        }
                        tree.hasChildren = dormcount == 0 ? false : true;
                        tree.parentId = unit.DormUnitId;
                        tree.img = "";
                        tree.Attribute = "show";
                        tree.AttributeValue = "floor";

                        treeList.Add(tree);
                    }

                    tree = new TreeEntity();
                    tree.id = unit.DormUnitId;
                    tree.text = unit.DormUnitName + "(" + unit.DormUnitType + ")";
                    tree.value = unit.DormUnitId;
                    tree.isexpand = true;
                    tree.complete = false;
                    tree.hasChildren = hasChildren2 == 0 ? false : true;
                    tree.parentId = item.DormBuildingId;
                    tree.img = "";
                    tree.Attribute = "show";
                    tree.AttributeValue = "unit";

                    treeList.Add(tree);
                }
                tree = new TreeEntity();
                tree.id = item.DormBuildingId;
                tree.text = item.DormBuildingName;
                tree.value = item.DormBuildingId;
                tree.isexpand = true;
                tree.complete = false;
                tree.hasChildren = hasChildren == 0 ? false : true;
                tree.parentId = "0";
                tree.img = "fa fa-building";
                tree.Attribute = "show";
                tree.AttributeValue = "build";

                treeList.Add(tree);
            }
            var temp = treeList.TreeToJson();

            return Content(temp);
        }

        /// <summary>
        /// �����б�
        /// </summary>
        /// <param name="dormids">����ID���б�</param>
        /// <returns>��������Json</returns>
        [HttpGet]
        public ActionResult GetDormTreeJson(string dormids)
        {
            var treeList = new List<TreeEntity>();
            string[] dormidlist = dormids.Split(',');
            foreach (var dormid in dormidlist)
            {
                BK_DormEntity dorm = bk_dormbll.GetEntity(dormid);
                if (dorm != null && dorm.NotDistributeBeds > 0)
                {
                    //ֻ�е�ѡ������᲻Ϊ�գ����һ�Ҫ����δ�ֵĴ�λ����Ҫ����0�Ĳ���ʾ
                    TreeEntity tree = new TreeEntity();

                    tree.id = dorm.DormId;
                    tree.text = dorm.DormName;
                    tree.value = dorm.DormId;
                    tree.isexpand = false;
                    tree.complete = true;
                    tree.hasChildren = false;
                    tree.parentId = "0";// dorm.DormFloorsId;
                    tree.img = "";
                    tree.Attribute = "show";
                    tree.AttributeValue = "dorm";

                    treeList.Add(tree);
                }
            }
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// ����ѧ��ID�ţ�������������
        /// </summary>
        /// <param name="stuid">ѧ��ID��</param>
        /// <returns></returns>
        public ActionResult GetDormTreeJsonByStuId(string stuid)
        {
            BK_StuInfoBLL stubll = new BK_StuInfoBLL();//ѧ��
            BK_MajorBLL mbll = new BK_MajorBLL();//רҵ
            BK_StuInfoEntity student = stubll.GetEntity(stuid);
            var treeList = new List<TreeEntity>();

            if (student != null)
            {
                string queryJson = (new { MajorNo = student.MajorNo, DormFloorsType = student.Gender }).ToJson();
                var dormbedList = bedbll.GetListByStr(queryJson);//�õ����רҵ���������Ա�����д�λ

                HashSet<string> floorids = new HashSet<string>();
                foreach (var bed in dormbedList)
                {
                    floorids.Add(bed.DormFloorsId);//ȥ���ظ���¥��ID�ţ�
                }

                foreach (var floorid in floorids)
                {
                    BK_DormFloorsEntity floor = fbll.GetEntity(floorid);
                    TreeEntity tree = new TreeEntity();
                    int dormcount = 0;
                    var dormList = fbll.GetDetails(floorid);
                    foreach (var dorm in dormList)
                    {
                        queryJson = (new { DormId = dorm.DormId, MajorId = student.MajorNo }).ToJson();
                        //���²�ѯ��������������Ƿ������רҵ�Ĵ�λ�����û�У��Ͳ�Ҫ��ӵ������ˣ�����У�����ӵ�����
                        var bedlist = bedbll.GetList(queryJson);
                        if (bedlist.Count > 0)
                        {
                            int sybed = dorm.Beds.Value - dorm.UsedBeds;
                            if (bedlist.Count < dorm.Beds.Value)//����õ��Ĵ�λ����������Ĵ�λ������ͬ�Ͳ��������¼���ʣ�ലλ����
                            {
                                sybed = 0;
                                foreach (var bed in bedlist)
                                {
                                    if (bed.IsUsed == 0)
                                    {
                                        sybed++;
                                    }
                                }
                            }


                            dormcount++;
                            tree = new TreeEntity();
                            tree.id = dorm.DormId;
                            tree.text = dorm.DormName + "(��" + sybed + "��λ)";
                            tree.value = dorm.DormId;
                            tree.isexpand = false;
                            tree.complete = true;
                            tree.hasChildren = false;
                            tree.parentId = floorid;
                            tree.img = "";
                            tree.Attribute = "show";
                            tree.AttributeValue = "dorm";

                            tree.Attribute = "majorno";
                            tree.AttributeValue = student.MajorNo;//רҵ�Ŵ���ǰ̨ȥ



                            treeList.Add(tree);
                        }
                    }
                    tree = new TreeEntity();
                    tree.id = floor.DormFloorsId;
                    tree.text = floor.DormFloorsName + "(" + floor.DormFloorsType + ")";
                    tree.value = floor.DormFloorsId;
                    tree.isexpand = true;
                    tree.complete = true;
                    tree.hasChildren = dormcount == 0 ? false : true;
                    tree.parentId = "0";
                    tree.img = "";
                    tree.Attribute = "show";
                    tree.AttributeValue = "floor";
                    tree.Attribute = "majorno";
                    tree.AttributeValue = student.MajorNo;//רҵ�Ŵ���ǰ̨ȥ
                    treeList.Add(tree);
                }
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
            var data = bk_dormbll.GetPageList(pagination, queryJson);
            if (pagination == null)
            {
                return ToJsonResult(data);
            }
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
            var data = bk_dormbll.GetEntity(keyValue);
            var childData = bk_dormbll.GetDetails(keyValue);
            var jsonData = new
            {
                entity = data,
                childEntity = childData
            };
            return ToJsonResult(jsonData);
        }

        /// <summary>
        /// ����¥��õ����е��������������Ĵ�λ
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public ActionResult GetListAndChildList(string queryJson)
        {
            var data = bk_dormbll.GetList(queryJson);
            List<Dorm> dormList = new List<Dorm>();
            foreach (var dorm in data)
            {
                var childData = bk_dormbll.GetDetails(dorm.DormId); //�õ����еĴ�λ��Ϣ      
                Dorm d = new Dorm();
                d.entity = dorm;
                d.childEntity = childData;
                dormList.Add(d);
            }
            var temp = ToJsonResult(dormList);
            return temp;
        }

        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetDetailsJson(string keyValue, string majorno)
        {
            if (string.IsNullOrEmpty(majorno))
            {
                var data = bk_dormbll.GetDetails(keyValue);
                return ToJsonResult(data);
            }
            else
            {
                string queryjson = new { MajorId = majorno, DormId = keyValue }.ToJson();
                var data = bedbll.GetList(queryjson);
                return ToJsonResult(data);
            }
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
            bk_dormbll.RemoveForm(keyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ���Ԥ�����ᴲλ
        /// </summary>
        /// <param name="strEntity">����id��</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult ClearYFDorm(string strEntity)
        {
            if (!string.IsNullOrEmpty(strEntity))
            {
                string[] dormids = strEntity.Split(',');
                try
                {
                    foreach (var dormid in dormids)
                    {
                        BK_DormEntity dorm = bk_dormbll.GetEntity(dormid);
                        if (dorm != null && dorm.DistributeBeds > 0)
                        {
                            List<BK_DormBedEntity> bedls = new List<BK_DormBedEntity>();
                            var bedlist = bk_dormbll.GetDetails(dormid);//�õ����д�λ����
                            int bdcount = 0;
                            foreach (var bed in bedlist)
                            {
                                bdcount++;
                                if (bed.IsDistribute == 1)
                                {
                                    dorm.NotDistributeBeds += 1;
                                    dorm.DistributeBeds -= 1;
                                    if (dorm.UsedBeds == 0)
                                    {
                                        dorm.UsedBeds = 0;
                                    }
                                    else
                                    {
                                        dorm.UsedBeds -= 1;
                                    }
                                    if (dorm.NotUseBeds == 0)
                                    {
                                        dorm.NotUseBeds = 0;
                                    }
                                    else
                                    {
                                        dorm.NotUseBeds += 1;
                                    }

                                    bed.IsDistribute = 0;
                                    bed.MajorDetailId = "";
                                    bed.MajorId = "";
                                    bed.IsDwell = "��";
                                    bed.IsUsed = 0;//���ʹ�����
                                    bed.StuId = "";//���ѧ��
                                    bed.StuName = "";//�������
                                    bedls.Add(bed);//���ӵ������У�����serverͳһ�޸�
                                }
                            }

                            if (dorm.NotUseBeds >= bdcount)
                            {
                                dorm.NotUseBeds = bdcount;
                            }
                            if (dorm.NotDistributeBeds >= bdcount)
                            {
                                dorm.NotDistributeBeds = bdcount;
                            }
                            if (dorm.DistributeBeds <= 0)
                            {
                                dorm.DistributeBeds = 0;
                            }
                            if (dorm.UsedBeds <= 0)
                            {
                                dorm.UsedBeds = 0;
                            }
                            dorm.ClassInfoId = "";//��հ༶id��
                            dorm.MajorDetailId = "";//���רҵ����ID��
                            dorm.MajorId = "";//���רҵID��
                            bk_dormbll.SaveForm(dormid, dorm, bedls);//�޸�����ʹ�λ����
                        }
                    }
                    return Success("�������ɹ���");
                }
                catch (System.Exception)
                {

                    return Error("�������ʧ�ܣ�");
                }
            }
            return Error("Ҫ������᲻��Ϊ�գ�");
        }

        /// <summary>
        /// ������ᴲλ,ֻ���ѧ��ID�ź�ѧ��������רҵ�����
        /// </summary>
        /// <param name="strEntity">����id��</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult ClearDormUse(string strEntity)
        {
            if (!string.IsNullOrEmpty(strEntity))
            {
                string[] dormids = strEntity.Split(',');
                try
                {
                    foreach (var dormid in dormids)
                    {
                        BK_DormEntity dorm = bk_dormbll.GetEntity(dormid);
                        if (dorm != null)
                        {
                            List<BK_DormBedEntity> bedls = new List<BK_DormBedEntity>();
                            var bedlist = bk_dormbll.GetDetails(dormid);//�õ����д�λ����
                            int bdcount = 0;
                            foreach (var bed in bedlist)
                            {
                                bdcount++;
                                //bed.IsDistribute = 0;
                                //bed.MajorDetailId = "";
                                //bed.MajorId = "";
                                bed.IsDwell = "��Ԥ��";
                                bed.IsUsed = 0;//���ʹ�����
                                bed.StuId = "";//���ѧ��
                                bed.StuName = "";//�������
                                bedls.Add(bed);//���ӵ������У�����serverͳһ�޸�
                            }
                            dorm.UsedBeds = 0;
                            dorm.NotUseBeds = bdcount;

                            //dorm.NotDistributeBeds = bdcount;
                            //dorm.DistributeBeds = 0;                            
                            //dorm.ClassInfoId = "";//��հ༶id��
                            //dorm.MajorDetailId = "";//���רҵ����ID��
                            //dorm.MajorId = "";//���רҵID��
                            bk_dormbll.SaveForm(dormid, dorm, bedls);//�޸�����ʹ�λ����
                        }
                    }
                    return Success("�������ɹ���");
                }
                catch (System.Exception)
                {

                    return Error("�������ʧ�ܣ�");
                }
            }
            return Error("Ҫ������᲻��Ϊ�գ�");
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strChildEntitys)
        {
            var entity = strEntity.ToObject<BK_DormEntity>();
            var childEntitys = strChildEntitys.ToList<BK_DormBedEntity>();
            bk_dormbll.SaveForm(keyValue, entity, childEntitys);
            return Success("�����ɹ���");
        }



        /// <summary>
        /// ����Ԥ������ʹ�λ
        /// </summary>
        /// <param name="dormids">����ID���б�</param>
        /// <param name="strEntity">ҳ����</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveYFForm(string dormids, string strEntity)
        {
            if (!string.IsNullOrEmpty(dormids))
            {
                string[] dormidss = dormids.Split(',');
                string majorid = "";
                string majordetailid = "";

                var queryParam = strEntity.ToJObject();
                if (!queryParam["MajorId"].IsEmpty())
                {
                    majorid = queryParam["MajorId"].ToString();
                }
                if (!queryParam["MajorDetailId"].IsEmpty())
                {
                    majordetailid = queryParam["MajorDetailId"].ToString();
                }

                if (!string.IsNullOrEmpty(majorid) && dormidss.Length > 0)//���רҵΪ�գ��Ͳ���Ԥ��
                {
                    foreach (var dormid in dormidss)
                    {
                        BK_DormEntity dormentity = bk_dormbll.GetEntity(dormid);
                        if (dormentity != null)
                        {
                            //δԤ�ִ�λ����0
                            if (dormentity.NotDistributeBeds > 0)
                            {
                                int yfcount = 0;//��¼Ԥ�ִ�λ������
                                int bedcount = 0;//��¼��λ����
                                List<BK_DormBedEntity> bedslist = new List<BK_DormBedEntity>();

                                var bedlist = bk_dormbll.GetDetails(dormid);
                                foreach (var bed in bedlist)
                                {
                                    bedcount++;
                                    //��λ�Ƿ��Ѿ�Ԥ�֣������û��Ԥ�־�Ԥ�ִ�λ
                                    if (bed.IsDistribute == 0)
                                    {
                                        bed.IsDistribute = 1;//�޸�ΪԤ��
                                        bed.IsDwell = "��Ԥ��";
                                        bed.MajorId = majorid;
                                        bed.MajorDetailId = majordetailid;
                                        yfcount++;//��¼Ԥ�ֵĴ�λ��

                                        bedslist.Add(bed);
                                        //bedbll.SaveForm(bed.BedId, bed);//�޸Ĵ�λ��Ϣ
                                    }
                                }
                                dormentity.DistributeBeds += yfcount;//�޸��ѷִ�λ����
                                dormentity.NotDistributeBeds -= yfcount;//�޸�δ�ִ�λ����

                                //���ǲ���ȫ����λ����ͬһ��רҵ�ģ������ͬһ��רҵ�Ļ��������רҵ�ž͸�Ϊ���ڵ����רҵ�ţ�Ҫ��Ȼ�ǲ����޸������רҵ�ŵ�
                                if (yfcount > 0 && yfcount == bedcount)
                                {
                                    dormentity.MajorId = majorid;
                                    dormentity.MajorDetailId = majordetailid;
                                }

                                //���ַ�ʽ����ʹ�ڷ�������ʱ���Իع�
                                bk_dormbll.SaveForm(dormentity.DormId, dormentity, bedslist);
                            }
                        }
                    }
                    return Success("�����ɹ���");
                }
                else
                {
                    return Error("û��ѡ��רҵ������ʧ�ܡ�");
                }


            }
            else
            {
                return Error("û��ѡ��Ҫ����Ԥ�ֵ����ᣬ����ʧ�ܡ�");
            }
        }

        /// <summary>
        /// ����Ԥ�ִ�λ
        /// </summary>
        /// <param name="dormids">����ID���б�</param>
        /// <param name="strEntity">ҳ����</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveYFBedForm(string strEntity)
        {
            string majorid = "";
            string majordetailid = "";
            string bedids = "";
            string dormids = "";
            var queryParam = strEntity.ToJObject();

            try
            {
                if (!queryParam["MajorId"].IsEmpty())
                {
                    majorid = queryParam["MajorId"].ToString();
                }
                if (!queryParam["MajorDetailId"].IsEmpty())
                {
                    majordetailid = queryParam["MajorDetailId"].ToString();
                }
                if (!queryParam["bedIds"].IsEmpty())
                {
                    bedids = queryParam["bedIds"].ToString();
                }
                if (!queryParam["dormids"].IsEmpty())
                {
                    dormids = queryParam["dormids"].ToString();
                }

                if (!string.IsNullOrEmpty(majorid) && !string.IsNullOrEmpty(bedids))//רҵ�ʹ�λ�Ų���Ϊ��
                {
                    string[] bedidlist = bedids.Split(',');
                    foreach (var bedid in bedidlist)
                    {
                        BK_DormBedEntity bedentity = bedbll.GetEntity(bedid);
                        if (bedentity != null && bedentity.IsDistribute == 0 && !string.IsNullOrEmpty(majorid))
                        {
                            //Ҫ�ֵ�רҵid�Ų���Ϊ��
                            bedentity.IsDistribute = 1;//�޸�ΪԤ��
                            bedentity.IsDwell = "��Ԥ��";
                            bedentity.MajorId = majorid;
                            bedentity.MajorDetailId = majordetailid;

                            var dorm = bk_dormbll.GetEntity(bedentity.DormId);//�õ��ô�λ������
                            if (dorm != null)
                            {
                                dorm.DistributeBeds += 1;//�޸��ѷִ�λ����
                                dorm.NotDistributeBeds -= 1;//�޸�δ�ִ�λ����
                                bk_dormbll.SaveForm(dorm.DormId, dorm, null);//�޸�����Ĵ�λ��Ϣ
                            }
                            bedbll.SaveForm(bedid, bedentity);//�޸Ĵ�λ��Ϣ
                        }
                    }
                }



                return Success("��λԤ�ֳɹ���");
            }
            catch (System.Exception)
            {
                return Error("����ʧ�ܣ�");
            }
        }

        #endregion
    }

    public class Dorm
    {
        public BK_DormEntity entity { get; set; }
        public IEnumerable<BK_DormBedEntity> childEntity { get; set; }
    }


}
