using System.ComponentModel.DataAnnotations;

namespace JwtExample.Models
{
    public class TaskLists
    {
        [Key]
        public long Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskType { get; set; }
        // aslinda burada boyle birsey olmamali. TaskType isminde tablo olup ordan joinle taskTypeId cekilmeli.
        // bu TaskLists classi icinde sadece TaskTypeId sini tutmaliyiz. Sadece yetismeyecegi icin bu sekilde birakiyorum
        //Gunluk, Haftalik, Aylik diye 3 ihtimal var. Bunlari enum olarak tanimlayip ordan cekmekte mumkun. Bu sekilde hataya cok acik bu sistem oldugunun farkindayim
    }
}

