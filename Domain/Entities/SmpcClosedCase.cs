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
    [Table(name: "SMPC_Closed_Cases")]
    public class SmpcClosedCase
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("IDSMPC_Verification")]
        public int IDSMPCVerification { get; set; }

        [ForeignKey("IDSMPCVerification")]
        public virtual SmpcCallType CallType { get; set; }

        [Column("VerificationDescription")]
        [Unicode(false)]
        [MaxLength(1000)]
        public required string VerificationDescription { get; set; }

        [Column("isComplaint")]
        public byte IsComplaint { get; set; }

        [Column("IDSMPC_VerificatonRsult")]
        public int IDSMPCVerificatonResult { get; set; }

        [ForeignKey("IDSMPCVerificatonResult")]
        public virtual SmpcCallReason CallReason { get; set; }

        [Column("IDSMPC_Case")]
        public int IDSMPCCase { get; set; }

        [ForeignKey("IDSMPCCase")]
        public virtual SmpcCase Case { get; set; }

        [Column("UniqueNumber")]
        [Unicode(false)]
        [MaxLength(50)]
        public string? UniqueNumber { get; set; }

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

        [Column("UniqueNumberDescription")]
        [Unicode(false)]
        [MaxLength(1000)]
        public string? UniqueNumberDescription { get; set; }

        [Column("DeactivationUNDescription")]
        [Unicode(false)]
        [MaxLength(1000)]
        public string? DeactivationUNDescription { get; set; }

        [Column("Id_UN_User")]
        public int? IdUnUser { get; set; }

        [ForeignKey("IdUnUser")]
        public virtual SmpcUser User { get; set; }
    }
}
