using LeaRun.Application.Entity.ArrangeLesson;
using LeaRun.Application.Busines.ArrangeLesson;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Web.Mvc;
using System.Collections.Generic;

namespace LeaRun.Application.Web.Areas.ArrangeLesson.Controllers
{
    /// <summary>
    /// 课程明细
    /// </summary>
    public class CourseInfor
    {
        /// <summary>
        /// 专业名称
        /// </summary>
        public string majorName { get; set; }

        /// <summary>
        /// 课程号
        /// </summary>
        public   string lessonNo { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        public string lessonName { get; set; }

        /// <summary>
        /// 考核方式
        /// </summary>
        public string testType { get; set; }
        /// <summary>
        /// 学分
        /// </summary>
        public decimal xueFen { get; set; }
        /// <summary>
        /// 总学时数
        /// </summary>
        public int totalHours { get; set; }
        /// <summary>
        /// 理论教学
        /// </summary>
        public int theoryHours { get; set; }
        /// <summary>
        /// 实践或技能
        /// </summary>
        public int practiceHours { get; set; }
        /// <summary>
        /// 一学期周学时/周数
        /// </summary>
        public string term1 { get; set; }
        /// <summary>
        /// 二学期周学时/周数
        /// </summary>
        public string term2 { get; set; }
        /// <summary>
        /// 三学期周学时/周数
        /// </summary>
        public string term3 { get; set; }
        /// <summary>
        /// 四学期周学时/周数
        /// </summary>
        public string term4 { get; set; }
        /// <summary>
        /// 五学期周学时/周数
        /// </summary>
        public string term5 { get; set; }
        /// <summary>
        /// 六学期周学时/周数
        /// </summary>
        public string term6 { get; set; }
    }

    /// <summary>
    /// 课程类型：必修课或选修课
    /// </summary>
    public class ChosenType
    {
        /// <summary>
        /// 类型名称：必修课或选修课
        /// </summary>
        public string chosenName { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        public List<CourseInfor> courseInfoList {get;set; } 
    }

    /// <summary>
    /// 公共课或专业课
    /// </summary>
    public class ProfessionalType
    {
        /// <summary>
        /// 课程类型：公开课或专业课
        /// </summary>
      public string professionalName { get; set; }

        /// <summary>
        /// 必修课或选修课
        /// </summary>
        public List<ChosenType> choseTypeList { get; set; }
    }


    /// <summary>
    /// 教学进程
    /// </summary>
    public class TeachingProcessController : MvcControllerBase
    {
        private TrainingPlanBLL trainingplanbll = new TrainingPlanBLL();
        private InfoMajorBLL mbll = new InfoMajorBLL();


        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            #region 得到所有的专业
            var majorList = mbll.GetList(null);
            List<string> majorNameList = new List<string>();
            foreach (var major in majorList)
            {
                majorNameList.Add(major.MajorName);
            }
            ViewBag.majorNameList = majorNameList;
            #endregion
            //var trainingList = GetList("{\"Major\":\"电子信息工程技术\"}"); 
            //List<ProfessionalType> proTypeList = GetProfessTypeList(trainingList); 
            //ViewBag.protypeList = proTypeList;

            return View();
        }

        public IEnumerable<TrainingPlanEntity> GetList(string strJson)
        {
            Pagination pagination = new Pagination();
            pagination.page = 1;
            pagination.rows = 200;
            pagination.records = 0;
            pagination.sidx = "TrainingPlanId";
            pagination.sord = "esc";
            return trainingplanbll.GetPageListForProcess(pagination, strJson);
        }


        /// <summary>
        /// 返回公共课和专业课的集合
        /// </summary>
        /// <param name="trainingList">查询得到的数据</param>
        /// <returns></returns>
        public List<ProfessionalType> GetProfessTypeList(IEnumerable<TrainingPlanEntity> trainingList)
        {
            List<ProfessionalType> professTypeList = new List<ProfessionalType>();
            {
                ProfessionalType proType = new ProfessionalType();
                proType.professionalName = "公共课";
                List < ChosenType > choseTypeList = GetChosenTypeList("公共", trainingList);
                if (choseTypeList.Count>0)
                {
                    proType.choseTypeList = choseTypeList;
                    professTypeList.Add(proType);
                }
            }
            {
                ProfessionalType proType = new ProfessionalType();
                proType.professionalName = "专业课";
                List<ChosenType> choseTypeList = GetChosenTypeList("专业", trainingList);
                if (choseTypeList.Count > 0)
                {
                    proType.choseTypeList = choseTypeList;
                    professTypeList.Add(proType);
                }
            }
            return professTypeList;
        }


        /// <summary>
        /// 返回必修课和选修课的list
        /// </summary>
        /// <param name="professType">公共、专业</param>
        /// <param name="trainingList">查询出来的原始数据</param>
        /// <returns></returns>
        public List<ChosenType> GetChosenTypeList(string professType, IEnumerable<TrainingPlanEntity> trainingList)
        {
            List<ChosenType> choseTypeList = new List<ChosenType>();
            {
                string mustType = "必修课";
                ChosenType ct = new ChosenType();
                ct.chosenName = mustType;
                List<CourseInfor> courseInfoList = GetCourseInfo(trainingList, professType+ mustType);
                if (courseInfoList.Count > 0)
                {
                    ct.courseInfoList = courseInfoList;
                    choseTypeList.Add(ct);
                }
            }
            {
                string mustType = "选修课";
                ChosenType ct = new ChosenType();
                ct.chosenName = mustType;
                List<CourseInfor> courseInfoList = GetCourseInfo(trainingList, professType + mustType);
                if (courseInfoList.Count > 0)
                {
                    ct.courseInfoList = courseInfoList;
                    choseTypeList.Add(ct);
                }
            }
            return choseTypeList;
        }

        /// <summary>
        /// 返回课程的集合
        /// </summary>
        /// <param name="trainingList"></param>
        /// <param name="lsnType"></param>
        /// <returns></returns>
        public List<CourseInfor> GetCourseInfo(IEnumerable<TrainingPlanEntity> trainingList,string lsnType)
        {
            List<CourseInfor> courseInfoList = new List<CourseInfor>();
            foreach (var pt in trainingList)
            {
                if (!pt.LessonType.Equals(lsnType))
                {
                    continue;
                }
                CourseInfor courseinfo = new CourseInfor();
                courseinfo.majorName = pt.Major;
                courseinfo.lessonNo = pt.LessonNo;
                courseinfo.lessonName = pt.LessonName;
                string testType = "";
                decimal totalXueFen = 0;//总学分
                int theoryHours = 0;//理论学时
                int practiceHours = 0;//实践或技能学时

                #region 循环查询这个课程所有学期的信息，并记录

                foreach (var proLession in trainingList)
                {
                    if (proLession.LessonType.Equals(lsnType) && proLession.LessonNo.Equals(pt.LessonNo))
                    {
                        #region 得到哪个学期是考试或考查
                        if (proLession.TestType.Equals("考试") && !testType.Contains("S"))
                        {
                            if (string.IsNullOrEmpty(testType))
                            {
                                testType = proLession.Semester + "S";
                            }
                            else
                            {
                                if (testType.Contains("/"))
                                {
                                    testType += proLession.Semester + "S";
                                }
                                else
                                {
                                    testType += "/" + proLession.Semester + "S";
                                }
                            }
                        }
                        else if (proLession.TestType.Equals("考查") && !testType.Contains("C"))
                        {
                            if (string.IsNullOrEmpty(testType))
                            {
                                testType = proLession.Semester + "C";
                            }
                            else
                            {
                                if (testType.Contains("/"))
                                {
                                    testType += proLession.Semester + "C";
                                }
                                else
                                {
                                    testType += "/" + proLession.Semester + "C";
                                }
                            }
                        }
                        #endregion
                        theoryHours += (proLession.TheoryHours != null ? proLession.TheoryHours.Value : 0); //理论学时
                        practiceHours += (proLession.PracticeHourse != null ? proLession.PracticeHourse.Value : 0);//实践或技能学时
                        totalXueFen += (proLession.Xuefen != null ? proLession.Xuefen.Value : 0);//学分
                        if (proLession.Semester != null)
                        {
                            if (proLession.Semester.Value == 1)
                            {
                                courseinfo.term1 = (proLession.EveryWeekStudyTimes != null ? proLession.EveryWeekStudyTimes.Value : 0) + "/" + (proLession.WeekTotal != null ? proLession.WeekTotal.Value : 0);
                            }
                            if (proLession.Semester.Value == 2)
                            {
                                courseinfo.term2 = (proLession.EveryWeekStudyTimes != null ? proLession.EveryWeekStudyTimes.Value : 0) + "/" + (proLession.WeekTotal != null ? proLession.WeekTotal.Value : 0);
                            }
                            if (proLession.Semester.Value == 3)
                            {
                                courseinfo.term3 = (proLession.EveryWeekStudyTimes != null ? proLession.EveryWeekStudyTimes.Value : 0) + "/" + (proLession.WeekTotal != null ? proLession.WeekTotal.Value : 0);
                            }
                            if (proLession.Semester.Value == 4)
                            {
                                courseinfo.term4 = (proLession.EveryWeekStudyTimes != null ? proLession.EveryWeekStudyTimes.Value : 0) + "/" + (proLession.WeekTotal != null ? proLession.WeekTotal.Value : 0);
                            }
                            if (proLession.Semester.Value == 5)
                            {
                                courseinfo.term5 = (proLession.EveryWeekStudyTimes != null ? proLession.EveryWeekStudyTimes.Value : 0) + "/" + (proLession.WeekTotal != null ? proLession.WeekTotal.Value : 0);
                            }
                            if (proLession.Semester.Value == 6)
                            {
                                courseinfo.term6 = (proLession.EveryWeekStudyTimes != null ? proLession.EveryWeekStudyTimes.Value : 0) + "/" + (proLession.WeekTotal != null ? proLession.WeekTotal.Value : 0);
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                #endregion

                if (!testType.Contains("/"))
                {
                    if (testType.Contains("S"))
                    {
                        testType = "S";
                    }
                    if (testType.Contains("C"))
                    {
                        testType = "C";
                    }
                }
                courseinfo.testType = testType;
                courseinfo.practiceHours = practiceHours;//实践或技能学时
                courseinfo.theoryHours = theoryHours;//理论学时
                courseinfo.totalHours = practiceHours + theoryHours;//总学时
                courseinfo.xueFen = totalXueFen;//学分
                courseInfoList.Add(courseinfo);//增加一个课程的内容
            }
            return courseInfoList;

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
            var data = trainingplanbll.GetPageList(pagination, queryJson);
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
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetProcessListJson(Pagination pagination, string queryJson)
        {
            if (string.IsNullOrEmpty(queryJson))
            {
                queryJson = "{\"Major\":\"电子信息工程技术\"}";
            }
            var trainingList = GetList(queryJson);
            List<ProfessionalType> proTypeList = GetProfessTypeList(trainingList);
            return ToJsonResult(proTypeList);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var data = trainingplanbll.GetList(queryJson);
            return ToJsonResult(data);
        }

        


        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = trainingplanbll.GetEntity(keyValue);
            return ToJsonResult(data);
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
            trainingplanbll.RemoveForm(keyValue);
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
        public ActionResult SaveForm(string keyValue, TrainingPlanEntity entity)
        {
            trainingplanbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
