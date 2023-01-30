using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VPM.Models.Request;
using VPM.Models.Response;

namespace VPM.Domain.Interface
{
    public interface IAccount
    {
        Task<UserDetailResponse> Post(CreateUserRequestModel user);

        Task<UserAuthenticationResponse> Login(UserAuthenticationRequest login);
        Task<UserAuthenticationResponse> RefreshToken(RefreshTokenRequest refreshTokenRequest);
    }
}
