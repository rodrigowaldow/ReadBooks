using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadBooks.Core.Exceptions
{
    public class BookAlreadyStartedException : Exception
    {
        public BookAlreadyStartedException() : base ("Book is already in Started status")
        {

        }
    }
}
