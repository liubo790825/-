using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 09:54
    /// �� ����У��
    /// </summary>
    public class BK_DeptEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ϵ��ID
        /// </summary>
        /// <returns></returns>
        [Column("DEPTID")]
        public string DeptId { get; set; }
        /// <summary>
        /// У��ID
        /// </summary>
        /// <returns></returns>
        [Column("AREAID")]
        public string AreaId { get; set; }
        /// <summary>
        /// ϵ�����루���źţ�
        /// </summary>
        /// <returns></returns>
        [Column("DEPTNO")]
        public string DeptNo { get; set; }
        /// <summary>
        /// ϵ������(��������
        /// </summary>
        /// <returns></returns>
        [Column("DEPTNAME")]
        public string DeptName { get; set; }
        /// <summary>
        /// ϵ�������ţ����   Attr
        /// </summary>
        /// <returns></returns>
        [Column("DEPTSHORTNAME")]
        public string DeptShortName { get; set; }
        /// <summary>
        /// ϵ��Ӣ�ļ��
        /// </summary>
        /// <returns></returns>
        [Column("DEPTENBRIEF")]
        public string DeptEnBrief { get; set; }
        /// <summary>
        /// ��������   ֻ�н�ѧ���ŲŻ���ֽ���ѧ���ȶ�������
        /// </summary>
        /// <returns></returns>
        [Column("DEPTSORT")]
        public string DeptSort { get; set; }
        /// <summary>
        /// ϵ��Ӣ�ļ��
        /// </summary>
        /// <returns></returns>
        [Column("DEPTENSHORT")]
        public string DeptEnShort { get; set; }
        /// <summary>
        /// ϵ���ε�ְ����
        /// </summary>
        /// <returns></returns>
        [Column("DEPTDIRECTOR")]
        public string DeptDirector { get; set; }
        /// <summary>
        /// ��ѧ�����ְ����
        /// </summary>
        /// <returns></returns>
        [Column("TEACHSECRETARY")]
        public string TeachSecretary { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("DEPTOLDNAME")]
        public string DeptOldName { get; set; }
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
            this.DeptId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
            this.EnableRemark = 1;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.DeptId = keyValue;
                                    
        }
        #endregion
    }
}