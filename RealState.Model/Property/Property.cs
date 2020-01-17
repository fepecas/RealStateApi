using RealState.Model.Enum;
using System;
using System.Collections.Generic;

namespace RealState.Model.Property
{
    public class Property
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public PropertyTypeOfferEnum TypeOffer { get; set; }
        public float AreaM2 { get; set; }
        public decimal Price { get; set; }
        public List<Room> Rooms { get; set; }
        public PropertyFloor Floor { get; set; }
        public Garage Garage { get; set; }
        public Deposit Deposit { get; set; }
        public DateTime? BuiltDate { get; set; }
        public bool VIS { get; set; }
        public bool VIP { get; set; }
    }
}
