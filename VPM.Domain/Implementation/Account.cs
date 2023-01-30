using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VPM.Common;
using VPM.Domain.Interface;
using VPM.Infrastructure.UnitOfWork;
using VPM.Models.Constant;
using VPM.Models.DbEntity;
using VPM.Models.Request;
using VPM.Models.Response;

namespace VPM.Domain.Implementation
{
    public class Account : IAccount
    {
        public IUnitOfWork uow;

        public Account(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        public async Task<UserAuthenticationResponse> Login(UserAuthenticationRequest login)
        {
            var user = new User();

            user = await uow.RepositoryAsync<User>().SingleOrDefaultAsync(t => t.Email.ToLower() == login.Username.ToLower());

            if (user == null)
            {
                throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Entered email is not registered with us", "2");
            }

            if (login.Password == StringCipher.Decrypt(user.Password))
            {
                UserAuthenticationResponse responseModel = await GetResponseModel(user);
                return responseModel;
            }
            else
            {
                var codes = Models.MessageHelper.ReadModuleCodesMessage(MessengerCodeConstant.InvalidUserOrPassword);
                throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, string.Format("Invalid Credentials", login.Username), "3");
            }


        }

        public async Task<UserDetailResponse> Post(CreateUserRequestModel model)
        {
            var isExists = await uow.RepositoryAsync<User>().SingleOrDefaultAsync(m => m.Email == model.Email && !string.IsNullOrEmpty(model.Email));
            if (isExists != null)
            {
                throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, string.Format("User With Email Address - {0} already exists", model.Email), "1");
            }
            var userdoc = CommonHelper.ToDocumentData<CreateUserRequestModel, User>(model);
            userdoc.Sid = Guid.NewGuid();
            userdoc.RefreshToken = CommonHelper.RandomString(50);
            userdoc.Password = StringCipher.Encrypt(model.Password);
            await uow.RepositoryAsync<User>().InsertAsync(userdoc);
            await uow.CommitAsync();
            var userDetailResponse = CommonHelper.ToDocumentData<User, UserDetailResponse>(userdoc);
            return userDetailResponse;
        }
        private async Task<UserAuthenticationResponse> GetResponseModel(User user)
        {
            var responseModel = new UserAuthenticationResponse
            {
                id= user.Id,
                sid = user.Sid,
                email = user.Email,
                firstName = user.FirstName,
                lastName = user.LastName,
                RefreshToken = user.RefreshToken
            };
            responseModel.Token = this.GenerateJSONWebToken(responseModel);
            return responseModel;
        }

        private string GenerateJSONWebToken(UserAuthenticationResponse userInfo)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                 new Claim(JwtRegisteredClaimNames.Sub, userInfo.email),
                new Claim("Id", userInfo.id.ToString()),
                new Claim("Sid", userInfo.sid.ToString()),
                new Claim("Email", userInfo.RefreshToken),
                new Claim("RefreshToken", userInfo.RefreshToken)

                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Audience = AppConfiguration.JwtAudience,
                Issuer = AppConfiguration.JwtIssuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfiguration.JwtKey)), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }

        public async Task<UserAuthenticationResponse> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            var user = await uow.RepositoryAsync<User>().SingleOrDefaultAsync(t => t.Sid == refreshTokenRequest.SID  && t.RefreshToken == refreshTokenRequest.RefreshToken);
            if (user == null)
            {                
                throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Session expired", "6");
            }

            user.RefreshToken = CommonHelper.RandomString(50);
            uow.RepositoryAsync<User>().Update(user);
            await uow.CommitAsync(true);

            UserAuthenticationResponse responseModel = await GetResponseModel(user);
            return responseModel;
        }
    }
}
