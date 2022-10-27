using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace prjdemo.Models
{
    public class HomeSelectViewModel
    {
        [DisplayName("學號")]
        public string STUD_NO { get; set; }
        [DisplayName("學年")]
        public string ACAD_YEAR { get; set; }
        [DisplayName("學期課號")]
        public string COURSE_NO { get; set; }
        [DisplayName("系所中文名稱")]
        public string DEPT_NAME { get; set; }
        [DisplayName("課程中文名稱")]
        public string SUBJ_NAME { get; set; }
    }
}