using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-07 10:07
    /// �� ����BK_LvseTongdao
    /// </summary>
    public class BK_LvseTongdaoEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string LvseId { get; set; }
        /// <summary>
        /// ѧ��ID
        /// </summary>
        /// <returns></returns>
        public string StuInfoId { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public string HujiLeibie { get; set; }
        /// <summary>
        /// ��ͥ����
        /// </summary>
        /// <returns></returns>
        public string FamilyType { get; set; }
        /// <summary>
        /// ����1
        /// </summary>
        /// <returns></returns>
        public string Name1 { get; set; }
        /// <summary>
        /// ��ϵ1
        /// </summary>
        /// <returns></returns>
        public string Relationship1 { get; set; }
        /// <summary>
        /// ������ò1
        /// </summary>
        /// <returns></returns>
        public string ZhengZhiMianMao1 { get; set; }
        /// <summary>
        /// ������λ1
        /// </summary>
        /// <returns></returns>
        public string GongZuoDanWei1 { get; set; }
        /// <summary>
        /// ְλ1
        /// </summary>
        /// <returns></returns>
        public string Position1 { get; set; }
        /// <summary>
        /// ����2
        /// </summary>
        /// <returns></returns>
        public string Name2 { get; set; }
        /// <summary>
        /// ��ϵ2
        /// </summary>
        /// <returns></returns>
        public string Relationship2 { get; set; }
        /// <summary>
        /// ������ò2
        /// </summary>
        /// <returns></returns>
        public string ZhengZhiMianMao2 { get; set; }
        /// <summary>
        /// ������λ2
        /// </summary>
        /// <returns></returns>
        public string GongZuoDanWei2 { get; set; }
        /// <summary>
        /// ְλ2
        /// </summary>
        /// <returns></returns>
        public string Position2 { get; set; }
        /// <summary>
        /// ��ͥ������
        /// </summary>
        /// <returns></returns>
        public int? FamilyNumber { get; set; }
        /// <summary>
        /// ��ͥ������
        /// </summary>
        /// <returns></returns>
        public int? FamilyMonthIncome { get; set; }
        /// <summary>
        /// �˾�������
        /// </summary>
        /// <returns></returns>
        public int? OneMonthIncome { get; set; }
        /// <summary>
        /// ��ͥ��������˵��
        /// </summary>
        /// <returns></returns>
        public string JingjiKunnan { get; set; }
        /// <summary>
        /// ��Դ�ش�������
        /// </summary>
        /// <returns></returns>
        public string LoanBank { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public int? LoanAmount { get; set; }
        /// <summary>
        /// ��ִ����֤������ͼƬ
        /// </summary>
        /// <returns></returns>
        public string ProveImg { get; set; }
        /// <summary>
        /// �����л�ִУ����
        /// </summary>
        /// <returns></returns>
        public string HuiZhiMa { get; set; }
        /// <summary>
        /// �ύ����
        /// </summary>
        /// <returns></returns>
        public string LvseOther { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string LvseOther1 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string LvseOther2 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string LvseOther3 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string LvseOther4 { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.LvseId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.LvseId = keyValue;
                                    
        }
        #endregion
    }
}