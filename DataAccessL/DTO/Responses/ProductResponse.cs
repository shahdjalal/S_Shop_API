﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.DTO.Responses
{
  public  class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public string MainImage { get; set; }

        public string MainImageURL { get; set; }

        public List<string> SubImagesUrls { get; set; }= new List<string>();
        public List<ReviewResponse> Reviews { get; set; } = new List<ReviewResponse>();


    }
}
