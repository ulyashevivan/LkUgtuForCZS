﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LkUgtu.orm
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UGTUEntities : DbContext
    {
        public UGTUEntities()
            : base("name=UGTUEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Vakans> Vakans { get; set; }
        public virtual DbSet<Predpriyatie> Predpriyatie { get; set; }
        public virtual DbSet<Resume> Resume { get; set; }
        public virtual DbSet<Trudoustr> Trudoustr { get; set; }
        public virtual DbSet<Dolznost> Dolznost { get; set; }
        public virtual DbSet<Param_Vakans> Param_Vakans { get; set; }
        public virtual DbSet<Parametr> Parametr { get; set; }
        public virtual DbSet<ZnachParam> ZnachParam { get; set; }
        public virtual DbSet<Param_Resume> Param_Resume { get; set; }
        public virtual DbSet<Status> Status { get; set; }
    }
}
