using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.HVSMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-08 11:06
    /// �� �����̲Ļ�����Ϣ���̲ı�š��̲����ơ��̲����ߡ���𡢳����硢���ۡ�����񽱽̲ġ���ְ��ר���̲�ISBN����ע����𡢳��棨ӡˢ��ʱ�䡢�����������ܺš���ʼ��(���ӡˢ����)��
    /// </summary>
    public class TbBasicInfoEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// �̲ı��
        /// </summary>
        /// <returns></returns>
        public int? TeachBookId { get; set; }
        /// <summary>
        /// �̲�����
        /// </summary>
        /// <returns></returns>
        public string TeachBook { get; set; }
        /// <summary>
        /// �̲�����
        /// </summary>
        /// <returns></returns>
        public string Author { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string Version { get; set; }
        /// <summary>
        /// ������ ��������CdPubCompany)
        /// </summary>
        /// <returns></returns>
        public string PubCompany { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public decimal? Price { get; set; }
        /// <summary>
        /// ����񽱽̲�(1Ϊ����񽱽̲ģ�0���ǣ�
        /// </summary>
        /// <returns></returns>
        public string IsExcellent { get; set; }
        /// <summary>
        /// ��ְ��ר(1Ϊ��ְ��ר�̲ģ�0���ǣ�
        /// </summary>
        /// <returns></returns>
        public string IsProfessional { get; set; }
        /// <summary>
        /// �̲�ISBN
        /// </summary>
        /// <returns></returns>
        public string ISBN { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// CheckMark
        /// </summary>
        /// <returns></returns>
        public string CheckMark { get; set; }
        /// <summary>
        /// PublishDate
        /// </summary>
        /// <returns></returns>
        public DateTime? PublishDate { get; set; }
        /// <summary>
        /// �̲���𣨷�Ϊ����̲ġ��Ա�̲ġ�ӡˢ���ϣ�
        /// </summary>
        /// <returns></returns>
        public string Sort { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public int? StockSum { get; set; }
        /// <summary>
        /// ��ܺ�
        /// </summary>
        /// <returns></returns>
        public string BookCaseNo { get; set; }
        /// <summary>
        /// ӡˢʱ�䣨�Ա�̲ģ�
        /// </summary>
        /// <returns></returns>
        public DateTime? PressDate { get; set; }
        /// <summary>
        /// ӡˢ�������Ա�̲ĳ�ʼӡˢ������
        /// </summary>
        /// <returns></returns>
        public int? PressSum { get; set; }
        /// <summary>
        /// �̲ġ��Ա�̲ģ����ϣ�����˵��
        /// </summary>
        /// <returns></returns>
        public string Detail { get; set; }
        /// <summary>
        /// DeptNo
        /// </summary>
        /// <returns></returns>
        public string DeptNo { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.TeachBookId = 1;// Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.TeachBookId = keyValue;
                                    
        }
        #endregion
    }
}