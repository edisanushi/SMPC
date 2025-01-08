using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table(name: "SMPC_Users")]
    public class SmpcUser
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("IDOrg")]
        public int IdOrg { get; set; }

        [ForeignKey("IdOrg")]
        public virtual SmpcOrganigram Organigram { get; set; }

        [Column("Username")]
        [Unicode(false)]
        [MaxLength(1000)]
        public required string Username { get; set; }

        [Column("Password")]
        [Unicode(false)]
        [MaxLength(1000)]
        public required string Password { get; set; }

        [Column("isActive")]
        public byte IsActive { get; set; }

        [Column("CreatedOn")]
        public DateTime? CreatedOn { get; set; }

        [Column("CreatedBy")]
        public int CreatedBy { get; set; }

        [Column("CreatedIP")]
        [Unicode(true)]
        [MaxLength(50)]
        public required string CreatedIP { get; set; }

        [Column("ModifiedOn")]
        public DateTime ModifiedOn { get; set; }

        [Column("ModifiedBy")]
        public int ModifiedBy { get; set; }

        [Column("ModifiedIP")]
        [Unicode(true)]
        [MaxLength(50)]
        public string? ModifiedIP { get; set; }

        [Column("Invalidated")]
        public byte Invalidated { get; set; }
    }
}
