using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace diplomApiV4
{
    public partial class Client
    {
        public Client()
        {
            ClientComponents = new HashSet<ClientComponent>();           
        }

        public int ClientId { get; set; }
        public string ClientNick { get; set; } = null!;
        public string? ClientMail { get; set; }
        public DateTime? ClientBirthday { get; set; }
        public string? ClientImage { get; set; }
        public string ClientPassword { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<ClientComponent> ClientComponents { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
