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
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-28 16:33
    /// 描 述：宿舍信息
    /// </summary>
    public class BK_DormController : MvcControllerBase
    {
        private BK_DormBLL bk_dormbll = new BK_DormBLL();
        private BK_DormBuildingBLL buildbll = new BK_DormBuildingBLL();//楼
        private BK_DormUnitBLL ubll = new BK_DormUnitBLL();
        private BK_DormFloorsBLL fbll = new BK_DormFloorsBLL();//楼层
        private BK_DormBedBLL bedbll = new BK_DormBedBLL();

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
        /// 新生入住列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult StuChkDormIndex()
        {
            return View();
        }

        /// <summary>
        /// 预分宿舍页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult YFIndex()
        {
            return View();
        }

        /// <summary>
        /// 院系专业床位统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MajorBedsCountIndex()
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
        /// 预分专业选择页面表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult YFForm()
        {
            return View();
        }

        /// <summary>
        /// 预分床位专业选择页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult YFBedForm()
        {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 功能列表 
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="usedrom">是否使用宿舍树</param>
        /// <returns>返回树形Json</returns>
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
                                tree.text = dorm.DormName+"(共"+dorm.Beds+"床，空"+dorm.NotUseBeds+"床)";
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
        /// 宿舍列表
        /// </summary>
        /// <param name="dormids">宿舍ID号列表</param>
        /// <returns>返回树形Json</returns>
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
                    //只有当选择的宿舍不为空，而且还要他的未分的床位数还要大于0的才显示
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
        /// 根据学生ID号，返回宿舍数据
        /// </summary>
        /// <param name="stuid">学生ID号</param>
        /// <returns></returns>
        public ActionResult GetDormTreeJsonByStuId(string stuid)
        {
            BK_StuInfoBLL stubll = new BK_StuInfoBLL();//学生
            BK_MajorBLL mbll = new BK_MajorBLL();//专业
            BK_StuInfoEntity student = stubll.GetEntity(stuid);
            var treeList = new List<TreeEntity>();

            if (student != null)
            {
                string queryJson = (new { MajorNo = student.MajorNo, DormFloorsType = student.Gender }).ToJson();
                var dormbedList = bedbll.GetListByStr(queryJson);//得到这个专业下面的这个性别的所有床位

                HashSet<string> floorids = new HashSet<string>();
                foreach (var bed in dormbedList)
                {
                    floorids.Add(bed.DormFloorsId);//去掉重复的楼层ID号，
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
                        //重新查询看这个宿舍下面是否有这个专业的床位，如果没有，就不要添加到树里了，如果有，就添加到树里
                        var bedlist = bedbll.GetList(queryJson);
                        if (bedlist.Count > 0)
                        {
                            int sybed = dorm.Beds.Value - dorm.UsedBeds;
                            if (bedlist.Count < dorm.Beds.Value)//如果得到的床位总数与宿舍的床位总数相同就不用再重新计算剩余床位数量
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
                            tree.text = dorm.DormName + "(余" + sybed + "床位)";
                            tree.value = dorm.DormId;
                            tree.isexpand = false;
                            tree.complete = true;
                            tree.hasChildren = false;
                            tree.parentId = floorid;
                            tree.img = "";
                            tree.Attribute = "show";
                            tree.AttributeValue = "dorm";

                            tree.Attribute = "majorno";
                            tree.AttributeValue = student.MajorNo;//专业号传到前台去



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
                    tree.AttributeValue = student.MajorNo;//专业号传到前台去
                    treeList.Add(tree);
                }
            }
            return Content(treeList.TreeToJson());
        }



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
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
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
        /// 根据楼层得到所有的宿舍和宿舍下面的床位
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public ActionResult GetListAndChildList(string queryJson)
        {
            var data = bk_dormbll.GetList(queryJson);
            List<Dorm> dormList = new List<Dorm>();
            foreach (var dorm in data)
            {
                var childData = bk_dormbll.GetDetails(dorm.DormId); //得到所有的床位信息      
                Dorm d = new Dorm();
                d.entity = dorm;
                d.childEntity = childData;
                dormList.Add(d);
            }
            var temp = ToJsonResult(dormList);
            return temp;
        }

        /// <summary>
        /// 获取子表详细信息 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
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
            bk_dormbll.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 清空预分宿舍床位
        /// </summary>
        /// <param name="strEntity">宿舍id号</param>
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
                            var bedlist = bk_dormbll.GetDetails(dormid);//得到所有床位数据
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
                                    bed.IsDwell = "空";
                                    bed.IsUsed = 0;//请空使用情况
                                    bed.StuId = "";//清空学号
                                    bed.StuName = "";//清空姓名
                                    bedls.Add(bed);//增加到集合中，进行server统一修改
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
                            dorm.ClassInfoId = "";//清空班级id号
                            dorm.MajorDetailId = "";//清空专业方向ID号
                            dorm.MajorId = "";//清空专业ID号
                            bk_dormbll.SaveForm(dormid, dorm, bedls);//修改宿舍和床位数据
                        }
                    }
                    return Success("清空宿舍成功！");
                }
                catch (System.Exception)
                {

                    return Error("清空宿舍失败！");
                }
            }
            return Error("要清空宿舍不能为空！");
        }

        /// <summary>
        /// 清空宿舍床位,只清空学生ID号和学生姓名，专业不清除
        /// </summary>
        /// <param name="strEntity">宿舍id号</param>
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
                            var bedlist = bk_dormbll.GetDetails(dormid);//得到所有床位数据
                            int bdcount = 0;
                            foreach (var bed in bedlist)
                            {
                                bdcount++;
                                //bed.IsDistribute = 0;
                                //bed.MajorDetailId = "";
                                //bed.MajorId = "";
                                bed.IsDwell = "已预分";
                                bed.IsUsed = 0;//请空使用情况
                                bed.StuId = "";//清空学号
                                bed.StuName = "";//清空姓名
                                bedls.Add(bed);//增加到集合中，进行server统一修改
                            }
                            dorm.UsedBeds = 0;
                            dorm.NotUseBeds = bdcount;

                            //dorm.NotDistributeBeds = bdcount;
                            //dorm.DistributeBeds = 0;                            
                            //dorm.ClassInfoId = "";//清空班级id号
                            //dorm.MajorDetailId = "";//清空专业方向ID号
                            //dorm.MajorId = "";//清空专业ID号
                            bk_dormbll.SaveForm(dormid, dorm, bedls);//修改宿舍和床位数据
                        }
                    }
                    return Success("清空宿舍成功！");
                }
                catch (System.Exception)
                {

                    return Error("清空宿舍失败！");
                }
            }
            return Error("要清空宿舍不能为空！");
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strChildEntitys)
        {
            var entity = strEntity.ToObject<BK_DormEntity>();
            var childEntitys = strChildEntitys.ToList<BK_DormBedEntity>();
            bk_dormbll.SaveForm(keyValue, entity, childEntitys);
            return Success("操作成功。");
        }



        /// <summary>
        /// 保存预分宿舍和床位
        /// </summary>
        /// <param name="dormids">宿舍ID号列表</param>
        /// <param name="strEntity">页面数</param>
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

                if (!string.IsNullOrEmpty(majorid) && dormidss.Length > 0)//如果专业为空，就不能预分
                {
                    foreach (var dormid in dormidss)
                    {
                        BK_DormEntity dormentity = bk_dormbll.GetEntity(dormid);
                        if (dormentity != null)
                        {
                            //未预分床位大于0
                            if (dormentity.NotDistributeBeds > 0)
                            {
                                int yfcount = 0;//记录预分床位的总数
                                int bedcount = 0;//记录床位总数
                                List<BK_DormBedEntity> bedslist = new List<BK_DormBedEntity>();

                                var bedlist = bk_dormbll.GetDetails(dormid);
                                foreach (var bed in bedlist)
                                {
                                    bedcount++;
                                    //床位是否已经预分，如果还没有预分就预分床位
                                    if (bed.IsDistribute == 0)
                                    {
                                        bed.IsDistribute = 1;//修改为预分
                                        bed.IsDwell = "已预分";
                                        bed.MajorId = majorid;
                                        bed.MajorDetailId = majordetailid;
                                        yfcount++;//记录预分的床位数

                                        bedslist.Add(bed);
                                        //bedbll.SaveForm(bed.BedId, bed);//修改床位信息
                                    }
                                }
                                dormentity.DistributeBeds += yfcount;//修改已分床位总数
                                dormentity.NotDistributeBeds -= yfcount;//修改未分床位总数

                                //看是不是全部床位都是同一个专业的，如果是同一个专业的话，宿舍的专业号就改为现在的这个专业号，要不然是不用修改宿舍的专业号的
                                if (yfcount > 0 && yfcount == bedcount)
                                {
                                    dormentity.MajorId = majorid;
                                    dormentity.MajorDetailId = majordetailid;
                                }

                                //这种方式可以使在发生错误时可以回滚
                                bk_dormbll.SaveForm(dormentity.DormId, dormentity, bedslist);
                            }
                        }
                    }
                    return Success("操作成功。");
                }
                else
                {
                    return Error("没有选择专业，操作失败。");
                }


            }
            else
            {
                return Error("没有选择要进行预分的宿舍，操作失败。");
            }
        }

        /// <summary>
        /// 保存预分床位
        /// </summary>
        /// <param name="dormids">宿舍ID号列表</param>
        /// <param name="strEntity">页面数</param>
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

                if (!string.IsNullOrEmpty(majorid) && !string.IsNullOrEmpty(bedids))//专业和床位号不能为空
                {
                    string[] bedidlist = bedids.Split(',');
                    foreach (var bedid in bedidlist)
                    {
                        BK_DormBedEntity bedentity = bedbll.GetEntity(bedid);
                        if (bedentity != null && bedentity.IsDistribute == 0 && !string.IsNullOrEmpty(majorid))
                        {
                            //要分的专业id号不能为空
                            bedentity.IsDistribute = 1;//修改为预分
                            bedentity.IsDwell = "已预分";
                            bedentity.MajorId = majorid;
                            bedentity.MajorDetailId = majordetailid;

                            var dorm = bk_dormbll.GetEntity(bedentity.DormId);//得到该床位的宿舍
                            if (dorm != null)
                            {
                                dorm.DistributeBeds += 1;//修改已分床位总数
                                dorm.NotDistributeBeds -= 1;//修改未分床位总数
                                bk_dormbll.SaveForm(dorm.DormId, dorm, null);//修改宿舍的床位信息
                            }
                            bedbll.SaveForm(bedid, bedentity);//修改床位信息
                        }
                    }
                }



                return Success("床位预分成功！");
            }
            catch (System.Exception)
            {
                return Error("操作失败！");
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
