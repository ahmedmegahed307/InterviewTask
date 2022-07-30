using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
namespace AFS_.NET_Developer_Test.Controllers
{
    
    public class TranslationController : Controller
    {
        //this is the main controller for all translators.
        //if we needed to use another translator later, we can inject it here and overload Create method.
        private readonly ILeetSpeakService _leetspeak;
        public TranslationController(ILeetSpeakService leetSpeak) 
        {
            _leetspeak = leetSpeak;
            
        }

        [HttpPost] 
        public IActionResult Create(LeetSpeakTranslator translate)
        {
            var data = _leetspeak.CreateLeetSpeak(translate);
            return RedirectToAction("GetCalls","Home");
        }
       

    }
}
