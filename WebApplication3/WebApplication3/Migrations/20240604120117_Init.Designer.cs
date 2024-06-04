﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using cursach_3.Repository.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240604120117_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("cursach_3.DATA.Article_DATA", b =>
                {
                    b.Property<long>("Article_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Article_ID"));

                    b.Property<string>("Article_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Author_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Category_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Creation_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Photo_folder_ID")
                        .HasColumnType("bigint");

                    b.Property<long>("Rating")
                        .HasColumnType("bigint");

                    b.HasKey("Article_ID");

                    b.HasIndex("Author_ID");

                    b.HasIndex("Photo_folder_ID")
                        .IsUnique();

                    b.ToTable("Article_DATA");
                });

            modelBuilder.Entity("cursach_3.DATA.Author_DATA", b =>
                {
                    b.Property<long>("Author_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Author_ID"));

                    b.Property<string>("Author_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Author_URL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Photo_folder_ID")
                        .HasColumnType("bigint");

                    b.Property<long>("User_ID")
                        .HasColumnType("bigint");

                    b.HasKey("Author_ID");

                    b.HasIndex("Photo_folder_ID")
                        .IsUnique();

                    b.HasIndex("User_ID")
                        .IsUnique();

                    b.ToTable("Author_DATA");
                });

            modelBuilder.Entity("cursach_3.DATA.Commentary_DATA", b =>
                {
                    b.Property<long>("Commentary_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Commentary_ID"));

                    b.Property<long>("Article_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Commentary_size")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Creation_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Thread_ID")
                        .HasColumnType("bigint");

                    b.Property<long>("Topic_ID")
                        .HasColumnType("bigint");

                    b.Property<long>("User_ID")
                        .HasColumnType("bigint");

                    b.HasKey("Commentary_ID");

                    b.HasIndex("Article_ID");

                    b.HasIndex("Thread_ID");

                    b.HasIndex("Topic_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Commentary_DATA");
                });

            modelBuilder.Entity("cursach_3.DATA.File_Archive_DATA", b =>
                {
                    b.Property<long>("File_Archive_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("File_Archive_ID"));

                    b.Property<long>("Article_ID")
                        .HasColumnType("bigint");

                    b.Property<long>("Commentary_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("File_Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Files_Archive_Desc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Thread_ID")
                        .HasColumnType("bigint");

                    b.Property<long>("Topic_ID")
                        .HasColumnType("bigint");

                    b.HasKey("File_Archive_ID");

                    b.HasIndex("Article_ID")
                        .IsUnique();

                    b.HasIndex("Commentary_ID")
                        .IsUnique();

                    b.HasIndex("Thread_ID");

                    b.HasIndex("Topic_ID");

                    b.ToTable("File_Archive_DATA");
                });

            modelBuilder.Entity("cursach_3.DATA.Photo_folder_DATA", b =>
                {
                    b.Property<long>("Photo_folder_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Photo_folder_ID"));

                    b.Property<string>("Photo_folder_Desc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Photo_folder_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Photo_folder_Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Photo_folder_ID");

                    b.ToTable("Photo_folder_DATA");
                });

            modelBuilder.Entity("cursach_3.DATA.Thread_DATA", b =>
                {
                    b.Property<long>("Thread_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Thread_ID"));

                    b.Property<long>("Author_ID")
                        .HasColumnType("bigint");

                    b.Property<long>("Rating")
                        .HasColumnType("bigint");

                    b.Property<string>("Thread_Desc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Thread_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Thread_URL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Thread_ID");

                    b.HasIndex("Author_ID");

                    b.ToTable("Thread_DATA");
                });

            modelBuilder.Entity("cursach_3.DATA.Topic_DATA", b =>
                {
                    b.Property<long>("Topic_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Topic_ID"));

                    b.Property<long>("Thread_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Topic_Desc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Topic_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Topic_URL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Topic_ID");

                    b.HasIndex("Thread_ID");

                    b.ToTable("Topic_DATA");
                });

            modelBuilder.Entity("cursach_3.DATA.User_DATA", b =>
                {
                    b.Property<long>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("User_ID"));

                    b.Property<string>("User_Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("User_NickName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("User_Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("User_URL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("User_ID");

                    b.ToTable("User_DATA");
                });

            modelBuilder.Entity("cursach_3.DATA.Article_DATA", b =>
                {
                    b.HasOne("cursach_3.DATA.Author_DATA", "Author")
                        .WithMany("Article_List")
                        .HasForeignKey("Author_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cursach_3.DATA.Photo_folder_DATA", "Photo")
                        .WithOne("Article")
                        .HasForeignKey("cursach_3.DATA.Article_DATA", "Photo_folder_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("cursach_3.DATA.Author_DATA", b =>
                {
                    b.HasOne("cursach_3.DATA.Photo_folder_DATA", "Photo")
                        .WithOne("Author")
                        .HasForeignKey("cursach_3.DATA.Author_DATA", "Photo_folder_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cursach_3.DATA.User_DATA", "User")
                        .WithOne("Author")
                        .HasForeignKey("cursach_3.DATA.Author_DATA", "User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Photo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("cursach_3.DATA.Commentary_DATA", b =>
                {
                    b.HasOne("cursach_3.DATA.Article_DATA", "Article")
                        .WithMany("Commentary_List")
                        .HasForeignKey("Article_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cursach_3.DATA.Thread_DATA", "Thread")
                        .WithMany("Commentary_List")
                        .HasForeignKey("Thread_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cursach_3.DATA.Topic_DATA", "Topic")
                        .WithMany("Commentary_List")
                        .HasForeignKey("Topic_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cursach_3.DATA.User_DATA", "User")
                        .WithMany("Commentary_List")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Thread");

                    b.Navigation("Topic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("cursach_3.DATA.File_Archive_DATA", b =>
                {
                    b.HasOne("cursach_3.DATA.Article_DATA", "Article")
                        .WithOne("File")
                        .HasForeignKey("cursach_3.DATA.File_Archive_DATA", "Article_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cursach_3.DATA.Commentary_DATA", "Commentary")
                        .WithOne("File")
                        .HasForeignKey("cursach_3.DATA.File_Archive_DATA", "Commentary_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cursach_3.DATA.Thread_DATA", "Thread")
                        .WithMany("File_List")
                        .HasForeignKey("Thread_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cursach_3.DATA.Topic_DATA", "Topic")
                        .WithMany("File_List")
                        .HasForeignKey("Topic_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Commentary");

                    b.Navigation("Thread");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("cursach_3.DATA.Thread_DATA", b =>
                {
                    b.HasOne("cursach_3.DATA.Author_DATA", "Author")
                        .WithMany("Thread_List")
                        .HasForeignKey("Author_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("cursach_3.DATA.Topic_DATA", b =>
                {
                    b.HasOne("cursach_3.DATA.Thread_DATA", "Thread")
                        .WithMany("Topic_List")
                        .HasForeignKey("Thread_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Thread");
                });

            modelBuilder.Entity("cursach_3.DATA.Article_DATA", b =>
                {
                    b.Navigation("Commentary_List");

                    b.Navigation("File")
                        .IsRequired();
                });

            modelBuilder.Entity("cursach_3.DATA.Author_DATA", b =>
                {
                    b.Navigation("Article_List");

                    b.Navigation("Thread_List");
                });

            modelBuilder.Entity("cursach_3.DATA.Commentary_DATA", b =>
                {
                    b.Navigation("File")
                        .IsRequired();
                });

            modelBuilder.Entity("cursach_3.DATA.Photo_folder_DATA", b =>
                {
                    b.Navigation("Article")
                        .IsRequired();

                    b.Navigation("Author")
                        .IsRequired();
                });

            modelBuilder.Entity("cursach_3.DATA.Thread_DATA", b =>
                {
                    b.Navigation("Commentary_List");

                    b.Navigation("File_List");

                    b.Navigation("Topic_List");
                });

            modelBuilder.Entity("cursach_3.DATA.Topic_DATA", b =>
                {
                    b.Navigation("Commentary_List");

                    b.Navigation("File_List");
                });

            modelBuilder.Entity("cursach_3.DATA.User_DATA", b =>
                {
                    b.Navigation("Author")
                        .IsRequired();

                    b.Navigation("Commentary_List");
                });
#pragma warning restore 612, 618
        }
    }
}
