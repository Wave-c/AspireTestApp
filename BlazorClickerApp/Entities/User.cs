using System;

namespace BlazorClickerApp.Entities
{
    public class User
    {
        public Guid Id { set; get; }
        public int ClicksCount { get; set; }
    }
}