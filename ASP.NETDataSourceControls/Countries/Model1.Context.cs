﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Countries
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EarthEntities : DbContext
    {
        public EarthEntities()
            : base("name=EarthEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Continents> Continents { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
