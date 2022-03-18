﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Roster.Infrastructure;

#nullable disable

namespace Roster.Api.Migrations
{
    [DbContext(typeof(RosterContext))]
    [Migration("20220318175332_Accepted")]
    partial class Accepted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("Roster.Core.MembershipApplication", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("_accepted")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Accepted");

                    b.Property<string>("_hashedPassword")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("HashedPassword");

                    b.HasKey("Username");

                    b.ToTable("MembershipApplications");
                });
#pragma warning restore 612, 618
        }
    }
}