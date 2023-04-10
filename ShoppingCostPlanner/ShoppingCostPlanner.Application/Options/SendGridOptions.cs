using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Application.Options
{
    public class SendGridOptions
    {
        public string ApiKey { get; set; }
        public string SenderEmail { get; set; }


    }


}
