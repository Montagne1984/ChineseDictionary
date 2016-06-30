using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ChineseDictionary.Data;

namespace ChineseDictionary.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160630083525_Models")]
    partial class Models
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChineseDictionary.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SimplifiedSymbol");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.HasKey("Id");

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.CharacterPronunciation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CharacterId");

                    b.Property<string>("Description");

                    b.Property<int>("PronunciationId");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("PronunciationId");

                    b.HasIndex("CharacterId", "PronunciationId")
                        .IsUnique();

                    b.ToTable("CharacterPronunciation");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.Consonant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 5);

                    b.HasKey("Id");

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.ToTable("Consonants");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.ConsonantMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaId");

                    b.Property<int>("ConsonantId");

                    b.Property<int>("IPAConsonantId");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("ConsonantId");

                    b.HasIndex("IPAConsonantId");

                    b.HasIndex("AreaId", "ConsonantId")
                        .IsUnique();

                    b.ToTable("ConsonantMappings");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.IPAConsonant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 5);

                    b.HasKey("Id");

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.ToTable("IPAConsonants");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.IPAVowel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 5);

                    b.HasKey("Id");

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.ToTable("IPAVowels");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.Pronunciation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConsonantId");

                    b.Property<int>("ToneId");

                    b.Property<int>("VowelId");

                    b.HasKey("Id");

                    b.HasIndex("ConsonantId");

                    b.HasIndex("ToneId");

                    b.HasIndex("VowelId");

                    b.HasIndex("ConsonantId", "VowelId", "ToneId")
                        .IsUnique();

                    b.ToTable("Pronunciations");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.Tone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaId");

                    b.Property<int>("ToneTypeId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("ToneTypeId");

                    b.HasIndex("AreaId", "Value")
                        .IsUnique();

                    b.ToTable("Tones");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.ToneType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ToneTypes");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.Vowel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 5);

                    b.HasKey("Id");

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.ToTable("Vowels");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.VowelMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaId");

                    b.Property<int>("IPAVowelId");

                    b.Property<int>("VowelId");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("IPAVowelId");

                    b.HasIndex("VowelId");

                    b.HasIndex("AreaId", "VowelId")
                        .IsUnique();

                    b.ToTable("VowelMappings");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Words");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.WordCharacterPronunciation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CharacterPronunciationId");

                    b.Property<string>("ToneValue")
                        .IsRequired();

                    b.Property<int>("WordPronunciationId");

                    b.HasKey("Id");

                    b.HasIndex("CharacterPronunciationId");

                    b.HasIndex("WordPronunciationId");

                    b.ToTable("WordCharacterPronunciation");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.WordDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("WordId");

                    b.HasKey("Id");

                    b.HasIndex("WordId");

                    b.ToTable("WordDefinition");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.WordExample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Sentence")
                        .IsRequired();

                    b.Property<int>("WordDefinitionId");

                    b.HasKey("Id");

                    b.HasIndex("WordDefinitionId");

                    b.ToTable("WordExample");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.WordLabel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LabelId");

                    b.Property<int>("WordId");

                    b.HasKey("Id");

                    b.HasIndex("LabelId");

                    b.HasIndex("WordId");

                    b.ToTable("WordLabel");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.WordPronunciation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaId");

                    b.Property<int>("WordId");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("WordId");

                    b.ToTable("WordPronunciations");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.WordPronunciationDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("WordDefinitionId");

                    b.Property<int>("WordPronunciationId");

                    b.HasKey("Id");

                    b.HasIndex("WordDefinitionId");

                    b.HasIndex("WordPronunciationId");

                    b.ToTable("WordPronunciationDefinition");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.CharacterPronunciation", b =>
                {
                    b.HasOne("ChineseDictionary.Models.EntityModels.Character")
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChineseDictionary.Models.EntityModels.Pronunciation")
                        .WithMany()
                        .HasForeignKey("PronunciationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.ConsonantMapping", b =>
                {
                    b.HasOne("ChineseDictionary.Models.EntityModels.Area")
                        .WithMany()
                        .HasForeignKey("AreaId");

                    b.HasOne("ChineseDictionary.Models.EntityModels.Consonant")
                        .WithMany()
                        .HasForeignKey("ConsonantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChineseDictionary.Models.EntityModels.IPAConsonant")
                        .WithMany()
                        .HasForeignKey("IPAConsonantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.Pronunciation", b =>
                {
                    b.HasOne("ChineseDictionary.Models.EntityModels.Consonant")
                        .WithMany()
                        .HasForeignKey("ConsonantId");

                    b.HasOne("ChineseDictionary.Models.EntityModels.Tone")
                        .WithMany()
                        .HasForeignKey("ToneId");

                    b.HasOne("ChineseDictionary.Models.EntityModels.Vowel")
                        .WithMany()
                        .HasForeignKey("VowelId");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.Tone", b =>
                {
                    b.HasOne("ChineseDictionary.Models.EntityModels.Area")
                        .WithMany()
                        .HasForeignKey("AreaId");

                    b.HasOne("ChineseDictionary.Models.EntityModels.ToneType")
                        .WithMany()
                        .HasForeignKey("ToneTypeId");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.VowelMapping", b =>
                {
                    b.HasOne("ChineseDictionary.Models.EntityModels.Area")
                        .WithMany()
                        .HasForeignKey("AreaId");

                    b.HasOne("ChineseDictionary.Models.EntityModels.IPAVowel")
                        .WithMany()
                        .HasForeignKey("IPAVowelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChineseDictionary.Models.EntityModels.Vowel")
                        .WithMany()
                        .HasForeignKey("VowelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.WordCharacterPronunciation", b =>
                {
                    b.HasOne("ChineseDictionary.Models.EntityModels.CharacterPronunciation")
                        .WithMany()
                        .HasForeignKey("CharacterPronunciationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChineseDictionary.Models.EntityModels.WordPronunciation")
                        .WithMany()
                        .HasForeignKey("WordPronunciationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.WordDefinition", b =>
                {
                    b.HasOne("ChineseDictionary.Models.EntityModels.Word")
                        .WithMany()
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.WordExample", b =>
                {
                    b.HasOne("ChineseDictionary.Models.EntityModels.WordDefinition")
                        .WithMany()
                        .HasForeignKey("WordDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.WordLabel", b =>
                {
                    b.HasOne("ChineseDictionary.Models.EntityModels.Label")
                        .WithMany()
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChineseDictionary.Models.EntityModels.Word")
                        .WithMany()
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.WordPronunciation", b =>
                {
                    b.HasOne("ChineseDictionary.Models.EntityModels.Area")
                        .WithMany()
                        .HasForeignKey("AreaId");

                    b.HasOne("ChineseDictionary.Models.EntityModels.Word")
                        .WithMany()
                        .HasForeignKey("WordId");
                });

            modelBuilder.Entity("ChineseDictionary.Models.EntityModels.WordPronunciationDefinition", b =>
                {
                    b.HasOne("ChineseDictionary.Models.EntityModels.WordDefinition")
                        .WithMany()
                        .HasForeignKey("WordDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChineseDictionary.Models.EntityModels.WordPronunciation")
                        .WithMany()
                        .HasForeignKey("WordPronunciationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ChineseDictionary.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ChineseDictionary.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChineseDictionary.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
