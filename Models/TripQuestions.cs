using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class TripQuestions
    {
        public int QuestionID { get; set; }
        public int TripID { get; set; }
        public int QuestionUserID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int AnswerUserID { get; set; }
        public DateTime QuestionTime { get; set; }
        public DateTime AnswerTime { get; set; }

    }
}