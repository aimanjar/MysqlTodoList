using System;
using System.Collections.Generic;

namespace MySQLTodoList.Models
{
    public partial class TodoTable
    {
        public int Id { get; set; }
        public string Task { get; set; } = null!;
        public string Remark { get; set; } = null!;
        public string StatusActivity { get; set; } = null!;
    }
}
