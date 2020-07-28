using System;
namespace GrocedyAPI.DataModels
{
    public class TrackModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool CurrentStateCompleted { get; set; }
    }
}
