using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-07-13 05:03
    /// �� ����BK_BaodaoYuyue
    /// </summary>
    public class BK_BaodaoYuyueService : RepositoryFactory, BK_BaodaoYuyueIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_BaodaoYuyueEntity> GetList(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_BaodaoYuyueEntity>();
            //�ο�����
            //*
            var queryParam = queryJson.ToJObject();
            if (!queryParam["BaodaoOther1"].IsEmpty())//IdentityCardNo
            {
                string IdentityCardNo = queryParam["BaodaoOther1"].ToString();
                expression = expression.And(t => t.BaodaoOther1.Contains(IdentityCardNo));
            }//*/

            //������ֶ�2���ֶ�3Ҳ����д...

            return this.BaseRepository(conn).IQueryable(expression).ToList();
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_BaodaoYuyueEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BK_BaodaoYuyueEntity>();
            //�ο�����
            //*
            var queryParam = queryJson.ToJObject();
            if (!queryParam["BaodaoOther1"].IsEmpty())//IdentityCardNo
            {
                string IdentityCardNo = queryParam["BaodaoOther1"].ToString();
                expression = expression.And(t => t.BaodaoOther1.Contains(IdentityCardNo));
            }//*/
            //������ֶ�2���ֶ�3Ҳ����д...

            //var queryParam = queryJson.ToJObject();
            ////��ѯ����
            //if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            //{
            //    string condition = queryParam["condition"].ToString();
            //    string keyword = queryParam["keyword"].ToString();
            //    switch (condition)
            //    {
            //        case "StuName":            //����
            //            expression = expression.And(t => t.StuName.Contains(keyword));
            //            break;
            //        case "Telephone":       //�绰
            //            expression = expression.And(t => t.Telephone.Contains(keyword));
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //expression = expression.And(t => !string.IsNullOrEmpty(t.YuyueId));
            return this.BaseRepository(conn).FindList(expression, pagination);
        }


        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_BaodaoYuyueEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_BaodaoYuyueEntity>(keyValue);
        }


        //��¼����
        public List<M_BK_NumberEntity> Number(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select COUNT(1) number");
            strsql.Append(@"  from BK_BaodaoYuyue");
            strsql.Append(@"  where 1=1");
            return this.BaseRepository(conn).FindList<M_BK_NumberEntity>(strsql.ToString()).ToList();
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
        public void SaveForm(string conn, string keyValue, BK_BaodaoYuyueEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository(conn).Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository(conn).Insert(entity);
            }
        }
        #endregion
    }
}
