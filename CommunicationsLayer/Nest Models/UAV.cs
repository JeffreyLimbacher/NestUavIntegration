//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NEST_App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UAV
    {
        public UAV()
        {

        }
    
        public int Id { get; set; }
        public string Callsign { get; set; }
        public int NumDeliveries { get; set; }
        public int Mileage { get; set; }
        public System.DateTime create_date { get; set; }
        public System.DateTime modified_date { get; set; }
        public double MaxVelocity { get; set; }
        public double MaxAcceleration { get; set; }
        public double MaxVerticalVelocity { get; set; }
        public double UpdateRate { get; set; }
        public double CruiseAltitude { get; set; }
        public double MinDeliveryAlt { get; set; }
        public Nullable<int> User_user_id { get; set; }
        public bool isActive { get; set; }
        public int estimated_workload { get; set; }
    
    }
}
