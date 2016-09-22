using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Entities {

	/// <summary>
	/// Default base class for Caliper entities.
	/// </summary>
	public class Entity : BaseEntity {

		public Entity( string id )
			: base( id ) {
			this.Extensions = new Object();
		}

		[JsonProperty( "@context", Order = 0 )]
		public string Context {
			get { return CaliperContext.Context.Value; }
		}

		[JsonProperty( "name", Order = 3 )]
		public string Name { get; set; }

		[JsonProperty( "description", Order = 4 )]
		public string Description { get; set; }

		[JsonProperty( "extensions", Order = 51 )]
		public Object Extensions { get; set; }

		[JsonProperty( "dateCreated", Order = 52 )]
		public Instant? DateCreated { get; set; }

		[JsonProperty( "dateModified", Order = 53 )]
		public Instant? DateModified { get; set; }

	}

}
