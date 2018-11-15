using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.ToolLaunch
{
    public class LtiLink : Entity
    {
        public LtiLink(string id)
            : base(id)
        {
            this.Type = EntityType.LtiLink;
        }

        [JsonProperty("messageType")]
        public IType MessageType { get; set; }
    }
}
