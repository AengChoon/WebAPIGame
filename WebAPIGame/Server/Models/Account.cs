using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

[Table("Account")]
public class Account
{
    public long Id { get; set; }
    public DateTime Created { get; set; }
}