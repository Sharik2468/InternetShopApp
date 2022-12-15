using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Model
{
    class LocationModel
    {
        public LocationModel()
        {

        }

        public LocationModel(DBAccess.Location_Table c)
        {
            Location_Code = c.Location_Code;
            Name = c.Name;
        }

        public int Location_Code { get; set; }
        public string Name { get; set; }
    }
}
