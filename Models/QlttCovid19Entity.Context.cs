﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1760081.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLTTCovid19Entities : DbContext
    {
        public QLTTCovid19Entities()
            : base("name=QLTTCovid19Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<LichSuHoatDong> LichSuHoatDongs { get; set; }
        public virtual DbSet<LichSuTinhTrangNhiem> LichSuTinhTrangNhiems { get; set; }
        public virtual DbSet<NguoiLienQuan> NguoiLienQuans { get; set; }
        public virtual DbSet<NoiDieuTriCachLy> NoiDieuTriCachLies { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
    }
}
