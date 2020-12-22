using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusMindEntityLayer
{
    [Serializable]
    public class TechnologyEntity
    {
        public int TechnologyId { get; set; }
        public string TechnologyName { get; set; }
        public string Description { get; set; }
    }
}
