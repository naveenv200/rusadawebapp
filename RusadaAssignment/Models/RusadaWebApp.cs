using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RusadaAssignment.Models
{
    public class RusadaWebApp
    {
        public int Id { get; set; }

        [MaxLength(128, ErrorMessage = "Maximum number of characters that can be entered is 128!")]
        public string Make { get; set; }

        [MaxLength(128, ErrorMessage = "Maximum number of characters that can be entered is 128!")]
        public string Model { get; set; }

        public string Registration { get; set; }

        [MaxLength(225, ErrorMessage = "Maximum number of characters that can be entered is 225!")]
        public string Location { get; set; }

        
        public DateTime dateTime { get; set; }

        public RusadaWebApp()
        {

        }
    }

    
}
