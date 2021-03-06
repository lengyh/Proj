using System;
using System.Data;
using System.Collections.Generic;

namespace WorksShow.BLL
{
    /// <summary>
    /// 资讯模块
    /// </summary>
    public partial class article
    {
        private readonly DAL.article dal = new DAL.article();
        public article()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.article model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.article model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int channel_id, int id)
        {
            return dal.Delete(channel_id, id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WorksShow.Model.article GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">where子句</param>
        /// <param name="maxNum">最大数据条数，默认为0,为0时取全部数据</param>
        /// <returns></returns>
        public DataSet GetList(string strWhere,int maxNum=0)
        {
            return dal.GetList(maxNum, strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion  Method

    }
}