using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Core.Entities
{
	[Table("Categories")]
	public class Entity_Category
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int Id { get; set; }
		[StringLength(100)]
		[Required(ErrorMessage = "This field is required")]
		public virtual string Name { get; set; }
		[Required]
		[Display(Name = "CreatedOn")]
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		[Required]
		[Display(Name = "UpdatedOn")]
		public DateTime UpdatedOn { get; set; } = DateTime.Now;
		[Required]
		[Display(Name = "IsDeleted")]
		public bool IsDeleted { get; set; } = false;
	}
}
