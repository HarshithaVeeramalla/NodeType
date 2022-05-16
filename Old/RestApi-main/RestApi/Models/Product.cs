using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class Product
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public long Id { get; set; }

        /*[Required]
        public int departmentId { get; set; }*/

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string productName { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string quantity { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string productImage { get; set; }

        //1.- entityframwork tool nuget
        //2.- Add-Migration "comment"
        //3.- Ensure created don't let use migrations so it's needeed to delete the database
        //4.-Update-databse
    }
}
