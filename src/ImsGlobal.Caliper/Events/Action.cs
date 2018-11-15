
using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Events {
	using ImsGlobal.Caliper.Util;

	[JsonConverter( typeof( JsonValueConverter<Action> ) )]
	public sealed class Action : IJsonValue {

		public static readonly Action Abandoned = new Action( "Abandoned");
		public static readonly Action Activated = new Action( "Activated");
		public static readonly Action Added = new Action( "Added");
		public static readonly Action Attached = new Action( "Attached");
		public static readonly Action Bookmarked = new Action( "Bookmarked");
		public static readonly Action ChangedResolution = new Action( "ChangedResolution");
		public static readonly Action ChangedSize = new Action( "ChangedSize");
		public static readonly Action ChangedSpeed = new Action( "ChangedSpeed");
		public static readonly Action ChangedVolume = new Action( "ChangedVolume");
		public static readonly Action Classified = new Action( "Classified");
		public static readonly Action ClosedPopout = new Action( "ClosedPopout");
		public static readonly Action Commented = new Action( "Commented");
		public static readonly Action Completed = new Action( "Completed");
		public static readonly Action Created = new Action( "Created");
		public static readonly Action Deactivated = new Action( "Deactivated");
		public static readonly Action Deleted = new Action( "Deleted");
		public static readonly Action Described = new Action( "Described");
		public static readonly Action DisabledCloseCaptioning = new Action( "DisabledCloseCaptioning");
		public static readonly Action Disliked = new Action( "Disliked");
		public static readonly Action EnabledCloseCaptioning = new Action( "EnabledCloseCaptioning");
		public static readonly Action Ended = new Action( "Ended");
		public static readonly Action EnteredFullScreen = new Action( "EnteredFullScreen");
		public static readonly Action ExitedFullScreen = new Action( "ExitedFullScreen");
		public static readonly Action ForwardedTo = new Action( "ForwardedTo");
		public static readonly Action Graded = new Action( "Graded");
		public static readonly Action Hid = new Action( "Hid");
		public static readonly Action Highlighted = new Action( "Highlighted");
		public static readonly Action Identified = new Action( "Identified");
		public static readonly Action JumpedTo = new Action( "JumpedTo");
        public static readonly Action Launched = new Action("Launched");
        public static readonly Action Liked = new Action( "Liked");
		public static readonly Action Linked = new Action( "Linked");
		public static readonly Action LoggedIn = new Action( "LoggedIn");
		public static readonly Action LoggedOut = new Action( "LoggedOut");
		public static readonly Action MarkedAsRead = new Action( "MarkedAsRead");
		public static readonly Action MarkedAsUnread = new Action( "MarkedAsUnread");
		public static readonly Action Modified = new Action( "Modified");
		public static readonly Action Muted = new Action( "Muted");
		public static readonly Action NavigatedTo = new Action( "NavigatedTo");
		public static readonly Action OpenedPopout = new Action( "OpenedPopout");
		public static readonly Action Paused = new Action( "Paused");
		public static readonly Action Posted = new Action( "Posted");
		public static readonly Action Questioned = new Action( "Questioned");
		public static readonly Action Ranked = new Action( "Ranked");
		public static readonly Action Recommended = new Action( "Recommended");
		public static readonly Action Removed = new Action( "Removed");
		public static readonly Action Reset = new Action( "Reset");
		public static readonly Action Restarted = new Action( "Restarted");
		public static readonly Action Resumed = new Action( "Resumed");
		public static readonly Action Retrieved = new Action( "Retrieved");
        public static readonly Action Returned = new Action("Returned");
        public static readonly Action Reviewed = new Action( "Reviewed");
		public static readonly Action Rewound = new Action( "Rewound");
		public static readonly Action Searched = new Action( "Searched");
		public static readonly Action Shared = new Action( "Shared" );
		public static readonly Action Showed = new Action( "Showed" );
		public static readonly Action Skipped = new Action( "Skipped" );
		public static readonly Action Started = new Action( "Started" );
		public static readonly Action Submitted = new Action( "Submitted" );
		public static readonly Action Subscribed = new Action( "Subscribed" );
		public static readonly Action Tagged = new Action( "Tagged" );
		public static readonly Action TimedOut = new Action( "TimedOut" );
		public static readonly Action Unmuted = new Action( "Unmuted" );
		public static readonly Action Unsubscribed = new Action( "Unsubscribed" );
		public static readonly Action Used = new Action( "Used" );
		public static readonly Action Viewed = new Action( "Viewed" );


        public Action() {}

		public Action( string action ) {
			this.Value = action;
		}

		public string Value { get; set; }

	}

}

