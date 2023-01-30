using FluentValidation;
using Newtonsoft.Json;

namespace VPM.Models.Request
{
    /// <summary>
    /// 
    /// </summary>

    public class UserAuthenticationRequestValidator : AbstractValidator<UserAuthenticationRequest>
    {
        /// <summary>
        /// 
        /// </summary>
        public UserAuthenticationRequestValidator()
        {
            this.RuleFor(m => m.Username).NotEmpty().NotNull().MaximumLength(50).OverridePropertyName("username");
            this.RuleFor(m => m.Password).NotEmpty().NotNull().MaximumLength(500).OverridePropertyName("password");
        }
    }

    /// <summary>
    /// 
    /// </summary>   
    public class UserAuthenticationRequest
    {
        /// <summary>
        /// The string that you assign as name username.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }
        /// <summary>
        /// The string that you assign as password.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }
    }
    
}
