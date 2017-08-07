using System;
using System.Data;
using System.Collections.Generic;
using WorksShow.Model;
namespace WorksShow.BLL
{
    /// <summary>
    /// ͼ������
    /// </summary>
    public partial class photo_attribute
    {
        private readonly WorksShow.DAL.photo_attribute dal = new WorksShow.DAL.photo_attribute();
        public photo_attribute()
        { }
        #region  Method

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(WorksShow.Model.photo_attribute model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(WorksShow.Model.photo_attribute model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public WorksShow.Model.photo_attribute GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        #endregion  Method
    }
}