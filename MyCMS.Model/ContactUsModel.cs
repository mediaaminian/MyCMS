using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyCMS.Model
{
    public class ContactUsModel
    {

        [Required(ErrorMessage = "نام باید وارد شود"),
         MaxLength(500, ErrorMessage = "نام باید کمتر از 500 حرف باشد"),
         MinLength(3, ErrorMessage = "نام باید بیشتر از 3 حرف باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ایمیل باید وارد شود"),
         MaxLength(100, ErrorMessage = "ایمیل باید کمتر از 500 حرف باشد"),
         MinLength(5, ErrorMessage = "ایمیل باید بیشتر از 5 حرف باشد")]
        public string Email { get; set; }

        [MaxLength(15, ErrorMessage = "تلفن باید کمتر از 15 حرف باشد"),
         MinLength(7, ErrorMessage = "تلفن باید بیشتر از 7 حرف باشد")]
        public string Phone { get; set; }

        [MaxLength(100, ErrorMessage = "نام شرکت باید کمتر از 100 حرف باشد")]
        public string CompanyName { get; set; }

        public string Unit { get; set; }

        [Required(ErrorMessage = "موضوع باید وارد شود"),
         MaxLength(500, ErrorMessage = "موضوع باید کمتر از 500 حرف باشد"),
         MinLength(3, ErrorMessage = "موضوع باید بیشتر از 3 حرف باشد")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "متن باید وارد شود"), MinLength(4, ErrorMessage = "متن باید بیشتر از 3 حرف باشد")]
        public string Body { get; set; }
    }
}