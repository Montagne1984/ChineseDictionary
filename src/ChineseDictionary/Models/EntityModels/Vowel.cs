using System.Collections.Generic;

namespace ChineseDictionary.Models.EntityModels
{
    public class Vowel : Phoneme
    {
        public List<Pronunciation> Pronunciations { get; set; }
        public List<VowelMapping> VowelMappings { get; set; }
    }
}
