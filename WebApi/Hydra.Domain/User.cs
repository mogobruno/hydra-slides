using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Domain
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nationality { get; set; }
        public string Job { get; set; }
        public virtual ICollection<Slide> Slides { get; set; }
    }
}
