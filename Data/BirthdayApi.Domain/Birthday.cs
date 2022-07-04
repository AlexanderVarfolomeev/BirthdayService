using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayApi.Domain
{
    public class Birthday : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public BirthdayDate Time { get; set; }
    }
}
