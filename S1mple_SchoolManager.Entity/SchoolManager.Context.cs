//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace S1mple_SchoolManager.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SchoolManagementEntities : DbContext
    {
        public SchoolManagementEntities()
            : base("name=SchoolManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Info_Class> Info_Class { get; set; }
        public virtual DbSet<Info_Parent> Info_Parent { get; set; }
        public virtual DbSet<Info_Admin> Info_Admin { get; set; }
        public virtual DbSet<Info_Student> Info_Student { get; set; }
        public virtual DbSet<Info_Menu> Info_Menu { get; set; }
        public virtual DbSet<Sys_Nation> Sys_Nation { get; set; }
        public virtual DbSet<O_T_C_N> O_T_C_N { get; set; }
        public virtual DbSet<V_T_C_N> V_T_C_N { get; set; }
        public virtual DbSet<Info_Attendance> Info_Attendance { get; set; }
        public virtual DbSet<Info_Schedule> Info_Schedule { get; set; }
        public virtual DbSet<Info_Leave> Info_Leave { get; set; }
        public virtual DbSet<Info_Teacher> Info_Teacher { get; set; }
        public virtual DbSet<O_C_S_C> O_C_S_C { get; set; }
        public virtual DbSet<O_S_T_C> O_S_T_C { get; set; }
        public virtual DbSet<Info_Curriculum> Info_Curriculum { get; set; }
        public virtual DbSet<V_C_S_C> V_C_S_C { get; set; }
        public virtual DbSet<V_S_T_C> V_S_T_C { get; set; }
        public virtual DbSet<O_L_T> O_L_T { get; set; }
        public virtual DbSet<V_L_T> V_L_T { get; set; }
        public virtual DbSet<Info_Location> Info_Location { get; set; }
        public virtual DbSet<O_L_S> O_L_S { get; set; }
        public virtual DbSet<V_L_S> V_L_S { get; set; }
    }
}
