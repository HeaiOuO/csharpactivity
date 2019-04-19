
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CSharpbelt.Models
{
    public class RegisterUser
    {
        //  length and entry both are needed
        // come later to add regex to check if it is only alpha or not
        [Required(ErrorMessage="First name is required and must be at least 2 characters long and must be characters only")]
        [MinLength(2, ErrorMessage="First name is required and must be at least 2 characters long and must be characters only")]
        [RegularExpression("^[a-zA-Z ]*$")]
        [Display(Name = "First Name")]
        public string FirstName {get; set;}


        [Required(ErrorMessage="Last name is required and must be at least 2 characters long and must be characters only")]
        [MinLength(2,ErrorMessage="Last name is required and must be at least 2 characters long and must be characters only")]
        [RegularExpression("^[a-zA-Z ]*$")]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}
        [Required(ErrorMessage="Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email Address")]

        // work on getting the regex for the requirements
        public string Email {get; set;}
        [Required(ErrorMessage="Password must contain 1 letter, 1 number and 1 special character and MUST be 6 characters long")]
        [MinLength(6, ErrorMessage = "Password must contain 1 letter, 1 number and 1 special character and MUST be 6 characters long")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&-_])[A-Za-z\d$@$!%*#?&-_]{8,}$", ErrorMessage = "Password must contain 1 letter, 1 number and 1 special character and MUST be 6 characters long")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password {get; set;}
        [Compare("Password", ErrorMessage="Your Passwords should match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Your Password")]
        public string PasswordConfirm {get; set;}
    }
    public class LoginUser
    {
        [Required(ErrorMessage="Email Validation Failed, this could be due to wrong/invalid email entry")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string LogEmail {get; set;}
        [Required(ErrorMessage="Password is must and it should match the one that you used to create your account")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string LogPassword {get; set;}
    }
    public class NewActivity
    {
        [Required]
        [MinLength(2, ErrorMessage="Title must be at least 2 characters")]
        [Display(Name = "Title")]
        public string Title {get; set;}
        [Required]
        [Display(Name = "Date")]
        [CheckDateRange]
        public DateTime Date {get; set;}
        [Required]
        [Display(Name = "Time")]
        [RegularExpression(@"\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))", ErrorMessage="Please make sure your time is chosen hh/mm AM or PM")]
        public string Time {get; set;}
        [Required]
        [Display(Name = "Duration:")]
        [RegularExpression(@"^[+]?\d+([.]\d+)?$", ErrorMessage = "Only positive numbers allowed")]
        public int Duration {get; set;}
        [Required]
        [MinLength(10, ErrorMessage= "Description must be at leat 10 characters long")]
        public string Description {get; set;}
    }
    public class DashboardModels
    {
        public List<Activity> AllActivities {get; set;}
        public User User {get; set;}
        public List<User> AllUsers {get; set;}
        public List<Activity> JoinedActivities {get; set;}
    }

    //  found it on udemy and also on various forums
    public class CheckDateRangeAttribute: ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        DateTime dt = (DateTime)value;
        if (dt >= DateTime.UtcNow) {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Make sure your date is in the future");
        }
    }
}