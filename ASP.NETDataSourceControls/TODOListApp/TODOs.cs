//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TODOListApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class TODOs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }
        public System.DateTime Last_Edited { get; set; }
    
        public virtual Categories Categories { get; set; }
    }
}
