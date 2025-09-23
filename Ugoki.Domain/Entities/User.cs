using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugoki.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = String.Empty;
        public string PasswordHashed { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string FullName { get; set; } = String.Empty;
    }
}
