﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VeterLabParcial.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VeterLabParcialEntities : DbContext
    {
        public VeterLabParcialEntities()
            : base("name=VeterLabParcialEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Laboratorio> Laboratorio { get; set; }
        public virtual DbSet<Recepcion> Recepcion { get; set; }
    }
}
