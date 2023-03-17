using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Domain.Entities
{
    public class Visit
    {
        public int Id;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public Decimal? TotalPrice { get; set; }
        public bool IsCancelled { get; set; } = false;
        public string? CancellationReason { get; set; }
        public DateTime? CancellationDate { get; set; }

        public BeautyStudio BeautyStudio { get; set; } = default!;
        public int BeautyStudioId { get; set; }
        public Client Client { get; set; } = default!;
        public int ClientId { get; set; }
        public User Beautician { get; set; } = default!;
        public int BeauticianId { get; set; }
    }
}
