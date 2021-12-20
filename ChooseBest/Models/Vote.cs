using System.ComponentModel.DataAnnotations;

namespace ChooseBest.Models
{
    public class Vote
    {
        [Required]
        public Guid Id { get; set; }
        [DataType(DataType.Text)]
        public string? Name { get; set; }
        [DataType(DataType.ImageUrl)]
        public string? Img { get; set; }
        public uint? Votes { get; set; } = 0;
    }
}
