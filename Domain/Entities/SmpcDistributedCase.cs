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
    [Table(name: "SMPC_Distributed_Cases")]
    public class SmpcDistributedCase
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("IDSMPC_Case")]
        public int IDSMPCCase { get; set; }

        [ForeignKey("IDSMPCCase")]
        public virtual SmpcCase Case { get; set; }

        [Column("IDSMPC_Coverage_Zone")]
        public int IDSMPCCoverageZone { get; set; }

        [ForeignKey("IDSMPCCoverageZone")]
        public virtual SmpcZone Zone { get; set; }

        [Column("NotfiedPatrol")]
        [Unicode(false)]
        [MaxLength(1000)]
        public required string NotfiedPatrol { get; set; }

        [Column("VerificationPatrol")]
        [Unicode(false)]
        [MaxLength(1000)]
        public required string VerificationPatrol { get; set; }

        [Column("CallDescription")]
        [Unicode(false)]
        [MaxLength(1000)]
        public required string CallDescription { get; set; }

        [Column("VerificationDescription")]
        [Unicode(false)]
        [MaxLength(1000)]
        public required string VerificationDescription { get; set; }

        [Column("Orders")]
        [Unicode(false)]
        [MaxLength(1000)]
        public required string Orders { get; set; }

        [Column("ChangedZoneDescription")]
        [Unicode(false)]
        [MaxLength(1000)]
        public required string ChangedZoneDescription { get; set; }

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
