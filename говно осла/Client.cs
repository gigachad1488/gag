using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace говно_осла
{
    public class Client
    {
        private string fio;
        private int phonenumber;
        private string email;

        public string Fio { get => fio; set => fio = value; }
        public int Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Email { get => email; set => email = value; }
    }
}
