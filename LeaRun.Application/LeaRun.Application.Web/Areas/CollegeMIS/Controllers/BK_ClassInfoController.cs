using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.Busines.CollegeMIS;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Web.Mvc;
using System;

namespace LeaRun.Application.Web.Areas.CollegeMIS.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 10:07
    /// �� ����������
    /// </summary>
    public class BK_ClassInfoController : MvcControllerBase
    {
        private BK_ClassInfoBLL bk_classinfobll = new BK_ClassInfoBLL();
        private BK_DeptBLL deptbll = new BK_DeptBLL();
        private BK_MajorBLL majorbll = new BK_MajorBLL();
        private BK_ClassInfoBLL cbll = new BK_ClassInfoBLL();

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
        /// �ְ�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FBIndex()
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
        /// �ְ����ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RuleForm()
        {
            return View();
        }
        /// <summary>
        /// ����ѧ�Ź���ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateStuNoRuleForm()
        {
            return View();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeClassIndex()
        {
            return View();
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeForm()
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
            var data = bk_classinfobll.GetPageList(pagination, queryJson);
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
        /// ��ȡԺϵרҵ�༶����
        /// </summary>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson()
        {
            var data = deptbll.GetPageList(null, null);//��ѯ�����е�Ժϵ
            var treeList = new List<TreeEntity>();
            foreach (var dept in data)
            {
                TreeEntity tree = new TreeEntity();
                int hasChildren = 0;
                var majorList = deptbll.GetListDetails(dept.DeptNo);//�õ�Ժϵ���������רҵ
                foreach (var major in majorList)
                {
                    hasChildren++;
                    int hasChildren2 = 0;//��¼�༶����
                    var classlist = bk_classinfobll.GetList(new { MajorNo = major.MajorNo }.ToJson());
                    foreach (var cls in classlist)
                    {
                        int stucount = bk_classinfobll.GetListDetails(cls.ClassNo).Count;//��ѯ�����е�ѧ������
                        hasChildren2++;
                        int dormcount = 0;
                        tree = new TreeEntity();
                        tree.id = cls.ClassNo;
                        tree.text = cls.ClassName + "(����" + stucount + "��)";
                        tree.value = cls.ClassNo;
                        tree.isexpand = true;
                        tree.complete = true;
                        tree.hasChildren = dormcount == 0 ? false : true;
                        tree.parentId = major.MajorNo;
                        tree.img = "";
                        tree.Attribute = "show";
                        tree.AttributeValue = "cls";

                        treeList.Add(tree);
                    }

                    tree = new TreeEntity();
                    tree.id = major.MajorNo;
                    tree.text = major.MajorName + "(��" + hasChildren2 + "����)";
                    tree.value = major.MajorNo;
                    tree.isexpand = true;
                    tree.complete = false;
                    tree.hasChildren = hasChildren2 == 0 ? false : true;
                    tree.parentId = dept.DeptNo;
                    tree.img = "";
                    tree.Attribute = "show";
                    tree.AttributeValue = "major";

                    treeList.Add(tree);
                }
                tree = new TreeEntity();
                tree.id = dept.DeptNo;
                tree.text = dept.DeptName;
                tree.value = dept.DeptNo;
                tree.isexpand = true;
                tree.complete = false;
                tree.hasChildren = hasChildren == 0 ? false : true;
                tree.parentId = "0";
                tree.img = "fa fa-building";
                tree.Attribute = "show";
                tree.AttributeValue = "dept";

                treeList.Add(tree);
            }
            var temp = treeList.TreeToJson();
            return Content(temp); 
        }


        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = bk_classinfobll.GetEntity(keyValue);
            var childData = bk_classinfobll.GetDetails(keyValue);
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
            var data = bk_classinfobll.GetDetails(keyValue);
            return ToJsonResult(data);
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var data = bk_classinfobll.GetPageList(null, queryJson);
            return Content(data.ToJson());
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
            bk_classinfobll.RemoveForm(keyValue);
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
            var entity = strEntity.ToObject<BK_ClassInfoEntity>();
            var childEntitys = strChildEntitys.ToList<BK_StuClassEntity>();
            bk_classinfobll.SaveForm(keyValue, entity, childEntitys);
            return Success("�����ɹ���");
        }
        #endregion

        #region �ְ�����
        /// <summary>
        /// �ְ�����
        /// </summary>
        /// <param name="secRule">����</param>
        /// <returns></returns>
        [HttpPost]       
        [AjaxOnly]
        public ActionResult DivideClasses(string secRule)
        {
            List<string> ruleList = new List<string>();
            if (!string.IsNullOrEmpty(secRule))
            {
                ruleList = secRule.ToObject<List<string>>();
            }
            BK_ClassInfoBLL cbll = new BK_ClassInfoBLL();
            BK_StuInfoBLL stubll = new BK_StuInfoBLL();

            DateTime dt = DateTime.Now;
            /*
             *                 entity.StuOther = "δ�ְ�"; //�ְ��־
                entity.GuiDangMark = "δ�鵵";//ֻ��������û�й鵵
                entity.TransMark = "0";//ֻ��������û�й鵵
             */
            string curryear = dt.ToString("yyyy");//�õ���ǰ���� 
            string queryJson = (new { Grade = curryear }).ToJson();
            List<BK_ClassInfoEntity> classlist = bk_classinfobll.GetList(queryJson);//�õ����еĵ�ǰ����°༶,Ҳ��Ҫ�ְ�İ༶
            HashSet<string>  majornolist = new HashSet<string>();//�õ����ظ���רҵ���б�
            foreach (var classentity in classlist)
            {
                majornolist.Add(classentity.MajorNo);    //�õ����ظ���רҵ��            
            }
            queryJson = (new { newstu = "newstu" }).ToJson();//�õ���ѯ����
            List<BK_StuInfoEntity> stuNewList = stubll.GetList(queryJson);//��ѯ�����е�δ�ְ�����

            #region ѭ������רҵ����רҵ�����зְ�
            foreach (var majorno in majornolist)//�õ���רҵ�İ༶������
            {
                int stunewcount = 0;
                List<BK_ClassInfoEntity> classByMajorList = classlist.FindAll(s => s.MajorNo.Equals(majorno));//��ǰ������רҵ��������а༶
                List<BK_StuInfoEntity> stuNewByMajorList = stuNewList.FindAll(s=>s.MajorNo.Equals(majorno) && s.StuOther.Equals("δ�ְ�"));//��ѯ�����е�δ�ְ�����רҵ������
                
                if (classByMajorList.Count==1 )
                {//������רҵ����İ༶ֻ��1��������£��Ͱ����ѧ��ȫ����� ������༶��ȥ  
                   // bk_classinfobll.InsertStuCls(classByMajorList[0].ClassId, stuNewByMajorList);
                    bk_classinfobll.InsertStuCls(classByMajorList[0].ClassNo, stuNewByMajorList);
                }
                else
                {
                    #region ѭ��רҵ��������еİ༶
                    if (!string.IsNullOrEmpty(secRule))
                    {
                        #region �Ա�
                        if (ruleList.Contains("�Ա�"))
                        {
                            stuNewByMajorList.Sort(BK_StuInfoEntity.CompareByGender);
                        }
                        #endregion
                        #region ����������
                        if (ruleList.Contains("����"))
                        {
                            stuNewByMajorList.Sort(BK_StuInfoEntity.CompareByProv);
                            stuNewByMajorList.Sort(BK_StuInfoEntity.CompareByCity);
                            stuNewByMajorList.Sort(BK_StuInfoEntity.CompareByDest);
                        }
                        #endregion
                        #region �ɼ�����
                        if (ruleList.Contains("�ɼ�"))
                        {
                            //stuNewByMajorList.Sort((BK_StuInfoEntity mx, BK_StuInfoEntity my) => //�÷���ʵ�ֵ��ǽ�Asm�ɴ�С������
                            //{
                            //    if (mx.HighAmountScore > my.HighAmountScore) return -1;  //����-1��ʾmx���϶�����ֵС��my,��������ǰ��
                            //    else if (mx.HighAmountScore < my.HighAmountScore) return 1; //����1 ��ʾmx���϶�����ֵ����my,�������ں���.
                            //    else return 0;
                            //});
                            stuNewByMajorList.Sort(BK_StuInfoEntity.CompareByScore);
                        }
                        #endregion
                        #region ��������
                        if (ruleList.Contains("����"))
                        {
                            stuNewByMajorList.Sort(BK_StuInfoEntity.CompareByNation);
                        }
                        #endregion
                    }

                    /*
                     * ֻ�������רҵ�������2���༶������²Ż�������ְ�
                     */
                    foreach (var clsentity in classByMajorList) // ���༶���зְ�
                    {
                        //var stuclslist = bk_classinfobll.GetDetails_old(clsentity.ClassId); //�õ�����༶�������е�ѧ��
                        //List<BK_StuClassEntity> stuclsList = new List<BK_StuClassEntity>();
                        List<BK_StuInfoEntity> stuinfolist = new List<BK_StuInfoEntity>();
                        for (int i = 0; i < clsentity.StuNum; i++)
                        {
                            if (stunewcount < stuNewByMajorList.Count)
                            {
                                //BK_StuClassEntity stucls = new BK_StuClassEntity();
                                //stucls.ClassId = clsentity.ClassId;
                                //stucls.stuInfoId = stuNewByMajorList[stunewcount].stuInfoId;
                                //stuclsList.Add(stucls);
                                stuinfolist.Add(stuNewByMajorList[stunewcount]);
                                stunewcount += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (stuinfolist.Count>0)
                        {
                            //bk_classinfobll.InsertStuCls(clsentity.ClassId, stuinfolist);
                            bk_classinfobll.InsertStuCls(clsentity.ClassNo, stuNewByMajorList);
                        }
                    }
                    #endregion
                }

            }
            #endregion

            return Success("�����ɹ���");
        }
        #endregion

        #region ѧ������
        /// <summary>
        /// ѧ������
        /// </summary>
        /// <param name="secRule">����</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult CreateStuNo(string stunorule)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string fno = "";//ǰ��ֵ
            int ycount = 0;//ʹ����ĳ���
            int depcount = 0;//ʹ��Ժϵ�ų���
            int mjcount = 0;//ʹ��רҵ�ų���
            int clscount = 0;//ʹ�ð༶�ų���
            int lastcount = 0;//β�ų���
            if (!string.IsNullOrEmpty(stunorule))
            {
                dic = stunorule.ToObject<Dictionary<string,object>>();
                if (dic.Count>0)
                {
                    //�Ƿ�Ҫǰ��
                    var hasfrant = dic["chfrant"].ToString();// �Ƿ�ʹ��ǰ��
                    if (hasfrant=="1")
                    {
                        fno = dic["frantno"].ToString();//ǰ��ֵ
                    }
                    var useyear = dic["useyear"].ToString();//�Ƿ�ʹ�����
                    if (useyear=="1")
                    {
                        ycount = dic["secyear"].ToString()!=""? Convert.ToInt32(dic["secyear"]):0;//���ʹ�ó���
                    }
                    var chkdeptno = dic["chkdeptno"].ToString();//�Ƿ�ʹ��Ժϵ
                    if (chkdeptno=="1")
                    {
                        depcount = dic["deptnocount"].ToString()!=""?Convert.ToInt32(dic["deptnocount"]):0;//Ժϵ��ʹ�ó���
                    }
                    var majorno = dic["majorno"].ToString();//�Ƿ�ʹ��רҵ
                    if (majorno=="1")
                    {
                        mjcount = dic["majornocount"].ToString() != "" ? Convert.ToInt32(dic["majornocount"]) : 0;//רҵ��ʹ�ó���
                    }
                    
                    var chkclsno = dic["chkclsno"].ToString();//�Ƿ�ʹ�ð༶
                    if (chkclsno=="1")
                    {
                        clscount = dic["clsnocount"].ToString() != "" ? Convert.ToInt32(dic["clsnocount"]) : 0;//�༶��ʹ�ó���
                    }
                    lastcount = dic["lastnocount"].ToString() != "" ? Convert.ToInt32(dic["lastnocount"]) : 0;//���β�ŵĳ���
                }
            }

            BK_ClassInfoBLL cbll = new BK_ClassInfoBLL();
            BK_StuInfoBLL stubll = new BK_StuInfoBLL();
            BK_MajorDetailBLL mjbll = new BK_MajorDetailBLL();
            BK_MajorBLL mbll = new BK_MajorBLL();
            BK_DeptBLL dbll = new BK_DeptBLL();

           
          
            DateTime dt = DateTime.Now;

            if (ycount>0)
            {
                if (ycount==4)
                {
                    fno += dt.ToString("yyyy");
                }
                if (ycount==2)
                {
                    fno += dt.ToString("yy");
                }
            }

            string curryear = dt.ToString("yyyy");//�õ���ǰ����           
            string queryJson = (new { Grade = curryear }).ToJson();
            List<BK_ClassInfoEntity> classlist = bk_classinfobll.GetList(queryJson);//�õ����еĵ�ǰ����°༶,Ҳ��Ҫ�ְ�İ༶
            HashSet<string> majordetailnoList = new HashSet<string>();//�õ����ظ���רҵ�����б�
           
            foreach (var classentity in classlist)
            {
                majordetailnoList.Add(classentity.MajorDetailNo);    //�õ����ظ���רҵ�����   
                string newstuno = fno;//ѧ�ų�ʼֵ
                #region �õ�Ժϵ��
                if (depcount>0)//���ʹ��Ժϵ�ų��ȴ�����
                {
                    if (!string.IsNullOrEmpty(classentity.DeptNo))
                    {
                        if (depcount<classentity.DeptNo.Length)
                        {
                            newstuno += classentity.DeptNo.Substring(0, depcount);
                        }
                        else
                        {
                            newstuno += classentity.DeptNo;
                        }
                    }
                }
                #endregion

                #region �õ�רҵ��
                if (mjcount > 0)//���ʹ��רҵ�ų��ȴ�����
                {
                    if (!string.IsNullOrEmpty(classentity.MajorNo))
                    {
                        if (mjcount < classentity.MajorNo.Length)
                        {
                            newstuno += classentity.MajorNo.Substring(0, mjcount);
                        }
                        else
                        {
                            newstuno += classentity.MajorNo;
                        }
                    }
                }
                #endregion

                #region �õ��༶��
                if (clscount > 0)//���ʹ��רҵ�ų��ȴ�����
                {
                    if (!string.IsNullOrEmpty(classentity.ClassNo))
                    {
                        if (clscount < classentity.ClassNo.Length)
                        {
                            newstuno += classentity.ClassNo.Substring(0, clscount);
                        }
                        else
                        {
                            newstuno += classentity.ClassNo;
                        }
                    }
                }
                #endregion

                IEnumerable<BK_StuInfoEntity> stulist = bk_classinfobll.GetDetails(classentity.ClassId);
                foreach (var stuentity in stulist)
                {
                    if (!string.IsNullOrEmpty( stuentity.StuNo))//ֻ��ѧ��Ϊ�յ�����²�����ѧ��
                    {
                        continue;
                    }

                    string lastno = "";
                    if (lastcount>0)
                    {
                        Random rd = new Random();
                        if (lastcount==3)
                        {
                            lastno = rd.Next(1, 1000).ToString();
                        }
                        if (lastcount ==4 )
                        {
                            lastno = rd.Next(1, 10000).ToString();
                        }
                        if (lastcount==5)
                        {
                            lastno = rd.Next(1, 100000).ToString();
                        }
                        lastno = lastno.PadLeft(lastcount,'0');
                    }
                    stuentity.StuNo = newstuno + lastno;//�õ�ѧ����ѧ��
                    stubll.SaveForm(stuentity.stuInfoId, stuentity, null);//�޸�ѧ����ѧ��
                }
            }



            return Success("�����ɹ�");
        }
        #endregion

    }
}
