using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class ContactController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblContact.ToList();
            return View(values);
        }

        public ActionResult DeleteContact(int id)
        {
            var value = db.TblContact.Find(id);
            db.TblContact.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ContactDetail(int id)
        {
            var message = db.TblContact.FirstOrDefault(x => x.ContactID == id);

            if (message == null)
            {
                // Mesaj bulunamazsa, hata sayfasına yönlendirme yapabilirsiniz
                return RedirectToAction("Error");
            }

            return View(message);
        }

        public ActionResult MarkAsRead(int id) // Okundu bilgisini güncelleme
        {
            var message = db.TblContact.Find(id);

            if (message != null)
            {
                message.IsRead = true;
                db.SaveChanges();
            }

            return RedirectToAction("ContactDetail", new { id = id });
        }
    }
}