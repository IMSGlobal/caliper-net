using System;
using ImsGlobal.Caliper.Entities;
using ImsGlobal.Caliper.Entities.Agent;
using ImsGlobal.Caliper.Entities.Assessment;
using ImsGlobal.Caliper.Entities.Assignable;
using ImsGlobal.Caliper.Entities.Collection;
using ImsGlobal.Caliper.Entities.Forum;
using ImsGlobal.Caliper.Entities.Lis;
using ImsGlobal.Caliper.Entities.Media;
using ImsGlobal.Caliper.Entities.Outcome;
using ImsGlobal.Caliper.Entities.Reading;
using ImsGlobal.Caliper.Entities.Session;
using ImsGlobal.Caliper.Events.Outcome;
using Newtonsoft.Json;
using NodaTime;
using ImsGlobal.Caliper.Entities.Search;

namespace ImsGlobal.Caliper.Tests {

	internal static class Caliper11TestEntities {

		public static Instant EnvelopeDefaultSendTime = Instant.FromUtc(2016, 11, 15, 11, 05, 01);

		public static string EnvelopeDefaultSensorId = "https://example.edu/sensors/1";

		public static Instant Instant20160801060000 = Instant.FromUtc(2016, 08, 01, 06, 00, 00);
		public static Instant Instant20160902113000 = Instant.FromUtc(2016, 09, 02, 11, 30, 00);
		public static Instant Instant20161001060000 = Instant.FromUtc(2016, 10, 01, 06, 00, 00);
		public static Instant Instant20161112100000 = Instant.FromUtc(2016, 11, 12, 10, 00, 00);
		public static Instant Instant20161112101500 = Instant.FromUtc(2016, 11, 12, 10, 15, 00);
		public static Instant Instant20161112101000 = Instant.FromUtc(2016, 11, 12, 10, 10, 00);
		public static Instant Instant20161115101500 = Instant.FromUtc(2016, 11, 15, 10, 15, 00);
		public static Instant Instant20161115101530 = Instant.FromUtc(2016, 11, 15, 10, 15, 30);
		public static Instant Instant20161115100000 = Instant.FromUtc(2016, 11, 15, 10, 00, 00);
		public static Instant Instant20161115101512 = Instant.FromUtc(2016, 11, 15, 10, 15, 12);
		public static Instant Instant20161115101502 = Instant.FromUtc(2016, 11, 15, 10, 15, 02);
		public static Instant Instant20161114050000 = Instant.FromUtc(2016, 11, 14, 05, 00, 00);
		public static Instant Instant20161115101430 = Instant.FromUtc(2016, 11, 15, 10, 14, 30);
		public static Instant Instant20161115102530 = Instant.FromUtc(2016, 11, 15, 10, 25, 30);
		public static Instant Instant20161118115959 = Instant.FromUtc(2016, 11, 18, 11, 59, 59);
		public static Instant Instant20161112071500 = Instant.FromUtc(2016, 11, 12, 07, 15, 00);
		public static Instant Instant20161113110000 = Instant.FromUtc(2016, 11, 13, 11, 00, 00);
		public static Instant Instant20160914110000 = Instant.FromUtc(2016, 09, 14, 11, 00, 00);
		public static Instant Instant20161115101600 = Instant.FromUtc(2016, 11, 15, 10, 16, 00);
		public static Instant Instant20161115101200 = Instant.FromUtc(2016, 11, 15, 10, 12, 00);
		public static Instant Instant20160801090000 = Instant.FromUtc(2016, 08, 01, 09, 00, 00);
		public static Instant Instant20161115105706 = Instant.FromUtc(2016, 11, 15, 10, 57, 06);
		public static Instant Instant20161115105505 = Instant.FromUtc(2016, 11, 15, 10, 55, 05);
		public static Instant Instant20161115100500 = Instant.FromUtc(2016, 11, 15, 10, 05, 00);
		public static Instant Instant20161115105512 = Instant.FromUtc(2016, 11, 15, 10, 55, 12);
		public static Instant Instant20161115201115 = Instant.FromUtc(2016, 11, 15, 20, 11, 15);
		public static Instant Instant20161115111500 = Instant.FromUtc(2016, 11, 15, 11, 15, 00);
		public static Instant Instant20161115110500 = Instant.FromUtc(2016, 11, 15, 11, 05, 00);
		public static Instant Instant20161115102000 = Instant.FromUtc(2016, 11, 15, 10, 20, 00);
		public static Instant Instant20161115102100 = Instant.FromUtc(2016, 11, 15, 10, 21, 00);
		public static Instant Instant20160815093000 = Instant.FromUtc(2016, 08, 15, 09, 30, 00);
		public static Instant Instant20160816050000 = Instant.FromUtc(2016, 08, 16, 05, 00, 00);
		public static Instant Instant20160928115959 = Instant.FromUtc(2016, 09, 28, 11, 59, 59);
		public static Instant Instant20161115105600 = Instant.FromUtc(2016, 11, 15, 10, 56, 00);
		public static Instant Instant20161101060000 = Instant.FromUtc(2016, 11, 01, 06, 00, 00);
		public static Instant Instant20161115101546 = Instant.FromUtc(2016, 11, 15, 10, 15, 46);
		public static Instant Instant20161115101720 = Instant.FromUtc(2016, 11, 15, 10, 17, 20);
        public static Instant Instant20180801060000 = Instant.FromUtc(2018, 08, 01, 06, 00, 00);
        public static Instant Instant20181115100000 = Instant.FromUtc(2018, 11, 15, 10, 00, 00);
        public static Instant Instant20181115100500 = Instant.FromUtc(2018, 11, 15, 10, 05, 00);
        public static Instant Instant20181115101500 = Instant.FromUtc(2018, 11, 15, 10, 15, 00);

        public static Person Person778899 = new Person("https://example.edu/users/778899");
		public static Person Person554433 = new Person("https://example.edu/users/554433");
		public static Person Person112233 = new Person("https://example.edu/users/112233");
		public static Person Person554433dates = new Person("https://example.edu/users/554433") {
			DateCreated = Instant20160801060000,
			DateModified = Instant20160902113000
		};


		public static Membership EntityMembership554433Learner = new Membership
			("https://example.edu/terms/201601/courses/7/sections/1/rosters/1") {
			Member = new Person("https://example.edu/users/554433"),
			Organization = new Organization("https://example.edu/terms/201601/courses/7/sections/1"),
			Roles = new[] { Role.Learner },
			Status = Status.Active,
			DateCreated = Instant20160801060000
		};

        public static Membership EntityMembership554433Learner_2018 = new Membership
             ("https://example.edu/terms/201601/courses/7/sections/1/rosters/1")
        {
            Member = new Person("https://example.edu/users/554433"),
            Organization = new Organization("https://example.edu/terms/201601/courses/7/sections/1"),
            Roles = new[] { Role.Learner },
            Status = Status.Active,
            DateCreated = Instant20180801060000,
            HideCaliperContext = true
        };

        public static Membership EntityMembership778899Learner = new Membership
			("https://example.edu/terms/201601/courses/7/sections/1/rosters/1") {
			Member = new Person("https://example.edu/users/778899"),
			Organization = new Organization("https://example.edu/terms/201601/courses/7/sections/1"),
			Roles = new[] { Role.Learner },
			Status = Status.Active,
			DateCreated = Instant20160801060000
		};

		public static Membership EntityMembership112233Instructor = new Membership
			("https://example.edu/terms/201601/courses/7/sections/1/rosters/1") {
			Member = new Person("https://example.edu/users/112233"),
			Organization = new Organization("https://example.edu/terms/201601/courses/7/sections/1"),
			Roles = new[] { Role.Instructor },
			Status = Status.Active,
			DateCreated = Instant20160801060000
		};

		public static CourseSection CourseSectionCPS43501Fall16 = new CourseSection
			("https://example.edu/terms/201601/courses/7/sections/1") {
			CourseNumber = "CPS 435-01",
			AcademicSession = "Fall 2016"		
		};

		public static CourseSection CourseSectionCPS43501Fall16b = new CourseSection
			("https://example.edu/terms/201601/courses/7/sections/1") {
			Extensions = new {
				edu_example_course_section_instructor = "https://example.edu/faculty/1234"
			}		
		};

        public static CourseSection CourseSectionCPS43501Fall18 = new CourseSection
              ("https://example.edu/terms/201601/courses/7/sections/1")
        {
            CourseNumber = "CPS 435-01",
            AcademicSession = "Fall 2018",
            HideCaliperContext = true
        };
        
        public static Session Session6259 = new Session("https://example.com/sessions/1f6442a482de72ea6ad134943812bff564a76259") {
			StartedAt = Instant20161115100000
		};

		public static Session Session6259b = new Session("https://example.edu/sessions/1f6442a482de72ea6ad134943812bff564a76259") {
			StartedAt = Instant20161115100000,
			DateCreated = Instant20161115100000,
			User = Person554433
		};

		public static Session Session6259c = new Session("https://example.edu/sessions/1f6442a482de72ea6ad134943812bff564a76259") {
			StartedAt = Instant20161115201115,
			DateCreated = Instant20161115201115,
			User = Person554433
		};

		public static Session Session6259d = new Session("https://example.edu/sessions/1f6442a482de72ea6ad134943812bff564a76259") {
			StartedAt = Instant20161115100000,
			DateCreated = Instant20161115100000,
			EndedAt = Instant20161115110500,
			User = Person554433,
			Duration = Period.FromSeconds(3000)
		};


		public static Session Session6259edu = new Session("https://example.edu/sessions/1f6442a482de72ea6ad134943812bff564a76259") {
			StartedAt = Instant20161115100000
		};

		public static Session Session6259edu2 = new Session("https://example.edu/sessions/f095bbd391ea4a5dd639724a40b606e98a631823") {
			StartedAt = Instant20161112100000
		};

        public static Session Session6259_2018 = new Session("https://example.edu/sessions/1f6442a482de72ea6ad134943812bff564a76259")
        {
            StartedAt = Instant20181115100000,
            HideCaliperContext = true
        };

        public static Session SessionCd50 = new Session("https://example.edu/sessions/1d6fa9adf16f4892650e4305f6cf16610905cd50") {
			StartedAt = Instant20161115101200
		};

		public static Session Session1241 = new Session("https://example.com/sessions/c25fd3da-87fa-45f5-8875-b682113fa5ee") {
			StartedAt = Instant20161115102000,
			DateCreated = Instant20161115102000
		};


		public static SoftwareApplication EpubReader123 = new SoftwareApplication("https://example.com/reader") {
			Name = "ePub Reader",
			Version = "1.2.3"
		};

		public static SoftwareApplication SoftwareAppV2 = new SoftwareApplication("https://example.edu") {
			Version = "v2"
		};

		public static SoftwareApplication ForumAppV2 = new SoftwareApplication("https://example.edu/forums") {
			Version = "v2"
		};

        public static SoftwareApplication CatalogApp = new SoftwareApplication("https://example.edu/catalog") { HideCaliperContext = true };

        public static AssessmentItem AssessmentItem2 = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/2") {
			Name = "Assessment Item 2",
			IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
			DateToStartOn = Instant20161114050000,
			DateToSubmit = Instant20161118115959,
			MaxAttempts = 2,
			MaxSubmits = 2,
			MaxScore = 1.0,
			IsTimeDependent = false,
			Version = "1.0"
		};

		public static AssessmentItem AssessmentItem3 = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3") {
			Name = "Assessment Item 3",
			IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1")
		};

		public static AssessmentItem AssessmentItem6 = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/6") {
			IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
			DateCreated = Caliper11TestEntities.Instant20160801060000,
			DatePublished = Caliper11TestEntities.Instant20160815093000,
			IsTimeDependent = false,
			MaxAttempts = 2,
			MaxScore = 5.0,
			MaxSubmits = 2,
			Extensions = new { questionType = "Short Answer", questionText = "Define a Caliper Event and provide examples." }
		};

		public static AssessmentItem AssessmentItem3b = new AssessmentItem("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3") {
			Name = "Assessment Item 3",
			IsPartOf = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
			DateToStartOn = Instant20161114050000,
			DateToSubmit = Instant20161118115959,
			MaxAttempts = 2,
			MaxSubmits = 2,
			MaxScore = 1.0,
			IsTimeDependent = false,
			Version = "1.0"
		};

		public static Assessment AssessmentQuizOne = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1") {
			Name = "Quiz One",
			DateToStartOn = Instant20161114050000,
			DateToSubmit = Instant20161118115959,
			MaxAttempts = 2,
			MaxSubmits = 2,
			MaxScore = 25.0,
			Version = "1.0"
		};

		public static Assessment AssessmentQuizOneB = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1") {
			Name = "Quiz One",
			DateCreated = Instant20160801060000,
			DateToStartOn = Instant20161114050000,
			DateToSubmit = Instant20161118115959,
			DateModified = Instant20160902113000,
			DatePublished = Instant20161112101000,
			DateToActivate = Instant20161112101500,
			MaxAttempts = 2,
			MaxSubmits = 2,
			MaxScore = 25.0,
			Version = "1.0"
		};

		public static Attempt Attempt1 = new Attempt(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/attempts/1") {
			Assignee = Person554433,
			Assignable = AssessmentItem3,
			IsPartOf = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1"),
			Count = 1,
			DateCreated = Instant20161115101502,
			StartedAtTime = Instant20161115101502,
			EndedAtTime = Instant20161115101512
		};

		public static Attempt Attempt2 = new Attempt(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
			Assignee = Person554433,
			Assignable = AssessmentQuizOne,
			Count = 1,
			DateCreated = Instant20161115101500,
			StartedAtTime = Instant20161115101500,
			EndedAtTime = Instant20161115102530,
			Duration = Period.FromMinutes(10) + Period.FromSeconds(30)
		};

		public static Attempt Attempt1b = new Attempt(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/attempts/1") {
			Assignee = Person554433,
			Assignable = AssessmentItem3,
			IsPartOf = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1"),
			Count = 1,
			DateCreated = Instant20161115101500,
			StartedAtTime = Instant20161115101500
		};

		public static Attempt Attempt1c = new Attempt(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
			Assignee = Person554433,
			Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
			Count = 1,
			DateCreated = Instant20161115101500,
			StartedAtTime = Instant20161115101500
		};

		public static Attempt Attempt1d = new Attempt(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1") {
			Assignee = Person554433,
			Assignable = new Assessment("https://example.edu/terms/201601/courses/7/sections/1/assess/1"),
			Count = 1,
			DateCreated = Instant20161115100500,
			StartedAtTime = Instant20161115100500,
			EndedAtTime = Instant20161115105512,
			Duration = Period.FromMinutes(50) + Period.FromSeconds(12)

		};

		public static SoftwareApplication AutoGraderV2 = new SoftwareApplication(
			"https://example.edu/autograder") {
			Version = "v2"
		};

		public static Result Result1 = new Result(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/results/1") {
			Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1"),
			MaxResultScore = 15.0,
			ResultScore = 10.0,
			ScoredBy = AutoGraderV2,
			Comment = "Consider retaking the assessment.",
			DateCreated = Instant20161115105505
		};

		public static Score Score1 = new Score(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1/scores/1") {
			Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1"),
			MaxScore = 15.0,
			ScoreGiven = 10.0,
			ScoredBy = AutoGraderV2,
			Comment = "auto-graded exam",
			DateCreated = Instant20161115105600
		};

		public readonly static GradeEvent GradeEvent1 = new GradeEvent(
						"urn:uuid:a50ca17f-5971-47bb-8fca-4e6e6879001d", Events.Action.Graded) {
			Actor = AutoGraderV2,
			Object = Attempt1d,
			Generated = Score1,
			EventTime = Instant20161115105706,
			EdApp = new SoftwareApplication("https://example.edu"),
			Group = CourseSectionCPS43501Fall16
		};

		public static Forum Forum1Caliper = new Forum("https://example.edu/terms/201601/courses/7/sections/1/forums/1") {
			Name = "Caliper Forum",
			IsPartOf = new CourseSection("https://example.edu/terms/201601/courses/7/sections/1"),
			DateCreated = Instant20160914110000
		};

		public static VideoObject VideoObject1 = new VideoObject("https://example.edu/UQVK-dsU7-Y") {
			Name = "Information and Welcome",
			MediaType = "video/ogg",
			Duration = Period.FromMinutes(20) + Period.FromSeconds(20)
		};
		/*
				public static MediaLocation MediaLocation1 = new MediaLocation("https://example.edu/UQVK-dsU7-Y?t=321") {
					CurrentTime = Period.FromMinutes(5) + Period.FromSeconds(21),						                    
				};
		*/
		public static Message Message2 = new Message("https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1/messages/2") {
			Creators = new[] { Person554433 },
			Body = "Are the Caliper Sensor reference implementations production-ready?",
			IsPartOf = new Thread("https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1") {
				Name = "Caliper Adoption",
				IsPartOf = new Forum("https://example.edu/terms/201601/courses/7/sections/1/forums/2") {
					Name = "Caliper Forum"
				}
			},
			DateCreated = Instant20161115101500

		};

		public static Message Message3 = new Message("https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1/messages/3") {
			Creators = new[] { new Person("https://example.edu/users/778899") },
			ReplyTo = new Message("https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1/messages/2"),
			IsPartOf = new Thread("https://example.edu/terms/201601/courses/7/sections/1/forums/2/topics/1") {
				IsPartOf = new Forum("https://example.edu/terms/201601/courses/7/sections/1/forums/2")
			},
			DateCreated = Instant20161115101530
		};

		public static WebPage WebPage2 = new WebPage("https://example.edu/terms/201601/courses/7/sections/1/pages/2") {
			Name = "Learning Analytics Specifications",
			Description = "Overview of Learning Analytics Specifications with particular emphasis on IMS Caliper.",
			DateCreated = Instant20160801090000
		};

		public static Document Epub202 = new Document("https://example.com/lti/reader/202.epub") {
			Name = "Caliper Case Studies",
			MediaType = "application/epub+zip",
			DateCreated = Instant20160801090000
		};

		public static Document Epub201 = new Document("https://example.edu/etexts/201.epub") {
			Name = "IMS Caliper Implementation Guide",
			DateCreated = Instant20160801060000,
			DatePublished = Instant20161001060000,
			Version = "1.1"
		};

		public static Document Epub200 = new Document("https://example.edu/etexts/200.epub") {
			Name = "IMS Caliper Specification",
			Version = "1.1"
		};

		public static Result Result1b = new Result(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/results/1") {
			Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/attempts/1"),
			ResultScore = 1.0,
			MaxResultScore = 1.0,
			ScoredBy = new SoftwareApplication("https://example.edu/autograder"),
			DateCreated = Instant20161115105505
		};

		public static Score Score1b = new Score(
			"https://example.edu/terms/201601/courses/7/sections/1/assess/1/items/3/users/554433/attempts/1/scores/1") {
			Attempt = new Attempt("https://example.edu/terms/201601/courses/7/sections/1/assess/1/users/554433/attempts/1"),
			MaxScore = 5.0,
			ScoreGiven = 5.0,
			ScoredBy = new SoftwareApplication("https://example.edu/autograder"),
			Comment = "auto-graded exam",
			DateCreated = Instant20161115105505
		};

		public static Thread Thread1 = new Thread(
			"https://example.edu/terms/201601/courses/7/sections/1/forums/1/topics/1") {
			Name = "Caliper Information Model",
			IsPartOf = new Forum("https://example.edu/terms/201601/courses/7/sections/1/forums/1") {
				Name = "Caliper Forum",
				DateCreated = Instant20161115101500
			},
			DateCreated = Instant20161115101600
		};

		public static VideoObject VideoObject_1 = new VideoObject("https://example.edu/videos/1225") {
			MediaType = "video/ogg",
			Name = "Introduction to IMS Caliper",
			DateCreated = Instant20160801060000,
			Duration = Period.FromHours(1) + Period.FromMinutes(12) + Period.FromSeconds(27),
			Version = "1.1"
		};


		public static VideoObject VideoObject_2 = new VideoObject("https://example.edu/videos/5629") {
			MediaType = "video/ogg",
			Name = "IMS Caliper Activity Profiles",
			DateCreated = Instant20160801060000,
			Duration = Period.FromMinutes(55) + Period.FromSeconds(13),
			Version = "1.1.1"
		};

		public class LtiParams {

			public string lti_message_type = "basic-lti-launch-request";

			public string lti_version = "LTI-2p0";

			public string context_id = "4f1a161f-59c3-43e5-be37-445ad09e3f76";

			public string context_type = "CourseSection";

			public string resource_link_id = "6b37a950-42c9-4117-8f4f-03e6e5c88d24";

			public string[] roles = new[] { "Learner" };

			public string user_id = "0ae836b9-7fc9-4060-006f-27b2066ac545";

			public object custom = new {
				caliper_profile_url = "https://example.edu/lti/tc/cps",
				caliper_session_id = "1c519ff7-3dfa-4764-be48-d2fb35a2925a",
				tool_consumer_instance_url = "https://example.edu"
			};

			public object ext = new {
				edu_example_course_section = "https://example.edu/terms/201601/courses/7/sections/1",
				edu_example_course_section_roster = "https://example.edu/terms/201601/courses/7/sections/1/rosters/1",
				edu_example_course_section_learner = "https://example.edu/users/554433",
				edu_example_course_section_instructor = "https://example.edu/faculty/1234"
			};


		};

        public class LtiParamsViewViewedFedSession
        {
            public string lti_message_type = "basic-lti-launch-request";

            public string lti_version = "LTI-1p0";

            public string context_id = "4f1a161f-59c3-43e5-be37-445ad09e3f76";

            public string context_type = "urn:lti:context-type:ims/lis/CourseSection";

            public string context_label = "SI182";

            public string context_title = "Design of Personal Environments";

            public string resource_link_id = "6b37a950-42c9-4117-8f4f-03e6e5c88d24";

            public string[] roles = new[] { "urn:lti:role:ims/lis/Learner" };

            public string tool_consumer_instance_guid = "SomeLMS.example.edu";

            public string tool_consumer_instance_description = "Sample University (SomeLMS)";

            public string user_id = "0ae836b9-7fc9-4060-006f-27b2066ac545";

            public Instant custom_xstart = Instant.FromUtc(2016, 08, 21, 01, 00, 00);

            public string ext_com_somelms_example_course_section_instructor = "https://example.edu/faculty/1234";
        };

        public class LtiParamsLtiSession
        {
            public string iss = "https://example.edu";
            public string sub = "https://example.edu/users/554433";
            public string[] aud = new[] { "https://example.com/lti/tool" };
            public long exp = 1510185728;
            public long iat = 1510185228;
            public string azp = "962fa4d8-bcbf-49a0-94b2-2de05ad274af";
            public string nonce = "fc5fdc6d-5dd6-47f4-b2c9-5d1216e9b771";
            public string name = "Ms Jane Marie Doe";
            public string given_name = "Jane";
            public string family_name = "Doe";
            public string middle_name = "Marie";
            public string picture = "https://example.edu/jane.jpg";
            public string email = "jane@example.edu";
            public string locale = "en-US";

            [JsonProperty("https://purl.imsglobal.org/spec/lti/claim/deployment_id")]
            public string deployment_id = "07940580-b309-415e-a37c-914d387c1150";

            [JsonProperty("https://purl.imsglobal.org/spec/lti/claim/message_type")]
            public string message_type = "LtiResourceLinkRequest";

            [JsonProperty("https://purl.imsglobal.org/spec/lti/claim/version")]
            public string version = "1.3.0";

            [JsonProperty("https://purl.imsglobal.org/spec/lti/claim/roles")]
            public string[] roles = new[]{
                "http://purl.imsglobal.org/vocab/lis/v2/institution/person#Student",
                "http://purl.imsglobal.org/vocab/lis/v2/membership#Learner",
                "http://purl.imsglobal.org/vocab/lis/v2/membership#Mentor"
            };

            [JsonProperty("https://purl.imsglobal.org/spec/lti/claim/role_scope_mentor")]
            public string[] role_scope_mentor = new string[] { "http://purl.imsglobal.org/vocab/lis/v2/institution/person#Administrator" };

            [JsonProperty("https://purl.imsglobal.org/spec/lti/claim/context")]
            public object context = new
            {
                id = "https://example.edu/terms/201801/courses/7/sections/1",
                label = "CPS 435-01",
                title = "CPS 435 Learning Analytics, Section 01",
                type = new[] { "http://purl.imsglobal.org/vocab/lis/v2/course#CourseSection" }
            };

            [JsonProperty("https://purl.imsglobal.org/spec/lti/claim/resource_link")]
            public object resource_link = new
            {
                id = "200d101f-2c14-434a-a0f3-57c2a42369fd",
                description = "Assignment to introduce who you are",
                title = "Introduction Assignment"
            };

            [JsonProperty("https://purl.imsglobal.org/spec/lti/claim/tool_platform")]
            public object tool_platform = new
            {
                guid = "https://example.edu",
                contact_email = "support@example.edu",
                description = "An Example Tool Platform",
                name = "Example Tool Platform",
                url = "https://example.edu",
                product_family_code = "ExamplePlatformVendor-Product",
                version = "1.0"
            };

            [JsonProperty("https://purl.imsglobal.org/spec/lti/claim/launch_presentation")]
            public object launch_presentation = new
            {
                document_target = "iframe",
                height = 320,
                width = 240,
                return_url = "https://example.edu/terms/201801/courses/7/sections/1/pages/1"
            };

            [JsonProperty("https://purl.imsglobal.org/spec/lti/claim/custom")]
            public object custom = new
            {
                xstart = "2017-04-21T01:00:00Z",
                request_url = "https://tool.com/link/123"
            };

            [JsonProperty("https://purl.imsglobal.org/spec/lti/claim/lis")]
            public object lis = new
            {
                person_sourcedid = "example.edu:71ee7e42-f6d2-414a-80db-b69ac2defd4",
                course_offering_sourcedid = "example.edu:SI182-F16",
                course_section_sourcedid = "example.edu:SI182-001-F16"
            };

            [JsonProperty("http://www.ExamplePlatformVendor.com/session")]
            public object session = new { id = "89023sj890dju080" };
        };

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

        public static SearchResponse SearchIMSCaliperAnalytics = new SearchResponse(
            "https://example.edu/users/554433/search?query=IMS%20AND%20%28Caliper%20OR%20Analytics%29")
        {
            SearchProvider = SoftwareAppV2,
            SearchTarget = new Entity("https://example.edu/catalog"),
            Query = new Query(
                "https://example.edu/users/554433/search?query=IMS%20AND%20%28Caliper%20OR%20Analytics%29")
            {
                Creator = Person554433,
                SearchTarget = new Entity("https://example.edu/catalog"),
                SearchTerms = "IMS AND (Caliper OR Analytics)",
                DateCreated = Instant20181115100500,
                HideCaliperContext = true
            },
            SearchResultsItemCount = 3,
            SearchResults = new[] {
                new DigitalResource("https://example.edu/catalog/record/01234?query=IMS%20AND%20%28Caliper%20OR%20Analytics%29"),
                new DigitalResource("https://example.edu/catalog/record/09876?query=IMS%20AND%20%28Caliper%20OR%20Analytics%29"),
                new DigitalResource("https://example.edu/catalog/record/05432?query=IMS%20AND%20%28Caliper%20OR%20Analytics%29")
            },
            HideCaliperContext = true
        };
    }
}
