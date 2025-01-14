﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EFCore
{
    [Table("TBuilders")]
    public class TBuilder
    {
        [Column("Id")]
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }

        [Column("Name")]
        public String Name { get; set; }

        [ForeignKey("City")]
        public Int32 CityId { get; set; }

        public TCity City { get; set; }

        public virtual ICollection<TBuilding> Buildings { get; set; }
    }
}
