using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaParser.Entities.Entities
{
    public class AbstractEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
