using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Entities {
	using ImsGlobal.Caliper.Entities.SchemaDotOrg;
    using ImsGlobal.Caliper.Entities.Agent;

	/// <summary>
	/// Caliper representation of a CreativeWork (https://schema.org/CreativeWork)
	/// </summary>
	public class DigitalResource : Entity, ICreativeWork {

		public DigitalResource( string id )
			: base( id ) {
			this.Type = EntityType.DigitalResource;
			this.ObjectTypes = new List<string>();
			this.AlignedLearningObjectives = new List<LearningObjective>();
			this.Keywords = new List<string>();
            this.Creators = new List<Person>();
		}

		/// <summary>
		/// The object type of the resource.
		/// </summary>
		[JsonProperty( "objectType", Order = 11 )]
		public IList<string> ObjectTypes { get; set; }

		/// <summary>
		/// List of learning objectives aligned with this resource.
		/// </summary>
		[JsonProperty( "alignedLearningObjective", Order = 12 )]
		public IList<LearningObjective> AlignedLearningObjectives { get; set; }

		/// <summary>
		/// List of keywords that describe this resource.
		/// </summary>
		[JsonProperty( "keywords", Order = 13 )]
		public IList<string> Keywords { get; set; }

        /// <summary>
		/// List of creators that describe this resource.
		/// </summary>
		[JsonProperty("creators", Order = 14)]
        public IList<Person> Creators { get; set; }

        /// <summary>
        /// A reference to the parent resource, if any.
        /// </summary>
        [JsonProperty( "isPartOf", Order = 61 )]
		public ICreativeWork IsPartOf { get; set; }

		/// <summary>
		/// The date the digital resource was published.
		/// </summary>
		[JsonProperty( "datePublished", Order = 62 )]
		public Instant? DatePublished { get; set; }

		/// <summary>
		/// The current version of the digital resource.
		/// </summary>
		[JsonProperty( "version", Order = 63 )]
		public string Version { get; set; }

	}
}
