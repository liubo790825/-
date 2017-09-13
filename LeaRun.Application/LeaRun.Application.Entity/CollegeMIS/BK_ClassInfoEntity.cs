using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 10:04
    /// �� ����רҵ����
    /// </summary>
    public class BK_ClassInfoEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ClassId
        /// </summary>
        /// <returns></returns>
        [Column("CLASSID")]
        public string ClassId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("CLASSNO")]
        public string ClassNo { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("CLASSNAME")]
        public string ClassName { get; set; }
        /// <summary>
        /// ϵ����
        /// </summary>
        /// <returns></returns>
        [Column("DEPTNO")]
        public string DeptNo { get; set; }
        /// <summary>
        /// רҵ��
        /// </summary>
        /// <returns></returns>
        [Column("MAJORNO")]
        public string MajorNo { get; set; }
        /// <summary>
        /// רҵ����ţ���0��1��2��3��4��5��      0������רҵ����ϸ��
        /// </summary>
        /// <returns></returns>
        [Column("MAJORDETAILNO")]
        public string MajorDetailNo { get; set; }
        /// <summary>
        /// רҵ������
        /// </summary>
        /// <returns></returns>
        [Column("MAJORDETAILNAME")]
        public string MajorDetailName { get; set; }
        /// <summary>
        /// �꼶
        /// </summary>
        /// <returns></returns>
        [Column("GRADE")]
        public string Grade { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        /// <returns></returns>
        [Column("STUNUM")]
        public Int16 StuNum { get; set; }
        /// <summary>
        /// �꼶�����
        /// </summary>
        /// <returns></returns>
        [Column("SERIALNUM")]
        public string SerialNum { get; set; }
        /// <summary>
        /// ������ְ����
        /// </summary>
        /// <returns></returns>
        [Column("CLASSDIREDCTORNO")]
        public string ClassDiredctorNo { get; set; }
        /// <summary>
        /// ����Աְ����   
        /// </summary>
        /// <returns></returns>
        [Column("CLASSTUTORNO")]
        public string ClassTutorNo { get; set; }
        /// <summary>
        /// �༶����ȫ��(�����꼶��רҵ���ơ�����Զ����ɣ�
        /// </summary>
        /// <returns></returns>
        [Column("CLASSNAMEFULL")]
        public string ClassNameFull { get; set; }
        /// <summary>
        /// ��˱�־
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
            this.ClassId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
            this.CheckMark = 0;
            this.EnableRemark = 1;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ClassId = keyValue;
                                    
        }
        #endregion
    }
}