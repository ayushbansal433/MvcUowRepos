using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcUowRepos.Model.DtoModels
{
    public class UserDto : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="Length can not be greater than 100 letters")]
        [RegularExpression(@"^[A-Za-z]+[A-Za-z\ ]+$", ErrorMessage ="Invalid Name")]
        public string Name { get; set; }
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Invalid Name")]
        [Required]
        public string Email { get; set; }
    }
}
