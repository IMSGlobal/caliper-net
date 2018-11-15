using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Events {
	using ImsGlobal.Caliper.Util;

	[JsonConverter( typeof( JsonValueConverter<EventType> ) )]
	public sealed class EventType : IJsonValue {

		public static readonly EventType Annotation = new EventType( "AnnotationEvent" );
		public static readonly EventType Assessment = new EventType( "AssessmentEvent" );
		public static readonly EventType AssessmentItem = new EventType( "AssessmentItemEvent" );
		public static readonly EventType Assignable = new EventType( "AssignableEvent" );
		public static readonly EventType Event = new EventType( "Event" );
        public static readonly EventType Forum = new EventType("ForumEvent");
        public static readonly EventType Media = new EventType( "MediaEvent" );
        public static readonly EventType Message = new EventType("MessageEvent");
        public static readonly EventType Navigation = new EventType( "NavigationEvent" );
		public static readonly EventType Outcome = new EventType( "GradeEvent" );
        public static readonly EventType Search = new EventType("SearchEvent");
        public static readonly EventType Session = new EventType( "SessionEvent" );
        public static readonly EventType Thread = new EventType("ThreadEvent");
        public static readonly EventType ToolLaunch = new EventType("ToolLaunchEvent");
        public static readonly EventType ToolUse = new EventType("ToolUseEvent" );
		public static readonly EventType View = new EventType( "ViewEvent" );


		public EventType() {}

		public EventType( string value ) {
			this.Value = value;
		}

		public string Value { get; set; }

	}

}