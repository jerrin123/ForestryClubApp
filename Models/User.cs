//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ForestryClubApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="Required")]
        [Display(Name ="Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[a-zA-Z\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long and include one uppercase letter, one lowercase letter, one digit, and one symbol (@, $, !, %, *, ?, or &)")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[a-zA-Z\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long and include one uppercase letter, one lowercase letter, one digit, and one symbol (@, $, !, %, *, ?, or &)")]

        public string UserPassword { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Department")]
        public string UserDepartment { get; set; }
    }
}


//[Required(ErrorMessage = "Required")]
//[Display(Name = "Name")]