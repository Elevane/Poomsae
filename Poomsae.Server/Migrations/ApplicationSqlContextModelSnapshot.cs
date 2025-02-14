﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Poomsae.Server.Infrastructure.Persistence;

#nullable disable

namespace Poomsae.Server.Migrations
{
    [DbContext(typeof(ApplicationSqlContext))]
    internal partial class ApplicationSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("MasterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("MasterId");

                    b.ToTable("Club", (string)null);
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.Kata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int?>("SportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("SportId");

                    b.ToTable("Kata", (string)null);
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.Movement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BodyPart")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("StepId")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("StepId");

                    b.ToTable("Movement", (string)null);
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Ecole")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Sport", (string)null);
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("KataId")
                        .HasColumnType("int");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("KataId");

                    b.ToTable("Step", (string)null);
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.UserKata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FollowerId")
                        .HasColumnType("int");

                    b.Property<int>("KatasId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Validated")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("FollowerId");

                    b.HasIndex("KatasId");

                    b.ToTable("UserKata");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.UserMovement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FollowerId")
                        .HasColumnType("int");

                    b.Property<int>("MovementId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Validated")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("FollowerId");

                    b.HasIndex("MovementId");

                    b.ToTable("UserMovement");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.UserSport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FollowerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Validated")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("FollowerId");

                    b.HasIndex("SportId");

                    b.ToTable("UserSport");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.UserStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FollowerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Validated")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("FollowerId");

                    b.HasIndex("StepId");

                    b.ToTable("UserStep");
                });

            modelBuilder.Entity("UserClub", b =>
                {
                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ClubId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserClubs", (string)null);
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.Club", b =>
                {
                    b.HasOne("Poomsae.Server.Domain.Entitites.User", "Master")
                        .WithMany()
                        .HasForeignKey("MasterId");

                    b.Navigation("Master");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.Kata", b =>
                {
                    b.HasOne("Poomsae.Server.Domain.Entitites.Sport", null)
                        .WithMany("SubChildEntityList")
                        .HasForeignKey("SportId");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.Movement", b =>
                {
                    b.HasOne("Poomsae.Server.Domain.Entitites.Step", null)
                        .WithMany("SubChildEntityList")
                        .HasForeignKey("StepId");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.Sport", b =>
                {
                    b.HasOne("Poomsae.Server.Domain.Entitites.Club", null)
                        .WithMany("Sports")
                        .HasForeignKey("ClubId");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.Step", b =>
                {
                    b.HasOne("Poomsae.Server.Domain.Entitites.Kata", null)
                        .WithMany("SubChildEntityList")
                        .HasForeignKey("KataId");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.UserKata", b =>
                {
                    b.HasOne("Poomsae.Server.Domain.Entitites.User", "Follower")
                        .WithMany("Katas")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Poomsae.Server.Domain.Entitites.Kata", "Katas")
                        .WithMany()
                        .HasForeignKey("KatasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("Katas");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.UserMovement", b =>
                {
                    b.HasOne("Poomsae.Server.Domain.Entitites.User", "Follower")
                        .WithMany("Movement")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Poomsae.Server.Domain.Entitites.Movement", "Movement")
                        .WithMany()
                        .HasForeignKey("MovementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("Movement");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.UserSport", b =>
                {
                    b.HasOne("Poomsae.Server.Domain.Entitites.User", "Follower")
                        .WithMany("Sports")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Poomsae.Server.Domain.Entitites.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.UserStep", b =>
                {
                    b.HasOne("Poomsae.Server.Domain.Entitites.User", "Follower")
                        .WithMany("Steps")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Poomsae.Server.Domain.Entitites.Step", "Step")
                        .WithMany()
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("Step");
                });

            modelBuilder.Entity("UserClub", b =>
                {
                    b.HasOne("Poomsae.Server.Domain.Entitites.Club", null)
                        .WithMany()
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Poomsae.Server.Domain.Entitites.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.Club", b =>
                {
                    b.Navigation("Sports");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.Kata", b =>
                {
                    b.Navigation("SubChildEntityList");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.Sport", b =>
                {
                    b.Navigation("SubChildEntityList");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.Step", b =>
                {
                    b.Navigation("SubChildEntityList");
                });

            modelBuilder.Entity("Poomsae.Server.Domain.Entitites.User", b =>
                {
                    b.Navigation("Katas");

                    b.Navigation("Movement");

                    b.Navigation("Sports");

                    b.Navigation("Steps");
                });
#pragma warning restore 612, 618
        }
    }
}