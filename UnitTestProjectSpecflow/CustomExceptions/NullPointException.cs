using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject2.CustomException 
{
   public  class NullPointException : Exception
    {
        public NullPointException()
        {
        }

        public NullPointException(string msg): base(msg)
        {

        }
    }
}
