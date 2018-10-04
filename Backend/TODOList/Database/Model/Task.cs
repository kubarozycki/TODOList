using System.ComponentModel.DataAnnotations.Schema;

namespace TODOList.Database
{
    [Table("Tasks")]
    public class Task
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }
    }
}
