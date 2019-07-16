﻿using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Feedback
{
    public class Question : DigitalResource
    {
        public Question(string id, ICaliperContext caliperContext = null)
            : base(id, caliperContext)
        {
            this.Type = EntityType.Question;
        }

        /// <summary>
        /// A string value comprising the question posed
        /// </summary>
        [JsonProperty("questionPosed", Order = 12)]
        public string QuestionPosed { get; set; }
    }
}