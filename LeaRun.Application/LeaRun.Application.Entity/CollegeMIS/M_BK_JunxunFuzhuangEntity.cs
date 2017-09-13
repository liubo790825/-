using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin 2017-7-21 ������
    /// �� �ڣ�2017-07-21 11:00
    /// �� ����BK_JunxunFuzhuang
    /// </summary>
    public class M_BK_JunxunFuzhuangEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// FuzhuangId
        /// </summary>
        /// <returns></returns>
        public string FuzhuangId { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public string StuNo { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string Height { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string BodyWeight { get; set; }
        /// <summary>
        /// ��Χ
        /// </summary>
        /// <returns></returns>
        public string Waistline { get; set; }
        /// <summary>
        /// ͷΧ
        /// </summary>
        /// <returns></returns>
        public string HeadWaistline { get; set; }
        /// <summary>
        /// �·��ߴ�
        /// </summary>
        /// <returns></returns>
        public string ClothSize { get; set; }
        /// <summary>
        /// ���ӳߴ�
        /// </summary>
        /// <returns></returns>
        public string PantsSize { get; set; }
        /// <summary>
        /// Ь�ӳߴ�
        /// </summary>
        /// <returns></returns>
        public string ShoesSize { get; set; }
        /// <summary>
        /// ���֤��
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
        /// ����
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        /// <returns></returns>
        public string Gender { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.FuzhuangId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.FuzhuangId = keyValue;
                                    
        }
        #endregion
    }
}