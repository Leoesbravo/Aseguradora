﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
  public  class Email
    {
        public string From;
        public string FromDisplayName { get; set; }

        public string To;

        public string Subject;

        public string Body;
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

    }
}
