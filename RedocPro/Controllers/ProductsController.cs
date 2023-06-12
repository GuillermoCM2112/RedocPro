using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RedocPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("nombre/{id}")]
        public string LeerNombre(int id)
        {
            return id switch
            {
                1 => "Net",
                2 => "mentor",
                _ => throw new System.NotImplementedException()
            };
        }
    }
}
