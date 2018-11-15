using System;
using ImsGlobal.Caliper.Util;
using NUnit.Framework;

namespace ImsGlobal.Caliper.Tests {
	using ImsGlobal.Caliper.Entities;
	using ImsGlobal.Caliper.Entities.Agent;
	using ImsGlobal.Caliper.Entities.Annotation;
	using ImsGlobal.Caliper.Entities.Assessment;
	using ImsGlobal.Caliper.Entities.Assignable;
	using ImsGlobal.Caliper.Entities.Collection;
	using ImsGlobal.Caliper.Entities.Forum;
	using ImsGlobal.Caliper.Entities.Lis;
	using ImsGlobal.Caliper.Entities.Media;
	using ImsGlobal.Caliper.Entities.Outcome;
	using ImsGlobal.Caliper.Entities.Reading;
	using ImsGlobal.Caliper.Entities.Response;
	using ImsGlobal.Caliper.Entities.Session;
	using ImsGlobal.Caliper.Events;
	using ImsGlobal.Caliper.Events.Annotation;
	using ImsGlobal.Caliper.Events.Assessment;
	using ImsGlobal.Caliper.Events.Assignable;
	using ImsGlobal.Caliper.Events.Forum;
	using ImsGlobal.Caliper.Events.Media;
	using ImsGlobal.Caliper.Events.Outcome;
	using ImsGlobal.Caliper.Events.Reading;
    using ImsGlobal.Caliper.Events.Search;
    using ImsGlobal.Caliper.Events.Session;
	using ImsGlobal.Caliper.Events.Tool;
	using ImsGlobal.Caliper.Tests.SimpleHelpers;
	using ImsGlobal.Caliper.Protocol;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using NodaTime;
	using static JsonSerializeUtils;
	using System.Collections;
	using NodaTime.Text;
    using ImsGlobal.Caliper.Entities.ToolLaunch;

    [TestFixture]
	public class Caliper11Tests {

		[OneTimeSetUp]
		public void Init() {
			FixtureCoverageChecker.Initialize();
		}

		[OneTimeTearDown]
		public void Dispose() {
			bool covered = FixtureCoverageChecker.Compare();
		}

		[Test]
		public void EntityAgent_MatchesReferenceJson() {
			var entity = new Agent("https://example.edu/agents/99999") {
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateModified = Caliper11TestEntities.Instant20160902113000
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityAgent");
		} 

		[Test]
		public void EntityAnnotation_MatchesReferenceJson() {
			var entity = new Annotation("https://example.com/users/554433/texts/imscaliperimplguide/annotations/1") {
				Annotator = Caliper11TestEntities.Person554433,
				Annotated = new Page("https://example.com/#/texts/imscaliperimplguide/cfi/6/10!/4/2/2/2@0:0"),
				DateCreated = Caliper11TestEntities.Instant20160801060000,
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityAnnotation");
		}

		[Test]
		public void EntityAssessment_MatchesReferenceJson() {

			string itemUrlBase = "https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/";

			var entity = new Assessment(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1") {
				Name = "Quiz One",
				Items = new[] {
					new AssessmentItem( itemUrlBase + "1" ),
					new AssessmentItem( itemUrlBase + "2" ),
					new AssessmentItem( itemUrlBase + "3" )
				},
				DateCreated = Instant.FromUtc(2016, 8, 1, 6, 0, 0),
				DateModified = Instant.FromUtc(2016, 9, 2, 11, 30, 0),
				DatePublished = Instant.FromUtc(2016, 8, 15, 9, 30, 0),
				DateToActivate = Instant.FromUtc(2016, 8, 16, 5, 0, 0),
				DateToShow = Instant.FromUtc(2016, 8, 16, 5, 0, 0),
				DateToStartOn = Instant.FromUtc(2016, 8, 16, 5, 0, 0),
				DateToSubmit = Instant.FromUtc(2016, 9, 28, 11, 59, 59),
				MaxAttempts = 2,
				MaxScore = 15.0, //TODO is set as int in spec
				MaxSubmits = 2,
				Version = "1.0"
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityAssessment");
		}

		[Test]
		public void EntityAssessmentItemExtended_MatchesReferenceJson() {

			var entity = new AssessmentItem(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3") {

				IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
				DateCreated = Instant.FromUtc(2016, 8, 1, 6, 0, 0),
				DatePublished = Instant.FromUtc(2016, 8, 15, 9, 30, 0),
				IsTimeDependent = false,
				MaxScore = 1.0,
				MaxSubmits = 2,
				Extensions = new ExtensionObject()
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityAssessmentItemExtended");
		}

		class ExtensionObject {
			[JsonProperty("questionType", Order = 91)]
			public string QuestionType = "Dichotomous";

			[JsonProperty("questionText", Order = 92)]
			public string QuestionText = "Is a Caliper SoftwareApplication a subtype of Caliper Agent?";

			[JsonProperty("correctResponse", Order = 93)]
			public string CorrectResponse = "yes";
		}

		[Test]
		public void EntityAssignableDigitalResource_MatchesReferenceJson() {

			var entity = new AssignableDigitalResource(
				"https://example.edu/terms/201601/courses/7/sections/1/assign/2") {

				Name = "Week 9 Reflection",
				Description = "3-5 page reflection on this week's assigned readings.",
				DateCreated = Instant.FromUtc(2016, 11, 1, 06, 0, 0),
				DateToActivate = Instant.FromUtc(2016, 11, 10, 11, 59, 59),
				DateToShow = Instant.FromUtc(2016, 11, 10, 11, 59, 59),
				DateToStartOn = Instant.FromUtc(2016, 11, 10, 11, 59, 59),
				DateToSubmit = Instant.FromUtc(2016, 11, 14, 11, 59, 59),
				MaxAttempts = 2,
				MaxSubmits = 2,
				MaxScore = 50.0
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityAssignableDigitalResource");
		}

		[Test]
		public void EntityAttempt_MatchesReferenceJson() {

			var entity = new Attempt(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {

				Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
				Assignee = new Person("https://example.edu/users/554433"),
				Count = 1,
				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 05, 00),
				StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 05, 00),
				EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 55, 30),
				Duration = Period.FromMinutes(50) + Period.FromSeconds(30)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityAttempt");
		}

		[Test]
		public void EntityAudioObject_MatchesReferenceJson() {

			var entity = new AudioObject(
				"https://example.edu/audio/765") {
				Name = "Audio Recording: IMS Caliper Sensor API Q&A.",
				MediaType = "audio/ogg",
				DatePublished = Instant.FromUtc(2016, 12, 01, 06, 00, 00),
				Duration = Period.FromMinutes(55) + Period.FromSeconds(13)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityAudioObject");
		}

		[Test]
		public void EntityBookmarkAnnotation_MatchesReferenceJson() {

			var entity = new BookmarkAnnotation(
				"https://example.com/users/554433/texts/imscaliperimplguide/bookmarks/1") {
				Annotator = new Person("https://example.edu/users/554433"),
				Annotated = new Page("https://example.com/#/texts/imscaliperimplguide/cfi/6/10!/4/2/2/2@0:0"),
				BookmarkNotes = "Caliper profiles model discrete learning activities or supporting activities that facilitate learning.",
				DateCreated = Instant.FromUtc(2016, 8, 1, 6, 0, 0)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityBookmarkAnnotation");
		}

		[Test]
		public void EntityChapter_MatchesReferenceJson() {

			var entity = new Chapter(
				"https://example.com/#/texts/imscaliperimplguide/cfi/6/10") {
				Name = "The Caliper Information Model",
				IsPartOf = new Document("https://example.com/#/texts/imscaliperimplguide") {
					DateCreated = Instant.FromUtc(2016, 10, 01, 6, 00, 00),
					Name = "IMS Caliper Implementation Guide",
					Version = "1.1"
				}
			};
			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityChapter");
		}


		[Test]
		public void EntityCourseOffering_MatchesReferenceJson() {

			var entity = new CourseOffering(
					"https://example.edu/terms/201601/courses/7") {
				CourseNumber = "CPS 435",
				AcademicSession = "Fall 2016",
				Name = "CPS 435 Learning Analytics",
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateModified = Instant.FromUtc(2016, 09, 02, 11, 30, 00)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityCourseOffering");
		}

		[Test]
		public void EntityCourseSection_MatchesReferenceJson() {

			var entity = new CourseSection(
					"https://example.edu/terms/201601/courses/7/sections/1") {
				AcademicSession = "Fall 2016",
				CourseNumber = "CPS 435-01",
				Name = "CPS 435 Learning Analytics, Section 01",
				Category = "seminar",
				SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7") {
					CourseNumber = "CPS 435"
				},
				DateCreated = Caliper11TestEntities.Instant20160801060000
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityCourseSection");
		}

		[Test]
		public void EntityDigitalResource_MatchesReferenceJson() {

			var entity = DigitalResourceSyllabusPDF;

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityDigitalResource");
		}


		public static DigitalResource DigitalResourceSyllabusPDF = new DigitalResource(
					"https://example.edu/terms/201601/courses/7/sections/1/resources/1/syllabus.pdf") {
			Name = "Course Syllabus",
			MediaType = "application/pdf",
			Creators = new[] { new Person("https://example.edu/users/223344") },
			IsPartOf = new DigitalResourceCollection(
					"https://example.edu/terms/201601/courses/7/sections/1/resources/1") {
				Name = "Course Assets",
				IsPartOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1")
			},
			DateCreated = Instant.FromUtc(2016, 08, 02, 11, 32, 00)
		};

		[Test]
		public void EntityDigitalResourceCollection_MatchesReferenceJson() {

			var entity = new DigitalResourceCollection(
					"https://example.edu/terms/201601/courses/7/sections/1/resources/2") {
				Name = "Video Collection",
				Keywords = new[] { "collection", "videos" },
				Items = new[] {
					new VideoObject("https://example.edu/videos/1225"){
						MediaType = "video/ogg",
						Name = "Introduction to IMS Caliper",
						DateCreated = Instant.FromUtc(2016,08,01,06,00,00),
						Duration = Period.FromHours(1) + Period.FromMinutes(12) + Period.FromSeconds(27),
						Version = "1.1"
					},
					new VideoObject("https://example.edu/videos/5629"){
						MediaType = "video/ogg",
						Name = "IMS Caliper Activity Profiles",
						DateCreated = Instant.FromUtc(2016,08,01,06,00,00),
						Duration = Period.FromMinutes(55) + Period.FromSeconds(13),
						Version = "1.1.1"
					}
				},
				IsPartOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1") {
					SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7")
				},
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateModified = Instant.FromUtc(2016, 09, 02, 11, 30, 00)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityDigitalResourceCollection");
		}

		[Test]
		public void EntityDocument_MatchesReferenceJson() {

			var entity = new Document(
					"https://example.edu/etexts/201.epub") {
				Name = "IMS Caliper Implementation Guide",
				MediaType = "application/epub+zip",
				Creators = new[] {
					new Person("https://example.edu/people/12345"),
					new Person("https://example.com/staff/56789")
				},
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DatePublished = Instant.FromUtc(2016, 10, 01, 06, 00, 00),
				Version = "1.1"
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityDocument");
		}


		[Test]
		public void EntityFillInBlankResponse_MatchesReferenceJson() {

			var entity = new FillInBlankResponse(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/1/users/554433/responses/1") {
				Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/1/users/554433/attempts/1") {
					Assignee = new Person("https://example.edu/users/554433"),
					Assignable = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/1") {
						IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1")
					},
					Count = 1,
					StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 02),
					EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 12)
				},

				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 15, 12),
				StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 02),
				EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 12),
				Values = new[] { "data interoperability", "semantic interoperability" }
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityFillinBlankResponse");
		}


		[Test]
		public void EntityForum_MatchesReferenceJson() {

			var entity = new Forum(
				"https://example.edu/terms/201601/courses/7/sections/1/forums/1") {
				Name = "Caliper Forum",
				Items = new[] {
					new Thread("https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/1"){
						Name = "Caliper Information Model",
						DateCreated = Instant.FromUtc(2016,11,01,09,30,00)
					},
					new Thread("https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/2"){
						Name = "Caliper Sensor API",
						DateCreated = Instant.FromUtc(2016,11,01,09,30,00)
					},
					new Thread("https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/3"){
						Name = "Caliper Certification",
						DateCreated = Instant.FromUtc(2016,11,01,09,30,00)
					}
				},
				IsPartOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1") {
					SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7")
				},

				DateCreated = Instant.FromUtc(2016, 08, 01, 6, 0, 0),
				DateModified = Instant.FromUtc(2016, 09, 02, 11, 30, 0)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityForum");
		}

		[Test]
		public void EntityGroup_MatchesReferenceJson() {
			var entity = new Group("https://example.edu/terms/201601/courses/7/sections/1/groups/2") {
				Name = "Discussion Group 2",
				SubOrganizationOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1") {
					SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7")
				},
				Members = new[] {
					new Person("https://example.edu/users/554433"),
					new Person("https://example.edu/users/778899"),
					new Person("https://example.edu/users/445566"),
					new Person("https://example.edu/users/667788"),
					new Person("https://example.edu/users/889900")
				},
				DateCreated = Caliper11TestEntities.Instant20161101060000,
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityGroup");
		}

		[Test]
		public void EntityFrame_MatchesReferenceJson() {

			var entity = new Frame(
				"https://example.edu/etexts/201?index=2502") {
				DateCreated = Instant.FromUtc(2016, 08, 01, 6, 0, 0),
				Index = 2502,
				IsPartOf = new Document("https://example.edu/etexts/201") {
					Name = "IMS Caliper Implementation Guide",
					Version = "1.1"
				}
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityFrame");
		}


		[Test]
		public void EntityHighlightAnnotation_MatchesReferenceJson() {

			var entity = new HighlightAnnotation(
				"https://example.edu/users/554433/etexts/201/highlights/20") {
				Annotator = Caliper11TestEntities.Person554433,
				Annotated = new Document("https://example.edu/etexts/201"),
				Selection = new TextPositionSelector() {
					Start = 2300,
					End = 2370
				},
				SelectionText = "ISO 8601 formatted date and time expressed with millisecond precision.",
				DateCreated = Caliper11TestEntities.Instant20160801060000
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityHighlightAnnotation");
		}



		[Test]
		public void EntityImageObject_MatchesReferenceJson() {

			var entity = new ImageObject(
				"https://example.edu/images/caliper_lti.jpg") {
				Name = "IMS Caliper/LTI Integration Work Flow",
				MediaType = "image/jpeg",
				DateCreated = Instant.FromUtc(2016, 09, 01, 6, 0, 0)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityImageObject");
		}


		[Test]
		public void EntityLearningObjective_MatchesReferenceJson() {

			var entity = new AssignableDigitalResource(
				"https://example.edu/terms/201601/courses/7/sections/1/assign/2") {
				Name = "Caliper Profile Design",
				Description = "Choose a learning activity and describe the actions, entities and events that comprise it.",
				LearningObjectives = new[] {
					new LearningObjective("https://example.edu/terms/201601/courses/7/sections/1/objectives/1") {
						Name = "Research techniques",
						Description = "Demonstrate ability to model a learning activity as a Caliper profile.",
						DateCreated = Instant.FromUtc(2016,08,01,06,00,00)
					}
				},

				DateToActivate = Instant.FromUtc(2016, 11, 10, 11, 59, 59),
				DateToShow = Instant.FromUtc(2016, 11, 10, 11, 59, 59),
				DateCreated = Instant.FromUtc(2016, 11, 01, 06, 00, 00),
				DateToStartOn = Instant.FromUtc(2016, 11, 15, 11, 59, 59),
				DateToSubmit = Instant.FromUtc(2016, 11, 14, 11, 59, 59),
				MaxAttempts = 2,
				MaxSubmits = 2,
				MaxScore = 50.0
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityLearningObjective");
		}

		[Test]
		public void EntityLtiSession_MatchesReferenceJson() {

            var entity = new LtiSession(
                "https://example.edu/lti/sessions/b533eb02823f31024e6b7f53436c42fb99b31241") {
                Context = CaliperContext.ToolLaunchProfileExtension.Value,
                User = new Person("https://example.edu/users/554433") { HideCaliperContext = true },
                MessageParameters = new Caliper11TestEntities.LtiParamsLtiSession(),
                DateCreated = Instant.FromUtc(2018, 11, 15, 10, 15, 00),
                StartedAt = Instant.FromUtc(2018, 11, 15, 10, 15, 00)

            };

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityLtiSession");
		}


		[Test]
		public void EntityMediaObject_MatchesReferenceJson() {

			var entity = new MediaObject(
				"https://example.edu/media/54321") {
				DateCreated = Instant.FromUtc(2016, 08, 1, 6, 0, 0),
				DateModified = Instant.FromUtc(2016, 09, 2, 11, 30, 0),
				Duration = Period.FromHours(1) + Period.FromMinutes(17) + Period.FromSeconds(50)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityMediaObject");
		}


		[Test]
		public void EntityMediaLocation_MatchesReferenceJson() {

			var entity = new MediaLocation(
				"https://example.edu/videos/1225") {
				CurrentTime = Period.FromMinutes(30) + Period.FromSeconds(54),
				DateCreated = Instant.FromUtc(2016, 08, 1, 6, 0, 0)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityMediaLocation");
		}

		[Test]
		public void EntityMembership_MatchesReferenceJson() {

			var entity = new Membership(
				"https://example.edu/terms/201601/courses/7/sections/1/rosters/1/members/554433") {
				Member = new Person("https://example.edu/users/554433"),
				Organization = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1") {
					SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7")
				},
				Roles = new[] { Role.Learner },
				Status = Status.Active,
				DateCreated = Instant.FromUtc(2016, 11, 1, 6, 0, 0)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityMembership");
		}


		[Test]
		public void EntityMessage_MatchesReferenceJson() {

			var entity = new Message(
				"https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1/messages/3") {
				Creators = new[] { new Person("https://example.edu/users/778899") },
				Body = "The Caliper working group provides a set of Caliper Sensor reference implementations for"
					+ " the purposes of education and experimentation.  They have not been tested for use in a "
					+ "production environment.  See the Caliper Implementation Guide for more details.",
				ReplyTo = new Message("https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1/messages/2"),
				IsPartOf = new Thread("https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1") {
					IsPartOf = new Forum("https://example.edu/terms/201601/courses/7/sections/1/forums/2")
				},
				Attachments = new[] { new Document("https://example.edu/etexts/201.epub") {
						Name = "IMS Caliper Implementation Guide",
						DateCreated = Instant.FromUtc(2016,10,01,06,00,00),
						  Version = "1.1"
					}
				},
				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 15, 30)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityMessage");

		}

		[Test]
		public void EntityMultipleChoiceResponse_MatchesReferenceJson() {

			var entity = new MultipleChoiceResponse(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/2/users/554433/responses/1") {

				Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/2/users/554433/attempts/1") {
					Assignee = new Person("https://example.edu/users/554433"),
					Assignable = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/2") {
						IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1")
					},
					Count = 1,
					StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 14),
					EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 20)

				},
				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 15, 20),
				StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 14),
				EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 20),
				Value = "C"
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityMultipleChoiceResponse");
		}

		[Test]
		public void EntityMultipleResponseResponse_MatchesReferenceJson() {

			var entity = new MultipleResponseResponse(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/responses/1") {


				Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/attempts/1") {
					Assignee = new Person("https://example.edu/users/554433"),
					Assignable = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3") {
						IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1")
					},
					Count = 1,
					StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 22),
					EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 30)

				},
				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 15, 22),
				StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 22),
				EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 30),
				Values = new[] { "A", "D", "E" }
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityMultipleResponseResponse");
		}

		[Test]
		public void EntityOrganization_MatchesReferenceJson() {

			var entity = new Organization(
							"https://example.edu/colleges/1/depts/1") {
				Name = "Computer Science Department",
				SubOrganizationOf = new Organization("https://example.edu/colleges/1") {
					Name = "College of Engineering"
				}
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityOrganization");
		}


		[Test]
		public void EntityPage_MatchesReferenceJson() {

			var entity = new Page(
				"https://example.com/#/texts/imscaliperimplguide/cfi/6/10!/4/2/2/2@0:0") {
				Name = "Page 5",
				IsPartOf = new Chapter("https://example.com/#/texts/imscaliperimplguide/cfi/6/10") {
					Name = "Chapter 1",
					IsPartOf = new Document("https://example.com/#/texts/imscaliperimplguide") {
						Name = "IMS Caliper Implementation Guide",
						DateCreated = Instant.FromUtc(2016, 10, 01, 06, 00, 00),
						Version = "1.1"

					}
				}
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityPage");
		}


		[Test]
		public void EntityPerson_MatchesReferenceJson() {

			var entity = new Person(
				"https://example.edu/users/554433") {
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateModified = Instant.FromUtc(2016, 09, 02, 11, 30, 00)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityPerson");
		}

		[Test]
		public void EntityResponseExtended_MatchesReferenceJson() {
			var entity = new Response(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/6/users/554433/responses/1") {
				Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/6/users/554433/attempts/1") {
					Assignee = Caliper11TestEntities.Person554433,
					Assignable = Caliper11TestEntities.AssessmentItem6,
					Count = 1,
					StartedAtTime = Caliper11TestEntities.Instant20161115101546,
					EndedAtTime = Caliper11TestEntities.Instant20161115101720,
				},
				DateCreated = Caliper11TestEntities.Instant20161115101546,
				StartedAtTime = Caliper11TestEntities.Instant20161115101546,
				EndedAtTime = Caliper11TestEntities.Instant20161115101720,
				Extensions = new { value = "A Caliper Event describes a relationship established between an actor and an object.  The relationship is formed as a result of a purposeful action undertaken by the actor in connection to the object at a particular moment. A learner starting an assessment, annotating a reading, pausing a video, or posting a message to a forum, are examples of learning activities that Caliper models as events." }
			};

			var coerced = JsonAssertions.coerce(entity,
				new string[] { "..attempt.assignee" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEntityResponseExtended");
		}


		[Test]
		public void EntityResult_MatchesReferenceJson() {

			var entity = new Result(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1/results/1") {
				Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
					Assignee = new Person("https://example.edu/users/554433"),
					Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
					Count = 1,
					DateCreated = Instant.FromUtc(2016, 11, 15, 10, 05, 00),
					StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 05, 00),
					EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 55, 30),
					Duration = Period.FromMinutes(50) + Period.FromSeconds(30)

				},
				Comment = "Consider retaking the assessment.",
				MaxResultScore = 15.0,
				ResultScore = 10.0,
				ScoredBy = new SoftwareApplication("https://example.edu/autograder") {
					DateCreated = Instant.FromUtc(2016, 11, 15, 10, 55, 58)
				},
				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 56, 00)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityResult");
		}

		[Test]
		public void EntityScore_MatchesReferenceJson() {
			var entity = new Score("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1/scores/1") {
				Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
					Assignee = Caliper11TestEntities.Person554433,
					Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
					Count = 1,
					DateCreated = Instant.FromUtc(2016, 11, 15, 10, 05, 00),
					StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 05, 00),
					EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 55, 30),
					Duration = Period.FromMinutes(50) + Period.FromSeconds(30)
				},
				MaxScore = 15.0,
				ScoreGiven = 10.0,
				ScoredBy = new SoftwareApplication("https://example.edu/autograder") {
					DateCreated = Instant.FromUtc(2016, 11, 15, 10, 55, 58),
				},
				Comment = "auto-graded exam",
				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 56, 00),
			};

			var coerced = JsonAssertions.coerce(entity,
				new string[] { "..attempt.assignee", "..attempt.assignable" });


			JsonAssertions.AssertSameObjectJson(coerced, "caliperEntityScore");
		}


		[Test]
		public void EntitySelectTextResponse_MatchesReferenceJson() {

			var entity = new SelectTextResponse(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/4/users/554433/responses/1") {
				Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/4/users/554433/attempts/1") {
					Assignee = new Person("https://example.edu/users/554433"),
					Assignable = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/4") {
						IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1")
					},
					Count = 1,
					StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 32),
					EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 38)
				},

				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 15, 32),
				StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 32),
				EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 38),
				Values = new[] { "Information Model", "Sensor API", "Profiles" }
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntitySelectTextResponse");
		}


		[Test]
		public void EntitySession_MatchesReferenceJson() {

			var entity = new Session(
				"https://example.edu/sessions/1f6442a482de72ea6ad134943812bff564a76259") {
				User = new Person("https://example.edu/users/554433"),
				StartedAt = Instant.FromUtc(2016, 9, 15, 10, 00, 00)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntitySession");
		}

		[Test]
		public void EntitySharedAnnotation_MatchesReferenceJson() {

			var entity = new ShareAnnotation(
				"https://example.edu/users/554433/etexts/201/shares/1") {
				Annotator = new Person("https://example.edu/users/554433"),
				Annotated = new Document("https://example.edu/etexts/201.epub"),
				WithAgents = new[] {
					new Person("https://example.edu/users/657585"),
					new Person("https://example.edu/users/667788")
				},
				DateCreated = Instant.FromUtc(2016, 08, 01, 9, 00, 00)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntitySharedAnnotation");
		}

		[Test]
		public void EntitySoftwareApplication_MatchesReferenceJson() {

			var entity = new SoftwareApplication(
				"https://example.edu/autograder") {
				Name = "Auto Grader",
				Description = "Automates assignment scoring.",
				Version = "2.5.2"
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntitySoftwareApplication");
		}

		[Test]
		public void EntityTagAnnotation_MatchesReferenceJson() {

			var entity = new TagAnnotation(
				"https://example.com/users/554433/texts/imscaliperimplguide/tags/3") {
				Annotator = new Person("https://example.edu/users/554433"),
				Annotated = new Page("https://example.com/#/texts/imscaliperimplguide/cfi/6/10!/4/2/2/2@0:0"),
				Tags = new[] { "profile", "event", "entity" },
				DateCreated = Instant.FromUtc(2016, 08, 01, 9, 0, 0)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityTagAnnotation");
		}

		[Test]
		public void EntityThread_MatchesReferenceJson() {

			var msg1 = new Message(
				"https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/1/messages/1");
			var msg2 = new Message(
				"https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/1/messages/2") { ReplyTo = msg1 };
			var msg3 = new Message(
				"https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/1/messages/3") {
				ReplyTo = new Message("https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/1/messages/2")
			};

			var entity = new Thread(
				"https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/1") {
				Name = "Caliper Information Model",
				Items = new[] { msg1, msg2, msg3 },
				IsPartOf = new Forum("https://example.edu/terms/201601/courses/7/sections/1/forums/1") {
					Name = "Caliper Forum",
					IsPartOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1") {
						SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7")
					}
				},
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateModified = Instant.FromUtc(2016, 09, 02, 11, 30, 00)
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityThread");
		}

		[Test]
		public void EntityTrueFalseResponse_MatchesReferenceJson() {

			var entity = new TrueFalseResponse(
				"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/5/users/554433/responses/1") {
				Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/5/users/554433/attempts/1") {
					Assignee = new Person("https://example.edu/users/554433"),
					Assignable = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/5") {
						IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1")
					},
					Count = 1,
					StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 40),
					EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 45)
				},
				DateCreated = Instant.FromUtc(2016, 11, 15, 10, 15, 45),
				StartedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 40),
				EndedAtTime = Instant.FromUtc(2016, 11, 15, 10, 15, 45),
				Value = "true"

			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityTrueFalseResponse");
		}


		[Test]
		public void EntityVideoObject_MatchesReferenceJson() {

			var entity = new VideoObject(
				"https://example.edu/videos/1225") {
				MediaType = "video/ogg",
				Name = "Introduction to IMS Caliper",
				Version = "1.1",
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateModified = Instant.FromUtc(2016, 09, 02, 11, 30, 00),
				Duration = Period.FromHours(1) + Period.FromMinutes(12) + Period.FromSeconds(27)

			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityVideoObject");
		}

		[Test]
		public void EntityWebPage_MatchesReferenceJson() {

			var entity = new WebPage(
				"https://example.edu/terms/201601/courses/7/sections/1/pages/index.html") {
				Name = "CPS 435-01 Landing Page",
				MediaType = "text/html",
				IsPartOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1") {
					CourseNumber = "CPS 435-01",
					AcademicSession = "Fall 2016"
				}
			};

			JsonAssertions.AssertSameObjectJson(entity, "caliperEntityWebPage");
		}

		[Test]
		public void EnvelopeEntityBatch_MatchesReferenceJson() {

			var Person554433 = Caliper11TestEntities.Person554433dates;

			var Epub201 = new Document("https://example.edu/etexts/201.epub") {
				Name = "IMS Caliper Implementation Guide",
				Creators = new[] { new Person("https://example.edu/people/12345"),
					new Person("https://example.com/staff/56789") },
				DateCreated = Caliper11TestEntities.Instant20161001060000,
				Version = "1.1"
			};

			var VideoCollection = new DigitalResourceCollection(
				"https://example.edu/terms/201601/courses/7/sections/1/resources/2") {
				Name = "Video Collection",
				IsPartOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1") {
					SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7")
				},
				Items = new[] { Caliper11TestEntities.VideoObject_1, Caliper11TestEntities.VideoObject_2 },
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateModified = Caliper11TestEntities.Instant20160902113000
			};

			var envelope = new CaliperMessage<JObject> {
				SensorId = Caliper11TestEntities.EnvelopeDefaultSensorId,
				SendTime = Caliper11TestEntities.EnvelopeDefaultSendTime,
				Data = new[] {
					clean(toJobject(Person554433)),
					clean(toJobject(Epub201)),
					clean(toJobject(VideoCollection))
				}
			};

			JsonAssertions.AssertSameObjectJson(envelope, "caliperEnvelopeEntityBatch", false);
		}

		[Test]
		public void EnvelopeEntitySingle_MatchesReferenceJson() {

			var envelope = new CaliperMessage<Entity> {
				SensorId = Caliper11TestEntities.EnvelopeDefaultSensorId,
				SendTime = Caliper11TestEntities.EnvelopeDefaultSendTime,
				Data = new[] { Caliper11TestEntities.DigitalResourceSyllabusPDF }
			};

			JsonAssertions.AssertSameObjectJson(envelope, "caliperEnvelopeEntitySingle");
		}


		[Test]
		public void EnvelopeEventBatch_MatchesReferenceJson() {

			var NavigationEvent = new NavigationEvent(
				"urn:uuid:72f66ce5-d2ec-44cc-bce5-41602e1015dc") {
				Actor = Caliper11TestEntities.Person554433,
				Object = new WebPage("https://example.edu/terms/201601/courses/7/sections/1/pages/2") {
					Name = "Learning Analytics Specifications",
					Description = "Overview of Learning Analytics Specifications with particular emphasis on IMS Caliper.",
					DateCreated = Caliper11TestEntities.Instant20160801090000
				},
				EventTime = Caliper11TestEntities.Instant20161115101500,
				Referrer = new WebPage("https://example.edu/terms/201601/courses/7/sections/1/pages/1"),
				EdApp = Caliper11TestEntities.EpubReader123,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259
			};

			var BookmarkAnnotation = new BookmarkAnnotation(
				"https://example.com/users/554433/texts/imscaliperimplguide/bookmarks/1") {
				Annotator = Caliper11TestEntities.Person554433,
				Annotated = new Page("https://example.com/#/texts/imscaliperimplguide/cfi/6/10!/4/2/2/2@0:0"),
				BookmarkNotes = "Caliper profiles model discrete learning activities or supporting activities that facilitate learning.",
				DateCreated = Caliper11TestEntities.Instant20161115102000

			};

			var AnnotationEvent = new AnnotationEvent(
				"urn:uuid:c0afa013-64df-453f-b0a6-50f3efbe4cc0", BookmarkAnnotation) {
				Actor = Caliper11TestEntities.Person554433,
				Object = new Document("https://example.com/#/texts/imscaliperimplguide") {
					Name = "IMS Caliper Implementation Guide",
					Version = "1.1"
				},
				EventTime = Caliper11TestEntities.Instant20161115102000,
				EdApp = Caliper11TestEntities.EpubReader123,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259

			};

			var ViewEvent = new ViewEvent(
							"urn:uuid:94bad4bd-a7b1-4c3e-ade4-2253efe65172") {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.Epub201,
				EventTime = Caliper11TestEntities.Instant20161115102100,
				EdApp = Caliper11TestEntities.EpubReader123,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259
			};

			var envelope = new CaliperMessage<JObject> {
				SensorId = Caliper11TestEntities.EnvelopeDefaultSensorId,
				SendTime = Caliper11TestEntities.EnvelopeDefaultSendTime,
				Data = new[] {
					clean(toJobject(NavigationEvent)),
					clean(toJobject(AnnotationEvent)),
					clean(toJobject(ViewEvent))
				}
			};

			var coerced = JsonAssertions.coerce(envelope,
				new string[] { "..membership.member", "..membership.organization",
					"..generated.annotator", "..generated.annotated" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEnvelopeEventBatch", false);
		}


		[Test]
		public void EnvelopeEventSingle_MatchesReferenceJson() {

			var envelope = new CaliperMessage<Event> {
				SensorId = "https://example.edu/sensors/1",
				SendTime = Caliper11TestEntities.EnvelopeDefaultSendTime,
				Data = new[] { new AssessmentEvent(
					"urn:uuid:c51570e4-f8ed-4c18-bb3a-dfe51b2cc594", Action.Started) {
						Actor = Caliper11TestEntities.Person554433,
						Object = Caliper11TestEntities.AssessmentQuizOne,
						Generated = Caliper11TestEntities.Attempt1c,
						EventTime = Caliper11TestEntities.Instant20161115101500,
						EdApp = Caliper11TestEntities.SoftwareAppV2,
						Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
						Membership = Caliper11TestEntities.EntityMembership554433Learner,
						Session = Caliper11TestEntities.Session6259edu
					}
				}
			};

			var coerced = JsonAssertions.coerce(envelope,
				new string[] { "..membership.member", "..membership.organization",
							"..generated.assignee", "..generated.assignable" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEnvelopeEventSingle");
		}


		[Test]
		public void EnvelopeMixedBatch_MatchesReferenceJson() {

			var Assessment = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1?ver=v1p0") {
				Name = "Quiz One",
				Items = new[] {
					new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/1"),
					new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/2"),
					new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3")
				},
				DateCreated = Caliper11TestEntities.Instant20160801060000,
				DateToStartOn = Caliper11TestEntities.Instant20160816050000,
				DateToSubmit = Caliper11TestEntities.Instant20160928115959,
				DateModified = Caliper11TestEntities.Instant20160902113000,
				DatePublished = Caliper11TestEntities.Instant20160815093000,
				DateToActivate = Caliper11TestEntities.Instant20160816050000,
				DateToShow = Caliper11TestEntities.Instant20160816050000,
				MaxAttempts = 2,
				MaxSubmits = 2,
				MaxScore = 15.0,
				Version = "1.0"
			};

			var CourseSection = new CourseSection
				("https://example.edu/terms/201601/courses/7/sections/1") {
				CourseNumber = "CPS 435-01",
				AcademicSession = "Fall 2016",
				Name = "CPS 435 Learning Analytics, Section 01",
				Category = "seminar",
				SubOrganizationOf = new CourseOffering("https://example.edu/terms/201601/courses/7") {
					CourseNumber = "CPS 435"
				},
				DateCreated = Caliper11TestEntities.Instant20160801060000
			};

			var AssessmentEventStarted = new AssessmentEvent(
				"urn:uuid:c51570e4-f8ed-4c18-bb3a-dfe51b2cc594", Action.Started) {
				Actor = Caliper11TestEntities.Person554433,
				Object = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1?ver=v1p0"),
				Generated = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
					Assignee = Caliper11TestEntities.Person554433,
					Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1?ver=v1p0"),
					Count = 1,
					DateCreated = Caliper11TestEntities.Instant20161115101500,
					StartedAtTime = Caliper11TestEntities.Instant20161115101500
				},
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var AssessmentEventSubmitted = new AssessmentEvent(
				"urn:uuid:dad88464-0c20-4a19-a1ba-ddf2f9c3ff33", Action.Submitted) {
				Actor = Caliper11TestEntities.Person554433,
				Object = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1?ver=v1p0"),
				Generated = new Attempt(
					"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
					Assignee = Caliper11TestEntities.Person554433,
					Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1?ver=v1p0"),
					Count = 1,
					DateCreated = Caliper11TestEntities.Instant20161115101500,
					StartedAtTime = Caliper11TestEntities.Instant20161115101500,
					EndedAtTime = Caliper11TestEntities.Instant20161115105512,
					Duration = Period.FromMinutes(40) + Period.FromSeconds(12)
				},

				EventTime = Caliper11TestEntities.Instant20161115102530,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var GradeEvent = new GradeEvent(
						"urn:uuid:a50ca17f-5971-47bb-8fca-4e6e6879001d", Action.Graded) {
				Actor = Caliper11TestEntities.AutoGraderV2,
				Object = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
					Assignee = Caliper11TestEntities.Person554433,
					Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1?ver=v1p0"),
					Count = 1,
					DateCreated = Caliper11TestEntities.Instant20161115101500,
					StartedAtTime = Caliper11TestEntities.Instant20161115101500,
					EndedAtTime = Caliper11TestEntities.Instant20161115105512,
					Duration = Period.FromMinutes(40) + Period.FromSeconds(12)
				},
				Generated = Caliper11TestEntities.Score1,
				EventTime = Caliper11TestEntities.Instant20161115105706,
				EdApp = new SoftwareApplication("https://example.edu"),
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16
			};

			var envelope = new CaliperMessage<JObject> {
				SensorId = Caliper11TestEntities.EnvelopeDefaultSensorId,
				SendTime = Caliper11TestEntities.EnvelopeDefaultSendTime,
				Data = new[] {
					clean(toJobject(Caliper11TestEntities.Person554433dates)),
					clean(toJobject(Assessment)),
					clean(toJobject(Caliper11TestEntities.SoftwareAppV2)),
					clean(toJobject(CourseSection)),
					clean(toJobject(AssessmentEventStarted)),
					clean(toJobject(AssessmentEventSubmitted)),
					clean(toJobject(GradeEvent))
				}
			};

			var coerced = JsonAssertions.coerce(envelope,
				new string[] { "..generated.assignable", "..generated.assignee",
				"..membership.member", "..membership.organization",
				"..edApp", "..group", "..object.assignable", "..object.assignee",
				"..generated.attempt", "..generated.scoredBy", "$.data[:6].actor",
					"$.data[:5].object" , "$.data[:6].object"});

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEnvelopeMixedBatch", false);
		}

		[Test]
		public void EventAnnotationBookmarked_MatchesReferenceJson() {

			var page = new Page("https://example.com/#/texts/imscaliperimplguide/cfi/6/10!/4/2/2/2@0:0") {
				Name = "IMS Caliper Implementation Guide, pg 5",
				Version = "1.1"
			};

			var annotation = new BookmarkAnnotation(
				"https://example.com/users/554433/texts/imscaliperimplguide/bookmarks/1") {
				Annotator = Caliper11TestEntities.Person554433,
				Annotated = page,
				BookmarkNotes = "Caliper profiles model discrete learning activities or supporting activities"
				+ " that facilitate learning.",
				DateCreated = Caliper11TestEntities.Instant20161115101500
			};

			var bookmarkEvent = new AnnotationEvent("urn:uuid:d4618c23-d612-4709-8d9a-478d87808067", annotation) {
				Actor = Caliper11TestEntities.Person554433,
				Object = page,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.EpubReader123,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259
			};

			var coerced = JsonAssertions.coerce(bookmarkEvent,
				new string[] { "..generated.annotator", "..generated.annotated",
								"..membership.organization", "..membership.member" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAnnotationBookmarked");
		}

		[Test]
		public void EventAnnotationHighlighted_MatchesReferenceJson() {

			var doc = new Document("https://example.com/#/texts/imscaliperimplguide") {
				Name = "IMS Caliper Implementation Guide",
				DateCreated = Caliper11TestEntities.Instant20161001060000,
				Version = "1.1"
			};

			var annotation = new HighlightAnnotation(
				"https://example.com/users/554433/texts/imscaliperimplguide/highlights?start=2300&end=2370") {
				Annotator = Caliper11TestEntities.Person554433,
				Annotated = doc,
				Selection = new TextPositionSelector {
					Start = 2300,
					End = 2370
				},
				SelectionText = "ISO 8601 formatted date and time expressed with millisecond precision.",
				DateCreated = Caliper11TestEntities.Instant20161115101500
			};

			var highlightEvent = new AnnotationEvent("urn:uuid:0067a052-9bb4-4b49-9d1a-87cd43da488a", annotation) {
				Actor = Caliper11TestEntities.Person554433,
				Object = doc,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.EpubReader123,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259
			};

			var coerced = JsonAssertions.coerce(highlightEvent,
				new string[] { "..generated.annotator", "..generated.annotated",
								"..membership.organization", "..membership.member" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAnnotationHighlighted");
		}

		[Test]
		public void EventAnnotationShared_MatchesReferenceJson() {
			var doc = new Document("https://example.com/#/texts/imscaliperimplguide") {
				Name = "IMS Caliper Implementation Guide",
				Version = "1.1"
			};

			var annotation = new ShareAnnotation(
				"https://example.com/users/554433/texts/imscaliperimplguide/shares/1") {
				Annotator = Caliper11TestEntities.Person554433,
				Annotated = doc,
				WithAgents = new[] {
					new Person( "https://example.edu/users/657585" ) {
					},
					new Person( "https://example.edu/users/667788" ) {
					}
				},
				DateCreated = Caliper11TestEntities.Instant20161115101500
			};

			var shareEvent = new AnnotationEvent("urn:uuid:3bdab9e6-11cd-4a0f-9d09-8e363994176b", annotation) {
				Actor = Caliper11TestEntities.Person554433,
				Object = doc,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.EpubReader123,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259
			};

			var coerced = JsonAssertions.coerce(shareEvent,
				new string[] { "..generated.annotator", "..generated.annotated",
								"..membership.organization", "..membership.member" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAnnotationShared");
		}

		[Test]
		public void EventAnnotationTagged_MatchesReferenceJson() {
			var doc = new Page("https://example.com/#/texts/imscaliperimplguide/cfi/6/10!/4/2/2/2@0:0") {
				Name = "IMS Caliper Implementation Guide, pg 5",
				Version = "1.1"
			};

			var annotation = new TagAnnotation(
				"https://example.com/users/554433/texts/imscaliperimplguide/tags/3") {
				Annotator = Caliper11TestEntities.Person554433,
				Annotated = doc,
				Tags = new[] { "profile", "event", "entity" },
				DateCreated = Caliper11TestEntities.Instant20161115101500
			};

			var tagEvent = new AnnotationEvent("urn:uuid:b2009c63-2659-4cd2-b71e-6e03c498f02b", annotation) {
				Actor = Caliper11TestEntities.Person554433,
				Object = doc,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.EpubReader123,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259
			};

			var coerced = JsonAssertions.coerce(tagEvent,
				new string[] { "..generated.annotator", "..generated.annotated",
								"..membership.organization", "..membership.member" });
			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAnnotationTagged");
		}

		[Test]
		public void EventAssessmentItemCompleted_MatchesReferenceJson() {

			var assessmentItemEvent = new AssessmentItemEvent(
				"urn:uuid:e5891791-3d27-4df1-a272-091806a43dfb", Action.Completed) {
				Actor = Caliper11TestEntities.Person554433,
				Object = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3") {
					Name = "Assessment Item 3",
					IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
					DateToStartOn = Caliper11TestEntities.Instant20161114050000,
					DateToSubmit = Caliper11TestEntities.Instant20161118115959,
					MaxAttempts = 2,
					MaxSubmits = 2,
					MaxScore = 1.0,
					IsTimeDependent = false,
					Version = "1.0"

				},
				Generated = new FillInBlankResponse(
					"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/responses/1") {
					Attempt = Caliper11TestEntities.Attempt1,
					DateCreated = Caliper11TestEntities.Instant20161115101512,
					StartedAtTime = Caliper11TestEntities.Instant20161115101502,
					EndedAtTime = Caliper11TestEntities.Instant20161115101512,
					Values = new[] { "subject", "object", "predicate" }
				},

				EventTime = Caliper11TestEntities.Instant20161115101512,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(assessmentItemEvent,
				new string[] { "..attempt.assignee", "..attempt.isPartOf", "..membership.member", "..membership.organization" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAssessmentItemCompleted");
		}

		[Test]
		public void EventAssessmentItemSkipped_MatchesReferenceJson() {

			var assessmentItemEvent = new AssessmentItemEvent(
				"urn:uuid:04e27704-73bf-4d3c-912c-1b2da40aef8f", Action.Skipped) {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.AssessmentItem2,
				EventTime = Caliper11TestEntities.Instant20161115101430,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(assessmentItemEvent,
				new string[] { "..membership.member", "..membership.organization" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAssessmentItemSkipped");
		}

		[Test]
		public void EventAssessmentItemStarted_MatchesReferenceJson() {

			var assessmentItemEvent = new AssessmentItemEvent(
				"urn:uuid:1b557176-ba67-4624-b060-6bee670a3d8e", Action.Started) {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.AssessmentItem3b,
				Generated = Caliper11TestEntities.Attempt1b,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(assessmentItemEvent,
				new string[] { "..membership.member", "..membership.organization",
							"..generated.assignee", "..generated.assignable" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAssessmentItemStarted");
		}

		[Test]
		public void EventAssessmentStarted_MatchesReferenceJson() {

			var assessmentEvent = new AssessmentEvent(
				"urn:uuid:27734504-068d-4596-861c-2315be33a2a2", Action.Started) {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.AssessmentQuizOne,
				Generated = Caliper11TestEntities.Attempt1c,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};


			var coerced = JsonAssertions.coerce(assessmentEvent,
				new string[] { "..membership.member", "..membership.organization",
							"..generated.assignee", "..generated.assignable" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAssessmentStarted");
		}

		[Test]
		public void EventAssessmentSubmitted_MatchesReferenceJson() {

			var assessmentEvent = new AssessmentEvent(
				"urn:uuid:dad88464-0c20-4a19-a1ba-ddf2f9c3ff33", Action.Submitted) {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.AssessmentQuizOne,
				Generated = Caliper11TestEntities.Attempt2,
				EventTime = Caliper11TestEntities.Instant20161115102530,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(assessmentEvent,
				new string[] { "..generated.assignable", "..generated.assignee", "..membership.member", "..membership.organization",
							"..object.assignee" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAssessmentSubmitted");
		}

		[Test]
		public void EventAssignableActivated_MatchesReferenceJson() {
			var assignableEvent = new AssignableEvent(
				"urn:uuid:2635b9dd-0061-4059-ac61-2718ab366f75", Action.Activated) {
				Actor = Caliper11TestEntities.Person112233,
				Object = Caliper11TestEntities.AssessmentQuizOneB,
				EventTime = Caliper11TestEntities.Instant20161112101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership112233Instructor,
				Session = Caliper11TestEntities.Session6259edu2
			};

			var coerced = JsonAssertions.coerce(assignableEvent,
				new string[] { "..membership.member", "..membership.organization" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventAssignableActivated");
		}

		[Test]
		public void EventBasicCreated_MatchesReferenceJson() {
			var evnt = new Event("urn:uuid:3a648e68-f00d-4c08-aa59-8738e1884f2c") {
				Action = Action.Created,
				Actor = Caliper11TestEntities.Person554433,
				Object = new Document("https://example.edu/terms/201601/courses/7/sections/1/resources/123") {
					Name = "Course Syllabus",
					DateCreated = Caliper11TestEntities.Instant20161112071500,
					Version = "1"
				},
				EventTime = Caliper11TestEntities.Instant20161115101500
			};
			JsonAssertions.AssertSameObjectJson(evnt, "caliperEventBasicCreated");
		}

		[Test]
		public void EventBasicModifiedExtended_MatchesReferenceJson() {
			var evnt = new Event("urn:uuid:5973dcd9-3126-4dcc-8fd8-8153a155361c") {
				Action = Action.Modified,
				Actor = Caliper11TestEntities.Person554433,
				Object = new Document("https://example.edu/terms/201601/courses/7/sections/1/resources/123?version=3") {
					Name = "Course Syllabus",
					DateCreated = Caliper11TestEntities.Instant20161112071500,
					DateModified = Caliper11TestEntities.Instant20161115101500,
					Version = "3"
				},
				EventTime = Caliper11TestEntities.Instant20161115101500,
				Extensions = new ExtensionObject2()

			};
			JsonAssertions.AssertSameObjectJson(evnt, "caliperEventBasicModifiedExtended");
		}

		class ExtensionObject2 {

			[JsonProperty("archive", Order = 90)]
			public IList Archive = new[] {
				new Document(
				"https://example.edu/terms/201601/courses/7/sections/1/resources/123?version=2") {
					DateCreated = Caliper11TestEntities.Instant20161112071500,
					DateModified = Caliper11TestEntities.Instant20161113110000,
					Version = "2"
				},
				new Document(
				"https://example.edu/terms/201601/courses/7/sections/1/resources/123?version=1") {
					DateCreated = Caliper11TestEntities.Instant20161112071500,
					Version = "1"
				}
			};
		}

		[Test]
		public void EventForumSubscribed_MatchesReferenceJson() {
			var forumEvent = new ForumEvent(
				"urn:uuid:a2f41f9c-d57d-4400-b3fe-716b9026334e", Action.Subscribed) {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.Forum1Caliper,
				EventTime = Caliper11TestEntities.Instant20161115101600,
				EdApp = Caliper11TestEntities.ForumAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(forumEvent,
				new string[] { "..membership.member", "..membership.organization" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventForumSubscribed");
		}

		[Test]
		public void EventMediaPausedVideo_MatchesReferenceJson() {

			var mediaEvent = new MediaEvent(
				"urn:uuid:956b4a02-8de0-4991-b8c5-b6eebb6b4cab", Action.Paused) {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.VideoObject1,
				Target = new MediaLocation("https://example.edu/UQVK-dsU7-Y?t=321") {
					CurrentTime = Period.FromMinutes(5) + Period.FromSeconds(21)                 
				},
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = new SoftwareApplication("https://example.edu/player"),
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			JObject coerced = JsonAssertions.coerce(mediaEvent,
				new string[] { "..membership.member", "..membership.organization", "..edApp" });

			//nodatime period doesnt allow zero-padding, so fix in JObject state
			// (would otherwise be "PT5M21S")
			JToken tok = coerced.SelectToken("..currentTime");
			tok.Replace(JProperty.FromObject("PT05M21S"));

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventMediaPausedVideo");
		}

		[Test]
		public void EventMessagePosted_MatchesReferenceJson() {
			var messageEvent = new MessageEvent(
				"urn:uuid:0d015a85-abf5-49ee-abb1-46dbd57fe64e", Action.Posted) {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.Message2,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.ForumAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(messageEvent,
				new string[] { "..membership.member", "..membership.organization" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventMessagePosted");
		}

		[Test]
		public void EventMessageReplied_MatchesReferenceJson() {
			var messageEvent = new MessageEvent(
				"urn:uuid:aed54386-a3fb-45ff-90f9-a35d3daaf031", Action.Posted) {
				Actor = Caliper11TestEntities.Person778899,
				Object = Caliper11TestEntities.Message3,
				EventTime = Caliper11TestEntities.Instant20161115101530,
				EdApp = Caliper11TestEntities.ForumAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership778899Learner,
				Session = Caliper11TestEntities.SessionCd50
			};

			var coerced = JsonAssertions.coerce(messageEvent,
				new string[] { "..membership.member", "..membership.organization" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventMessageReplied");
		}

		[Test]
		public void EventNavigationNavigatedTo_MatchesReferenceJson() {
			var navEvent = new NavigationEvent(
				"urn:uuid:ff9ec22a-fc59-4ae1-ae8d-2c9463ee2f8f") {

				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.WebPage2,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				Referrer = new WebPage("https://example.edu/terms/201601/courses/7/sections/1/pages/1"),
				EdApp = new SoftwareApplication("https://example.edu"),
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(navEvent,
				new string[] { "..membership.member", "..membership.organization", "..edApp" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventNavigationNavigatedTo");
		}

		[Test]
		public void EventViewViewedFedSession_MatchesReferenceJson() {
			var viewEvent = new ViewEvent(
				"urn:uuid:4be6d29d-5728-44cd-8a8f-3d3f07e46b61") {

				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.Epub202,
				EventTime = Caliper11TestEntities.Instant20161115102000,
				EdApp = new SoftwareApplication("https://example.com"),
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16b,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session1241,
				FederatedSession = new LtiSession(
					"urn:uuid:1c519ff7-3dfa-4764-be48-d2fb35a2925a") {
					User = Caliper11TestEntities.Person554433,
                    MessageParameters = new Caliper11TestEntities.LtiParamsViewViewedFedSession(),
                    DateCreated = Caliper11TestEntities.Instant20161115101500,
					StartedAt = Caliper11TestEntities.Instant20161115101500
				}
			};

			var coerced = JsonAssertions.coerce(viewEvent,
				new string[] { "..membership.member", "..membership.organization",
							"..edApp", "..federatedSession.user" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventViewViewedFedSession");
		}

		[Test]
		public void EventNavigationNavigatedToThinned_MatchesReferenceJson() {
			var navEvent = new NavigationEvent(
				"urn:uuid:71657137-8e6e-44f8-8499-e1c3df6810d2") {

				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.WebPage2,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				Referrer = new WebPage("https://example.edu/terms/201601/courses/7/sections/1/pages/1"),
				EdApp = new SoftwareApplication("https://example.edu"),
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(navEvent,
				new string[] { "..actor", "..object", "..referrer", "..edApp",
				"..group", "..membership", "..session" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventNavigationNavigatedToThinned");
		}


		[Test]
		public void EventGradeGraded_MatchesReferenceJson() {
			var gradeEvent = Caliper11TestEntities.GradeEvent1;

			var coerced = JsonAssertions.coerce(gradeEvent,
				new string[] { "..edApp", "..scoredBy", "..generated.attempt" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventGradeGraded");
		}


		[Test]
		public void EventGradeGradedItem_MatchesReferenceJson() {
			var gradeEvent = new GradeEvent(
				"urn:uuid:12c05c4e-253f-4073-9f29-5786f3ff3f36", Action.Graded) {

				Actor = Caliper11TestEntities.AutoGraderV2,
				Object = Caliper11TestEntities.Attempt1,
				EventTime = Caliper11TestEntities.Instant20161115105706,
				EdApp = new SoftwareApplication("https://example.edu"),
				Generated = Caliper11TestEntities.Score1b,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16
			};

			var coerced = JsonAssertions.coerce(gradeEvent,
				new string[] { "..edApp", "..scoredBy", "..generated.attempt",
							"..object.isPartOf" });
			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventGradeGradedItem");
		}

		[Test]
		public void EventSessionLoggedIn_MatchesReferenceJson() {
			var sessionEvent = new SessionEvent(
				"urn:uuid:fcd495d0-3740-4298-9bec-1154571dc211", Action.LoggedIn) {

				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.SoftwareAppV2,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Session = Caliper11TestEntities.Session6259b
			};

			var coerced = JsonAssertions.coerce(sessionEvent,
				new string[] { "..edApp", "..session.user" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventSessionLoggedIn");
		}

		[Test]
		public void EventSessionLoggedInExtended_MatchesReferenceJson() {

			var sessionEvent = new SessionEvent(
				"urn:uuid:4ec2c31e-3ec0-4fe1-a017-b81561b075d7", Action.LoggedIn) {

				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.SoftwareAppV2,
				EventTime = Caliper11TestEntities.Instant20161115201115,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Session = Caliper11TestEntities.Session6259c
			};

			sessionEvent.Session.Extensions = new RequestExtension();

			var coerced = JsonAssertions.coerce(sessionEvent,
				new string[] { "..edApp", "..session.user" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventSessionLoggedInExtended");
		}

		class RequestExtension {
			[JsonProperty("request")]
			public object request = new {
				id = "d71016dc-ed2f-46f9-ac2c-b93f15f38fdc",
				hostname = "example.com",
				userAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
			};
		}

		[Test]
		public void EventSessionLoggedOut_MatchesReferenceJson() {
			var sessionEvent = new SessionEvent(
				"urn:uuid:a438f8ac-1da3-4d48-8c86-94a1b387e0f6", Action.LoggedOut) {

				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.SoftwareAppV2,
				EventTime = Caliper11TestEntities.Instant20161115110500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Session = Caliper11TestEntities.Session6259d
			};

			var coerced = JsonAssertions.coerce(sessionEvent,
				new string[] { "..edApp", "..session.user" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventSessionLoggedOut");
		}

		[Test]
		public void EventSessionTimedOut_MatchesReferenceJson() {
			var sessionEvent = new SessionEvent(
				"urn:uuid:4e61cf6c-ffbe-45bc-893f-afe7ad4079dc", Action.TimedOut) {

				Actor = new SoftwareApplication("https://example.edu"),
				Object = new Session(
					"https://example.edu/sessions/7d6b88adf746f0692e2e873308b78c60fb13a864") {
					User = Caliper11TestEntities.Person112233,
					DateCreated = Caliper11TestEntities.Instant20161115101500,
					StartedAt = Caliper11TestEntities.Instant20161115101500,
					EndedAt = Caliper11TestEntities.Instant20161115111500,
					Duration = Period.FromSeconds(3600)

				},
				EventTime = Caliper11TestEntities.Instant20161115111500,
				EdApp = Caliper11TestEntities.SoftwareAppV2

			};

			var coerced = JsonAssertions.coerce(sessionEvent,
				new string[] { "..edApp" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventSessionTimedOut");
		}

		[Test]
		public void EventThreadMarkedAsRead_MatchesReferenceJson() {
			var threadEvent = new ThreadEvent(
				"urn:uuid:6b20c5ba-301c-4e56-85a0-2f3d9a94c249", Action.MarkedAsRead) {

				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.Thread1,
				EventTime = Caliper11TestEntities.Instant20161115101600,
				EdApp = Caliper11TestEntities.ForumAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(threadEvent,
				new string[] { "..membership.member", "..membership.organization" });
			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventThreadMarkedAsRead");
		}

		[Test]
		public void EventToolUseUsed_MatchesReferenceJson() {
			var toolUseEvent = new ToolUseEvent(
				"urn:uuid:7e10e4f3-a0d8-4430-95bd-783ffae4d916", Action.Used) {

				Actor = Caliper11TestEntities.Person554433,
				Object = new SoftwareApplication("https://example.edu"),
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(toolUseEvent,
				new string[] { "..membership.member", "..membership.organization", "..edApp" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventToolUseUsed");
		}

		[Test]
		public void EventViewViewed_MatchesReferenceJson() {
			var viewEvent = new ViewEvent(
				"urn:uuid:cd088ca7-c044-405c-bb41-0b2a8506f907") {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.Epub201,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu
			};

			var coerced = JsonAssertions.coerce(viewEvent,
				new string[] { "..membership.member", "..membership.organization", "..edApp" });
			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventViewViewed");
		}

		[Test]
		public void EventViewViewedExtended_MatchesReferenceJson() {
			var viewEvent = new ViewEvent(
				"urn:uuid:3a9bd869-addc-48b1-80f6-a14b2ff591ed") {
				Actor = Caliper11TestEntities.Person554433,
				Object = Caliper11TestEntities.Epub200,
				EventTime = Caliper11TestEntities.Instant20161115101500,
				EdApp = Caliper11TestEntities.SoftwareAppV2,
				Group = Caliper11TestEntities.CourseSectionCPS43501Fall16,
				Membership = Caliper11TestEntities.EntityMembership554433Learner,
				Session = Caliper11TestEntities.Session6259edu,
				Extensions = new ViewEventExtension1()
			};

			var coerced = JsonAssertions.coerce(viewEvent,
				new string[] { "..membership.member", "..membership.organization", "..edApp" });

			JsonAssertions.AssertSameObjectJson(coerced, "caliperEventViewViewedExtended");
		}

		public class ViewEventExtension1 {
			[JsonProperty("job")]
			public object Job = new {
				id = "08c1233d-9ba3-40ac-952f-004c47a50ff7",
				jobTag = "caliper_batch_job",
				jobDate = "2016-11-16T01:01:00.000Z",
			};
		}

        [Test]
        public void EventSearchSearched_MatchesReferenceJson()
        {
            var searchEvent = new SearchEvent(
                "urn:uuid:cb3878ed-8240-4c6d-9fee-77221810f5e4", Action.Searched)
            {
                Actor = new Person("https://example.edu/users/554433") { HideCaliperContext = true },
                Object = Caliper11TestEntities.CatalogApp,
                EventTime = Caliper11TestEntities.Instant20181115100500,
                Generated = Caliper11TestEntities.SearchIMSCaliperAnalytics,
                EdApp = Caliper11TestEntities.SoftwareAppV2,
                Group = Caliper11TestEntities.CourseSectionCPS43501Fall18,
                Membership = Caliper11TestEntities.EntityMembership554433Learner_2018,
                Session = Caliper11TestEntities.Session6259_2018
            };

            var coerced = JsonAssertions.coerce(searchEvent,
                new string[] { "..edApp", "..searchProvider", "..searchTarget", "..query.creator", "..query.searchTarget", "..generated.searchResults", "..membership.member", "..membership.organization" });

            JsonAssertions.AssertSameObjectJson(coerced, "caliperEventSearchSearched");
        }
        
        [Test]
        public void EventToolLaunchLaunched_MatchesReferenceJson()
        {
            var toolLaunchEvent = new ToolLaunchEvent(
                "urn:uuid:a2e8b214-4d4a-4456-bb4c-099945749117", Action.Launched)
            {
                Actor = new Person("https://example.edu/users/554433") { HideCaliperContext = true },
                Object = new SoftwareApplication("https://example.com/lti/tool") { HideCaliperContext = true },
                EventTime = Caliper11TestEntities.Instant20181115101500,
                EdApp = new SoftwareApplication("https://example.edu") { HideCaliperContext = true },
                Referrer = new Entity("https://example.edu/terms/201801/courses/7/sections/1/pages/1") { Type = EntityType.WebPage, HideCaliperContext = true },
                Group = new CourseSection("https://example.edu/terms/201801/courses/7/sections/1")
                {
                    CourseNumber = "CPS 435-01",
                    AcademicSession = "Fall 2018",
                    HideCaliperContext = true
                },
                Membership = new Membership("https://example.edu/terms/201801/courses/7/sections/1/rosters/1")
                {
                    Member = new Person("https://example.edu/users/554433"),
                    Organization = new Organization("https://example.edu/terms/201801/courses/7/sections/1"),
                    Roles = new[] { Role.Learner },
                    Status = Status.Active,
                    DateCreated = Caliper11TestEntities.Instant20180801060000,
                    HideCaliperContext = true
                },
                Session = Caliper11TestEntities.Session6259_2018,
                Target = new LtiLink("https://tool.com/link/123")
                {
                    MessageType = EntityType.LtiResourceLinkRequest,
                    HideCaliperContext = true
                },
                FederatedSession = new LtiSession("https://example.edu/lti/sessions/b533eb02823f31024e6b7f53436c42fb99b31241")
                {
                    User = new Person("https://example.edu/users/554433") { HideCaliperContext = true },
                    MessageParameters = new Caliper11TestEntities.LtiParamsLtiSession(),
                    DateCreated = Caliper11TestEntities.Instant20181115101500,
                    StartedAt = Caliper11TestEntities.Instant20181115101500,
                    HideCaliperContext = true
                }
            };

            var coerced = JsonAssertions.coerce(toolLaunchEvent, new [] { "..membership.member", "..membership.organization" });

            JsonAssertions.AssertSameObjectJson(coerced, "caliperEventToolLaunchLaunched");
        }


        [Test]
        public void EventToolLaunchReturned_MatchesReferenceJson()
        {
            var toolLaunchEvent = new ToolLaunchEvent(
                "urn:uuid:a2e8b214-4d4a-4456-bb4c-099945749117", Action.Returned)
            {
                Actor = new Person("https://example.edu/users/554433") { HideCaliperContext = true },
                Object = new SoftwareApplication("https://example.com/lti/tool") { HideCaliperContext = true },
                EventTime = Caliper11TestEntities.Instant20181115101500,
                EdApp = new SoftwareApplication("https://example.edu") { HideCaliperContext = true },
                Referrer = new Entity("https://tool.com/lti/123") { Type = EntityType.LtiLink, HideCaliperContext = true },
                Group = new CourseSection("https://example.edu/terms/201801/courses/7/sections/1")
                {
                    CourseNumber = "CPS 435-01",
                    AcademicSession = "Fall 2018",
                    HideCaliperContext = true
                },
                Membership = new Membership("https://example.edu/terms/201801/courses/7/sections/1/rosters/1")
                {
                    Member = new Person("https://example.edu/users/554433"),
                    Organization = new Organization("https://example.edu/terms/201801/courses/7/sections/1"),
                    Roles = new[] { Role.Learner },
                    Status = Status.Active,
                    DateCreated = Caliper11TestEntities.Instant20180801060000,
                    HideCaliperContext = true
                },
                Session = Caliper11TestEntities.Session6259_2018,
                Target = new Link("https://example.edu/terms/201801/courses/7/sections/1/pages/1") { HideCaliperContext = true },
                FederatedSession = new LtiSession("https://example.edu/lti/sessions/b533eb02823f31024e6b7f53436c42fb99b31241")
                {
                    User = new Person("https://example.edu/users/554433") { HideCaliperContext = true },
                    DateCreated = Caliper11TestEntities.Instant20181115101500,
                    StartedAt = Caliper11TestEntities.Instant20181115101500,
                    HideCaliperContext = true
                }
            };

            var coerced = JsonAssertions.coerce(toolLaunchEvent, new[] { "..membership.member", "..membership.organization" });

            JsonAssertions.AssertSameObjectJson(coerced, "caliperEventToolLaunchReturned");
        }
    }
}
