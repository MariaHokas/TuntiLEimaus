﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TuntiLeimausMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TuntiLeimausEntities : DbContext
    {
        public TuntiLeimausEntities()
            : base("name=TuntiLeimausEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Leimaus> Leimaus { get; set; }
        public virtual DbSet<Luokkahuone> Luokkahuone { get; set; }
        public virtual DbSet<Opettajat> Opettajat { get; set; }
        public virtual DbSet<Opiskelijat> Opiskelijat { get; set; }
        public virtual DbSet<Tuntiraportti> Tuntiraportti { get; set; }
    }
}
