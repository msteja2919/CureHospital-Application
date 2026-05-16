using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CureHospitalDALCrossPlatform.Models
{
    public partial class Surgery
    {
        public int SurgeryId { get; set; }
        [JsonIgnore]
        public int DoctorId { get; set; }
        [JsonIgnore]
        public DateTime SurgeryDate { get; set; }
        [JsonIgnore]
        public decimal StartTime { get; set; }
        
        public decimal EndTime { get; set; }
        [JsonIgnore]
        public string SurgeryCategory { get; set; } = null!;
        [JsonIgnore]
        public virtual Doctor Doctor { get; set; } = null!;
        [JsonIgnore]
        public virtual Specialization SurgeryCategoryNavigation { get; set; } = null!;
    }
}
