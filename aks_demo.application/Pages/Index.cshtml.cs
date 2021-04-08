using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace aks_demo.application.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        public Dictionary<string, string> appSettings { get; set; }
        public Dictionary<string, string> nestedSettings { get; set; }
        public Dictionary<string, string> rootSettings { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            appSettings = new Dictionary<string, string>();
            rootSettings = new Dictionary<string, string>();
            nestedSettings = new Dictionary<string, string>();
        }

        public void OnGet()
        {
           
            appSettings.Add("My non Key Vault based app setting", _configuration["myNonSecretAppSetting"]);

            rootSettings.Add("My new secret", _configuration["myNewSecret"]);
            rootSettings.Add("My other new secret", _configuration["myOtherNewSecret"]);

            nestedSettings.Add("My nested new secret", _configuration["MySecrets:myNewSecret"]);
            nestedSettings.Add("My nested other new secret", _configuration["MySecrets:myOtherNewSecret"]);

        }
    }
}
