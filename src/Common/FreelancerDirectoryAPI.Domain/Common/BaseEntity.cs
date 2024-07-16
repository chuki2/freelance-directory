using System;

namespace FreelancerDirectoryAPI.Domain.Common
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }

        private DateTime createdOn = DateTime.Now;
        public DateTime CreatedOn { get => createdOn; set => createdOn = value; }

        private DateTime updatedOn = DateTime.Now;
        public DateTime UpdatedOn { get => updatedOn; set => updatedOn = value; }

        private string updateBy { get; set; }

        public string UpdateBy { get => updateBy; set => updateBy = value; }

    }
}
