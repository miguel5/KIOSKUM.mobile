using System;
using System.Collections.Generic;
using System.Text;

namespace KIOSKUM.mobile.PostModels
{
    public class EditarContaPostModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int NumTelemovel { get; set; }
        public string PasswordAtual { get; set; }
        public string NovaPassword { get; set; }
    }
}
