using Microsoft.AspNetCore.Mvc;
using System;
using TransliterationLib;

namespace TransliterationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransliterationController : ControllerBase
    {
        private readonly Transliterator _transliterator;
         

        public TransliterationController()
        {
            _transliterator = new Transliterator();
            
        }

        [HttpGet]
        public ActionResult<string> Transliterate([FromQuery] string text)
        {
            try
            {
                var result = _transliterator.Transliterate(text);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
