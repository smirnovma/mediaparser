using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MediaParser.Models.ViewModels
{
    public class MainLinkViewModel
    {
        [Display(Name = "Link to video")]
        [Required(ErrorMessage = "You need to insert a link")]
        [Url(ErrorMessage = "Invalid URL specified")]
        public string Link { get; set; }
        public BusinessLogic.Types.InfoUnit InfoUnit { get; set; }
    }
}