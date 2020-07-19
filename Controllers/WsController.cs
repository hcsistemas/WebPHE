using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebPHE.Models;
using WebPHE.Models.ViewModels;

namespace WebPHE.Controllers
{
    public class WsController : ApiController
    {
        private pheEntities db = new pheEntities();

        // GET: api/Ws
        public string Get()
        {
            List<UsuariosViewModel> usuarios; 
            usuarios  = (from t in db.UsuariosSet
                        select new UsuariosViewModel
                        {
                            Id = t.id,
                            Nombres = t.nombres, 
                            Apellidos = t.apellidos,
                            Hoobies = t.hobbies, 
                            FechaNac = t.fec_nac,
                            Genero = t.GeneroSet.descripcion,
                            LugarNac = t.LugaresNacSet.descripcion,
                            LugarRes = t.LugaresResSet.descripcion
                        }).ToList();

            return JsonConvert.SerializeObject(usuarios);
        }

        // GET: api/Ws/5
        public string Get(int id)
        {
            List<UsuariosViewModel> usuarios;
            usuarios = (from t in db.UsuariosSet where t.id == id
                        select new UsuariosViewModel
                        {
                            Id = t.id,
                            Nombres = t.nombres,
                            Apellidos = t.apellidos,
                            Hoobies = t.hobbies,
                            FechaNac = t.fec_nac,
                            Genero = t.GeneroSet.descripcion,
                            LugarNac = t.LugaresNacSet.descripcion,
                            LugarRes = t.LugaresResSet.descripcion
                        }).ToList();

            return JsonConvert.SerializeObject(usuarios);
        }

        // POST: api/Ws
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Ws/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ws/5
        public void Delete(int id)
        {
        }
    }
}
