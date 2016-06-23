using System.ComponentModel.DataAnnotations;

namespace ChineseDictionary.Models.EntityModels
{
    public class WordLabel
    {
        public int Id { get; set; }
        [Required]
        public int WordId { get; set; }
        [Required]
        public Word Word { get; set; }
        [Required]
        public int LabelId { get; set; }
        [Required]
        public Label Label { get; set; }
    }
}
