using System;
using System.Net.Http;
using System.Web.Http;
using Informatiz.ControleEstoque.Comum.Clases;
using System.Threading.Tasks;
using System.Text;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Correios")]
    public class CorreiosController : ApiController
    {
        private readonly HttpClient _httpClient = new HttpClient();
               
        private async Task<Package> GetPackageTrackingAsync(string packageCode)
        {            
            var url = string.Format(Comum.Clases.Constantes.PACKAGE_TRACKING_URL, packageCode);
            var response = await _httpClient.GetByteArrayAsync(url);
            var html = Encoding.GetEncoding("ISO-8859-1").GetString(response, 0, response.Length - 1);
            return await Task.Run(() => Package.Parse(html));
        }

        [AcceptVerbs("GET")]
        [Route("Rastrear")]
        [Classes.ValidateModel]
        public Package GetPackageTracking(string packageCode)
        {
            return GetPackageTrackingAsync(packageCode).Result;
        }

    }
}
