using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RusadaAssignment.Custom_Validation;

namespace RusadaAssignment.Models
{
    public class RusadaWebApp
    {
        public int Id { get; set; }

        //Make
        [Required(ErrorMessage = "Field can not be empty!")]
        [MaxLength(128, ErrorMessage = "Maximum number of characters that can be entered is 128!")]
        public string Make { get; set; }

        //Model
        [Required(ErrorMessage = "Field can not be empty!")]
        [MaxLength(128, ErrorMessage = "Maximum number of characters that can be entered is 128!")]
        public string Model { get; set; }

        //Registration
        [Required(ErrorMessage = "Field can not be empty!")]
        public string Registration { get; set; }

        //Location
        [Required(ErrorMessage = "Field can not be empty!")]
        [MaxLength(225, ErrorMessage = "Maximum number of characters that can be entered is 225!")]
        public string Location { get; set; }

        //DateTime
        [Required(ErrorMessage = "Field can not be empty!")]
        [LessDate]
        public DateTime dateTime { get; set; }

        public RusadaWebApp()
        {

        }
    }

    
}
