﻿namespace testapiproject.DTOs
{
    public class CategoryReadDto
    {
        public Guid CateId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
