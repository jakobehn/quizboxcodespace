namespace QBox.Api.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Answer")]
    public partial class Answer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Answer()
        {
            GameQuestion = new HashSet<GameQuestion>();
        }

        public int Id { get; set; }

        public int QuestionId { get; set; }

        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameQuestion> GameQuestion { get; set; }
    }
}
