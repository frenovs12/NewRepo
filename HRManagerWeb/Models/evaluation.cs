namespace HRManagerWeb.Models
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("hrmanager.evaluation")]
    public partial class evaluation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
     


        public evaluation()
        {

        }
  
        public int E_ID { get; set; }

        [StringLength(255)]
        public string Role { get; set; }

        [DataType(DataType.Date)]
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime DD { get; set; }

        [DataType(DataType.Date)]
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime DF { get; set; }

        [StringLength(255)]
        public string TypeE { get; set; }
        internal class MicrosecondEpochConverter : Newtonsoft.Json.JsonConverter
        {

            private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteRawValue(((DateTime)value - _epoch).TotalMilliseconds + "000");
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.Value == null) { return null; }
                return _epoch.AddMilliseconds((long)reader.Value);
            }

            public override bool CanConvert(Type objectType)
            {
                throw new NotImplementedException();
            }
        }
    }
}
