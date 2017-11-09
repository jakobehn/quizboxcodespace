namespace QBox.Api.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GameQuestion")]
    public partial class GameQuestion
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public int QuestionId { get; set; }

        public int Order { get; set; }

        public int? AnswerId { get; set; }

        public virtual Answer Answer { get; set; }

        public virtual Game Game { get; set; }

        public virtual Question Question { get; set; }
    }
}
