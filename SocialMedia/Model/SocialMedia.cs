using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Model
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Family { get; set; }
        [StringLength(100)]
        public string InstagramId { get; set; }
        [StringLength(250)]
        public string TwitterUrl { get; set; }
        [StringLength(250)]
        public string FacebookUrl { get; set; }
    }
}
