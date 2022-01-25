﻿namespace QuertyKey_DAW.FrontendModels
{
    public class Switch
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AddedOn { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}