using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.DTO
{
    public class ContactListIn
    {
        public int? Id { get; set; }
    }
    public class ContactListOut
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
    public class ContactIn
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
    public class ContactDelIn
    {
        public int Id { get; set; }
    }
}
