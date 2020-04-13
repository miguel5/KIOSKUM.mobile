using System;
using System.Collections.Generic;
using System.Text;

namespace KIOSKUM.mobile.Models
{
    class ErrorMessages
    {
        public static Dictionary<int, string> _messages = new Dictionary<int, string>
        {
            {1, "O email inserido já existe"},
            {2, "Número de telemóvel inserido já existe"},
            {3, "Nome inserido ultrapassa o limite de caractéres"},
            {4, "O formato do email inserido é inválido"},
            {5, "A password deve ter entre 8 e 45 caractéres"},
            {6, "O número de telemóvel inserido é inválido"},
            {7, "O Email inserido não existe"},
            {8, "Codigo de Validação invlálido .Tentativas restantes: "},
            {9, "Numero de tentativas excedido. A sua conta foi removida"},
            {10, "<TODO>"},
            {11, "A conta já se encontra validada"},
            {12, "Email ou Password Incorreta"},
            {13, "Erro de autenticação"},
            {20, "Preenchimento obrigatório de todos os campos" },
            {21, "Erro do lado do servidor" }
        };
    }
}
