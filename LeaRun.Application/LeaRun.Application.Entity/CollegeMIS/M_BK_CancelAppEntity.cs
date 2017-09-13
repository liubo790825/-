using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-18 15:12
    /// 描 述：撤消申请记录
    /// </summary>
    public class M_BK_CancelAppEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// 申请要撤消的ID号
        /// </summary>
        /// <returns></returns>
        public string AppId { get; set; }
        /// <summary>
        /// 审核人或申请人
        /// </summary>
        /// <returns></returns>
        public string Checker { get; set; }
        /// <summary>
        /// 申请时间或审核时间
        /// </summary>
        /// <returns></returns>
        public DateTime? CheckerTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public string CheckState { get; set; }
        /// <summary>
        /// 备注或说明
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// 审核角色ID号
        /// </summary>
        public string RoleId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        /// <returns></returns>
        public string StuNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// 操行类型ID号
        /// </summary>
        /// <returns></returns>
        public string BehaviorTypeId { get; set; }
        /// <summary>
        /// 违反的操行
        /// </summary>
        /// <returns></returns>
        public string BreachBehavior { get; set; }
        /// <summary>
        /// 违反时间
        /// </summary>
        /// <returns></returns>
        public DateTime? BreachTime { get; set; }
        /// <summary>
        /// 提交者
        /// </summary>
        /// <returns></returns>
        public string Submiter { get; set; }
        /// <summary>
        /// 是否撤消，0未撤消，1撤消申请中，2撤消
        /// </summary>
        /// <returns></returns>
        public int? IsCanceled { get; set; }
        /// <summary>
        /// 申请撤消的次数
        /// </summary>
        /// <returns></returns>
        public int? AppCancel { get; set; }
        /// <summary>
        /// 是否可以申请撤消，如果申请撤消次数达3次以上者，不可再次申请
        /// </summary>
        /// <returns></returns>
        public int? CanCancel { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 院系名
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        /// <summary>
        /// 专业名
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// 班级名
        /// </summary>
        /// <returns></returns>
        public string ClassName { get; set; }



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