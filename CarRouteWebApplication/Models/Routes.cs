namespace CarRouteWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Routes
    {
        public int Id { get; set; }
        public string carPlate { get; set; }
        public string startLocationName { get; set; }
        public string startLocationLat { get; set; }
        public string startLocationLng { get; set; }
        public string endLocationName { get; set; }
        public string endLocationLat { get; set; }
        public string endLocationLng { get; set; }
    }
}
