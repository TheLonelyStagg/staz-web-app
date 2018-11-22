using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StazTestApp.Models
{
    public class Przedmiot
    {
        [Required]
        [ScaffoldColumn(false)]
        public int ItemID { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Nazwa przedmiotu")]
        public String Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Cena [zł]")]
        public Double Price { get; set; }

        [Required]
        [DisplayName("Ilość szt.")]
        public int Quantity { get; set; }

        [StringLength(120)]
        [DisplayName("Krótki opis")]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

    }
}