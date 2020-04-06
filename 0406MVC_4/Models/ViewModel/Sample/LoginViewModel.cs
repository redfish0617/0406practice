using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _0406MVC_4.Models.ViewModel.Sample
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0}欄位為必填")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "{0}欄位長度需介於{2} ~ {1}")]    
        [Display (Name ="帳號")]
        public string UserID { set; get; }
        [Required(ErrorMessage = "{0}欄位為必填")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "{0}欄位長度需介於{2} ~ {1}")]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { set; get; }
        [Display(Name = "保持登入")]
        public bool IsPersistent { set; get; }
        [ScaffoldColumn(false)]
        public string ReturnUrl { set; get; }
    }
}