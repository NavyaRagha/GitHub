﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Beg_Alphabet
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Beg_Alphabet()
    {
        this.Beg_Files = new HashSet<Beg_Files>();
        this.Beg_Test = new HashSet<Beg_Test>();
        this.Beg_Translate = new HashSet<Beg_Translate>();
    }

    public int Id { get; set; }
    public string CapitalLetter { get; set; }
    public string SmallLetter { get; set; }
    public string Explain { get; set; }
    public Nullable<int> SortOrder { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Beg_Files> Beg_Files { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Beg_Test> Beg_Test { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Beg_Translate> Beg_Translate { get; set; }
}

public partial class Beg_Files
{
    public int Id { get; set; }
    public int BegAlphabetId { get; set; }
    public string Name { get; set; }
    public string ContentType { get; set; }
    public byte[] Play { get; set; }

    public virtual Beg_Alphabet Beg_Alphabet { get; set; }
}

public partial class beg_Ind_1
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public beg_Ind_1()
    {
        this.beg_Tra_1 = new HashSet<beg_Tra_1>();
    }

    public int id { get; set; }
    public string FileName { get; set; }
    public string Description { get; set; }
    public string Translate { get; set; }
    public string ContentType { get; set; }
    public byte[] Data { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<beg_Tra_1> beg_Tra_1 { get; set; }
}

public partial class Beg_Result
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Result { get; set; }
    public Nullable<System.DateTime> Date { get; set; }
    public Nullable<int> BegTestId { get; set; }
    public Nullable<int> Correct { get; set; }
    public Nullable<int> wrong { get; set; }
}

public partial class Beg_Test
{
    public int Id { get; set; }
    public Nullable<int> BegAlphabetId { get; set; }
    public string Course { get; set; }
    public string Day { get; set; }
    public Nullable<int> QuestionNumber { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }

    public virtual Beg_Alphabet Beg_Alphabet { get; set; }
}

public partial class beg_Tra_1
{
    public int id { get; set; }
    public int BegIndId { get; set; }
    public string Kannada { get; set; }
    public string Hindi { get; set; }

    public virtual beg_Ind_1 beg_Ind_1 { get; set; }
}

public partial class Beg_Translate
{
    public int Id { get; set; }
    public int begAlphabetId { get; set; }
    public string Kannada { get; set; }
    public string Hindi { get; set; }

    public virtual Beg_Alphabet Beg_Alphabet { get; set; }
}

public partial class ButtonName
{
    public int Id { get; set; }
    public string English { get; set; }
    public string Kannada { get; set; }
    public string Hindi { get; set; }
}

public partial class CourseMst
{
    public int Id { get; set; }
    public Nullable<int> Lesson { get; set; }
    public Nullable<int> Topics { get; set; }
}

public partial class ForgotPassRequest
{
    public System.Guid Id { get; set; }
    public Nullable<int> Uid { get; set; }
    public Nullable<System.DateTime> RequestDateTime { get; set; }

    public virtual User User { get; set; }
}

public partial class tblFile
{
    public int id { get; set; }
    public string Name { get; set; }
    public string ContentType { get; set; }
    public byte[] Data { get; set; }
}

public partial class User
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public User()
    {
        this.ForgotPassRequests = new HashSet<ForgotPassRequest>();
    }

    public int Uid { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string LanguagePrefered { get; set; }
    public string Usertype { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<ForgotPassRequest> ForgotPassRequests { get; set; }
}
