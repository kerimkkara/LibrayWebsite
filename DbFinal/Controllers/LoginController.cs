using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DbFinal.Models;
using DbFinal.ViewModels.HomeModels;


namespace DbFinal.Controllers
{
    public class LoginController : Controller
    {
        //Login sayfası view i
        public ActionResult Login()
        {

            return View();

        }

        public ActionResult LoginControl(Administrator administrator)
        {
            // Bu arada login formundan gelen username ve password bilgilerini kontrol ediyorum

            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();

            string username = administrator.administratorUsername;
            string password = administrator.administratorPassword;

            var model = ent.usp_Login(username, password).ToList();
            // Parametreleri prosedüre gönderiyorum

            int sonuc = 0;
            foreach(var item in model)
            {
                 sonuc = item.Value;
            }

            if(sonuc == 1)
            {
                return RedirectToAction("../Home/PublicationList");
            }
            // eğer sonuc 1 ise bilgiler doğru olduğu için sisteme kullanıcıyı alıyorum
            if (sonuc == 0)
            {
                TempData["id"] = "0";
                return RedirectToAction("Login");

                // sonuc 0 ise yeniden login ekranına gönderiyorum
            }

            return View();
           
        }

    }
}