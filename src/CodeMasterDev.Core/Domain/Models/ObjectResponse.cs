﻿namespace CodeMasterDev.Core.Domain.Models
{
    public class ObjectResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
