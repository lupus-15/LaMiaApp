using System;
using System.Collections.Generic;

namespace LaMiaApp.Models
{
    public class DtoAppTratt
    {
        public int Appuntamentoid { get; set; }
        public int Clienteid { get; set; }
        public string Datainizio { get; set; }
        public string Datafine { get; set; }
        public List<int> TrattamentiIds { get; set; }
    }
}