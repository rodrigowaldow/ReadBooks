using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadBooks.Application.InputModels
{
    public class NewNoteInputModel
    {
        public string Content { get; set; }
        public int IdBook { get; set; }
        public int IdUser { get; set; }
    }
}
