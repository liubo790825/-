using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 15:23
    /// �� ����TeachingPlan
    /// </summary>
    public class TeachingPlanEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("TEACHINGPLANID")]
        public int? TeachingPlanId { get; set; }
        /// <summary>
        /// �ƻ����
        /// </summary>
        /// <returns></returns>
        [Column("TEACHINGPLANCODE")]
        public string TeachingPlanCode { get; set; }
        /// <summary>
        /// �ƻ�����
        /// </summary>
        /// <returns></returns>
        [Column("TEACHINGPLANNAME")]
        public string TeachingPlanName { get; set; }
        /// <summary>
        /// ѧԺ
        /// </summary>
        /// <returns></returns>
        [Column("COLLEGE")]
        public string College { get; set; }
        /// <summary>
        /// רҵ
        /// </summary>
        /// <returns></returns>
        [Column("MAJOR")]
        public string Major { get; set; }
        /// <summary>
        /// �ڼ�ѧ��
        /// </summary>
        /// <returns></returns>
        [Column("SEMESTER")]
        public int? Semester { get; set; }
        /// <summary>
        /// �꼶
        /// </summary>
        /// <returns></returns>
        [Column("GRADE")]
        public string Grade { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        [Column("XUENIAN")]
        public string Xuenian { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        [Column("XUEQI")]
        public string Xueqi { get; set; }
        /// <summary>
        /// ��־
        /// </summary>
        /// <returns></returns>
        [Column("TPMARK")]
        public string TpMark { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        /// <returns></returns>
        [Column("STATUS")]
        public string Status { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.TeachingPlanId = 0;// Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.TeachingPlanId = keyValue;
                                    
        }
        #endregion
    }
}