using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RusadaAssignment.Custom_Validation
{
    public class LessDateAttribute:ValidationAttribute
    {

        public LessDateAttribute() : base("{0} Should Less than current Date")
        {
                
        }

        public override bool IsValid(object value)
        {
            DateTime propValue = Convert.ToDateTime(value);
            if (propValue <= DateTime.Now)
                return true;
            else
                return false;
        }
    }

    
}
