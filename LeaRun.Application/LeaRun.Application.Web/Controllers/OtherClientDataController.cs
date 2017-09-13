using LeaRun.Application.Busines.SystemManage;
using LeaRun.Application.Entity.SystemManage;
using LeaRun.Application.Entity.SystemManage.ViewModel;
using LeaRun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeaRun.Application.Busines.CollegeMIS;
using LeaRun.Application.Entity.CollegeMIS;

namespace LeaRun.Application.Web.Controllers
{

    /// <summary>
    /// 其它数据
    /// </summary>
    public class OtherClientDataController : MvcControllerBase
    {
        private AreaBLL areaCache = new AreaBLL();
        private BK_SchoolAreaBLL sareabll = new BK_SchoolAreaBLL();
        private BK_DeptBLL deptbll = new BK_DeptBLL();
        private BK_MajorBLL mbll = new BK_MajorBLL();
        private BK_MajorDetailBLL mdbll = new BK_MajorDetailBLL();
        private BK_ClassInfoBLL cbll = new BK_ClassInfoBLL();

        private BK_DormBuildingBLL bbll = new BK_DormBuildingBLL();
        private BK_DormUnitBLL ubll = new BK_DormUnitBLL();
        private BK_DormFloorsBLL fbll = new BK_DormFloorsBLL();
        private BK_DormBLL dbll = new BK_DormBLL();

        private BK_NewStuRegFlowBLL flowbll = new BK_NewStuRegFlowBLL();

        [AjaxOnly(false), HttpPost]
        public ActionResult GetOtherClientDataJson()
        {
            var data = new
            {
                areaData = this.GetAreaList(),            //得到地区数据    
                schoolData = this.GetShoolAreaList(),//得到所有的校区
                deptData = this.GetBK_DeptList(),//得到所有系
                majorData = this.GetBK_MajorList(),//得到所有的专业
                majordetailData = this.GetBK_MajorDetailList(),//得到所有的专业方向
                classData = this.GetBK_ClassInfoList(),//班级信息

                buildingData = this.GetBK_DormBuildingList(),//得到所有的宿舍楼
                unitData = this.GetBK_DormUnitList(),//得到所有的单元数据
                floorsData = this.GetBK_DormFloorsList(),//得到所有的楼层
                dormData = this.GetBK_DormList(), //得到所有的宿舍房间

                flowData = this.GetAuthorFlowList()//得到当前用户新生报到可以操作的流程
            };
            return this.ToJsonResult(data);
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

        private object GetBK_ClassInfoList()
        {
            IEnumerable<BK_ClassInfoEntity> list = this.cbll.GetPageList(null, null);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (BK_ClassInfoEntity cinfo in list)
            {
                var value = new
                {
                    EnCode = cinfo.ClassNo,
                    FullName = cinfo.ClassName,
                    ID = cinfo.ClassNo
                };
                dictionary.Add(cinfo.ClassNo, value);
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

        /// <summary>
        /// 根据当前用户得到所有的可以操作的报到流程
        /// </summary>
        /// <returns></returns>
        private object GetAuthorFlowList()
        {
            IEnumerable<BK_NewStuRegFlowEntity> allFlowlist = this.flowbll.GetList(null);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (BK_NewStuRegFlowEntity flow in allFlowlist)
            {
                var value = new
                {
                    EnCode = flow.ID,
                    FullName = flow.Flowname
                };
                dictionary.Add(flow.ID, value);
            }
            return dictionary;


        }

    }
}
