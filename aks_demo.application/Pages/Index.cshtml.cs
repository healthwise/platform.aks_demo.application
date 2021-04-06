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

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            appSettings = new Dictionary<string, string>();
        }

        public void OnGet()
        {
            var mySecrets = new MySecrets();
            _configuration.GetSection("MySecrets").Bind(mySecrets);
            appSettings.Add("My new secret", mySecrets.myNewSecret);
            appSettings.Add("My other new secret", mySecrets.myOtherNewSecret);

        }
    }
}
