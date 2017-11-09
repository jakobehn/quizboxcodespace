namespace QBox.Api.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Highscore")]
    public partial class Highscore
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public double ScorePercent { get; set; }

        public int TimeElapsedSeconds { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public DateTime EndTime { get; set; }

        public int? Age { get; set; }

        public virtual Category Category { get; set; }
    }
}
