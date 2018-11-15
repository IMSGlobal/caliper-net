using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities
{
	using ImsGlobal.Caliper.Util;

	[JsonConverter(typeof(JsonValueConverter<EntityType>))]
	public class EntityType : IType, IJsonValue
	{

		public static readonly EntityType Agent = new EntityType("Agent");
		public static readonly EntityType Annotation = new EntityType("Annotation");
		public static readonly EntityType Assessment = new EntityType("Assessment");
		public static readonly EntityType AssessmentItem = new EntityType("AssessmentItem");
		public static readonly EntityType AssignableDigitalResource = new EntityType("AssignableDigitalResource");
		public static readonly EntityType Attempt = new EntityType("Attempt");
		public static readonly EntityType AudioObject = new EntityType("AudioObject");
		public static readonly EntityType Bookmark = new EntityType("BookmarkAnnotation");
		public static readonly EntityType Chapter = new EntityType("Chapter");
		public static readonly EntityType CourseOffering = new EntityType("CourseOffering");
		public static readonly EntityType CourseSection = new EntityType("CourseSection");
		public static readonly EntityType DigitalResource = new EntityType("DigitalResource");
		public static readonly EntityType DigitalResourceCollection = new EntityType("DigitalResourceCollection");
		public static readonly EntityType Document = new EntityType("Document");
		public static readonly EntityType Entity = new EntityType("Entity");
		public static readonly EntityType FillInBlank = new EntityType("FillinBlankResponse");
		public static readonly EntityType Forum = new EntityType("Forum");
		public static readonly EntityType Frame = new EntityType("Frame");
		public static readonly EntityType Group = new EntityType("Group");
		public static readonly EntityType Highlight = new EntityType("HighlightAnnotation");
		public static readonly EntityType ImageObject = new EntityType("ImageObject");
		public static readonly EntityType LearningObjective = new EntityType("LearningObjective");
        public static readonly EntityType Link = new EntityType("Link");
        public static readonly EntityType LtiDeepLinkingRequest = new EntityType("LtiDeepLinkingRequest");
        public static readonly EntityType LtiLink = new EntityType("LtiLink");
        public static readonly EntityType LtiResourceLinkRequest = new EntityType("LtiResourceLinkRequest");
        public static readonly EntityType LtiSession = new EntityType("LtiSession");
		public static readonly EntityType MediaLocation = new EntityType("MediaLocation");
		public static readonly EntityType MediaObject = new EntityType("MediaObject");
		public static readonly EntityType Membership = new EntityType("Membership");
		public static readonly EntityType Message = new EntityType("Message");
		public static readonly EntityType MultipleChoice = new EntityType("MultipleChoiceResponse");
		public static readonly EntityType MultipleResponse = new EntityType("MultipleResponseResponse");
		public static readonly EntityType Page = new EntityType("Page");
		public static readonly EntityType Person = new EntityType("Person");
		public static readonly EntityType Organization = new EntityType("Organization");
        public static readonly EntityType Query = new EntityType("Query");
        public static readonly EntityType Response = new EntityType("Response");
		public static readonly EntityType Result = new EntityType("Result");
		public static readonly EntityType Score = new EntityType("Score");
        public static readonly EntityType SearchResponse = new EntityType("SearchResponse");
        public static readonly EntityType Session = new EntityType("Session");
		public static readonly EntityType Share = new EntityType("SharedAnnotation");
		public static readonly EntityType SoftwareApplication = new EntityType("SoftwareApplication");
		public static readonly EntityType SelectText = new EntityType("SelectTextResponse");
		public static readonly EntityType Tag = new EntityType("TagAnnotation");
		public static readonly EntityType Thread = new EntityType("Thread");
		public static readonly EntityType TrueFalse = new EntityType("TrueFalseResponse");
		public static readonly EntityType VideoObject = new EntityType("VideoObject");
		public static readonly EntityType WebPage = new EntityType("WebPage");

        public EntityType() { }

		public EntityType(string value)
		{
			this.Value = value;
		}

		public string Value { get; set; }

	}

}