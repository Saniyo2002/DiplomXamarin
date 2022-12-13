using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public class AuthResponseToken
    {
        public string Token { get; set; }
        public Clients User { get; set; }

    }
}
