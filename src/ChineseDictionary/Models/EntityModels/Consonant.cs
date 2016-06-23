﻿using System.Collections.Generic;

namespace ChineseDictionary.Models.EntityModels
{
    public class Consonant : Phoneme
    {
        public List<Pronunciation> Pronunciations { get; set; }
        public List<ConsonantMapping> ConsonantMappings { get; set; }
    }
}
