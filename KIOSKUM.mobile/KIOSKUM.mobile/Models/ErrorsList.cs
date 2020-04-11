using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KIOSKUM.mobile.Models
{
    public class ErrorsList
    {
        [Required]
        public List<int> ListaErros { get; set; }

        public ErrorsList()
        {
            ListaErros = new List<int>();
        }
    }
}
