using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadBooks.Application.InputModels
{
    public class NewBookInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int IdBookOwner { get; set; }
        public int TotalPages { get; set; }
    }
}
