using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayApi.Domain
{
    public class BirthdayDate
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public ICollection<Birthday> Birthdays { get; set; }
    }
}
