using System;
using System.Collections.Generic;

namespace ClassLibrary.EFAutoGen
{
    public partial class Rooms
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public bool Occupied { get; set; }
        public int HospitalId { get; set; }

        public Hospital Hospital { get; set; }
    }
}
