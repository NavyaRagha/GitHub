﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

public partial class dbExtranetEntitiesWord : DbContext
{
    public dbExtranetEntitiesWord()
        : base("name=dbExtranetEntitiesWord")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<Beg_Word> Beg_Word { get; set; }
    public virtual DbSet<Beg_WordFiles> Beg_WordFiles { get; set; }
    public virtual DbSet<Beg_WordTranslate> Beg_WordTranslate { get; set; }
    public virtual DbSet<Beg_WordCourse> Beg_WordCourse { get; set; }
    public virtual DbSet<Beg_WordResult> Beg_WordResult { get; set; }
    public virtual DbSet<Beg_WordTest> Beg_WordTest { get; set; }
    public virtual DbSet<Beg_WordUserTest> Beg_WordUserTest { get; set; }
}
