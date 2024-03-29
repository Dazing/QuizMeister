﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizMeister.Core.Data;

namespace QuizMeister.Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuizMeister.Core.Models.DataModels.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<string>("Option")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("QuizMeister.Core.Models.DataModels.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuizMeister.Core.Models.DataModels.QuizAnswer", b =>
                {
                    b.Property<int>("QuizSessionId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.HasKey("QuizSessionId", "QuestionId");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuizAnswers");
                });

            modelBuilder.Entity("QuizMeister.Core.Models.DataModels.QuizSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("QuizSessions");
                });

            modelBuilder.Entity("QuizMeister.Core.Models.DataModels.Answer", b =>
                {
                    b.HasOne("QuizMeister.Core.Models.DataModels.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizMeister.Core.Models.DataModels.QuizAnswer", b =>
                {
                    b.HasOne("QuizMeister.Core.Models.DataModels.Answer", "Answer")
                        .WithMany()
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizMeister.Core.Models.DataModels.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizMeister.Core.Models.DataModels.QuizSession", "QuizSession")
                        .WithMany("QuizAnswers")
                        .HasForeignKey("QuizSessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Question");

                    b.Navigation("QuizSession");
                });

            modelBuilder.Entity("QuizMeister.Core.Models.DataModels.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("QuizMeister.Core.Models.DataModels.QuizSession", b =>
                {
                    b.Navigation("QuizAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}
