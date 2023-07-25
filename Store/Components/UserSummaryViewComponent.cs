using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Store.Components
{
    public class UserSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public UserSummaryViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public string Invoke()
        {
            return _serviceManager.AuthService.Users().Count().ToString();
        }
    }
}
