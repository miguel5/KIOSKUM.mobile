using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KIOSKUM.mobile.Models
{
    public class ErrorsList
    {
        [Required]
        public List<int> Erros { get; set; }

        public ErrorsList()
        {
            Erros = new List<int>();
        }
    }
}
