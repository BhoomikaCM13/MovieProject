using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreEntity
{
    public class ShowTiming
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Movie")]
        public int MId { get; set; }
        public Movie Movie { get; set; }

        [ForeignKey("Theater")]
        public int TId { get; set; }
        public Theater Theater { get; set; }
        public DateTime ShowTime { get; set; }

    }
}
