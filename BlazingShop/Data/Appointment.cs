using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Data
{
    public class Appointment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public DateTime AppointmentDate { get; set; }

        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerPhone { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        public bool IsConfirmed { get; set; }

    }
}
