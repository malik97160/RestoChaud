using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestoChaud.Data
{
    public partial class Site
    {
        public Site()
        {
            Subsidiaries = new HashSet<Site>();
        }

        [Key]
        public int SiteId { get; set; }
        public int CompanyId { get; set; }
        [StringLength(60)]
        public string Address { get; set; }
        [StringLength(15)]
        public string City { get; set; }
        [StringLength(10)]
        public string PostalCode { get; set; }
        [StringLength(15)]
        public string Country { get; set; }
        [StringLength(24)]
        public string Phone { get; set; }
        [StringLength(24)]
        public string Fax { get; set; }
        [StringLength(50)]
        public string OrganisationNumber { get; set; }
        [StringLength(10)]
        public string ActivityCode { get; set; }
        [Column("VATNumber")]
        [StringLength(50)]
        public string Vatnumber { get; set; }
        [StringLength(50)]
        public string Website { get; set; }
        public int? ReferentId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        [InverseProperty(nameof(Data.Company.Sites))]
        public virtual Company Company { get; set; }
        [ForeignKey(nameof(ReferentId))]
        [InverseProperty("Subsidiaries")]
        public virtual Site HeadOffice { get; set; }
        [InverseProperty("HeadOffice")]
        public virtual ICollection<Site> Subsidiaries { get; set; }
    }
}
