﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace _05_Html_Helpers.Models
{
    public class User
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is Required")]
        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage ="Country is Required")]
        public string Country { get; set; }

        public IEnumerable<SelectListItem> CountryList { get; set; } = new List<SelectListItem>();
    }
}
