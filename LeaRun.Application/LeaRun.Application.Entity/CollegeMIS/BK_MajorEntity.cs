using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 09:57
    /// �� ����ϵ��
    /// </summary>
    public class BK_MajorEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ��ʶ��
        /// </summary>
        /// <returns></returns>
        [Column("MAJORID")]
        public string MajorId { get; set; }
        /// <summary>
        /// רҵ����   ���ã�3λ��
        /// </summary>
        /// <returns></returns>
        [Column("MAJORNO")]
        public string MajorNo { get; set; }
        /// <summary>
        /// רҵ����
        /// </summary>
        /// <returns></returns>
        [Column("MAJORNAME")]
        public string MajorName { get; set; }
        /// <summary>
        /// רҵӢ������
        /// </summary>
        /// <returns></returns>
        [Column("MAJORNAMEEN")]
        public string MajorNameEn { get; set; }
        /// <summary>
        /// רҵ���Ƽ��
        /// </summary>
        /// <returns></returns>
        [Column("MAJORNAMEBRIEF")]
        public string MajorNameBrief { get; set; }
        /// <summary>
        /// ��ίרҵ����
        /// </summary>
        /// <returns></returns>
        [Column("GOVMAJORNO")]
        public string GovMajorNo { get; set; }
        /// <summary>
        /// ��ίרҵ����
        /// </summary>
        /// <returns></returns>
        [Column("GOVMAJORNAME")]
        public string GovMajorName { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        [Column("LENGTHOFSCHOOLING")]
        public decimal? LengthOfSchooling { get; set; }
        /// <summary>
        /// ѧ���������
        /// </summary>
        /// <returns></returns>
        [Column("SUBJECTSPECIESNO")]
        public string SubjectSpeciesNo { get; set; }
        /// <summary>
        /// ϵ������
        /// </summary>
        /// <returns></returns>
        [Column("DEPTNO")]
        public string DeptNo { get; set; }
        /// <summary>
        /// רҵѧλ���루ѧ��������룩
        /// </summary>
        /// <returns></returns>
        [Column("SUBJECTSPECIESNO1")]
        public string SubjectSpeciesNo1 { get; set; }
        /// <summary>
        /// ��ר�ƴ���
        /// </summary>
        /// <returns></returns>
        [Column("GRADUATENO")]
        public string GraduateNo { get; set; }
        /// <summary>
        /// רҵ����
        /// </summary>
        /// <returns></returns>
        [Column("MAJORDIRECTOR")]
        public string MajorDirector { get; set; }
        /// <summary>
        /// ������רҵ��־����Ϊ1��Ϊ�����������е�רҵ
        /// </summary>
        /// <returns></returns>
        [Column("FRESHSTUMARK")]
        public int FreshStuMark { get; set; }
        /// <summary>
        /// ����־
        /// </summary>
        /// <returns></returns>
        [Column("CHECKMARK")]
        public int CheckMark { get; set; }
        /// <summary>
        /// ��Ч
        /// </summary>
        [Column("EnableRemark")]
        public int EnableRemark { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.MajorId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
            this.EnableRemark = 1;
            this.FreshStuMark = 1;
            this.CheckMark = 0;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.MajorId = keyValue;
                                    
        }
        #endregion
    }
}