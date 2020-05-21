using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestoChaud.Data
{
    public class Company
    {
        public Company()
        {
            Sites = new HashSet<Site>();
        }

        [Key]
        public int CompanyId { get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [InverseProperty("Company")]
        public virtual ICollection<Site> Sites { get; set; }
    }
}
