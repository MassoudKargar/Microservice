using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ms.ValueObject.EFSample;

public class Person
{
    public int Id { get; set; }
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }

}
