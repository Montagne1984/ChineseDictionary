﻿using System.ComponentModel.DataAnnotations;

namespace ChineseDictionary.Models.EntityModels
{
    public class Phoneme
    {
        public int Id { get; set; }
        [Required, MaxLength(5)]
        public string Symbol { get; set; }
    }
}
