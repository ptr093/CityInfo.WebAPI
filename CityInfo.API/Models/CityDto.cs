namespace CityInfo.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace CityInfo.API.Models
    {
        public class CityDto
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; }

            public int NumberOfPointsIntrest
            {
                get
                {
                    return PointOfIntrests.Count;
                }
            }


            public ICollection<PointOfIntrestDto> PointOfIntrests { get; set; } = new List<PointOfIntrestDto>();
        }
    }
}
