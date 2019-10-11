using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary.Models
{
    public class Rooms:AbstractRooms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int RoomId { get; set; }
        public override string RoomName { get; set; }
        public override string RoomType { get; set; }
        public override bool Occupied { get; set; }
        [ForeignKey("hospitalId")]
        public override Hospital HospitalId { get; set; }
    }
}
