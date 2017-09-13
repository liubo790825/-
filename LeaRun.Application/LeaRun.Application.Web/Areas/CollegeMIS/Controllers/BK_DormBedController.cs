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
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-28 15:59
    /// 描 述：床位信息
    /// </summary>
    public class BK_DormBedController : MvcControllerBase
    {
        private BK_DormBedBLL bk_dormbedbll = new BK_DormBedBLL();
        private BK_DormBLL dormbll = new BK_DormBLL();
        private BK_StuBedDwellBLL dwellbll = new BK_StuBedDwellBLL();


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
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        /// <summary>
        /// 床位互换页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SwapBedIndex()
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
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var data = bk_dormbedbll.GetList(queryJson);
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
            var data = bk_dormbedbll.GetEntity(keyValue);
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
            bk_dormbedbll.RemoveForm(keyValue);
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
        public ActionResult SaveForm(string keyValue, BK_DormBedEntity entity)
        {
            bk_dormbedbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        /// <summary>
        /// 保存学生入住
        /// </summary>
        /// <param name="strEntity"></param>
        /// <returns></returns>
        public ActionResult SaveStuToBed(string strEntity)
        {
            string bedids = "";//床位ID号
            string stuinfoid = "";//学生ID号
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
                    if (bedentity.IsUsed == 0) //只有在没有使用的情况下才能入住
                    {
                        bedentity.IsUsed = 1;
                        bedentity.StuId = stuinfoid;
                        bedentity.StuName = student.StuName;

                        BK_DormEntity dorm = dbll.GetEntity(bedentity.DormId);
                        dorm.UsedBeds += 1;//修改已使用床位数量
                        dorm.NotUseBeds -= 1;//修改未使用床位数量

                        string queryjson = new { StuId = stuinfoid, BedId = bedids }.ToJson();
                        BK_StuBedDwellEntity beddwell = dwellbll.GetEntityByWhere(queryjson);//查询是否已经入住了，如果没有入住就增加入住
                        if (beddwell == null)
                        {
                            beddwell = new BK_StuBedDwellEntity();
                            beddwell.StuId = stuinfoid;
                            beddwell.BedId = bedids;
                        }
                        beddwell.EnterDate = DateTime.Now;
                        beddwell.EnterRemark = "新生入住";

                        dwellbll.SaveForm(beddwell.ID, beddwell);
                        bedlist.Add(bedentity);
                        dbll.SaveForm(dorm.DormId, dorm, bedlist);
                    }
                    }
                    else
                    {
                        return Error("该学生已经选择其它床位，不能再次选择床位！");
                    }
                }
            }
            catch (System.Exception ex)
            {

                return Error("入住失败！");
            }
            return Success("入住成功！");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromBeds">要调换的床位ID号</param>
        /// <param name="targetBeds">目标床位ID号</param>
        /// <returns></returns>
        public ActionResult ChangeBeds(string fromBeds, string targetBeds)
        {
            List<BK_DormBedEntity> fromBedList = new List<BK_DormBedEntity>();//要调换床位的床位数据
            List<BK_DormBedEntity> targetBedList = new List<BK_DormBedEntity>();//目标床位数据
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
                        BK_DormBedEntity frombed = fromBedList[i];//要调换的学生床位
                        BK_DormBedEntity targetbed = targetBedList[i];//目标床位

                        
                        int tempIsUsed = frombed.IsUsed;//表示为已使用    
                        int tempIsDistribute= frombed.IsDistribute;
                        string tempIsDwell = frombed.IsDwell;
                        string tempMajorDetailId = frombed.MajorDetailId;
                        string tempMajorId = frombed.MajorId;
                        string tempStuId  = frombed.StuId;
                        string tempStuName = frombed.StuName;
                        string tempClassInfoId = frombed.ClassInfoId;


                        //开始交换数据

                        #region 修改原床位信息
                        //先改变frombed数据
                        frombed.IsUsed = targetbed.IsUsed;//表示为已使用    
                        frombed.IsDistribute = targetbed.IsDistribute;
                        frombed.IsDwell = targetbed.IsDwell;
                        frombed.MajorDetailId = targetbed.MajorDetailId;
                        frombed.MajorId = targetbed.MajorId;
                        frombed.StuId = targetbed.StuId;
                        frombed.StuName = targetbed.StuName;
                        frombed.ClassInfoId = targetbed.ClassInfoId;

                        //如果改变后的床位与改变之前的床位状态相同，就不做宿舍数据的处理，如果不同就要做数据处理
                        var fromdorm = dormbll.GetEntity(frombed.DormId);
                        if (frombed.IsUsed != tempIsUsed)
                        {//原床位信息与现床位信息不相同时，要改变宿舍的床位数据
                            if (frombed.IsUsed == 0)//表示现床位为空床位
                            {
                                fromdorm.UsedBeds--;//使用的床位数要减1;
                                fromdorm.NotUseBeds++;//未使用床位数要加1;
                            }
                            else
                            {
                                fromdorm.UsedBeds++;//使用的床位数要减1;
                                fromdorm.NotUseBeds--;//未使用床位数要加1;
                            }
                        }
                        if (frombed.IsDistribute != tempIsDistribute)
                        {
                            if (frombed.IsUsed == 0)//表示现床位为空床位
                            {
                                fromdorm.DistributeBeds--;//使用的床位数要减1;
                                fromdorm.NotDistributeBeds++;//未使用床位数要加1;
                            }
                            else
                            {
                                fromdorm.DistributeBeds++;//使用的床位数要减1;
                                fromdorm.NotDistributeBeds--;//未使用床位数要加1;
                            }
                        }
                        modirybedList.Add(frombed);

                        //查询该生在这里的入住信息,只有在学生入住的情况下才能起作用
                        #region 退出原宿舍床位
                        if (!string.IsNullOrEmpty(tempStuId))
                        {
                            string queryjson = new { StuId = tempStuId, BedId = frombed.BedId }.ToJson();
                            BK_StuBedDwellEntity beddwell = dwellbll.GetEntityByWhere(queryjson);//查询是否已经入住信息
                            if (beddwell == null)
                            {
                                beddwell = new BK_StuBedDwellEntity();
                                beddwell.StuId = tempStuId;
                                beddwell.BedId = frombed.BedId;                                
                            }
                            beddwell.QuitDate = DateTime.Now;
                            beddwell.QuitRemark = "交换宿舍床位";
                            dwellbll.SaveForm(beddwell.ID, beddwell);
                        }
                        #endregion

                        #region 入住新宿舍床位
                        if (!string.IsNullOrEmpty(tempStuId))
                        {
                            string queryjson = new { StuId = tempStuId, BedId = targetbed.BedId }.ToJson();
                            BK_StuBedDwellEntity beddwell = dwellbll.GetEntityByWhere(queryjson);//查询是否已经入住信息
                            if (beddwell == null)
                            {
                                beddwell = new BK_StuBedDwellEntity();
                                beddwell.StuId = tempStuId;
                                beddwell.BedId = targetbed.BedId;
                            }
                            beddwell.EnterDate = DateTime.Now;
                            beddwell.EnterRemark = "交换宿舍床位";
                            dwellbll.SaveForm(beddwell.ID, beddwell);
                        }
                        #endregion


                        dormbll.SaveForm(fromdorm.DormId, fromdorm, modirybedList);//修改原床位信息
                        #endregion

                        #region 修改目标床位信息
                        int tempIsUsed2 = targetbed.IsUsed;//表示为已使用    
                        int tempIsDistribute2 = targetbed.IsDistribute;
                        string tempIsDwell2 = targetbed.IsDwell;
                        string tempMajorDetailId2 = targetbed.MajorDetailId;
                        string tempMajorId2 = targetbed.MajorId;
                        string tempStuId2 = targetbed.StuId;
                        string tempStuName2 = targetbed.StuName;
                        string tempClassInfoId2 = targetbed.ClassInfoId;

                        //改变目标数据
                        targetbed.IsUsed = tempIsUsed;//表示为已使用    
                        targetbed.IsDistribute = tempIsDistribute;
                        targetbed.IsDwell = tempIsDwell;
                        targetbed.MajorDetailId = tempMajorDetailId;
                        targetbed.MajorId = tempMajorId;
                        targetbed.StuId = tempStuId;
                        targetbed.StuName = tempStuName;
                        targetbed.ClassInfoId = tempClassInfoId;

                        var targetdorm = dormbll.GetEntity(targetbed.DormId);
                        if (targetbed.IsUsed != tempIsUsed2)
                        {//原床位信息与现床位信息不相同时，要改变宿舍的床位数据
                            if (targetbed.IsUsed == 0)//表示现床位为空床位
                            {
                                targetdorm.UsedBeds--;//使用的床位数要减1;
                                targetdorm.NotUseBeds++;//未使用床位数要加1;
                            }
                            else
                            {
                                targetdorm.UsedBeds++;//使用的床位数要减1;
                                targetdorm.NotUseBeds--;//未使用床位数要加1;
                            }
                        }
                        if (targetbed.IsDistribute != tempIsDistribute2)
                        {
                            if (targetbed.IsUsed == 0)//表示现床位为空床位
                            {
                                targetdorm.DistributeBeds--;//使用的床位数要减1;
                                targetdorm.NotDistributeBeds++;//未使用床位数要加1;
                            }
                            else
                            {
                                targetdorm.DistributeBeds++;//使用的床位数要减1;
                                targetdorm.NotDistributeBeds--;//未使用床位数要加1;
                            }
                        }

                        //查询该生在这里的入住信息,只有在学生入住的情况下才能起作用
                        #region 退出原宿舍床位
                        if (!string.IsNullOrEmpty(tempStuId2))
                        {
                            string queryjson = new { StuId = tempStuId2, BedId = targetbed.BedId }.ToJson();
                            BK_StuBedDwellEntity beddwell = dwellbll.GetEntityByWhere(queryjson);//查询是否已经入住信息
                            if (beddwell == null)
                            {
                                beddwell = new BK_StuBedDwellEntity();
                                beddwell.StuId = tempStuId2;
                                beddwell.BedId = targetbed.BedId;
                            }
                            beddwell.QuitDate = DateTime.Now;
                            beddwell.QuitRemark = "交换宿舍床位";
                            dwellbll.SaveForm(beddwell.ID, beddwell);
                        }
                        #endregion

                        #region 入住新宿舍床位
                        if (!string.IsNullOrEmpty(tempStuId2))
                        {
                            string queryjson = new { StuId = tempStuId2, BedId = frombed.BedId }.ToJson();
                            BK_StuBedDwellEntity beddwell = dwellbll.GetEntityByWhere(queryjson);//查询是否已经入住信息
                            if (beddwell == null)
                            {
                                beddwell = new BK_StuBedDwellEntity();
                                beddwell.StuId = tempStuId2;
                                beddwell.BedId = frombed.BedId;
                            }
                            beddwell.EnterDate = DateTime.Now;
                            beddwell.EnterRemark = "交换宿舍床位";
                            dwellbll.SaveForm(beddwell.ID, beddwell);
                        }
                        #endregion




                        modirybedList.Clear();//清空所有的数据，再重新装填新数据
                        modirybedList.Add(targetbed);
                        dormbll.SaveForm(targetdorm.DormId, targetdorm, modirybedList);//修改目标原床位信息
                        #endregion
                    }
                }
                catch (System.Exception ex)
                {

                    return Error("调换床位失败！");
                }
                return Success("床位调换成功！");
            }
            return Error("调换床位不能为空！");
        }

        #endregion
    }
}
