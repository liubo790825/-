using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.SystemManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-12 10:57
    /// 描 述：数据导入详细设置
    /// </summary>
    public class System_SetExcelImportFiledEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID号
        /// </summary>
        /// <returns></returns>
        public string F_Id { get; set; }
        /// <summary>
        /// 导入模板Id
        /// </summary>
        /// <returns></returns>
        public string F_ImportTemplateId { get; set; }
        /// <summary>
        /// 字典名字
        /// </summary>
        /// <returns></returns>
        public string F_FliedName { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        /// <returns></returns>
        public string F_FiledType { get; set; }
        /// <summary>
        /// Excel列名
        /// </summary>
        /// <returns></returns>
        public string F_ColName { get; set; }
        /// <summary>
        /// 唯一性验证:0要,1需要
        /// </summary>
        /// <returns></returns>
        public bool? F_OnlyOne { get; set; }
        /// <summary>
        /// 关联类型0:无关联,1:GUID,2:数据字典3:数据表;4:固定数值;5:操作人ID;6:操作人名字;7:操作时间;
        /// </summary>
        /// <returns></returns>
        public int? F_RelationType { get; set; }
        /// <summary>
        /// 数据字典编号
        /// </summary>
        /// <returns></returns>
        public string F_DataItemEncode { get; set; }
        /// <summary>
        /// 固定数据
        /// </summary>
        /// <returns></returns>
        public string F_Value { get; set; }
        /// <summary>
        /// 关联库id
        /// </summary>
        /// <returns></returns>
        public string F_DbId { get; set; }
        /// <summary>
        /// 关联表
        /// </summary>
        /// <returns></returns>
        public string F_DbTable { get; set; }
        /// <summary>
        /// 保存字段
        /// </summary>
        /// <returns></returns>
        public string F_DbSaveFlied { get; set; }
        /// <summary>
        /// 关联字段
        /// </summary>
        /// <returns></returns>
        public string F_DbRelationFlied { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        /// <returns></returns>
        public int? F_SortCode { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.F_Id = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.F_Id = keyValue;
                                    
        }
        #endregion
    }
}