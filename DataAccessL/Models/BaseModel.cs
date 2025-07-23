using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Models
{
    public enum Status
    {
        Active=1 ,
        InActive=2
    }
  public  class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Status Status { get; set; }
    }
}
