using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebPHE.Models;
using WebPHE.Models.ViewModels;

namespace WebPHE.Controllers
{
    public class ReportesController : Controller
    {
        private pheEntities db = new pheEntities();

        // GET: Reportes
        public ActionResult Index(string secc)
        {
            if (secc == null)
                ViewBag.Reporte = "rep-cursos";
            else
                ViewBag.Reporte = secc;

            var cursosSet = db.CursosSet.Include(c => c.CategoriasSet).Include(c => c.ModalidadesSet).Include(c => c.TipoCursosSet).Include(c => c.LineasCarrerasSet);

            List<UsuariosViewModel> usuarios= null;
            using (pheEntities db = new pheEntities())
            {
                usuarios = (from t in db.UsuariosSet
                           select new UsuariosViewModel
                           {
                               FechaNac = t.fec_nac,
                               IdGenero = t.id_genero
                           }
                        ).ToList();
            }

            var rango1 = (from t in usuarios where ((DateTime.Now - t.FechaNac).TotalDays/365) <= 10 select t).Count();
            var rango2 = (from t in usuarios where ((DateTime.Now - t.FechaNac).TotalDays/365) > 10 && ((DateTime.Now - t.FechaNac).TotalDays/365) <= 30 select t).Count();
            var rango3 = (from t in usuarios where ((DateTime.Now - t.FechaNac).TotalDays/365) > 30 && ((DateTime.Now - t.FechaNac).TotalDays/365) <= 50 select t).Count();
            var rango4 = (from t in usuarios where ((DateTime.Now - t.FechaNac).TotalDays/365) > 50 select t).Count();

            List<RangosViewModel> rangos = new List<RangosViewModel>();
            rangos.Add(new RangosViewModel() { Descripcion = "0 y 10 Años", Cantidad = rango1 });
            rangos.Add(new RangosViewModel() { Descripcion = "11 y 30 Años", Cantidad = rango2 });
            rangos.Add(new RangosViewModel() { Descripcion = "31 y 50 Años", Cantidad = rango3 });
            rangos.Add(new RangosViewModel() { Descripcion = "Mayores 50 Años", Cantidad = rango4 });

            ViewBag.Rangos = rangos;

            var genero1 = (from t in usuarios where t.IdGenero == 1 select t).Count();
            var genero2 = (from t in usuarios where t.IdGenero == 2 select t).Count();
            var genero3 = (from t in usuarios where t.IdGenero == 3 select t).Count();

            List<GenerosViewModel> generos = new List<GenerosViewModel>();
            generos.Add(new GenerosViewModel() { Descripcion = "Masculino", Cantidad = genero1 });
            generos.Add(new GenerosViewModel() { Descripcion = "Femenino", Cantidad = genero2 });
            generos.Add(new GenerosViewModel() { Descripcion = "Otros", Cantidad = genero3 });

            ViewBag.Generos = generos;


            return View(cursosSet.ToList());
        }

        // GET: Reportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.CursosSet.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        // GET: Reportes/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.CategoriasSet, "id", "descripcion");
            ViewBag.id_modalidad = new SelectList(db.ModalidadesSet, "id", "descripcion");
            ViewBag.id_tipo_curso = new SelectList(db.TipoCursosSet, "id", "descripcion");
            ViewBag.id_linea_carrera = new SelectList(db.LineasCarrerasSet, "id", "descripcion");
            return View();
        }

        // POST: Reportes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,titulo,id_modalidad,duracion,id_tipo_curso,id_categoria,id_linea_carrera")] Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.CursosSet.Add(cursos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.CategoriasSet, "id", "descripcion", cursos.id_categoria);
            ViewBag.id_modalidad = new SelectList(db.ModalidadesSet, "id", "descripcion", cursos.id_modalidad);
            ViewBag.id_tipo_curso = new SelectList(db.TipoCursosSet, "id", "descripcion", cursos.id_tipo_curso);
            ViewBag.id_linea_carrera = new SelectList(db.LineasCarrerasSet, "id", "descripcion", cursos.id_linea_carrera);
            return View(cursos);
        }

        // GET: Reportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.CursosSet.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.CategoriasSet, "id", "descripcion", cursos.id_categoria);
            ViewBag.id_modalidad = new SelectList(db.ModalidadesSet, "id", "descripcion", cursos.id_modalidad);
            ViewBag.id_tipo_curso = new SelectList(db.TipoCursosSet, "id", "descripcion", cursos.id_tipo_curso);
            ViewBag.id_linea_carrera = new SelectList(db.LineasCarrerasSet, "id", "descripcion", cursos.id_linea_carrera);
            return View(cursos);
        }

        // POST: Reportes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titulo,id_modalidad,duracion,id_tipo_curso,id_categoria,id_linea_carrera")] Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.CategoriasSet, "id", "descripcion", cursos.id_categoria);
            ViewBag.id_modalidad = new SelectList(db.ModalidadesSet, "id", "descripcion", cursos.id_modalidad);
            ViewBag.id_tipo_curso = new SelectList(db.TipoCursosSet, "id", "descripcion", cursos.id_tipo_curso);
            ViewBag.id_linea_carrera = new SelectList(db.LineasCarrerasSet, "id", "descripcion", cursos.id_linea_carrera);
            return View(cursos);
        }

        // GET: Reportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.CursosSet.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        // POST: Reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cursos cursos = db.CursosSet.Find(id);
            db.CursosSet.Remove(cursos);
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
