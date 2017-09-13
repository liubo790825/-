using LeaRun.Application.Busines.CollegeMIS;
using LeaRun.Application.Busines.SystemManage;
using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.Entity.SystemManage;
using Nancy.Responses.Negotiation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaRun.Application.AppSerivce.Modules
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技
    /// 创建人：陈彬彬
    /// 日 期：2016.05.19 13:57
    /// 描 述：获取行政区域信息
    /// </summary>
    public class BaseDataModule : BaseModule
    {
        private AreaBLL areaBLL = new AreaBLL();
        public BaseDataModule()
            : base("/learun/api")
        {
            Post["/BaseData/getBaseData"] = getBaseData;
        }

        private AreaBLL areaCache = new AreaBLL();
        private BK_SchoolAreaBLL sareabll = new BK_SchoolAreaBLL();
        private BK_DeptBLL deptbll = new BK_DeptBLL();
        private BK_MajorBLL mbll = new BK_MajorBLL();
        private BK_MajorDetailBLL mdbll = new BK_MajorDetailBLL();
        private BK_ClassInfoBLL clbll = new BK_ClassInfoBLL();

        private BK_DormBuildingBLL bbll = new BK_DormBuildingBLL();
        private BK_DormUnitBLL ubll = new BK_DormUnitBLL();
        private BK_DormFloorsBLL fbll = new BK_DormFloorsBLL();
        private BK_DormBLL dbll = new BK_DormBLL();

        #region 获取单个数据转换
        public Negotiator getBaseData(dynamic _)
        {
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            //bool resValidation = this.DataValidation(recdata.userid, recdata.token);
            //if (!resValidation)
            //{
            //    return this.SendData(ResponseType.Fail, "无该用户登录信息");
            //}
            //else
            {
                //"{\"stuInfoId\":\"010F79B8-5FFD-4071-9830-A6A64D4A5D3B\",\"noticeNo\":\"201600029\",\"ksh\":\"15140603132042\",\"zkzh\":\"15140603132042\",\"stuNo\":\"1502091029\",\"stuName\":\"阿克来拉依·努尔巴依\",\"deptNo\":\"2\",\"gender\":\"男\",\"majorNo\":\"9\",\"majorDetailNok\":null,\"majorDetailName\":null,\"birthday\":\"1995-03-07T00:00:00.0000000+08:00\",\"partyFaceNo\":\"群众\",\"familyOriginNo\":null,\"nationalityNo\":null,\"residenceNo\":null,\"testStuSortNo\":\"应届\",\"healthStatusNo\":\"健康\",\"willNo\":\"1\",\"testStuSubjectNo\":\"应届\",\"graduateNo\":\"本科\",\"planFormNo\":\"计划内\",\"highTestSortNo\":\"普通\",\"highAmountScore\":345.08,\"politicsScore\":0,\"chineseScore\":0,\"mathScore\":0,\"physicsScore\":0,\"chemScore\":0,\"biologyScore\":0,\"foreignLangScore\":0,\"foreignLangOralScore\":0,\"foreignLangSpecies\":\"英语\",\"isThreeGood\":\"0\",\"isExcellent\":\"0\",\"isNormalCadre\":\"0\",\"isProvinceFirstThree\":\"0\",\"overseasChineseNo\":\"0\",\"matriculateSort\":\"普通\",\"provinceNo\":\"14\",\"highSchoolNo\":null,\"regionNo\":\"朔州市平鲁区\",\"remark\":null,\"recruitYearDate\":\"06  2 2016 10:49PM\",\"classNo\":\"123\",\"identityCardNo\":\"140603199503070531\",\"highSchoolName\":null,\"goodAt\":null,\"arriveDate\":\"2016-09-01T00:00:00.0000000+08:00\",\"archivesNo\":null,\"telephone\":\"13834970011\",\"stuFromProvince\":\"朔州市平鲁区\",\"stuFromCity\":\"朔州市平鲁区\",\"stuFromDestrict\":\"朔州市平鲁区\",\"famliyProvince\":\"朔州市平鲁区\",\"famliyCity\":\"朔州市平鲁区\",\"famliyDistrict\":\"朔州市平鲁区\",\"familyAddress\":\"山西省朔州市平鲁区平安东街医院小区2-3-401\",\"registerStatus\":\"否\",\"mailAddress\":\"山西省朔州市平鲁区平安东街医院小区2-3-401\",\"postalCode\":\"036800\",\"transMark\":\"否\",\"logIp\":null,\"logNum\":null,\"logtime\":null,\"recruitDeptNo\":null,\"recruitMajorNo\":null,\"registerEmpNo\":null,\"registerEmpName\":null,\"approvedLeader\":null,\"changeReason\":null,\"changeDate\":null,\"textNo\":null,\"grade\":\"2017\",\"famliyPeoples\":3,\"headImg\":\"http://59.48.7.222:9000/Photos/StuPhotos/16/16141003150209.jpg\",\"deformity\":\"0\",\"singleParent\":\"0\",\"isMarry\":\"0\",\"orphan\":\"0\",\"martyrChildren\":\"0\",\"basicLivingAllowances\":\"0\",\"phoneNoUseId\":\"0\",\"parentPhone\":null,\"parentTel\":null,\"graduation\":\"0\",\"stuPwd\":\"e10adc3949ba59abbe56e057f20f883e\",\"stuOther\":null,\"stuOther1\":null,\"stuOther2\":null,\"stuOther3\":null,\"stuOther4\":null,\"stuOther5\":null,\"stuOther6\":null,\"stuOther7\":null,\"stuOther8\":null,\"stuOther9\":null,\"printNotice\":null}"
                try
                {
                    var queryParam = Newtonsoft.Json.Linq.JObject.Parse(recdata.data.queryData);
                    //if (queryParam["deptNo"] != null && queryParam["deptNo"].ToString() != "")//deptNo
                    //{
                    //    string deptNo = queryParam["deptNo"].ToString();
                    //}
                    //if (queryParam["majorNo"] != null && queryParam["majorNo"].ToString() != "")//majorNo
                    //{
                    //    string majorNo = queryParam["majorNo"].ToString();
                    //}
                    //if (queryParam["majorDetailNok"] != null && queryParam["majorDetailNok"].ToString() != "")//majorDetailNok
                    //{
                    //    string majorDetailNok = queryParam["majorDetailNok"].ToString();
                    //}
                    //if (queryParam["nationalityNo"] != null && queryParam["nationalityNo"].ToString() != "")//nationalityNo
                    //{
                    //    string nationalityNo = queryParam["nationalityNo"].ToString();
                    //}
                    //if (queryParam["provinceNo"] != null && queryParam["provinceNo"].ToString() != "")//provinceNo
                    //{
                    //    string provinceNo = queryParam["provinceNo"].ToString();
                    //}

                    //if (queryParam["stuFromProvince"] != null && queryParam["stuFromProvince"].ToString() != "")//stuFromProvince
                    //{
                    //    string stuFromProvince = queryParam["stuFromProvince"].ToString();
                    //}

                    //if (queryParam["stuFromCity"] != null && queryParam["stuFromCity"].ToString() != "")//stuFromCity
                    //{
                    //    string stuFromCity = queryParam["stuFromCity"].ToString();
                    //}
                    //if (queryParam["famliyDistrict"] != null && queryParam["famliyDistrict"].ToString() != "")//famliyDistrict
                    //{
                    //    string famliyDistrict = queryParam["famliyDistrict"].ToString();
                    //}


                    //if (queryParam["recruitDeptNo"] != null && queryParam["recruitDeptNo"].ToString() != "")//recruitDeptNo
                    //{
                    //    string recruitDeptNo = queryParam["recruitDeptNo"].ToString();
                    //}
                    //if (queryParam["recruitMajorNo"] != null && queryParam["recruitMajorNo"].ToString() != "")//recruitMajorNo
                    //{
                    //    string recruitMajorNo = queryParam["recruitMajorNo"].ToString();
                    //}
                    //if (queryParam["classNo"] != null && queryParam["classNo"].ToString() != "")//deptNo
                    //{
                    //    string classNo = queryParam["classNo"].ToString();
                    //}
                    var queryData = recdata.data.queryData;
                    var data = new
                    {
                        areaName = this.GetAreaName(queryData),            //得到地区    
                        schoolName =this.GetShoolAreaName(queryData),//得到校区
                        deptName = (queryParam["deptNo"] == null || queryParam["deptNo"].ToString() == "") ? null : this.GetDeptName(queryData),//得到系
                        majorName = (queryParam["majorNo"] == null || queryParam["majorNo"].ToString() == "") ? null : this.GetMajorName(queryData),//得到专业
                        majordetailName = (queryParam["majorDetailNok"] == null || queryParam["majorDetailNok"].ToString() == "") ? null : this.GetMajorDetailName(queryData),//得到专业方向
                        className = (queryParam["classNo"] == null || queryParam["classNo"].ToString() == "") ? null : this.GetClassName(queryData),//得到班名

                        buildingName = this.GetDormBuildingName(queryData),//得到宿舍楼
                        unitName = this.GetDormUnitName(queryData),//得到单元数据
                        floorsName = this.GetDormFloorsName(queryData),//得到楼层
                        dormName = this.GetDormName(queryData) //得到宿舍房间
                    };
                    return this.SendData(data, recdata.userid, recdata.token, ResponseType.Success);
                }catch(Exception ex)
                {
                    return this.SendData(ResponseType.Fail, "出错"+ex.Message);
                }
            }//
        }


        /// <summary>
        /// 得到地区名
        /// </summary>
        /// <returns></returns>
        private string GetAreaName(string queryJson)
        {
            //IEnumerable<AreaEntity> list = this.areaCache.GetList().Where(s=>s.AreaCode==;
            
            return "";
        }

        /// <summary>
        /// 得到校区名
        /// </summary>
        /// <returns></returns>
        private string GetShoolAreaName(string queryJson)
        {
            IEnumerable<BK_SchoolAreaEntity> list = this.sareabll.GetList(queryJson);
            return list.Count()==0 ? "": list.FirstOrDefault().AreaName;
        }

        /// <summary>
        /// 查询系名
        /// </summary>
        /// <returns></returns>
        private object GetDeptName(string queryJson)
        {
            IEnumerable<BK_DeptEntity> list = this.deptbll.GetPageList(null, queryJson);
            return list.Count()==0 ? "": list.FirstOrDefault().DeptName;
        }

        /// <summary>
        /// 查询专业名
        /// </summary>
        /// <returns></returns>
        private object GetMajorName(string queryJson)
        {
            IEnumerable<BK_MajorEntity> list = this.mbll.GetPageList(null, queryJson);
            return list.Count()==0 ? "": list.FirstOrDefault().MajorName;
        }

        private object GetMajorDetailName(string queryJson)
        {
            IEnumerable<BK_MajorDetailEntity> list = this.mdbll.GetPageList(null, queryJson);
            return list.Count() == 0 ? "" : list.FirstOrDefault().MajorDetailName;
        }

        private object GetClassName(string queryJson)
        {
            IEnumerable<BK_ClassInfoEntity> list = this.clbll.GetPageList(null, queryJson);
            return list.Count() == 0 ? "" : list.FirstOrDefault().ClassName;
        }


        /// <summary>
        /// 得到宿舍楼名
        /// </summary>
        /// <returns></returns>
        private object GetDormBuildingName(string queryJson)
        {
            IEnumerable<BK_DormBuildingEntity> list = this.bbll.GetPageList(null, queryJson);
            return list.Count() == 0 ? "" : list.FirstOrDefault().DormBuildingName;
        }

        //得到单元名
        private object GetDormUnitName(string queryJson)
        {
            IEnumerable<BK_DormUnitEntity> list = this.ubll.GetPageList(null, queryJson);
            return list.Count() == 0 ? "" : list.FirstOrDefault().DormUnitName;
        }

        /// <summary>
        /// 得到楼层名
        /// </summary>
        /// <returns></returns>
        private object GetDormFloorsName(string queryJson)
        {
            IEnumerable<BK_DormFloorsEntity> list = this.fbll.GetPageList(null, queryJson);
            return list.Count() == 0 ? "" : list.FirstOrDefault().DormFloorsName;
        }

        private object GetDormName(string queryJson)
        {
            IEnumerable<BK_DormEntity> list = this.dbll.GetPageList(null, queryJson);
            return list.Count() == 0 ? "" : list.FirstOrDefault().DormName;
        }

        #endregion 获取单个数据转换

        #region 获得数据集合

        public Negotiator getBaseDataList(dynamic _)
        {
            var recdata = this.GetModule<ReceiveModule<BK_StuInfoEntity>>();
            bool resValidation = this.DataValidation(recdata.userid, recdata.token);
            if (!resValidation)
            {
                return this.SendData(ResponseType.Fail, "无该用户登录信息");
            }
            else
            {
                var data = new
                {
                    areaData = this.GetAreaList(),            //得到地区数据    
                    schoolData = this.GetShoolAreaList(),//得到所有的校区
                    deptData = this.GetBK_DeptList(),//得到所有系
                    majorData = this.GetBK_MajorList(),//得到所有的专业
                    majordetailData = this.GetBK_MajorDetailList(),//得到所有的专业方向

                    buildingData = this.GetBK_DormBuildingList(),//得到所有的宿舍楼
                    unitData = this.GetBK_DormUnitList(),//得到所有的单元数据
                    floorsData = this.GetBK_DormFloorsList(),//得到所有的楼层
                    dormData = this.GetBK_DormList() //得到所有的宿舍房间
                };
                return this.SendData(data, recdata.userid, recdata.token, ResponseType.Success);
            }
        }

        /// <summary>
        /// 得到地区数据
        /// </summary>
        /// <returns></returns>
        private object GetAreaList()
        {
            IEnumerable<AreaEntity> list = this.areaCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (AreaEntity area in list)
            {
                var value = new
                {
                    EnCode = area.AreaCode,
                    FullName = area.AreaName
                };
                dictionary.Add(area.AreaId, value);
            }
            return dictionary;
        }

        /// <summary>
        /// 得到校区的数据
        /// </summary>
        /// <returns></returns>
        private object GetShoolAreaList()
        {
            IEnumerable<BK_SchoolAreaEntity> list = this.sareabll.GetList(null);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (BK_SchoolAreaEntity area in list)
            {
                var value = new
                {
                    EnCode = area.AreaId,
                    FullName = area.AreaName
                };
                dictionary.Add(area.AreaId, value);
            }
            return dictionary;
        }

        /// <summary>
        /// 查询所有的系
        /// </summary>
        /// <returns></returns>
        private object GetBK_DeptList()
        {
            IEnumerable<BK_DeptEntity> list = this.deptbll.GetPageList(null,null);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (BK_DeptEntity area in list)
            {
                var value = new
                {
                    EnCode = area.DeptNo,
                    FullName = area.DeptName,
                    Areaid= area.AreaId
                };
                dictionary.Add(area.DeptNo, value);
            }
            return dictionary;
        }

        /// <summary>
        /// 查询所有的专业
        /// </summary>
        /// <returns></returns>
        private object GetBK_MajorList()
        {
            IEnumerable<BK_MajorEntity> list = this.mbll.GetPageList(null, null);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (BK_MajorEntity major in list)
            {
                var value = new
                {
                    EnCode = major.DeptNo,
                    FullName = major.MajorName,
                    Majorid = major.MajorId
                };
                dictionary.Add(major.MajorNo, value);
            }
            return dictionary;
        }

        private object GetBK_MajorDetailList()
        {
            IEnumerable<BK_MajorDetailEntity> list = this.mdbll.GetPageList(null, null);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (BK_MajorDetailEntity major in list)
            {
                var value = new
                {
                    EnCode = major.MajorDetailNo,
                    FullName = major.MajorDetailName,
                    ID = major.ID
                };
                dictionary.Add(major.MajorDetailNo, value);
            }
            return dictionary;
        }

        /// <summary>
        /// 得到所有的宿舍楼
        /// </summary>
        /// <returns></returns>
        private object GetBK_DormBuildingList()
        {
            IEnumerable<BK_DormBuildingEntity> list = this.bbll.GetPageList(null, null);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (BK_DormBuildingEntity building in list)
            {
                var value = new
                {
                    EnCode = building.DormBuildingNo,
                    FullName = building.DormBuildingName
                };
                dictionary.Add(building.DormBuildingId, value);
            }
            return dictionary;
        }

        private object GetBK_DormUnitList()
        {
            IEnumerable<BK_DormUnitEntity> list = this.ubll.GetPageList(null, null);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (BK_DormUnitEntity unit in list)
            {
                var value = new
                {
                    Parentid = unit.DormBuildingId,
                    EnCode = unit.DormUnitNo,
                    FullName = unit.DormUnitName
                };
                dictionary.Add(unit.DormUnitId, value);
            }
            return dictionary;
        }

        /// <summary>
        /// 得到所有的楼层
        /// </summary>
        /// <returns></returns>
        private object GetBK_DormFloorsList()
        {
            IEnumerable<BK_DormFloorsEntity> list = this.fbll.GetPageList(null, null);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (BK_DormFloorsEntity floor in list)
            {
                var value = new
                {
                    Parent_Parentid= floor.DormBuildingId,
                    Parentid = floor.DormUnitId,
                    EnCode = floor.DormFloorsNo,
                    FullName = floor.DormFloorsName
                };
                dictionary.Add(floor.DormFloorsId, value);
            }
            return dictionary;
        }

        private object GetBK_DormList()
        {
            IEnumerable<BK_DormEntity> list = this.dbll.GetPageList(null, null);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (BK_DormEntity floor in list)
            {
                var value = new
                {
                    buildid = floor.DormBuildingId,
                    unitid = floor.DormUnitId,
                    floorid = floor.DormFloorsId,
                    EnCode = floor.DormNo,
                    FullName = floor.DormName
                };
                dictionary.Add(floor.DormId, value);
            }
            return dictionary;
        }

        #endregion 获得数据集合
    }
}
