using System;
using System.Data;
using System.Collections.Generic;
using WorksShow.Model;
namespace WorksShow.BLL
{
    /// <summary>
    /// 类别业务类
    /// </summary>
    public partial class category
    {
        private readonly WorksShow.DAL.category dal = new WorksShow.DAL.category();
        public category()
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
        /// 返回类别名称
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WorksShow.Model.category model)
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
        public bool Update(WorksShow.Model.category model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WorksShow.Model.category GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 取得所有类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetList(int parent_id, int channel_id)
        {
            return dal.GetList(parent_id, channel_id);
        }

        #region 扩展方法================================
        /// <summary>
        /// 取得父节点的ID
        /// </summary>
        public int GetParentId(int id)
        {
            return dal.GetParentId(id);
        }
        #endregion

        #region dan新增=================================
        /// <summary>
        /// 获取学期信息
        /// 默认不包括自己
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public DataSet GetTermList(string parentID,bool includeSelf=false)
        {
            return dal.GetTermList(parentID,includeSelf);
        }

        /// <summary>
        /// 获取指定学期下的指定等级集合信息
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public List<int> GetLevelIDByTermID(string parentID)
        {
            return dal.GetLevelIDByTermID(parentID);
        }

        /// <summary>
        /// 获取指定ID学期的指定等级的编号
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public int GetWorkInfo(string parentID, string title)
        {
            return dal.GetWorkInfo(parentID,title);
        }

        /// <summary>
        /// 获取指定学期下的指定等级集合信息
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public DataSet GetLevelList(string termId)
        {
            return dal.GetLevelList(termId);
        }

        #endregion

        #endregion  Method
    }
}