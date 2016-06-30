using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChineseDictionary.Data.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SimplifiedSymbol = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consonants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consonants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IPAConsonants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPAConsonants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IPAVowels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPAVowels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToneTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToneTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vowels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vowels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsonantMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: false),
                    ConsonantId = table.Column<int>(nullable: false),
                    IPAConsonantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsonantMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsonantMappings_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsonantMappings_Consonants_ConsonantId",
                        column: x => x.ConsonantId,
                        principalTable: "Consonants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsonantMappings_IPAConsonants_IPAConsonantId",
                        column: x => x.IPAConsonantId,
                        principalTable: "IPAConsonants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: false),
                    ToneTypeId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tones_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tones_ToneTypes_ToneTypeId",
                        column: x => x.ToneTypeId,
                        principalTable: "ToneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VowelMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: false),
                    IPAVowelId = table.Column<int>(nullable: false),
                    VowelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VowelMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VowelMappings_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VowelMappings_IPAVowels_IPAVowelId",
                        column: x => x.IPAVowelId,
                        principalTable: "IPAVowels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VowelMappings_Vowels_VowelId",
                        column: x => x.VowelId,
                        principalTable: "Vowels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    WordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordDefinition_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordLabel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LabelId = table.Column<int>(nullable: false),
                    WordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordLabel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordLabel_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordLabel_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordPronunciations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: false),
                    WordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordPronunciations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordPronunciations_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WordPronunciations_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pronunciations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConsonantId = table.Column<int>(nullable: false),
                    ToneId = table.Column<int>(nullable: false),
                    VowelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pronunciations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pronunciations_Consonants_ConsonantId",
                        column: x => x.ConsonantId,
                        principalTable: "Consonants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pronunciations_Tones_ToneId",
                        column: x => x.ToneId,
                        principalTable: "Tones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pronunciations_Vowels_VowelId",
                        column: x => x.VowelId,
                        principalTable: "Vowels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WordExample",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sentence = table.Column<string>(nullable: false),
                    WordDefinitionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordExample", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordExample_WordDefinition_WordDefinitionId",
                        column: x => x.WordDefinitionId,
                        principalTable: "WordDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordPronunciationDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WordDefinitionId = table.Column<int>(nullable: false),
                    WordPronunciationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordPronunciationDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordPronunciationDefinition_WordDefinition_WordDefinitionId",
                        column: x => x.WordDefinitionId,
                        principalTable: "WordDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordPronunciationDefinition_WordPronunciations_WordPronunciationId",
                        column: x => x.WordPronunciationId,
                        principalTable: "WordPronunciations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterPronunciation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PronunciationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterPronunciation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterPronunciation_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterPronunciation_Pronunciations_PronunciationId",
                        column: x => x.PronunciationId,
                        principalTable: "Pronunciations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordCharacterPronunciation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterPronunciationId = table.Column<int>(nullable: false),
                    ToneValue = table.Column<string>(nullable: false),
                    WordPronunciationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordCharacterPronunciation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordCharacterPronunciation_CharacterPronunciation_CharacterPronunciationId",
                        column: x => x.CharacterPronunciationId,
                        principalTable: "CharacterPronunciation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordCharacterPronunciation_WordPronunciations_WordPronunciationId",
                        column: x => x.WordPronunciationId,
                        principalTable: "WordPronunciations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Name",
                table: "Areas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Symbol",
                table: "Characters",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPronunciation_CharacterId",
                table: "CharacterPronunciation",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPronunciation_PronunciationId",
                table: "CharacterPronunciation",
                column: "PronunciationId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPronunciation_CharacterId_PronunciationId",
                table: "CharacterPronunciation",
                columns: new[] { "CharacterId", "PronunciationId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consonants_Symbol",
                table: "Consonants",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsonantMappings_AreaId",
                table: "ConsonantMappings",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsonantMappings_ConsonantId",
                table: "ConsonantMappings",
                column: "ConsonantId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsonantMappings_IPAConsonantId",
                table: "ConsonantMappings",
                column: "IPAConsonantId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsonantMappings_AreaId_ConsonantId",
                table: "ConsonantMappings",
                columns: new[] { "AreaId", "ConsonantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IPAConsonants_Symbol",
                table: "IPAConsonants",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IPAVowels_Symbol",
                table: "IPAVowels",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Labels_Name",
                table: "Labels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pronunciations_ConsonantId",
                table: "Pronunciations",
                column: "ConsonantId");

            migrationBuilder.CreateIndex(
                name: "IX_Pronunciations_ToneId",
                table: "Pronunciations",
                column: "ToneId");

            migrationBuilder.CreateIndex(
                name: "IX_Pronunciations_VowelId",
                table: "Pronunciations",
                column: "VowelId");

            migrationBuilder.CreateIndex(
                name: "IX_Pronunciations_ConsonantId_VowelId_ToneId",
                table: "Pronunciations",
                columns: new[] { "ConsonantId", "VowelId", "ToneId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tones_AreaId",
                table: "Tones",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tones_ToneTypeId",
                table: "Tones",
                column: "ToneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tones_AreaId_Value",
                table: "Tones",
                columns: new[] { "AreaId", "Value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToneTypes_Name",
                table: "ToneTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vowels_Symbol",
                table: "Vowels",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VowelMappings_AreaId",
                table: "VowelMappings",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_VowelMappings_IPAVowelId",
                table: "VowelMappings",
                column: "IPAVowelId");

            migrationBuilder.CreateIndex(
                name: "IX_VowelMappings_VowelId",
                table: "VowelMappings",
                column: "VowelId");

            migrationBuilder.CreateIndex(
                name: "IX_VowelMappings_AreaId_VowelId",
                table: "VowelMappings",
                columns: new[] { "AreaId", "VowelId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_Name",
                table: "Words",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WordCharacterPronunciation_CharacterPronunciationId",
                table: "WordCharacterPronunciation",
                column: "CharacterPronunciationId");

            migrationBuilder.CreateIndex(
                name: "IX_WordCharacterPronunciation_WordPronunciationId",
                table: "WordCharacterPronunciation",
                column: "WordPronunciationId");

            migrationBuilder.CreateIndex(
                name: "IX_WordDefinition_WordId",
                table: "WordDefinition",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordExample_WordDefinitionId",
                table: "WordExample",
                column: "WordDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_WordLabel_LabelId",
                table: "WordLabel",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_WordLabel_WordId",
                table: "WordLabel",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordPronunciations_AreaId",
                table: "WordPronunciations",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_WordPronunciations_WordId",
                table: "WordPronunciations",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordPronunciationDefinition_WordDefinitionId",
                table: "WordPronunciationDefinition",
                column: "WordDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_WordPronunciationDefinition_WordPronunciationId",
                table: "WordPronunciationDefinition",
                column: "WordPronunciationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsonantMappings");

            migrationBuilder.DropTable(
                name: "VowelMappings");

            migrationBuilder.DropTable(
                name: "WordCharacterPronunciation");

            migrationBuilder.DropTable(
                name: "WordExample");

            migrationBuilder.DropTable(
                name: "WordLabel");

            migrationBuilder.DropTable(
                name: "WordPronunciationDefinition");

            migrationBuilder.DropTable(
                name: "IPAConsonants");

            migrationBuilder.DropTable(
                name: "IPAVowels");

            migrationBuilder.DropTable(
                name: "CharacterPronunciation");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "WordDefinition");

            migrationBuilder.DropTable(
                name: "WordPronunciations");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Pronunciations");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Consonants");

            migrationBuilder.DropTable(
                name: "Tones");

            migrationBuilder.DropTable(
                name: "Vowels");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "ToneTypes");
        }
    }
}
