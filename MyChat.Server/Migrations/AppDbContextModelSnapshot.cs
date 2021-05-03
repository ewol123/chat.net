﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyChat.Server.Infrastructure;

namespace MyChat.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("MyChat.Domain.Model.Message", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("roomid")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("stamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("text")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("userid")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("roomid");

                    b.HasIndex("userid");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MyChat.Domain.Model.Room", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("identifier")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("MyChat.Domain.Model.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("avatar")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("roomid")
                        .HasColumnType("TEXT");

                    b.Property<string>("socketId")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("roomid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyChat.Domain.Model.Message", b =>
                {
                    b.HasOne("MyChat.Domain.Model.Room", "room")
                        .WithMany("messages")
                        .HasForeignKey("roomid");

                    b.HasOne("MyChat.Domain.Model.User", "user")
                        .WithMany("messages")
                        .HasForeignKey("userid");

                    b.Navigation("room");

                    b.Navigation("user");
                });

            modelBuilder.Entity("MyChat.Domain.Model.User", b =>
                {
                    b.HasOne("MyChat.Domain.Model.Room", "room")
                        .WithMany("users")
                        .HasForeignKey("roomid");

                    b.Navigation("room");
                });

            modelBuilder.Entity("MyChat.Domain.Model.Room", b =>
                {
                    b.Navigation("messages");

                    b.Navigation("users");
                });

            modelBuilder.Entity("MyChat.Domain.Model.User", b =>
                {
                    b.Navigation("messages");
                });
#pragma warning restore 612, 618
        }
    }
}
