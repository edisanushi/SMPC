using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table(name: "SMPC_HairColor")]
    public class SmpcHairColor
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Unicode(false)]
        [MaxLength(500)]
        public required string Name { get; set; }

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
