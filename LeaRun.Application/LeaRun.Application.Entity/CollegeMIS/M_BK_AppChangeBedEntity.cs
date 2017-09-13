using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-17 12:29
    /// 描 述：换床申请
    /// </summary>
    public class M_BK_AppChangeBedEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>   
        public string ID { get; set; }
        /// <summary>
        /// 申请学生ID号
        /// </summary>
        /// <returns></returns>
        public string AppStuId { get; set; }
        /// <summary>
        /// 申请人班级ID号
        /// </summary>
        /// <returns></returns>
        public string AppClassId { get; set; }
        /// <summary>
        /// 申请人学号
        /// </summary>
        /// <returns></returns>
        public string AppStuNo { get; set; }
        /// <summary>
        /// 申请人姓名
        /// </summary>
        /// <returns></returns>
        public string AppStuName { get; set; }
        /// <summary>
        /// 申请人电话
        /// </summary>
        /// <returns></returns>
        public string AppStuPhone { get; set; }
        /// <summary>
        /// 原床位ID号
        /// </summary>
        /// <returns></returns>
        public string OldBedId { get; set; }
        /// <summary>
        /// 目标学生ID号，可能为空
        /// </summary>
        /// <returns></returns>
        public string TargetStuId { get; set; }
        /// <summary>
        /// 目标学生班级ID号，可能为空
        /// </summary>
        /// <returns></returns>
        public string TargetClassId { get; set; }
        /// <summary>
        /// 目标学生号，可能为空
        /// </summary>
        /// <returns></returns>
        public string TargetStuNo { get; set; }
        /// <summary>
        /// 目标学生姓名，可能为空
        /// </summary>
        /// <returns></returns>
        public string TargetStuName { get; set; }
        /// <summary>
        /// 目标学生电话
        /// </summary>
        /// <returns></returns>
        public string TargetStuPhone { get; set; }
        /// <summary>
        /// 目标说明不同意说明
        /// </summary>
        /// <returns></returns>
        public string TargetRemark { get; set; }
        /// <summary>
        /// 目标床位ID号
        /// </summary>
        /// <returns></returns>
        public string NewBedId { get; set; }
        /// <summary>
        /// 目标学生是否同意，0未查看，1同意，2不同意
        /// </summary>
        /// <returns></returns>
        public int? TargetPassed { get; set; }
        /// <summary>
        /// 是否通过，1申请中，0未通过，2通过
        /// </summary>
        /// <returns></returns>
        public int? Passed { get; set; }
        /// <summary>
        /// 通过时间
        /// </summary>
        /// <returns></returns>
        public DateTime? PassedTime { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        /// <returns></returns>
        public DateTime? AppDatetime { get; set; }
        /// <summary>
        /// 申请原因
        /// </summary>
        /// <returns></returns>
        public string AppRemark { get; set; }
        /// <summary>
        /// 是否取消申请，0未取消，1取消
        /// </summary>
        /// <returns></returns>
        public int? DeleteMark { get; set; }
        /// <summary>
        /// 联合取消申请使用，1未取消，0取消
        /// </summary>
        /// <returns></returns>
        public int? EnableMark { get; set; }
        /// <summary>
        /// 取消时间
        /// </summary>
        /// <returns></returns>
        public DateTime? CancelTime { get; set; }
        /// <summary>
        /// 班级名
        /// </summary>
        /// <returns></returns>
        public string ClassName { get; set; }
        /// <summary>
        /// 房间名
        /// </summary>
        /// <returns></returns>
        public string DormName { get; set; }
        /// <summary>
        /// 床位名
        /// </summary>
        /// <returns></returns>
        public string BedName { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ID = keyValue;
                                    
        }
        #endregion
    }
}