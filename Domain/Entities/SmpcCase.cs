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
    [Table(name: "SMPC_Cases")]
    public class SmpcCase
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("IDSMPC_Call_Types")]
        public int IDSMPCCallTypes { get; set; }

        [ForeignKey("IDSMPCCallTypes")]
        public virtual SmpcCallType CallType { get; set; }

        [Column("Caller_Name")]
        [Unicode(false)]
        [MaxLength(1000)]
        public required string CallerName { get; set; }

        [Column("Caller_Phone")]
        [Unicode(false)]
        [MaxLength(1000)]
        public required string CallerPhone{ get; set; }

        [Column("Address")]
        [Unicode(false)]
        [MaxLength(1000)]
        public required string Address { get; set; }

        [Column("Description")]
        [Unicode(false)]
        [MaxLength(1000)]
        public required string Description { get; set; }

        [Column("IDSMPC_Caller")]
        public int IDSMPCCaller { get; set; }

        [ForeignKey("IDSMPCCaller")]
        public virtual SmpcCaller Caller { get; set; }

        [Column("IDSMPC_Call_Reason")]
        public int IDSMPCCallReason { get; set; }

        [ForeignKey("IDSMPCCallReason")]
        public virtual SmpcCallReason CallReason { get; set; }

        [Column("OrgID")]
        public int OrgId { get; set; }

        [ForeignKey("OrgId")]
        public virtual SmpcOrganigram Organigram { get; set; }

        [Column("IDSMPC_Coverage_Zone")]
        public int IDSMPCCoverageZone { get; set; }

        [ForeignKey("IDSMPCCoverageZone")]
        public virtual SmpcZone CoverageZone { get; set; }

        [Column("IsForSupervisor")]
        public byte IsForSupervisor { get; set; }

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
