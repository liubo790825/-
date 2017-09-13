using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin2017-7-21 ������
    /// �� �ڣ�2017-07-21 11:00
    /// �� ����BK_JunxunFuzhuang
    /// </summary>
    public class BK_JunxunFuzhuangService : RepositoryFactory, BK_JunxunFuzhuangIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_JunxunFuzhuangEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_JunxunFuzhuangEntity>();
             //�ο�����
             /*var queryParam = queryJson.ToJObject();
             if (!queryParam["�ֶ�1"].IsEmpty()){
                 string FullHead = queryParam["�ֶ�1"].ToString();
                 expression = expression.And(t => t.�ֶ�1.Contains(�ֶ�1));
             }*/
             //������ֶ�2���ֶ�3Ҳ����д...
             //expression = expression.And(t => t.FuzhuangId > 0);
             return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_JunxunFuzhuangEntity> GetList(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_JunxunFuzhuangEntity>();
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
        /// ��ȡ��ѵ��װ��Ϣ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public List<M_BK_JunxunFuzhuangEntity> GetJunXunFuList(string conn, Pagination pagination)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select a.*,b.StuName,b.Gender");
            strSql.Append(@" from BK_JunxunFuzhuang a");
            strSql.Append(@" left join BK_StuInfo b on a.BaodaoOther1=b.IdentityCardNo");
            
            //expression = expression.And(t => !string.IsNullOrEmpty(t.FuzhuangId));
            return this.BaseRepository(conn).FindList<M_BK_JunxunFuzhuangEntity>(strSql.ToString(), pagination).ToList();
        }



        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_JunxunFuzhuangEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_JunxunFuzhuangEntity>(keyValue);
        }


        //��¼����
        public List<M_BK_NumberEntity> Number(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select COUNT(1) number");
            strsql.Append(@"  from BK_JunxunFuzhuang");
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
        public void SaveForm(string conn, string keyValue, BK_JunxunFuzhuangEntity entity)
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
