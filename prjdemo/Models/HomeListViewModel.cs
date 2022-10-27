using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace prjdemo.Models
{
    public class HomeListViewModel
    {
        [DisplayName("學號")]
        public string STUD_NO { get; set; }
        [DisplayName("姓名")]
        public string STUD_NAME { get; set; }
        [DisplayName("科系中文名稱")]
        public string DEPT_NAME { get; set; }

    }
}