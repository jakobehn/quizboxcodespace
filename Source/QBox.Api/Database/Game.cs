namespace QBox.Api.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            GameQuestion = new HashSet<GameQuestion>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameQuestion> GameQuestion { get; set; }
    }
}
