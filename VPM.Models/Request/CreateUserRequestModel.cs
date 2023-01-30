using FluentValidation;
using System;
using System.Collections.Generic;

namespace VPM.Models.Request
{

    public class CreateMemberRequestValidator : AbstractValidator<CreateUserRequestModel>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateMemberRequestValidator()
        {
            this.RuleFor(model => model.FirstName).NotEmpty().NotNull().OverridePropertyName("first_name").MaximumLength(50);
            this.RuleFor(model => model.LastName).NotEmpty().NotNull().OverridePropertyName("last_name").MaximumLength(50);
            this.RuleFor(m => m.Email).NotEmpty().NotNull().EmailAddress().MaximumLength(50);
            this.RuleFor(model => model.Password).NotEmpty().NotNull().MinimumLength(8).OverridePropertyName("password");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateUserRequestModel
    {       
        /// <summary>
        ///  Email address of the user.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>
        ///  First name of the user.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("firstname")]
        public string FirstName { get; set; }

        /// <summary>
        ///  Last name of the user.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("lastname")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty("password")]
        public string Password { get; set; }



    }


}

