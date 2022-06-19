﻿// <auto-generated />
using IgwOutgoingStatus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IgwOutgoingStatus.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220610090042_AddedPrimaryKeyAuto")]
    partial class AddedPrimaryKeyAuto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DBWorkerService.Models.Igw_Loss_Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BillingCycle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Calling_Operator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Carrier_Rate_USD")
                        .HasColumnType("float");

                    b.Property<string>("Dest_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dest_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dest_Prefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Exchange_Rate")
                        .HasColumnType("float");

                    b.Property<string>("International_Carrier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Partition_Day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total_Calls")
                        .HasColumnType("int");

                    b.Property<double>("Total_Expense_BDT")
                        .HasColumnType("float");

                    b.Property<double>("Total_Expense_USD")
                        .HasColumnType("float");

                    b.Property<double>("Total_Loss_BDT")
                        .HasColumnType("float");

                    b.Property<double>("Total_Min")
                        .HasColumnType("float");

                    b.Property<double>("Total_Min_Pulse")
                        .HasColumnType("float");

                    b.Property<double>("Total_Revenue_BDT")
                        .HasColumnType("float");

                    b.Property<double>("X_Rate_BDT")
                        .HasColumnType("float");

                    b.Property<double>("Y_Rate_BDT")
                        .HasColumnType("float");

                    b.Property<double>("Y_Rate_USD")
                        .HasColumnType("float");

                    b.Property<double>("Z_Rate_BDT")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Igw_D_Stat_OG_Loss_Record");
                });

            modelBuilder.Entity("DBWorkerService.Models.Igw_Prft_Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BillingCycle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Calling_Operator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Carrier_Rate_USD")
                        .HasColumnType("float");

                    b.Property<string>("Dest_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dest_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dest_Prefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Exchange_Rate")
                        .HasColumnType("float");

                    b.Property<string>("International_Carrier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Partition_Day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total_Calls")
                        .HasColumnType("int");

                    b.Property<double>("Total_Expense_BDT")
                        .HasColumnType("float");

                    b.Property<double>("Total_Expense_USD")
                        .HasColumnType("float");

                    b.Property<double>("Total_Min")
                        .HasColumnType("float");

                    b.Property<double>("Total_Min_Pulse")
                        .HasColumnType("float");

                    b.Property<double>("Total_Profit_BDT")
                        .HasColumnType("float");

                    b.Property<double>("Total_Revenue_BDT")
                        .HasColumnType("float");

                    b.Property<double>("X_Rate_BDT")
                        .HasColumnType("float");

                    b.Property<double>("Y_Rate_BDT")
                        .HasColumnType("float");

                    b.Property<double>("Y_Rate_USD")
                        .HasColumnType("float");

                    b.Property<double>("Z_Rate_BDT")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Igw_D_Stat_OG_Prft_Record");
                });
#pragma warning restore 612, 618
        }
    }
}