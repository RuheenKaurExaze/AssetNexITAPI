using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AssetNex.API.Models.DomainModel;

namespace AssetNex.API.Models.DomainModel
{


    public class SoftwareLicenseInfo
    {
     

        [Key]
        public Guid Id { get; set; }

        public required string UserName { get; set; }

        public required string Request { get; set; }


        public required string EmployeeId { get; set; }

        public required string SoftwareName { get; set; }


        public required string? OtherSoftware { get; set; }


        public required DateTime DateApplied { get; set; }


    }
}