using FoC_Potluck.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoC_Potluck.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RSVPForm()
        {
            return View();
        }

        public IActionResult Confirmation(Member member)
        {
            bool errorFound = false;

            if (member == null)
            {
                errorFound = true;
            }

            if (member.FirstName.Length <= 1)
            {
                ViewBag.FirstNameMessage = "*Enter a valid first name";
                errorFound = true;
            }

            if (!member.Email.Contains("@"))
            {
                ViewBag.EmailMessage = "*Enter a valid email";
                errorFound=true;
            }

            if (member.Guest == null)
            {
                ViewBag.Guest = "";
            }
            else
            {
                ViewBag.Guest = $"Guest: {member.Guest}";
            }

            if (errorFound)
            {
                ViewBag.ErrorMessage = "Invalid information was provided. Please try again.";
                return View("RSVPForm");
            }
            else
            {
                
                return View(member);
            }
            

        }
    }
}
