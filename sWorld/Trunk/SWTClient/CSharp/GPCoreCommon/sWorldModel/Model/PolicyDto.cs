//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sWorldModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class PolicyDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public long GroupId { get; set; }

        [DataMember]
        public int ModuleId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Nullable<sbyte> Modify { get; set; }

        [DataMember]
        public Nullable<sbyte> Insert { get; set; }

        [DataMember]
        public Nullable<sbyte> Delete { get; set; }

        [DataMember]
        public Nullable<sbyte> View { get; set; }
    }
}