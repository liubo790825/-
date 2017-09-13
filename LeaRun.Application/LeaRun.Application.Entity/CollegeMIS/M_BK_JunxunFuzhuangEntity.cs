using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin 2017-7-21 唐世杰
    /// 日 期：2017-07-21 11:00
    /// 描 述：BK_JunxunFuzhuang
    /// </summary>
    public class M_BK_JunxunFuzhuangEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// FuzhuangId
        /// </summary>
        /// <returns></returns>
        public string FuzhuangId { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        /// <returns></returns>
        public string StuNo { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        /// <returns></returns>
        public string Height { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        /// <returns></returns>
        public string BodyWeight { get; set; }
        /// <summary>
        /// 腰围
        /// </summary>
        /// <returns></returns>
        public string Waistline { get; set; }
        /// <summary>
        /// 头围
        /// </summary>
        /// <returns></returns>
        public string HeadWaistline { get; set; }
        /// <summary>
        /// 衣服尺寸
        /// </summary>
        /// <returns></returns>
        public string ClothSize { get; set; }
        /// <summary>
        /// 裤子尺寸
        /// </summary>
        /// <returns></returns>
        public string PantsSize { get; set; }
        /// <summary>
        /// 鞋子尺寸
        /// </summary>
        /// <returns></returns>
        public string ShoesSize { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        /// <returns></returns>
        public string BaodaoOther1 { get; set; }
        /// <summary>
        /// BaodaoOther2
        /// </summary>
        /// <returns></returns>
        public string BaodaoOther2 { get; set; }
        /// <summary>
        /// BaodaoOther3
        /// </summary>
        /// <returns></returns>
        public string BaodaoOther3 { get; set; }
        /// <summary>
        /// BaodaoOther4
        /// </summary>
        /// <returns></returns>
        public string BaodaoOther4 { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        public string Gender { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.FuzhuangId = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.FuzhuangId = keyValue;
                                    
        }
        #endregion
    }
}