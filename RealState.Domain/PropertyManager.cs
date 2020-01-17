using RealState.Model.Enum;
using RealState.Model.Property;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealState.Domain
{
    public class PropertyManager
    {
        public Property GetById(int id)
        {
            return new Property
            {
                Id = id,
                AreaM2 = 66.55f,
                BuiltDate = DateTime.Now,
                Floor = (PropertyFloor)Enum.Parse(typeof(PropertyFloor), "2"),
                Code = "402",
                TypeOffer = PropertyTypeOfferEnum.ForRent
            };
        }
    }
}
