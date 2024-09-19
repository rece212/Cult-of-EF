using System;
using System.Collections.Generic;

namespace prjEFExample.Model;

public partial class TblContact
{
    public int PersonId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string Username { get; set; } = null!;

    public virtual TblUser UsernameNavigation { get; set; } = null!;
}
