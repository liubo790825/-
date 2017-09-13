using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-17 12:29
    /// �� ������������
    /// </summary>
    public class M_BK_AppChangeBedEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>   
        public string ID { get; set; }
        /// <summary>
        /// ����ѧ��ID��
        /// </summary>
        /// <returns></returns>
        public string AppStuId { get; set; }
        /// <summary>
        /// �����˰༶ID��
        /// </summary>
        /// <returns></returns>
        public string AppClassId { get; set; }
        /// <summary>
        /// ������ѧ��
        /// </summary>
        /// <returns></returns>
        public string AppStuNo { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        public string AppStuName { get; set; }
        /// <summary>
        /// �����˵绰
        /// </summary>
        /// <returns></returns>
        public string AppStuPhone { get; set; }
        /// <summary>
        /// ԭ��λID��
        /// </summary>
        /// <returns></returns>
        public string OldBedId { get; set; }
        /// <summary>
        /// Ŀ��ѧ��ID�ţ�����Ϊ��
        /// </summary>
        /// <returns></returns>
        public string TargetStuId { get; set; }
        /// <summary>
        /// Ŀ��ѧ���༶ID�ţ�����Ϊ��
        /// </summary>
        /// <returns></returns>
        public string TargetClassId { get; set; }
        /// <summary>
        /// Ŀ��ѧ���ţ�����Ϊ��
        /// </summary>
        /// <returns></returns>
        public string TargetStuNo { get; set; }
        /// <summary>
        /// Ŀ��ѧ������������Ϊ��
        /// </summary>
        /// <returns></returns>
        public string TargetStuName { get; set; }
        /// <summary>
        /// Ŀ��ѧ���绰
        /// </summary>
        /// <returns></returns>
        public string TargetStuPhone { get; set; }
        /// <summary>
        /// Ŀ��˵����ͬ��˵��
        /// </summary>
        /// <returns></returns>
        public string TargetRemark { get; set; }
        /// <summary>
        /// Ŀ�괲λID��
        /// </summary>
        /// <returns></returns>
        public string NewBedId { get; set; }
        /// <summary>
        /// Ŀ��ѧ���Ƿ�ͬ�⣬0δ�鿴��1ͬ�⣬2��ͬ��
        /// </summary>
        /// <returns></returns>
        public int? TargetPassed { get; set; }
        /// <summary>
        /// �Ƿ�ͨ����1�����У�0δͨ����2ͨ��
        /// </summary>
        /// <returns></returns>
        public int? Passed { get; set; }
        /// <summary>
        /// ͨ��ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? PassedTime { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? AppDatetime { get; set; }
        /// <summary>
        /// ����ԭ��
        /// </summary>
        /// <returns></returns>
        public string AppRemark { get; set; }
        /// <summary>
        /// �Ƿ�ȡ�����룬0δȡ����1ȡ��
        /// </summary>
        /// <returns></returns>
        public int? DeleteMark { get; set; }
        /// <summary>
        /// ����ȡ������ʹ�ã�1δȡ����0ȡ��
        /// </summary>
        /// <returns></returns>
        public int? EnableMark { get; set; }
        /// <summary>
        /// ȡ��ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? CancelTime { get; set; }
        /// <summary>
        /// �༶��
        /// </summary>
        /// <returns></returns>
        public string ClassName { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string DormName { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        /// <returns></returns>
        public string BedName { get; set; }

        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ID = keyValue;
                                    
        }
        #endregion
    }
}