using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Interfaces
{
    public abstract class AbstractRooms
    {
        public static readonly NullRooms nullRooms = NullRoomsInst;
        private static NullRooms NullRoomsInst
        {
            get { return new NullRooms(); }
        }
        public virtual int RoomId {get;set;}
        public virtual string RoomName { get; set; }
        public virtual string RoomType { get; set; }
        public virtual bool Occupied { get; set; }
        public virtual Hospital HospitalId { get; set; }
    }
    public class NullRooms:AbstractRooms
    {
        public override int RoomId { get => 0; }
        public override string RoomName { get => "No Room Name Provided"; }
        public override string RoomType { get => "No Room Type Specified"; }
        public override bool Occupied { get => false; }
        public override Hospital HospitalId { get => null;}
    }
}
