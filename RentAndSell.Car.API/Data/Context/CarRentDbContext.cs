using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentAndSell.Car.API.Data.Entities.Concrete;

namespace RentAndSell.Car.API.Data.Context
{
    public class CarRentDbContext : IdentityDbContext<Kullanici>
    {
        public CarRentDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Araba> Arabalar {  get; set; }
        public DbSet<ArabaTarihce> ArabaTarihcesi {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Araba>().ToTable(tb => tb.HasTrigger("ArabalarEklemeSonrasi"));
            modelBuilder.Entity<Araba>().ToTable(tb => tb.HasTrigger("ArabalarGuncellemeSonrasi"));
            modelBuilder.Entity<Araba>().ToTable(tb => tb.HasTrigger("ArabalarSilmeSonrasi"));


            #region Identity Kullanıcı Nesnesi Oluşturma
            Kullanici adminUser = new Kullanici();
            string userId = Guid.NewGuid().ToString();
            adminUser.Id = userId;
            adminUser.FirstName = "Admin";
            adminUser.LastName = "User";
            adminUser.UserName = "admin";
            adminUser.Email = "admin@mail.com";
            adminUser.NormalizedEmail = "ADMIN@mail.com";
            adminUser.NormalizedUserName = "ADMIN";
            adminUser.EmailConfirmed = true;
            adminUser.ConcurrencyStamp = Guid.NewGuid().ToString();
            adminUser.SecurityStamp = Guid.NewGuid().ToString();

            PasswordHasher<Kullanici> passwordHasher = new PasswordHasher<Kullanici>();
            passwordHasher.HashPassword(adminUser, "123456*Admin");

            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "123456*Admin");
            #endregion

            #region IdentityRole Nesnesi Oluşturma
            IdentityRole adminRole = new IdentityRole();

            string roleId = Guid.NewGuid().ToString();

            adminRole.Id = roleId;
            adminRole.Name = "Admin";
            adminRole.NormalizedName = "ADMIN";
            adminRole.ConcurrencyStamp = Guid.NewGuid().ToString();
            #endregion

            #region Kullanıcı,Role ve KullanıcıRole Seed Dataların Eklenmesi
            IdentityUserRole<string> kullaniciRole = new IdentityUserRole<string>();
            kullaniciRole.UserId = userId;
            kullaniciRole.RoleId = roleId;

            modelBuilder.Entity<Kullanici>().HasData(adminUser);
            modelBuilder.Entity<IdentityRole>().HasData(adminRole);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(kullaniciRole); 
            #endregion

            //IdentitiyDbContext den miras aldığımızda aşağıdaki kod bloğunun durması gerekiyor. çünkü tüm ek tablolar IdentityDbContext üzerinden oluşturulacaktır.
            base.OnModelCreating(modelBuilder);
        }
    }
}

