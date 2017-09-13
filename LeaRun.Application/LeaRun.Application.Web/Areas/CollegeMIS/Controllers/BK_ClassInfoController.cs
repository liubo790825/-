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
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 10:07
    /// 描 述：行政班
    /// </summary>
    public class BK_ClassInfoController : MvcControllerBase
    {
        private BK_ClassInfoBLL bk_classinfobll = new BK_ClassInfoBLL();
        private BK_DeptBLL deptbll = new BK_DeptBLL();
        private BK_MajorBLL majorbll = new BK_MajorBLL();
        private BK_ClassInfoBLL cbll = new BK_ClassInfoBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 分班页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FBIndex()
        {
            return View();
        }

        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        /// <summary>
        /// 分班规则页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RuleForm()
        {
            return View();
        }
        /// <summary>
        /// 生成学号规则页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateStuNoRuleForm()
        {
            return View();
        }

        /// <summary>
        /// 换班
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeClassIndex()
        {
            return View();
        }
        /// <summary>
        /// 换班
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeForm()
        {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
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
        /// 获取院系专业班级的树
        /// </summary>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson()
        {
            var data = deptbll.GetPageList(null, null);//查询出所有的院系
            var treeList = new List<TreeEntity>();
            foreach (var dept in data)
            {
                TreeEntity tree = new TreeEntity();
                int hasChildren = 0;
                var majorList = deptbll.GetListDetails(dept.DeptNo);//得到院系下面的所有专业
                foreach (var major in majorList)
                {
                    hasChildren++;
                    int hasChildren2 = 0;//记录班级数量
                    var classlist = bk_classinfobll.GetList(new { MajorNo = major.MajorNo }.ToJson());
                    foreach (var cls in classlist)
                    {
                        int stucount = bk_classinfobll.GetListDetails(cls.ClassNo).Count;//查询出所有的学生数据
                        hasChildren2++;
                        int dormcount = 0;
                        tree = new TreeEntity();
                        tree.id = cls.ClassNo;
                        tree.text = cls.ClassName + "(共：" + stucount + "人)";
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
                    tree.text = major.MajorName + "(共" + hasChildren2 + "个班)";
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
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
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
        /// 获取子表详细信息 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetDetailsJson(string keyValue)
        {
            var data = bk_classinfobll.GetDetails(keyValue);
            return ToJsonResult(data);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var data = bk_classinfobll.GetPageList(null, queryJson);
            return Content(data.ToJson());
        }


        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            bk_classinfobll.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, string strEntity,string strChildEntitys)
        {
            var entity = strEntity.ToObject<BK_ClassInfoEntity>();
            var childEntitys = strChildEntitys.ToList<BK_StuClassEntity>();
            bk_classinfobll.SaveForm(keyValue, entity, childEntitys);
            return Success("操作成功。");
        }
        #endregion

        #region 分班运算
        /// <summary>
        /// 分班运算
        /// </summary>
        /// <param name="secRule">规则</param>
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
             *                 entity.StuOther = "未分班"; //分班标志
                entity.GuiDangMark = "未归档";//只有新生才没有归档
                entity.TransMark = "0";//只有新生才没有归档
             */
            string curryear = dt.ToString("yyyy");//得到当前的年 
            string queryJson = (new { Grade = curryear }).ToJson();
            List<BK_ClassInfoEntity> classlist = bk_classinfobll.GetList(queryJson);//得到所有的当前年的新班级,也是要分班的班级
            HashSet<string>  majornolist = new HashSet<string>();//得到不重复的专业号列表
            foreach (var classentity in classlist)
            {
                majornolist.Add(classentity.MajorNo);    //得到不重复的专业号            
            }
            queryJson = (new { newstu = "newstu" }).ToJson();//得到查询参数
            List<BK_StuInfoEntity> stuNewList = stubll.GetList(queryJson);//查询出所有的未分班新生

            #region 循环所有专业，按专业来进行分班
            foreach (var majorno in majornolist)//得到按专业的班级和新生
            {
                int stunewcount = 0;
                List<BK_ClassInfoEntity> classByMajorList = classlist.FindAll(s => s.MajorNo.Equals(majorno));//当前年的这个专业下面的所有班级
                List<BK_StuInfoEntity> stuNewByMajorList = stuNewList.FindAll(s=>s.MajorNo.Equals(majorno) && s.StuOther.Equals("未分班"));//查询出所有的未分班的这个专业的新生
                
                if (classByMajorList.Count==1 )
                {//如果这个专业下面的班级只有1个的情况下，就把这个学生全部添加 到这个班级里去  
                   // bk_classinfobll.InsertStuCls(classByMajorList[0].ClassId, stuNewByMajorList);
                    bk_classinfobll.InsertStuCls(classByMajorList[0].ClassNo, stuNewByMajorList);
                }
                else
                {
                    #region 循环专业下面的所有的班级
                    if (!string.IsNullOrEmpty(secRule))
                    {
                        #region 性别
                        if (ruleList.Contains("性别"))
                        {
                            stuNewByMajorList.Sort(BK_StuInfoEntity.CompareByGender);
                        }
                        #endregion
                        #region 按地区排序
                        if (ruleList.Contains("地区"))
                        {
                            stuNewByMajorList.Sort(BK_StuInfoEntity.CompareByProv);
                            stuNewByMajorList.Sort(BK_StuInfoEntity.CompareByCity);
                            stuNewByMajorList.Sort(BK_StuInfoEntity.CompareByDest);
                        }
                        #endregion
                        #region 成绩排序
                        if (ruleList.Contains("成绩"))
                        {
                            //stuNewByMajorList.Sort((BK_StuInfoEntity mx, BK_StuInfoEntity my) => //该方法实现的是将Asm由大到小的排序
                            //{
                            //    if (mx.HighAmountScore > my.HighAmountScore) return -1;  //返回-1表示mx被认定排序值小于my,所以排在前面
                            //    else if (mx.HighAmountScore < my.HighAmountScore) return 1; //返回1 表示mx被认定排序值大于my,所以排在后面.
                            //    else return 0;
                            //});
                            stuNewByMajorList.Sort(BK_StuInfoEntity.CompareByScore);
                        }
                        #endregion
                        #region 民族排序
                        if (ruleList.Contains("民族"))
                        {
                            stuNewByMajorList.Sort(BK_StuInfoEntity.CompareByNation);
                        }
                        #endregion
                    }

                    /*
                     * 只有在这个专业下面大于2个班级的情况下才会有排序分班
                     */
                    foreach (var clsentity in classByMajorList) // 按班级进行分班
                    {
                        //var stuclslist = bk_classinfobll.GetDetails_old(clsentity.ClassId); //得到这个班级下面所有的学生
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

            return Success("操作成功。");
        }
        #endregion

        #region 学号生成
        /// <summary>
        /// 学号生成
        /// </summary>
        /// <param name="secRule">规则</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult CreateStuNo(string stunorule)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string fno = "";//前置值
            int ycount = 0;//使用年的长度
            int depcount = 0;//使用院系号长度
            int mjcount = 0;//使用专业号长度
            int clscount = 0;//使用班级号长度
            int lastcount = 0;//尾号长度
            if (!string.IsNullOrEmpty(stunorule))
            {
                dic = stunorule.ToObject<Dictionary<string,object>>();
                if (dic.Count>0)
                {
                    //是否要前置
                    var hasfrant = dic["chfrant"].ToString();// 是否使用前置
                    if (hasfrant=="1")
                    {
                        fno = dic["frantno"].ToString();//前置值
                    }
                    var useyear = dic["useyear"].ToString();//是否使用年份
                    if (useyear=="1")
                    {
                        ycount = dic["secyear"].ToString()!=""? Convert.ToInt32(dic["secyear"]):0;//年份使用长度
                    }
                    var chkdeptno = dic["chkdeptno"].ToString();//是否使用院系
                    if (chkdeptno=="1")
                    {
                        depcount = dic["deptnocount"].ToString()!=""?Convert.ToInt32(dic["deptnocount"]):0;//院系号使用长度
                    }
                    var majorno = dic["majorno"].ToString();//是否使用专业
                    if (majorno=="1")
                    {
                        mjcount = dic["majornocount"].ToString() != "" ? Convert.ToInt32(dic["majornocount"]) : 0;//专业号使用长度
                    }
                    
                    var chkclsno = dic["chkclsno"].ToString();//是否使用班级
                    if (chkclsno=="1")
                    {
                        clscount = dic["clsnocount"].ToString() != "" ? Convert.ToInt32(dic["clsnocount"]) : 0;//班级号使用长度
                    }
                    lastcount = dic["lastnocount"].ToString() != "" ? Convert.ToInt32(dic["lastnocount"]) : 0;//最后尾号的长度
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

            string curryear = dt.ToString("yyyy");//得到当前的年           
            string queryJson = (new { Grade = curryear }).ToJson();
            List<BK_ClassInfoEntity> classlist = bk_classinfobll.GetList(queryJson);//得到所有的当前年的新班级,也是要分班的班级
            HashSet<string> majordetailnoList = new HashSet<string>();//得到不重复的专业方向列表
           
            foreach (var classentity in classlist)
            {
                majordetailnoList.Add(classentity.MajorDetailNo);    //得到不重复的专业方向号   
                string newstuno = fno;//学号初始值
                #region 得到院系号
                if (depcount>0)//如果使用院系号长度大于零
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

                #region 得到专业号
                if (mjcount > 0)//如果使用专业号长度大于零
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

                #region 得到班级号
                if (clscount > 0)//如果使用专业号长度大于零
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
                    if (!string.IsNullOrEmpty( stuentity.StuNo))//只有学号为空的情况下才生成学号
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
                    stuentity.StuNo = newstuno + lastno;//得到学生的学号
                    stubll.SaveForm(stuentity.stuInfoId, stuentity, null);//修改学生的学号
                }
            }



            return Success("操作成功");
        }
        #endregion

    }
}
