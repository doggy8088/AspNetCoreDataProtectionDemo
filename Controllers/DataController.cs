using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection;

namespace AspNetCoreDataProtectionDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        IDataProtector _protector;

        public DataController(IDataProtectionProvider provider)
        {
            // 呼叫 CreateProtector 時要傳入一個 Purpose String 用來區隔不同的保護資料
            _protector = provider.CreateProtector("AspNetCoreDataProtectionDemo.v1");
        }

        [HttpGet("encrypt")]
        public ActionResult<String> Encrypt(string data)
        {
            return _protector.Protect(data);
        }

        [HttpGet("decrypt")]
        public ActionResult<String> Decrypt(string data)
        {
            return _protector.Unprotect(data);
        }
    }
}