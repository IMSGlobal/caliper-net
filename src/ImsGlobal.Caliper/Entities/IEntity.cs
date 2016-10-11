﻿using NodaTime;
using System;

namespace ImsGlobal.Caliper.Entities {

	/// <summary>
	/// Provides an entity with its JSON-LD @type identifier.
	/// </summary>
	public interface IEntity {
        
        string Context { get; set; }
       
        string Id { get; set; }

        IType Type { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        Object Extensions { get; set; }

        Instant? DateCreated { get; set; }

        Instant? DateModified { get; set; }
    }

}