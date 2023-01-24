﻿// <auto-generated />
using System;
using JPS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JPS.Domain.Entities.Migrations
{
    [DbContext(typeof(JPSContext))]
    [Migration("20200405193328_InitializeDB")]
    partial class InitializeDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JPS.Domain.Entities.Entities.AnswerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "JSPSurvey"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ParentCategoryId = 1,
                            Title = "ESAT"
                        });
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.DateAnswerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("DateAnswers");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.FileAnswerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.ToTable("FileAnswers");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.FileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.ImageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.OptionAnswerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.Property<int?>("OptionRowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.HasIndex("OptionRowId");

                    b.ToTable("OptionAnswers");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.OptionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal?>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.OptionRowEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("QuestionId");

                    b.ToTable("OptionRows");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.ParagraphAnswerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ParagraphAnswers");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.PollEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("FinishesAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("StartsAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.QuestionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int>("QuestionSectionId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("QuestionSectionId");

                    b.HasIndex("QuestionTypeId");

                    b.HasIndex("VideoId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.QuestionSectionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int>("PollId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.ToTable("QuestionSections");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.QuestionTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("QuestionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Text"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Paragraph"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Multiple choice"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Checkboxes"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Dropdown"
                        },
                        new
                        {
                            Id = 6,
                            Title = "File upload"
                        },
                        new
                        {
                            Id = 7,
                            Title = "Linear scale"
                        },
                        new
                        {
                            Id = 8,
                            Title = "Multiple choice grid"
                        },
                        new
                        {
                            Id = 9,
                            Title = "Checkbox grid"
                        },
                        new
                        {
                            Id = 10,
                            Title = "Date"
                        },
                        new
                        {
                            Id = 11,
                            Title = "Time"
                        });
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.TextAnswerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("TextAnswers");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.TimeAnswerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("TimeAnswers");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2"
                        },
                        new
                        {
                            Id = "5fc39df2-aea1-405d-b887-b7167fb3d60b"
                        },
                        new
                        {
                            Id = "39be8196-adbd-405e-a4ed-9025abdaaec7"
                        },
                        new
                        {
                            Id = "7ad340b8-5610-4aef-9531-808dd8befa06"
                        },
                        new
                        {
                            Id = "e661b6a9-aa0d-44e2-9013-a267dfed12ef"
                        });
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.VideoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.AnswerEntity", b =>
                {
                    b.HasOne("JPS.Domain.Entities.Entities.QuestionEntity", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JPS.Domain.Entities.Entities.UserEntity", "User")
                        .WithMany("Answers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.CategoryEntity", b =>
                {
                    b.HasOne("JPS.Domain.Entities.Entities.CategoryEntity", "Category")
                        .WithMany("Categories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.DateAnswerEntity", b =>
                {
                    b.HasOne("JPS.Domain.Entities.Entities.AnswerEntity", "Answer")
                        .WithOne("DateAnswer")
                        .HasForeignKey("JPS.Domain.Entities.Entities.DateAnswerEntity", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.FileAnswerEntity", b =>
                {
                    b.HasOne("JPS.Domain.Entities.Entities.FileEntity", "File")
                        .WithMany("FileAnswers")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JPS.Domain.Entities.Entities.AnswerEntity", "Answer")
                        .WithOne("FileAnswer")
                        .HasForeignKey("JPS.Domain.Entities.Entities.FileAnswerEntity", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.OptionAnswerEntity", b =>
                {
                    b.HasOne("JPS.Domain.Entities.Entities.AnswerEntity", "Answer")
                        .WithOne("OptionAnswer")
                        .HasForeignKey("JPS.Domain.Entities.Entities.OptionAnswerEntity", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JPS.Domain.Entities.Entities.OptionEntity", "Option")
                        .WithMany("OptionAnswers")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JPS.Domain.Entities.Entities.OptionRowEntity", "OptionRow")
                        .WithMany("OptionAnswers")
                        .HasForeignKey("OptionRowId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.OptionEntity", b =>
                {
                    b.HasOne("JPS.Domain.Entities.Entities.ImageEntity", "Image")
                        .WithMany("Options")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("JPS.Domain.Entities.Entities.QuestionEntity", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.OptionRowEntity", b =>
                {
                    b.HasOne("JPS.Domain.Entities.Entities.ImageEntity", "Image")
                        .WithMany("OptionRows")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("JPS.Domain.Entities.Entities.QuestionEntity", "Question")
                        .WithMany("OptionRows")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.ParagraphAnswerEntity", b =>
                {
                    b.HasOne("JPS.Domain.Entities.Entities.AnswerEntity", "Answer")
                        .WithOne("ParagraphAnswer")
                        .HasForeignKey("JPS.Domain.Entities.Entities.ParagraphAnswerEntity", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.PollEntity", b =>
                {
                    b.HasOne("JPS.Domain.Entities.Entities.CategoryEntity", "Category")
                        .WithMany("Polls")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.QuestionEntity", b =>
                {
                    b.HasOne("JPS.Domain.Entities.Entities.ImageEntity", "Image")
                        .WithMany("Questions")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("JPS.Domain.Entities.Entities.QuestionSectionEntity", "QuestionSection")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JPS.Domain.Entities.Entities.QuestionTypeEntity", "QuestionType")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JPS.Domain.Entities.Entities.VideoEntity", "Video")
                        .WithMany("Questions")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.QuestionSectionEntity", b =>
                {
                    b.HasOne("JPS.Domain.Entities.Entities.PollEntity", "Poll")
                        .WithMany("QuestionSections")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.TextAnswerEntity", b =>
                {
                    b.HasOne("JPS.Domain.Entities.Entities.AnswerEntity", "Answer")
                        .WithOne("TextAnswer")
                        .HasForeignKey("JPS.Domain.Entities.Entities.TextAnswerEntity", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("JPS.Domain.Entities.Entities.TimeAnswerEntity", b =>
                {
                    b.HasOne("JPS.Domain.Entities.Entities.AnswerEntity", "Answer")
                        .WithOne("TimeAnswer")
                        .HasForeignKey("JPS.Domain.Entities.Entities.TimeAnswerEntity", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
