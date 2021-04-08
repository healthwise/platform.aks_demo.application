using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace aks_demo.application
{
    public class MySecrets
    {
        public string myNewSecret { get; set; }
        public string myOtherNewSecret { get; set; }
    }


    public class NestedMySecrets
    {
        public string myNewSecret { get; set; }
        public string myOtherNewSecret { get; set; }
    }
}
