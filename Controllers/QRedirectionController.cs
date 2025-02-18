using Microsoft.AspNetCore.Mvc;

namespace QRedirection.Controllers
{
    [ApiController]
    [Route("redirect")]
    public class RedirectController : Controller
    {
        [HttpGet]
        public IActionResult Index(string? target = null) // Permitir que 'target' sea nulo
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string keitoeHealthAppleUrl = "https://apps.apple.com/es/app/keito-ehealth/id1546250400";
            string keitoeHealthGooglePlayUrl = "https://play.google.com/store/apps/details?id=com.keitoehealth.app";

            // Verificar si el User-Agent corresponde a un dispositivo Apple
            bool isAppleDevice = userAgent.Contains("Macintosh") || userAgent.Contains("iPhone") || userAgent.Contains("iPad") || userAgent.Contains("iPod");

            // Redirigir a las URLs de keitoeHealth si 'target' es nulo o vacío, o si no es 'sm'
            if (string.IsNullOrEmpty(target) || !target.Equals("sm", StringComparison.OrdinalIgnoreCase))
            {
                return isAppleDevice ? Redirect(keitoeHealthAppleUrl) : Redirect(keitoeHealthGooglePlayUrl);
            }

            // Si 'target' es 'sm', redirigir a las URLs específicas de SM
            string SMAppleUrl = "https://apps.apple.com/us/app/sm-demo-by-keito/id6470201705";
            string SMGooglePlayUrl = "https://play.google.com/store/apps/details?id=com.keito.smdemo.app";
            return isAppleDevice ? Redirect(SMAppleUrl) : Redirect(SMGooglePlayUrl);
        }
    }
}


