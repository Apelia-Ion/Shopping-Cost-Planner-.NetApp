using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Domain.Models
{
    public class EmailSendModel
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
