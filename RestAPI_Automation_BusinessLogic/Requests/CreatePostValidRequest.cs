﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI_Automation_BusinessLogic.Requests
{
    public class CreatePostValidRequest
    {
        public string id { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public string email { get; set; }
    }
}