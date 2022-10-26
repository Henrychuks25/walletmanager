using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User
    {
        public Guid Id { get; set; }
        //public Guid walletId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
    }
}
