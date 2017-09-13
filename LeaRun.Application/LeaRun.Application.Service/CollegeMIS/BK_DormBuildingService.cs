using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-28 16:41
    /// 描 述：宿舍楼信息
    /// </summary>
    public class BK_DormBuildingService : RepositoryFactory, BK_DormBuildingIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_DormBuildingEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BK_DormBuildingEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (!queryParam["dormBuildingId"].IsEmpty())//转换数据用
            {
                string DormBuildingId = queryParam["dormBuildingId"].ToString();
                expression = expression.And(t => t.DormBuildingId.Equals(DormBuildingId));
            }
            if (!queryParam["dormBuildingNo"].IsEmpty())
            {
                string dormBuildingNo = queryParam["dormBuildingNo"].ToString();
                expression = expression.And(t => t.DormBuildingNo.Equals(dormBuildingNo));
            }

            if (!queryParam["BuildType"].IsEmpty())
            {
                string BuildType = queryParam["BuildType"].ToString();
                expression = expression.And(t => t.BuildType.Equals(BuildType));
            }
            if (!queryParam["DormBuildingNo"].IsEmpty())
            {
                string DormBuildingNo = queryParam["DormBuildingNo"].ToString();
                expression = expression.And(t => t.DormBuildingNo.Equals(DormBuildingNo));
            }
            if (!queryParam["DormBuildingName"].IsEmpty())
            {
                string DormBuildingName = queryParam["DormBuildingName"].ToString();
                expression = expression.And(t => t.DormBuildingName.Contains(DormBuildingName));
            }
            if (pagination == null)
            {
                return this.BaseRepository(conn).FindList(expression);
            }
            return this.BaseRepository(conn).FindList(expression, pagination);
        }


        /// <summary>
        /// 查询所有的楼
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BK_DormBuildingEntity> GetList(string conn)
        {
            var expression = LinqExtensions.True<BK_DormBuildingEntity>();
            return this.BaseRepository(conn).FindList(expression);
        }


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_DormBuildingEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_DormBuildingEntity>(keyValue);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<BK_DormUnitEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_DormUnitEntity>("select * from BK_DormUnit where DormBuildingId='" + keyValue + "' order by DormUnitName");
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string conn, string keyValue)
        {
            IRepository db = new RepositoryFactory().BaseRepository(conn).BeginTrans();
            try
            {
                db.Delete<BK_DormBuildingEntity>(keyValue);
                db.Delete<BK_DormUnitEntity>(t => t.DormBuildingId.Equals(keyValue));
                db.Delete<BK_DormFloorsEntity>(t => t.DormBuildingId.Equals(keyValue));//再删除楼层
                db.Delete<BK_DormEntity>(t => t.DormBuildingId.Equals(keyValue));//再删除房间
                db.Delete<BK_DormBedEntity>(t => t.DormBuildingId.Equals(keyValue));//先删除床位

                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, BK_DormBuildingEntity entity, List<BK_DormUnitEntity> entryList)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //主表
                    entity.Modify(keyValue);
                    db.Update(entity);
                    if (entryList != null && entryList.Count > 0)
                    {
                        //明细
                        foreach (var item in entryList)
                        {
                            if (!string.IsNullOrEmpty(item.DormUnitId))
                            {
                                item.Modify(item.DormUnitId);
                                item.DormBuildingId = entity.DormBuildingId;
                                db.Update(item);
                            }
                            else
                            {
                                item.Create();
                                item.DormBuildingId = entity.DormBuildingId;
                                db.Insert(item);
                            }
                        }
                    }
                    //db.Delete<BK_DormUnitEntity>(t => t.DormBuildingId.Equals(keyValue));                  
                }
                else
                {
                    //主表
                    entity.Create();
                    db.Insert(entity);
                    //明细
                    foreach (BK_DormUnitEntity item in entryList)
                    {
                        item.Create();
                        item.DormBuildingId = entity.DormBuildingId;
                        db.Insert(item);
                    }
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }


        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, BK_DormBuildingEntity entity)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();
            try
            {
                #region 修改数据
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //主表
                    entity.Modify(keyValue);
                    db.Update(entity);
                    //明细    
                    //先删除，再重新创建   
                   
                    db.Delete<BK_DormUnitEntity>(t => t.DormBuildingId.Equals(keyValue));//最后删除单元信息
                    db.Delete<BK_DormFloorsEntity>(t => t.DormBuildingId.Equals(keyValue));//再删除楼层
                    db.Delete<BK_DormEntity>(t => t.DormBuildingId.Equals(keyValue));//再删除房间
                    db.Delete<BK_DormBedEntity>(t => t.DormBuildingId.Equals(keyValue));//先删除床位

                    List<BK_DormUnitEntity> unitList = new List<BK_DormUnitEntity>();
                    List<BK_DormFloorsEntity> floorList = new List<BK_DormFloorsEntity>();
                    List<BK_DormEntity> dormList = new List<BK_DormEntity>();
                    List<BK_DormBedEntity> bedList = new List<BK_DormBedEntity>();

                    #region 添加单元数据
                    if (entity.UnitCount > 0)//单元总数
                    {
                        for (int i = 0; i < entity.UnitCount; i++)
                        {
                            BK_DormUnitEntity dunit = new BK_DormUnitEntity();
                            dunit.DormBuildingId = entity.DormBuildingId;
                            // dunit.DormUnitId = Guid.NewGuid().ToString(); //生成单元的ID号
                            dunit.DormUnitName = (i + 1) + "单元";
                            dunit.DormUnitNo = (i + 1) + "单元";
                            if (entity.BuildType.Equals("不区分")) //宿舍楼不区分男生或女生的情况下，就看单元是否区分
                            {
                                if (!string.IsNullOrEmpty(entity.UnitType))
                                {
                                    if (entity.UnitType.Equals("区分"))
                                    {
                                        //如果单元区分了，就看单元区分的规则是什么
                                        dunit.DormUnitType = this.GetBoyOrGirl(entity.UnitTypeRule, i + 1);
                                    }
                                    else
                                    {
                                        dunit.DormUnitType = "不区分";
                                    }
                                }
                            }
                            else
                            {
                                dunit.DormUnitType = entity.BuildType;
                                //如果已经区分，就楼来看，如果这栋楼为男生，即所有单元都为男生，如果为女生，所有单元都为女生
                            }
                            dunit.Create();
                            unitList.Add(dunit);
                            //db.Insert<BK_DormUnitEntity>(dunit);//添加单元数据

                        }
                        if (unitList.Count>0)
                        {
                            db.Insert<BK_DormUnitEntity>(unitList);//添加单元数据
                        }
                    }

                    if (unitList.Count > 0)
                    {
                        foreach (var dunit in unitList)
                        {
                            #region if (entity.FloorsCountForUnit > 0)//单元楼层总数
                            if (entity.FloorsCountForUnit > 0)//单元楼层总数
                            {
                                for (int j = 0; j < entity.FloorsCountForUnit; j++)
                                {
                                    BK_DormFloorsEntity floor = new BK_DormFloorsEntity();
                                    floor.DormBuildingId = entity.DormBuildingId;
                                    floor.DormUnitId = dunit.DormUnitId;

                                    //floor.DormFloorsId = Guid.NewGuid().ToString();//生成楼层的ID号
                                    floor.DormFloorsName = (j + 1) + "楼";//楼层名称,即：1楼，2楼
                                    floor.DormFloorsNo = (j + 1) + "楼";
                                    if (dunit.DormUnitType.Equals("不区分"))
                                    {
                                        if (!string.IsNullOrEmpty(entity.FloorsType))
                                        {
                                            if (entity.FloorsType.Equals("区分"))
                                            {
                                                //如果单元区分了，就看单元区分的规则是什么
                                                floor.DormFloorsType = this.GetBoyOrGirl(entity.FloorsTypeRule, j + 1);
                                            }
                                            else
                                            {
                                                floor.DormFloorsType = "不区分";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        floor.DormFloorsType = dunit.DormUnitType;
                                    }
                                    floor.Create();
                                    floorList.Add(floor);
                                    //db.Insert<BK_DormFloorsEntity>(floor);//添加楼层数据


                                }
                                
                            }
                            #endregion
                        }

                        if (floorList.Count > 0)
                        {
                            db.Insert<BK_DormFloorsEntity>(floorList);//添加楼层数据
                        }

                    }

                    if (floorList.Count>0)
                    {
                        int j = 0;
                        foreach (var floor in floorList)
                        {

                            #region 添加房间数

                            if (entity.DormCountForFloor > 0)
                            {

                                for (int n = 0; n < entity.DormCountForFloor; n++)
                                {
                                    BK_DormEntity dorm = new BK_DormEntity();//这个是房间数据

                                    dorm.DormBuildingId = entity.DormBuildingId;
                                    dorm.DormUnitId = floor.DormUnitId;
                                    dorm.DormFloorsId = floor.DormFloorsId;

                                    dorm.DormName = (j + 1) + ((n + 1) < 10 ? "0" + (n + 1) : (n + 1) + "");//即：101、102,10以上是：110.112.113.120.124
                                    dorm.DormNo = (j + 1) + ((n + 1) < 10 ? "0" + (n + 1) : (n + 1) + "");//即：101、102,10以上是：110.112.113.120.124
                                    int beds = GetDormBeds(entity.BedRule, dorm.DormNo);
                                    dorm.Beds = beds;
                                    dorm.StarLevel = 0;//星级标准
                                    dorm.Price = GetPrice(entity.DormBuildingOther9, beds);
                                    dorm.UsedBeds = 0;
                                    dorm.NotUseBeds = beds;
                                    dorm.DistributeBeds = 0;
                                    dorm.NotDistributeBeds = beds;

                                    dorm.Create();
                                    //db.Insert<BK_DormEntity>(dorm);//添加宿舍
                                    dormList.Add(dorm);


                                }
                               
                            }
                            j++;
                            #endregion
                        }
                        if (dormList.Count > 0)
                        {
                            db.Insert<BK_DormEntity>(dormList);//添加宿舍
                        }

                    }

                    foreach (var dorm in dormList)
                    {
                        int beds = dorm.Beds.Value;
                        #region 添加床位

                        for (int b = 0; b < beds; b++)
                        { //添加宿舍里的床位
                            BK_DormBedEntity bedentity = new BK_DormBedEntity();

                            bedentity.DormBuildingId = entity.DormBuildingId;
                            bedentity.DormUnitId = dorm.DormUnitId;
                            bedentity.DormFloorsId = dorm.DormFloorsId;
                            bedentity.DormId = dorm.DormId;

                            bedentity.BedName = (b + 1) + "号床";
                            bedentity.BedNo = (b + 1) + "号床";
                            bedentity.BedPrice = dorm.Price;
                            bedentity.IsDwell = "空";
                            bedentity.IsDistribute = 0;
                            bedentity.IsUsed = 0;

                            bedentity.Create();
                            bedList.Add(bedentity);
                            //db.Insert<BK_DormBedEntity>(bedentity);
                        }
                        
                        #endregion
                    }
                    if (bedList.Count > 0)
                    {
                        db.Insert<BK_DormBedEntity>(bedList);
                    }
                    #endregion

                }
                #endregion
                #region 添加数据
                else
                {
                    //主表
                    entity.Create();
                    db.Insert(entity);


                    List<BK_DormUnitEntity> unitList = new List<BK_DormUnitEntity>();
                    List<BK_DormFloorsEntity> floorList = new List<BK_DormFloorsEntity>();
                    List<BK_DormEntity> dormList = new List<BK_DormEntity>();
                    List<BK_DormBedEntity> bedList = new List<BK_DormBedEntity>();

                    #region 添加单元数据
                    if (entity.UnitCount > 0)//单元总数
                    {
                        for (int i = 0; i < entity.UnitCount; i++)
                        {
                            BK_DormUnitEntity dunit = new BK_DormUnitEntity();
                            dunit.DormBuildingId = entity.DormBuildingId;
                            // dunit.DormUnitId = Guid.NewGuid().ToString(); //生成单元的ID号
                            dunit.DormUnitName = (i + 1) + "单元";
                            dunit.DormUnitNo = (i + 1) + "单元";
                            if (entity.BuildType.Equals("不区分")) //宿舍楼不区分男生或女生的情况下，就看单元是否区分
                            {
                                if (!string.IsNullOrEmpty(entity.UnitType))
                                {
                                    if (entity.UnitType.Equals("区分"))
                                    {
                                        //如果单元区分了，就看单元区分的规则是什么
                                        dunit.DormUnitType = this.GetBoyOrGirl(entity.UnitTypeRule, i + 1);
                                    }
                                    else
                                    {
                                        dunit.DormUnitType = "不区分";
                                    }
                                }
                            }
                            else
                            {
                                dunit.DormUnitType = entity.BuildType;
                                //如果已经区分，就楼来看，如果这栋楼为男生，即所有单元都为男生，如果为女生，所有单元都为女生
                            }
                            dunit.Create();
                            unitList.Add(dunit);
                            //db.Insert<BK_DormUnitEntity>(dunit);//添加单元数据

                        }
                        if (unitList.Count > 0)
                        {
                            db.Insert<BK_DormUnitEntity>(unitList);//添加单元数据
                        }
                    }

                    if (unitList.Count > 0)
                    {
                        foreach (var dunit in unitList)
                        {
                            #region if (entity.FloorsCountForUnit > 0)//单元楼层总数
                            if (entity.FloorsCountForUnit > 0)//单元楼层总数
                            {
                                for (int j = 0; j < entity.FloorsCountForUnit; j++)
                                {
                                    BK_DormFloorsEntity floor = new BK_DormFloorsEntity();
                                    floor.DormBuildingId = entity.DormBuildingId;
                                    floor.DormUnitId = dunit.DormUnitId;

                                    //floor.DormFloorsId = Guid.NewGuid().ToString();//生成楼层的ID号
                                    floor.DormFloorsName = (j + 1) + "楼";//楼层名称,即：1楼，2楼
                                    floor.DormFloorsNo = (j + 1) + "楼";
                                    if (dunit.DormUnitType.Equals("不区分"))
                                    {
                                        if (!string.IsNullOrEmpty(entity.FloorsType))
                                        {
                                            if (entity.FloorsType.Equals("区分"))
                                            {
                                                //如果单元区分了，就看单元区分的规则是什么
                                                floor.DormFloorsType = this.GetBoyOrGirl(entity.FloorsTypeRule, j + 1);
                                            }
                                            else
                                            {
                                                floor.DormFloorsType = "不区分";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        floor.DormFloorsType = dunit.DormUnitType;
                                    }
                                    floor.Create();
                                    floorList.Add(floor);
                                    //db.Insert<BK_DormFloorsEntity>(floor);//添加楼层数据


                                }

                            }
                            #endregion
                        }

                        if (floorList.Count > 0)
                        {
                            db.Insert<BK_DormFloorsEntity>(floorList);//添加楼层数据
                        }

                    }

                    if (floorList.Count > 0)
                    {
                        int j = 0;
                        foreach (var floor in floorList)
                        {

                            #region 添加房间数

                            if (entity.DormCountForFloor > 0)
                            {

                                for (int n = 0; n < entity.DormCountForFloor; n++)
                                {
                                    BK_DormEntity dorm = new BK_DormEntity();//这个是房间数据

                                    dorm.DormBuildingId = entity.DormBuildingId;
                                    dorm.DormUnitId = floor.DormUnitId;
                                    dorm.DormFloorsId = floor.DormFloorsId;

                                    dorm.DormName = (j + 1) + ((n + 1) < 10 ? "0" + (n + 1) : (n + 1) + "");//即：101、102,10以上是：110.112.113.120.124
                                    dorm.DormNo = (j + 1) + ((n + 1) < 10 ? "0" + (n + 1) : (n + 1) + "");//即：101、102,10以上是：110.112.113.120.124
                                    int beds = GetDormBeds(entity.BedRule, dorm.DormNo);
                                    dorm.Beds = beds;
                                    dorm.StarLevel = 0;//星级标准
                                    dorm.Price = GetPrice(entity.DormBuildingOther9, beds);
                                    dorm.UsedBeds = 0;
                                    dorm.NotUseBeds = beds;
                                    dorm.DistributeBeds = 0;
                                    dorm.NotDistributeBeds = beds;

                                    dorm.Create();
                                    //db.Insert<BK_DormEntity>(dorm);//添加宿舍
                                    dormList.Add(dorm);


                                }

                            }
                            j++;
                            #endregion
                        }
                        if (dormList.Count > 0)
                        {
                            db.Insert<BK_DormEntity>(dormList);//添加宿舍
                        }

                    }

                    foreach (var dorm in dormList)
                    {
                        int beds = dorm.Beds.Value;
                        #region 添加床位

                        for (int b = 0; b < beds; b++)
                        { //添加宿舍里的床位
                            BK_DormBedEntity bedentity = new BK_DormBedEntity();

                            bedentity.DormBuildingId = entity.DormBuildingId;
                            bedentity.DormUnitId = dorm.DormUnitId;
                            bedentity.DormFloorsId = dorm.DormFloorsId;
                            bedentity.DormId = dorm.DormId;

                            bedentity.BedName = (b + 1) + "号床";
                            bedentity.BedNo = (b + 1) + "号床";
                            bedentity.BedPrice = dorm.Price;
                            bedentity.IsDwell = "空";
                            bedentity.IsDistribute = 0;
                            bedentity.IsUsed = 0;

                            bedentity.Create();
                            bedList.Add(bedentity);
                            //db.Insert<BK_DormBedEntity>(bedentity);
                        }

                        #endregion
                    }
                    if (bedList.Count > 0)
                    {
                        db.Insert<BK_DormBedEntity>(bedList);
                    }
                    #endregion
                }
                #endregion
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 返回男生或女生，默认为不区分
        /// </summary>
        /// <param name="rules">规则</param>
        /// <param name="bs">第几</param>
        /// <returns></returns>
        private string GetBoyOrGirl(string rules, int bs)
        {
            string type = "";

            //如果单元区分了，就看单元区分的规则是什么
            if (!string.IsNullOrEmpty(rules.Trim()))
            {
                string[] urules = rules.Trim().Split('|');
                foreach (var urule in urules)
                {
                    if (string.IsNullOrEmpty(urule.Trim()))
                    {
                        continue;
                    }

                    string[] utype = urule.Trim().Split(':');
                    if (utype[0].Contains("-"))//如果包含了“-”表示为1个范围
                    {
                        string[] numbers = utype[0].Trim().Split('-');//比如 1-3
                        int min = Convert.ToInt32(numbers[0].Trim());//最小值
                        int max = Convert.ToInt32(numbers[1].Trim());//最大值
                        if (min>max)//交换数据
                        {
                            int t = min;
                            min = max;
                            max = t;
                        }
                        for (int i = min; i <= max; i++)
                        {
                            if (i==bs)
                            {
                                type = utype[1].Trim();
                            }
                        }
                    }
                    else
                    {//表示只针对单个单元
                        if (utype[0].Equals(bs))
                        {
                            type = utype[1].Trim();
                        }
                    }
                }
            }

            return type;

        }
        
        /// <summary>
        /// 返回房间内的床位数量
        /// </summary>
        /// <param name="rule">规则</param>
        /// <param name="dormno">宿舍号</param>
        /// <returns></returns>
        private int GetDormBeds(string rule,string dormno)
        {
            //101-105/8|106-110/6|201-205/6|206-220/8
            int beds = 0;
            if (!string.IsNullOrEmpty(rule.Trim()))
            {
                string[] ruless = rule.Trim().Split('|');//得到101-105/8、106-110/6、201-205/6、206-220/8
                foreach (var rules in ruless)
                {
                    if (string.IsNullOrEmpty(rules.Trim()))
                    {
                        continue;
                    }
                    string[] dormbeds = rules.Trim().Split('/');//得到101-105、8
                    if (dormbeds[0].Trim().Contains("-"))
                    {
                        string[] dorms = dormbeds[0].Trim().Split('-');
                        int min = Convert.ToInt32(dorms[0].Trim());//最小值
                        int max = Convert.ToInt32(dorms[1].Trim());//最大值
                        if (min > max)//交换数据
                        {
                            int t = min;
                            min = max;
                            max = t;
                        }
                        for (int i = min; i <= max; i++)
                        {
                            if (dormno.Equals(i.ToString()))
                            {
                                beds = Convert.ToInt32(dormbeds[1].Trim());//得到房间的床位数据
                            }
                        }
                    }
                    else
                    {
                        if (dormbeds[0].Trim().Equals(dormno))
                        {
                            beds = Convert.ToInt32(dormbeds[1].Trim());//得到房间的床位数据
                        }
                    }

                }
            }
            return beds;
        }

        /// <summary>
        /// 根据房间床位返回单价
        /// </summary>
        /// <param name="priceRule">规则</param>
        /// <param name="bedcount">床位数</param>
        /// <returns>床位单价</returns>
        private decimal GetPrice(string priceRule, int bedcount)
        {
            decimal price = 0;
            if (!string.IsNullOrEmpty(priceRule.Trim()))
            {
                //8/500|6/800|4/1200
                string[] rules = priceRule.Trim().Split('|');
                foreach (var bedprice in rules)
                {
                    string[] bp = bedprice.Trim().Split('/');
                    if (bp[0].Trim().Equals(bedcount.ToString()))
                    {
                        price = decimal.Parse(bp[1].Trim());
                        break;
                    }
                }

            }
            return price;
        } 

#endregion
    }
}
