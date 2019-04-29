using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebMvc.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebMvc.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(int idUser)
        {
            IEnumerable<UserModel> usersList;
            //IQueryable<RoleModel> rolesList;

            // Get Users
            HttpResponseMessage resp = _Global.apiClient.GetAsync("User").Result;
            usersList = resp.Content.ReadAsAsync<IEnumerable<UserModel>>().Result;

            ViewBag.CurrentUser = usersList.Where(u => u.idUser == idUser).FirstOrDefault();

            return View(usersList);
        }

        public ActionResult CreateOrEdit(int current, int idUser = 0)
        {
            ViewBag.CurrentId = current;

            HttpResponseMessage _resp = _Global.apiClient.GetAsync("Role").Result;
            var rolesList = _resp.Content.ReadAsAsync<IEnumerable<RoleModel>>().Result;

            List<int> roles = new List<int>();
            foreach (var item in rolesList)
            {
                roles.Add(item.idRole);
            }
            ViewBag.Roles = rolesList; // List of roles to show in dropdown list

            if (idUser == 0) // Create user
            {
                return View(new UserModel());
            }
            else // Edit user
            {
                HttpResponseMessage resp = _Global.apiClient.GetAsync("User/" + idUser.ToString()).Result;
                return View(resp.Content.ReadAsAsync<UserModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult CreateOrEdit(UserModel user, int current)
        {
            if (user.idUser == 0) // Create user
            {
                HttpResponseMessage resp = _Global.apiClient.PostAsJsonAsync("User", user).Result;
            }
            else // Edit user
            {
                HttpResponseMessage resp = _Global.apiClient.PutAsJsonAsync("User/" + user.idUser, user).Result;
            }

            return RedirectToAction("Index", "User", new { idUser = current });
            //return RedirectToAction("Index");
        }

        public ActionResult Delete(int current, int idUser = 0)
        {
            HttpResponseMessage resp = _Global.apiClient.DeleteAsync("User/" + idUser.ToString()).Result;            
            //return RedirectToAction("Index");
            return RedirectToAction("Index", "User", new { idUser = current });

        }

    }
}