using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Korbit
{
    public static class ReflectionUtility
    {
        public static string MakeURLParameter(object obj)
        {
            if(obj == null)
                return null;

            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields();
            int length = fields.Length;
            int loopIdx = 0;
            string sendParam = "?";
            foreach (var field in fields)
            {
                var key = field.Name;
                var value = field.GetValue(obj);

                sendParam += $"{key}={value}";
                if (loopIdx != length - 1)
                    sendParam += "&";
                loopIdx++;
            }

            return sendParam;
        }
    }
}
