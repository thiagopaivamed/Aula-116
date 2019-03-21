using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emails.Models
{
    public class EmailViewModel
    {
        public string Email { get; set; }

        public string Assunto { get; set; }

        public string Mensagem { get; set; }
    }
}
