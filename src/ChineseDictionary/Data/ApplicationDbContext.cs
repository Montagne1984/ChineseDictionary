using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ChineseDictionary.Models;
using ChineseDictionary.Models.EntityModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChineseDictionary.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Consonant>().HasIndex(c => c.Symbol).IsUnique();
            builder.Entity<Vowel>().HasIndex(v => v.Symbol).IsUnique();
            builder.Entity<IPAConsonant>().HasIndex(c => c.Symbol).IsUnique();
            builder.Entity<IPAVowel>().HasIndex(v => v.Symbol).IsUnique();
            builder.Entity<ToneType>().HasIndex(tt => tt.Name).IsUnique();
            builder.Entity<Area>().HasIndex(a => a.Name).IsUnique();
            builder.Entity<Tone>().HasIndex(t =>
                new
                {
                    t.AreaId,
                    t.Value
                }).IsUnique();
            builder.Entity<ConsonantMapping>().HasIndex(cm =>
                new
                {
                    cm.AreaId,
                    cm.ConsonantId
                }).IsUnique();
            builder.Entity<VowelMapping>().HasIndex(vm =>
                new
                {
                    vm.AreaId,
                    vm.VowelId
                }).IsUnique();
            builder.Entity<Pronunciation>().HasIndex(p =>
                new
                {
                    p.ConsonantId,
                    p.VowelId,
                    p.ToneId
                }).IsUnique();
            builder.Entity<Character>().HasIndex(c => c.Symbol).IsUnique();
            builder.Entity<CharacterPronunciation>().HasIndex(cp =>
                new
                {
                    cp.CharacterId,
                    cp.PronunciationId
                }).IsUnique();
            builder.Entity<Word>().HasIndex(w => w.Name).IsUnique();
            builder.Entity<WordCharacterPronunciation>();
            builder.Entity<WordPronunciation>();
            builder.Entity<WordDefinition>();
            builder.Entity<Label>().HasIndex(l => l.Name).IsUnique();
            builder.Entity<WordLabel>();

            builder.Entity<ConsonantMapping>()
                .HasOne(cm => cm.Area)
                .WithMany(a => a.ConsonantMappings)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<VowelMapping>()
                .HasOne(vm => vm.Area)
                .WithMany(a => a.VowelMappings)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Tone>()
                .HasOne(t => t.Area)
                .WithMany(a => a.Tones)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<WordPronunciation>()
                .HasOne(wp => wp.Area)
                .WithMany(a => a.WordPronunciations)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Pronunciation>()
                .HasOne(p => p.Consonant)
                .WithMany(c => c.Pronunciations)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Pronunciation>()
                .HasOne(p => p.Vowel)
                .WithMany(v => v.Pronunciations)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Pronunciation>()
                .HasOne(p => p.Tone)
                .WithMany(t => t.Pronunciations)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Tone>()
                .HasOne(t => t.ToneType)
                .WithMany(tt => tt.Tones)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<WordPronunciation>()
                .HasOne(wp => wp.Word)
                .WithMany(w => w.WordPronunciations)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Consonant> Consonants { get; set; }
        public DbSet<Vowel> Vowels { get; set; }
        public DbSet<IPAConsonant> IPAConsonants { get; set; }
        public DbSet<IPAVowel> IPAVowels { get; set; }
        public DbSet<ConsonantMapping> ConsonantMappings { get; set; }
        public DbSet<VowelMapping> VowelMappings { get; set; }
        public DbSet<ToneType> ToneTypes { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Tone> Tones { get; set; }
        public DbSet<Pronunciation> Pronunciations { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordPronunciation> WordPronunciations { get; set; }
        public DbSet<Label> Labels { get; set; }
    }
}
