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
    public class FiledsInfoEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID号
        /// </summary>
        /// <returns></returns>
        public string F_FiledsInfoId { get; set; }
        /// <summary>
        /// ID号
        /// </summary>
        /// <returns></returns>
        public string F_ExcelImportTemplateId { get; set; }
        /// <summary>
        /// 字段名
        /// </summary>
        /// <returns></returns>
        public string F_FliedName { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        /// <returns></returns>
        public string F_FiledType { get; set; }
        /// <summary>
        /// Excel列名
        /// </summary>
        /// <returns></returns>
        public string F_ColName { get; set; }
        /// <summary>
        /// 唯一性
        /// </summary>
        /// <returns></returns>
        public bool? F_OnlyOne { get; set; }
        /// <summary>
        /// 关联类型
        /// </summary>
        /// <returns></returns>
        public int? F_RelationType { get; set; }
        /// <summary>
        /// 数据字典编码
        /// </summary>
        /// <returns></returns>
        public string F_DataItemEncode { get; set; }
        /// <summary>
        /// 固定数值
        /// </summary>
        /// <returns></returns>
        public string F_Value { get; set; }
        /// <summary>
        /// 数据库ID号
        /// </summary>
        /// <returns></returns>
        public string F_DbId { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        /// <returns></returns>
        public string F_DbTable { get; set; }
        /// <summary>
        /// 字段名
        /// </summary>
        /// <returns></returns>
        public string F_FliedLabel { get; set; }
        /// <summary>
        /// 保存数据字段
        /// </summary>
        /// <returns></returns>
        public string F_DbSaveFlied { get; set; }
        /// <summary>
        /// 对应字段
        /// </summary>
        /// <returns></returns>
        public string F_DbRelationFiled { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        /// <returns></returns>
        public string F_Description { get; set; }
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
            this.F_FiledsInfoId = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.F_FiledsInfoId = keyValue;
                                    
        }
        #endregion
    }
}