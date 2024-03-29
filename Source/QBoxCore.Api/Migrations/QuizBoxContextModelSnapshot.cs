﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using QBoxCore.Api.Models;
using System;

namespace QBoxCore.Api.Migrations
{
    [DbContext(typeof(QuizBoxContext))]
    partial class QuizBoxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QBoxCore.Api.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsCorrect");

                    b.Property<int>("QuestionId");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("QuestionId")
                        .HasName("IX_QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("QBoxCore.Api.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("QBoxCore.Api.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId")
                        .HasName("IX_CategoryId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("QBoxCore.Api.Models.GameQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AnswerId");

                    b.Property<int>("GameId");

                    b.Property<int>("Order");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId")
                        .HasName("IX_AnswerId");

                    b.HasIndex("GameId")
                        .HasName("IX_GameId");

                    b.HasIndex("QuestionId")
                        .HasName("IX_QuestionId");

                    b.ToTable("GameQuestion");
                });

            modelBuilder.Entity("QBoxCore.Api.Models.Highscore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Age");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<double>("ScorePercent");

                    b.Property<int>("TimeElapsedSeconds");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId")
                        .HasName("IX_CategoryId");

                    b.ToTable("Highscore");
                });

            modelBuilder.Entity("QBoxCore.Api.Models.MigrationHistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasMaxLength(150);

                    b.Property<string>("ContextKey")
                        .HasMaxLength(300);

                    b.Property<byte[]>("Model")
                        .IsRequired();

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("MigrationId", "ContextKey");

                    b.ToTable("__MigrationHistory");
                });

            modelBuilder.Entity("QBoxCore.Api.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId")
                        .HasName("IX_CategoryId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("QBoxCore.Api.Models.Answer", b =>
                {
                    b.HasOne("QBoxCore.Api.Models.Question", "Question")
                        .WithMany("Answer")
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("FK_dbo.Answer_dbo.Question_QuestionId");
                });

            modelBuilder.Entity("QBoxCore.Api.Models.Game", b =>
                {
                    b.HasOne("QBoxCore.Api.Models.Category", "Category")
                        .WithMany("Game")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_dbo.Game_dbo.Category_CategoryId");
                });

            modelBuilder.Entity("QBoxCore.Api.Models.GameQuestion", b =>
                {
                    b.HasOne("QBoxCore.Api.Models.Answer", "Answer")
                        .WithMany("GameQuestion")
                        .HasForeignKey("AnswerId")
                        .HasConstraintName("FK_dbo.GameQuestion_dbo.Answer_AnswerId");

                    b.HasOne("QBoxCore.Api.Models.Game", "Game")
                        .WithMany("GameQuestion")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_dbo.GameQuestion_dbo.Game_GameId");

                    b.HasOne("QBoxCore.Api.Models.Question", "Question")
                        .WithMany("GameQuestion")
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("FK_dbo.GameQuestion_dbo.Question_QuestionId");
                });

            modelBuilder.Entity("QBoxCore.Api.Models.Highscore", b =>
                {
                    b.HasOne("QBoxCore.Api.Models.Category", "Category")
                        .WithMany("Highscore")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_dbo.Highscore_dbo.Category_CategoryId");
                });

            modelBuilder.Entity("QBoxCore.Api.Models.Question", b =>
                {
                    b.HasOne("QBoxCore.Api.Models.Category", "Category")
                        .WithMany("Question")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_dbo.Question_dbo.Category_CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
