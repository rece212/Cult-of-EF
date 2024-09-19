using System;
using System.Collections.Generic;

namespace prjEFExample.Model;

public partial class TblUser
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<TblContact> TblContacts { get; set; } = new List<TblContact>();
}
