// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhotoApp.DAL.EntityFramework;

namespace PhotoApp.PhotoAPI.Migrations
{
    [DbContext(typeof(PhotoDbContext))]
    [Migration("20230118135910_IlkDbOlusturma")]
    partial class IlkDbOlusturma
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("PhotoApp.Entities.Models.Firma", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<string>("FirmaAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Firmalar");
                });

            modelBuilder.Entity("PhotoApp.Entities.Models.KullaniciTip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Tip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("KullaniciTipler");
                });

            modelBuilder.Entity("PhotoApp.Entities.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FirmaID")
                        .HasColumnType("int");

                    b.Property<int>("KullaniciTipID")
                        .HasColumnType("int");

                    b.Property<int>("ParentID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("FirmaID");

                    b.HasIndex("KullaniciTipID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PhotoApp.Entities.Models.User", b =>
                {
                    b.HasOne("PhotoApp.Entities.Models.Firma", "Firma")
                        .WithMany("Users")
                        .HasForeignKey("FirmaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PhotoApp.Entities.Models.KullaniciTip", "KullaniciTip")
                        .WithMany("Users")
                        .HasForeignKey("KullaniciTipID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Firma");

                    b.Navigation("KullaniciTip");
                });

            modelBuilder.Entity("PhotoApp.Entities.Models.Firma", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PhotoApp.Entities.Models.KullaniciTip", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
