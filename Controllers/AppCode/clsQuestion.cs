using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsQuestion
    {
        public int insert(TripQuestions Question) {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = DataAccess.AddParamter("@TripID", Question.TripID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@QuestionUserID", Question.QuestionUserID, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@Question", Question.Question, SqlDbType.NVarChar, 500);
            param[3] = DataAccess.AddParamter("@Answer", Question.Answer, SqlDbType.NVarChar, 500);
            param[4] = DataAccess.AddParamter("@AnswerUserID", Question.AnswerUserID, SqlDbType.Int, 50);
            param[5] = DataAccess.AddParamter("@QuestionTime", Question.QuestionTime, SqlDbType.DateTime, 50);
            param[6] = DataAccess.AddParamter("@AnswerTime", Question.AnswerTime, SqlDbType.DateTime, 50);
            string sql = "INSERT INTO [TripQuestions]([TripID],[QuestionUserID],[Question],[Answer],[AnswerUserID],[QuestionTime],[AnswerTime],[QuestionPuplished],[AnswerPuplished]) Values" +
                          "(@TripID,@QuestionUserID,@Question,@Answer,@AnswerUserID,@QuestionTime,@AnswerTime,2,2)";
            DataAccess.ExecuteSQLNonQuery(sql, param);
            int QuestionID =0;
            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(QuestionID) as MaxID from TripQuestions");
              if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
              {
                  QuestionID = int.Parse(dt.Rows[0]["MaxID"].ToString());
              }
              return QuestionID;
        } 
    }
}