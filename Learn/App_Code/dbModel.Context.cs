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

public partial class dbExtranetEntities : DbContext
{
    public dbExtranetEntities()
        : base("name=dbExtranetEntities")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<Beg_Alphabet> Beg_Alphabet { get; set; }
    public virtual DbSet<Beg_Files> Beg_Files { get; set; }
    public virtual DbSet<beg_Ind_1> beg_Ind_1 { get; set; }
    public virtual DbSet<Beg_Result> Beg_Result { get; set; }
    public virtual DbSet<Beg_Test> Beg_Test { get; set; }
    public virtual DbSet<beg_Tra_1> beg_Tra_1 { get; set; }
    public virtual DbSet<Beg_Translate> Beg_Translate { get; set; }
    public virtual DbSet<ButtonName> ButtonNames { get; set; }
    public virtual DbSet<CourseMst> CourseMsts { get; set; }
    public virtual DbSet<ForgotPassRequest> ForgotPassRequests { get; set; }
    public virtual DbSet<tblFile> tblFiles { get; set; }
    public virtual DbSet<User> Users { get; set; }
}
