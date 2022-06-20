using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SB.Core.Entities
{
	[Table("Items")]
	public class Entity_Item
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual long ID { get; set; }
		[Required(ErrorMessage = "This field is required")]
		public virtual int? Category_ID_FK { get; set; }
		[ForeignKey("Category_ID_FK")]
		public Entity_Category Entity_Category { get; set; }
		[Required(ErrorMessage = "This field is required")]
		[StringLength(100)]
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public virtual decimal Price { get; set; }
		[StringLength(15)]
		public virtual string ItemCode { get; set; }
		[DisplayName("Upload Image")]

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
