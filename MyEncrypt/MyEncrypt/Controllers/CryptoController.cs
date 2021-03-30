using EscNet.Cryptography.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MyEncrypt.Controllers
{
    [Route("api/v1/crypto")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly IRijndaelCryptography _rijndaelCryptography;

        public CryptoController(IRijndaelCryptography rijndaelCryptography)
        {
            _rijndaelCryptography = rijndaelCryptography;
        }

        [HttpPost]
        [Route("encrypt")]
        public IActionResult Encrypt([FromBody]string text)
        {
            try
            {
                return Ok(_rijndaelCryptography.Encrypt(text));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPost]
        [Route("decrypt")]
        public IActionResult Decrypt([FromBody] string text)
        {
            try
            {
                return Ok(_rijndaelCryptography.Decrypt(text));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}
