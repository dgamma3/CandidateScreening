using CandidateScreening.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CandidateScreening.Models
{
    public class ProductListViewModel
    {

        public IEnumerable<Patient> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}