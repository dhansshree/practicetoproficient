using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authentica.Models
{
    public class Result<T>
    {
        public System.Net.HttpStatusCode Status { get; set; }

        public List<T> resultList { get; set; }

        public string error { get; set;  }

    }

}