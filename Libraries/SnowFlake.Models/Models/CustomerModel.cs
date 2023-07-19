using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFlakeSample.Models
{
    public class CustomerModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("First_Name")]
        public string FirstName { get; set; }

    }
}
