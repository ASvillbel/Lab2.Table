﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace таблица_лаба_2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class clientEntities2 : DbContext
    {
        private static clientEntities2 _context;
        public clientEntities2()
            : base("name=clientEntities2")
        {
        }
    
        public static clientEntities2 GetContext()
        {
            if (_context == null)
                _context = new clientEntities2();

            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Auto> Auto { get; set; }
        public virtual DbSet<Lizing> Lizing { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
