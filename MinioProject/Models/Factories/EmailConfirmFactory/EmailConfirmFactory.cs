using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.WebUtilities;

namespace Models.Factories
{
    public class EmailConfirmFactory : IEmailConfirmFactory
    {
        private readonly UserManager<User> _userManager;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly HttpContextAccessor _httpContextAccessor;
        
        public EmailConfirmFactory(UserManager<User> userManager, IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _urlHelperFactory = urlHelperFactory;
            _actionContextAccessor = actionContextAccessor;
        }

        public async Task<EmailConfirmDto> CreateEmailConfirmAsync(User user)
        {
            string code = CreateCode(user);
            string callBackUrl = CreateCallbackUrl(code, user.Id);

            return new EmailConfirmDto(
                user.Email,
                "Confirm your email",
                $"Please confirm your account by <a href='{callBackUrl}'>clicking here</a>."
            );
        }

        public string CreateCode(User user)
        {
            var token = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;
            return WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
        }

        public string CreateCallbackUrl(string code, string userId)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

            return urlHelper.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code },
                protocol: _httpContextAccessor.HttpContext.Request.Scheme
            );
        }
    }
}