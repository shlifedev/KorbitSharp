using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korbit.API
{
    public abstract class APIBase
    { 
        public abstract string Method { get; }
        public abstract string Resource { get; }
        public abstract void Request();

        //for generic reflection.
        public class ParamBase { }
        public class ResponseBase { } 
    }
}
