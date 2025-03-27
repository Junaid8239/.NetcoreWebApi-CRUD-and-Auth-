using Microsoft.AspNetCore.Identity;
using WebApi.Models;

namespace WebApi.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginInasync(SignInModel signInModel);
    }
}
