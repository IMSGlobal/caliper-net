using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Protocol {
	using ImsGlobal.Caliper.Entities;
	using ImsGlobal.Caliper.Events;
	using ImsGlobal.Caliper.Util;
	using Newtonsoft.Json.Linq;

	internal class CaliperClient {

		private readonly CaliperEndpointOptions _options;
		private readonly string _sensorId;
		private readonly JsonSerializerSettings _serializerSettings;

		public CaliperClient( CaliperEndpointOptions options, string sensorId ) {
			_options = options;
			_sensorId = sensorId;
			_serializerSettings = JsonSerializeUtils.serializerSettings;
		}

		public async Task<bool> Send( IEnumerable<Event> events ) {
			return await SendData( events );
		}

		public async Task<bool> Describe( IEnumerable<Entity> entities ) {
			return await SendData( entities );
		}

		public async Task<bool> SendData<T>( IEnumerable<T> data ) {

			var message = new CaliperMessage<T> {
				SensorId = _sensorId,
				SendTime = SystemClock.Instance.GetCurrentInstant(),
				Data = data
			};
			var jsonString = JsonConvert.SerializeObject( message, _serializerSettings );

			var jsonObject = JsonSerializeUtils.clean( JObject.Parse( jsonString ));

			var content = new StringContent( jsonObject.ToString(), Encoding.UTF8, "application/json" );

			using( var client = new HttpClient() ) {

				client.BaseAddress = _options.Host;
				
				if ( !string.IsNullOrWhiteSpace( _options.ApiKey ) ) {
				    client.DefaultRequestHeaders.Add( "Authorization", _options.ApiKey );
				}
				
				try {

					HttpResponseMessage response = await client.PostAsync( "", content );
					response.EnsureSuccessStatusCode();

				} catch( HttpRequestException ex ) {
					var msg = String.Format( "Failed to send data: {0}", ex.Message );
					Trace.WriteLine( msg );
					return false;
				}
			}

			return true;
		}

	}

}
