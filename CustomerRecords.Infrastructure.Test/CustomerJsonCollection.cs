﻿using System.Collections.Generic;

namespace CustomerRecords.Infrastructure.Test
{
    internal class CustomerJsonCollection
    {
        private static object[] _customerJsonArray =
        {
            new List<string>
            {
                "{'latitude': '52.986375', 'user_id': 12, 'name': 'Christina McArdle', 'longitude': '-6.043701'}",
                "{'latitude': '51.92893', 'user_id': 1, 'name': 'Alice Cahill', 'longitude': '-10.27699'}",
                "{'latitude': '51.8856167', 'user_id': 2, 'name': 'Ian McArdle', 'longitude': '-10.4240951'}",
                "{'latitude': '52.3191841', 'user_id': 3, 'name': 'Jack Enright', 'longitude': '-8.5072391'}",
                "{'latitude': '53.807778', 'user_id': 28, 'name': 'Charlie Halligan', 'longitude': '-7.714444'}"
            }
        };
    }
}