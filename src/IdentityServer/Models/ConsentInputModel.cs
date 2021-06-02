using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public class ConsentInputModel
    {
        public string Button { get; set; }
        public IEnumerable<string> ScopesConsented { get; set; }

        [Display(Name = "Remember consent")]
        public bool RememberConsent { get; set; }
        public string ReturnUrl { get; set; }
    }
}
