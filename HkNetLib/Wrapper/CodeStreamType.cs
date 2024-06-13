using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HkNetLib.Wrapper
{
    public enum CodeStreamType
    {
        [Description("主码流")]
        Main =0 ,
        [Description("子码流")]
        Sub = 1,
    }
}
