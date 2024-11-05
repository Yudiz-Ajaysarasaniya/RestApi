using RestApi.models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.models.Entities
{
    public class Customer : BaseEntity
    {
       
        [Required]
        public string? Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email is not Valid")]
        public string? Email { get; set; }
        [Phone(ErrorMessage = "Phone number is not valid.")]
        public string? Phone { get; set; }
    }
}
