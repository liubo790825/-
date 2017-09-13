using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 16:33
    /// �� ����������Ϣ
    /// </summary>
    public class M_BK_DormEntity : BaseEntity
    {
        #region ʵ���Ա
        
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string DormId { get; set; }
        /// <summary>
        /// ѧ��ID
        /// </summary>
        /// <returns></returns>
        public string StuInfoId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public string DormName { get; set; }
        /// <summary>
        /// ��λId
        /// </summary>
        /// <returns></returns>
        public string BedId { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        /// <returns></returns>
        public string BedName{get;set;}
        /// <summary>
        /// ѧ����
        /// </summary>
        /// <returns></returns>
        public string StuName{get;set;}
        /// <summary>
        /// רҵ��
        /// </summary>
        /// <returns></returns>
        public string MajorDetailName{get;set;}
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        public string NationalityNo{get;set;}
        /// <summary>
        /// ��Դ������
        /// </summary>
        /// <returns></returns>
        public string ProvinceNo{get;set;}
        /// <summary>
        /// �༶��
        /// </summary>
        /// <returns></returns>
        public string ClassNo{get;set;}
        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        [Column("TELEPHONE")]
        public string telephone { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        [Column("TELEPHONE")]
        public string StuNo { get; set; }



        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.DormId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.DormId = keyValue;
                                    
        }
        #endregion
    }
}