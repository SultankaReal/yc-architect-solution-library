﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using yc_scale_2022.Models;

namespace yc_scale_2022.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("yc_scale_2022.Models.AsrSession", b =>
                {
                    b.Property<Guid>("AsrSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("RemoteIpAddress")
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("TraceIdentifier")
                        .HasColumnType("text");

                    b.Property<string>("UserAgent")
                        .HasColumnType("varchar(255)");

                    b.HasKey("AsrSessionId");

                    b.ToTable("asr_sessions");
                });

            modelBuilder.Entity("yc_scale_2022.Models.Inference", b =>
                {
                    b.Property<int>("inference_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("InferenceId")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("anger")
                        .HasColumnName("Anger")
                        .HasColumnType("double precision");

                    b.Property<double>("fear")
                        .HasColumnName("Fear")
                        .HasColumnType("double precision");

                    b.Property<double>("joy")
                        .HasColumnName("Joy")
                        .HasColumnType("double precision");

                    b.Property<double>("no_emotion")
                        .HasColumnName("NoEmotion")
                        .HasColumnType("double precision");

                    b.Property<Guid>("recognition_id")
                        .HasColumnName("RecognitionId")
                        .HasColumnType("uuid");

                    b.Property<double>("sadness")
                        .HasColumnName("Sadness")
                        .HasColumnType("double precision");

                    b.Property<double>("surprise")
                        .HasColumnName("Surprise")
                        .HasColumnType("double precision");

                    b.HasKey("inference_id");

                    b.ToTable("ml_inference");
                });

            modelBuilder.Entity("yc_scale_2022.Models.SubstDictionary", b =>
                {
                    b.Property<int>("substitutionRuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("patternMatch")
                        .HasColumnType("text");

                    b.Property<string>("replacement")
                        .HasColumnType("text");

                    b.HasKey("substitutionRuleId");

                    b.ToTable("dic_substitution");
                });

            modelBuilder.Entity("yc_scale_2022.Models.V3SpeechKitModels+Alternative", b =>
                {
                    b.Property<Guid>("AlternativeId")
                        .HasColumnType("uuid");

                    b.Property<int>("Confidence")
                        .HasColumnType("integer");

                    b.Property<int>("EndTimeMs")
                        .HasColumnType("integer");

                    b.Property<Guid>("RecognitionId")
                        .HasColumnType("uuid");

                    b.Property<int>("StartTimeMs")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("AlternativeId");

                    b.ToTable("asr_alternative");
                });

            modelBuilder.Entity("yc_scale_2022.Models.V3SpeechKitModels+SessionUuid", b =>
                {
                    b.Property<int>("SpeechKitSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("UserRequestId")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Uuid")
                        .HasColumnType("varchar(50)");

                    b.HasKey("SpeechKitSessionId");

                    b.ToTable("asr_speechkit_session_ids");
                });

            modelBuilder.Entity("yc_scale_2022.Models.V3SpeechKitModels+SpeechKitResponseModel", b =>
                {
                    b.Property<Guid>("RecognitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double?>("AudioLen")
                        .HasColumnType("double precision");

                    b.Property<int>("EventCase")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RecognitionDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uuid");

                    b.Property<int?>("SessionUuidSpeechKitSessionId")
                        .HasColumnType("integer");

                    b.Property<string>("TrackerKey")
                        .HasColumnType("varchar(100)");

                    b.HasKey("RecognitionId");

                    b.HasIndex("SessionUuidSpeechKitSessionId");

                    b.ToTable("asr_recognition");
                });

            modelBuilder.Entity("yc_scale_2022.Models.V3SpeechKitModels+Word", b =>
                {
                    b.Property<int>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid>("AlternativeId")
                        .HasColumnType("uuid");

                    b.Property<int>("EndTimeMs")
                        .HasColumnType("integer");

                    b.Property<int>("StartTimeMs")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("WordId");

                    b.HasIndex("AlternativeId");

                    b.ToTable("asr_word");
                });

            modelBuilder.Entity("yc_scale_2022.Models.V3SpeechKitModels+Alternative", b =>
                {
                    b.HasOne("yc_scale_2022.Models.V3SpeechKitModels+SpeechKitResponseModel", null)
                        .WithMany("Alternatives")
                        .HasForeignKey("AlternativeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("yc_scale_2022.Models.V3SpeechKitModels+SpeechKitResponseModel", b =>
                {
                    b.HasOne("yc_scale_2022.Models.V3SpeechKitModels+SessionUuid", "SessionUuid")
                        .WithMany()
                        .HasForeignKey("SessionUuidSpeechKitSessionId");
                });

            modelBuilder.Entity("yc_scale_2022.Models.V3SpeechKitModels+Word", b =>
                {
                    b.HasOne("yc_scale_2022.Models.V3SpeechKitModels+Alternative", null)
                        .WithMany("Words")
                        .HasForeignKey("AlternativeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
