using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsTripIssue
    {
        public int insert(TripIssues issue)
        {
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DataAccess.AddParamter("@IssueID", issue.IssueID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@TripID", issue.TripID, SqlDbType.Int, 50);


            string sql = "insert into TripIssues(IssueID,TripID) values (@IssueID,@TripID)";
            DataAccess.ExecuteSQLNonQuery(sql, param);

            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from TripIssues");
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["MaxID"].ToString());
            }
            return 0;
        }

        public DataTable getTripIssues(int tripId)
        {
            string sql = "select TripIssues.ID as IssueID,Issues.Issue,TripRequest.ID as TripID,TripRequest.UserID,TripRequest.DriverID from TripIssues inner join Issues on TripIssues.IssueID = Issues.ID inner join TripRequest on tripIssues.TripID = TripRequest.ID where TripRequest.ID = " + tripId.ToString();
            return  DataAccess.ExecuteSQLQuery(sql);
        }
       
        public  DataTable getAllIssues()
        {
            string sql = "Select * from Issues";
            return    DataAccess.ExecuteSQLQuery(sql);

        } 
    }
}