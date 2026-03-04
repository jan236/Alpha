using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Nominatim;

    public interface INominatimClient
    {
        Task<List<NominatimLocationDto>> SearchAsync(string query);
    }

