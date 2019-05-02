using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DbUpLesson
{
 public class News : Entity
  {
    public string Newss { get; set; }
    public ICollection<Comments> newsComments { get; set; }
  }
}