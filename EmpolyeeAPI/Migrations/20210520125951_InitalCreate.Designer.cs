// <auto-generated />
using EmpolyeeAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmpolyeeAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210520125951_InitalCreate")]
    partial class InitalCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeModels.Department", b =>
                {
                    b.Property<int>("DepID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepID = 1,
                            DepName = "Management"
                        },
                        new
                        {
                            DepID = 2,
                            DepName = "Tea Department"
                        });
                });

            modelBuilder.Entity("EmployeeModels.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepID")
                        .HasColumnType("int");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpGender")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DepID = 1,
                            Designation = "CEO",
                            EmpGender = 0,
                            FirstName = "John",
                            ImagePath = "/img/John.jpeg",
                            LastName = "Doe"
                        },
                        new
                        {
                            ID = 2,
                            DepID = 2,
                            Designation = "Tea boy",
                            EmpGender = 0,
                            FirstName = "Ahmad",
                            ImagePath = "/img/TeaBoy.jpeg",
                            LastName = "Qureshi"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
