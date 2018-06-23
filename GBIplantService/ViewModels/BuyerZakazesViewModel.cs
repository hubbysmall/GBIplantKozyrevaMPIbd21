﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GBIplantService.ViewModels
{
    [DataContract]
    public class BuyerZakazesViewModel
    {
        [DataMember]
        public string BuyerName { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string GBIpieceOfArtName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}