using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Application.Models.BeautyStudio
{
    public class GetBeuatyStudioDto
    {
        public string Name { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
