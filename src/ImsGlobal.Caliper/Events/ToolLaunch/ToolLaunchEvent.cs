namespace ImsGlobal.Caliper.Events.Search
{
    public class ToolLaunchEvent : Event
    {

        public ToolLaunchEvent(string id, Action action)
            : base(id)
        {
            this.Context = CaliperContext.ToolLaunchProfileExtension;
            this.Type = EventType.ToolLaunch;
            this.Action = action;
        }
    }
}
