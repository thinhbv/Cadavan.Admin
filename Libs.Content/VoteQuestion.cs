using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Libs.Db;

namespace Libs.Content
{
    public class VoteQuestion
    {
        public int QuestionID { get; set; }
        public string Name { get; set; }
        public int VoteID { get; set; }
        public int Count { get; set; }
        public int Percent { get; set; }
        public int ReturnValue { get; set; }

        public VoteQuestion()
        {

        }

        ~VoteQuestion()
        {

        }

        public virtual void Dispose()
        {

        }

        /// <summary>
        /// Lấy giá trị của câu hỏi thăm dò theo ID
        /// </summary>
        /// <param name="voteID"></param>
        /// <returns></returns>
        public VoteQuestion Get(int questionID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<VoteQuestion>("sp_VoteQuestion_Select", new SqlParameter("@QuestionID", questionID));
        }

        /// <summary>
        /// Lấy giá trị của câu hỏi thăm dò theo ID
        /// </summary>
        /// <returns></returns>
        public VoteQuestion Get()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<VoteQuestion>("sp_VoteQuestion_Select", new SqlParameter("@QuestionID", QuestionID));
        }


        /// <summary>
        /// Lấy danh sách danh mục
        /// </summary>
        /// <returns></returns>
        public List<VoteQuestion> GetList(int voteID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetListSP<VoteQuestion>("sp_VoteQuestion_SelectList", new SqlParameter("@VoteID", voteID));
        }

        /// <summary>
        /// Thêm mới câu hỏi thăm dò
        /// </summary>
        public void Add()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[3];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@VoteID", VoteID);

            db.ExecuteNonQuerySP("sp_VoteQuestion_Insert", pars);
            VoteID = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Xóa câu hỏi thăm dò
        /// </summary>
        public void Delete()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@QuestionID", QuestionID);

            db.ExecuteNonQuerySP("sp_VoteQuestion_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Xóa câu hỏi thăm dò
        /// </summary>
        public void Delete(int questionID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@QuestionID", questionID);

            db.ExecuteNonQuerySP("sp_VoteQuestion_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Cập nhật câu hỏi thăm dò
        /// </summary>
        public void Update()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[5];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@QuestionID", QuestionID);
            pars[2] = new SqlParameter("@Name", Name);
            pars[3] = new SqlParameter("@VoteID", VoteID);
            pars[4] = new SqlParameter("@Count", Count);
            db.ExecuteNonQuerySP("sp_VoteQuestion_Update", pars);
            VoteID = Convert.ToInt32(pars[0].Value);
        }
    }
}
