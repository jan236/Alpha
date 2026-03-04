using System;
using System.Collections.Generic;
using System.Text;

namespace Alpha.Nominatim;

    public class NominatimLocationDto
    {
        public long PlaceId { get; set; }
        public string? DisplayName { get; set; }
        public string? Lat { get; set; }
        public string? Lon { get; set; }
        public string? Type { get; set; }
    }

