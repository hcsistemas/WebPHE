using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebPHE.Models;
using WebPHE.Models.ViewModels;

namespace WebPHE.Controllers
{
    public class UsuariosController : Controller
    {
        private pheEntities db = new pheEntities();

        // GET: Usuarios
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://localhost:51022/api/ws/");
            var jsonResult = JsonConvert.DeserializeObject(json).ToString();
            var user = JsonConvert.DeserializeObject<List<UsuariosViewModel>>(jsonResult);
            
            return View(user);
            //return View(db.UsuariosSet.ToList());
        }

        // GET: Usuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://localhost:51022/api/ws/"+id);
            var jsonResult = JsonConvert.DeserializeObject(json).ToString();
            var user = JsonConvert.DeserializeObject<List<UsuariosViewModel>>(jsonResult);

            //Usuarios usuarios = db.UsuariosSet.Find(id);
            if (user == null) {
                return HttpNotFound();
            }

            return View(user);
            //return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            List<Models.ViewModels.LugaresViewModel> lugares = null;
            using (Models.pheEntities db= new Models.pheEntities())
            {
                lugares= (from l in db.LugaresSet
                        select new Models.ViewModels.LugaresViewModel {
                            Id= l.id,
                            Descripcion= l.descripcion,
                        }
                        ).ToList();
            }

            List<SelectListItem> listaLugares= lugares.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Value = l.Id.ToString(),
                    Text = l.Descripcion.ToString(),
                    Selected = false,
                };
            });

            ViewBag.listaLugares = listaLugares;


            List<Models.ViewModels.GenerosViewModel> generos = null;
            using(Models.pheEntities db= new Models.pheEntities())
            {
                generos = (from g in db.GeneroSet
                           select new Models.ViewModels.GenerosViewModel
                           {
                               Id= g.id,
                               Descripcion= g.descripcion,
                           }
                           ).ToList();
            }

            List<SelectListItem> listaGeneros = generos.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Value = l.Id.ToString(),
                    Text = l.Descripcion.ToString(),
                    Selected = false,
                };
            });

            ViewBag.listaGeneros = listaGeneros;

            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombres,apellidos,fec_nac,id_lug_nac,id_lug_res,id_genero,hobbies")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.UsuariosSet.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.UsuariosSet.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }

            List<Models.ViewModels.LugaresViewModel> lugares = null;
            using (Models.pheEntities db = new Models.pheEntities())
            {
                lugares = (from l in db.LugaresSet
                           select new Models.ViewModels.LugaresViewModel
                           {
                               Id = l.id,
                               Descripcion = l.descripcion,
                           }
                        ).ToList();
            }

            List<SelectListItem> listaLugares = lugares.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Value = l.Id.ToString(),
                    Text = l.Descripcion.ToString(),
                    Selected = false,
                };
            });

            ViewBag.listaLugares = listaLugares;


            List<Models.ViewModels.GenerosViewModel> generos = null;
            using (Models.pheEntities db = new Models.pheEntities())
            {
                generos = (from g in db.GeneroSet
                           select new Models.ViewModels.GenerosViewModel
                           {
                               Id = g.id,
                               Descripcion = g.descripcion,
                           }
                           ).ToList();
            }

            List<SelectListItem> listaGeneros = generos.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Value = l.Id.ToString(),
                    Text = l.Descripcion.ToString(),
                    Selected = false,
                };
            });

            ViewBag.listaGeneros = listaGeneros;

            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombres,apellidos,fec_nac,id_lug_nac,id_lug_res,id_genero,hobbies")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    
            Usuarios usuarios = db.UsuariosSet.Find(id);
            if (usuarios == null)
                return HttpNotFound();

            db.UsuariosSet.Remove(usuarios);
            db.SaveChanges();
            return RedirectToAction("Index");

            //return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios usuarios = db.UsuariosSet.Find(id);
            db.UsuariosSet.Remove(usuarios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
