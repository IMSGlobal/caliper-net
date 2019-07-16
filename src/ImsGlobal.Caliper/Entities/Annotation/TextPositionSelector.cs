
using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Annotation {

	/// <summary>
	/// A selector which describes a range of text based on its start and end positions
	/// Defined by: http://www.w3.org/ns/oa#d4e667
	/// </summary>
	public class TextPositionSelector : Selector {

		public TextPositionSelector(ICaliperContext caliperContext = null) : base (SelectorType.Text, caliperContext) {}	

		[JsonProperty( "start", Order = 1 )]
		public int Start { get; set; }

		[JsonProperty( "end", Order = 2 )]
		public int End { get; set; }

	}

}
