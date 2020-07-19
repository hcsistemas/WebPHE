//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebPHE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cursos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cursos()
        {
            this.Usuarios_CursosSet = new HashSet<Usuarios_Cursos>();
        }
    
        public int id { get; set; }
        [Display(Name = "Titulos")]
        public string titulo { get; set; }
        [Display(Name = "Modalidad")]
        public int id_modalidad { get; set; }
        [Display(Name = "Duración")]
        public string duracion { get; set; }
        [Display(Name = "Tipo de Curso")]
        public int id_tipo_curso { get; set; }
        [Display(Name = "Categoria")]
        public int id_categoria { get; set; }
        [Display(Name = "Línea de Carrera")]
        public int id_linea_carrera { get; set; }
    
        public virtual Categorias CategoriasSet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios_Cursos> Usuarios_CursosSet { get; set; }
        public virtual Modalidades ModalidadesSet { get; set; }
        public virtual TipoCursos TipoCursosSet { get; set; }
        public virtual LineasCarreras LineasCarrerasSet { get; set; }
    }
}
