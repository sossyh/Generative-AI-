using Taskmanagement.Application.Models.Identity;
using Taskmanagement.Application.Responses;

namespace Taskmanagement.Application.Contracts.Identity;

public interface IAuthService
{
    public Task<Result<RegistrationResponse>> Register(RegistrationModel request);

    public Task<Result<LoginResponse>> Login(LoginModel request);

    public Task<Result<string>> sendConfirmEmailLink(string Email);

    public  Task<Result<string>> ConfirmEmail(string token, string email);
    
    public  Task<Result<string>> ForgotPassword(string Email);

    public  Task<Result<string>> ResetPassword(ResetPasswordModel resetPasswordModel);

    public Task<bool> DeleteUser(string Email);



}
