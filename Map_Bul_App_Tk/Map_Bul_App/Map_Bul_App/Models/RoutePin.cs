﻿using TK.CustomMap;
using TK.CustomMap.Overlays;

namespace Map_Bul_App.Models
{
    public class RoutePin : TKCustomMapPin
    {
        /// <summary>
        /// Gets/Sets if the pin is the source of a route. If <value>false</value> pin is destination
        /// </summary>
        public bool IsSource { get; set; }
        /// <summary>
        /// Gets/Sets reference to the route
        /// </summary>
        public TKRoute Route { get; set; }
    }
}
