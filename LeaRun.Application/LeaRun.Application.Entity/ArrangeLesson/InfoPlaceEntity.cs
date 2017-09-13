using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 12:31
    /// �� ����InfoPlace
    /// </summary>
    public class InfoPlaceEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public int? PlaceId { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string PlaceCode { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string PlaceName { get; set; }
        /// <summary>
        /// �ص�
        /// </summary>
        /// <returns></returns>
        public string PlaceAddress { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        /// <returns></returns>
        public string PlaceStatus { get; set; }
        /// <summary>
        /// У��
        /// </summary>
        /// <returns></returns>
        public string CampusName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public int? Capacity { get; set; }
        /// <summary>
        /// ¥��
        /// </summary>
        /// <returns></returns>
        public string BuildingName { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string PlaceType { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.PlaceId = 0;// Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.PlaceId = keyValue;
                                    
        }
        #endregion
    }
}