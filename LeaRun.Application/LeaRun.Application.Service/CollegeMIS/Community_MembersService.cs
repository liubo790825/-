using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 10:41
    /// �� �������Ż�Ա��
    /// </summary>
    public class Community_MembersService : RepositoryFactory<Community_MembersEntity>, Community_MembersIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<Community_MembersEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<Community_MembersEntity>();
             //�ο�����
             var queryParam = queryJson.ToJObject();
            /*if (!queryParam["�ֶ�1"].IsEmpty()){
                 string FullHead = queryParam["�ֶ�1"].ToString();
                 expression = expression.And(t => t.�ֶ�1.Contains(�ֶ�1));
             }
             //������ֶ�2���ֶ�3Ҳ����д...
             expression = expression.And(t => t.CM_Id > 0);*/
             return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<Community_MembersEntity> GetList(string conn, string queryJson)
        {
            
            return this.BaseRepository(conn).IQueryable().ToList();
        }

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        public Community_MembersEntity GetSingleEntity(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<Community_MembersEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["CM_Id"].IsEmpty())
            {
                string CM_Id = queryParam["CM_Id"].ToString();
                expression = expression.And(t => t.CM_Id.Equals(CM_Id));
            }
            if (!queryParam["C_Id"].IsEmpty())
            {
                string C_Id = queryParam["C_Id"].ToString();
                expression = expression.And(t => t.C_Id.Equals(C_Id));
            }
            //������ֶ�2���ֶ�3Ҳ����д...
            expression = expression.And(t => !string.IsNullOrEmpty(t.CM_Id));
            return this.BaseRepository(conn).FindEntity(expression);
        }


        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public Community_MembersEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string conn, string keyValue)
        {
            this.BaseRepository(conn).Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, Community_MembersEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository(conn).Update(entity);
            }
            else
            {
                //��Ҫ��ѯ�������Ƿ��Ѿ���������ѧ����������������Ѿ�����ˣ��Ͳ������
                /*string jsonStr = "{";
                jsonStr += "\"CMI_Id\":" + "\"" + entity.CMI_Id + "\"";
                jsonStr += ",\"C_Id\":"+"\""+ entity.C_Id + "\"" ;
                jsonStr += "}";
                Community_MembersEntity model = this.GetSingleEntity(conn, jsonStr);
                if (model == null)*/
                {
                    entity.Create();
                    this.BaseRepository(conn).Insert(entity);
                }
                
            }
        }
        #endregion
    }
}
