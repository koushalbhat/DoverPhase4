using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JoePizzaApp.Models
{
    public class TrackOrderViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
