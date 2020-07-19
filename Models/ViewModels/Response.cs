using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPHE.Models.ViewModels
{
    public class Response
    {
        public int CodigoError { get; set; }
        public string DesError { get; set; }
        public List<Usuarios> data { get; set; }
    }
}