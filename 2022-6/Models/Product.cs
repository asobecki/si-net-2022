

using System.ComponentModel.DataAnnotations;

namespace _2022_6.Models;

public class Product {
    public Product() {  }

    public Product(int id, String n, String p, String c) {
        this.id = id;
        this.Name = n;
        this.Price = p;
        this.Category = c;
    }


    [Required(ErrorMessage = "Wprowadź {0}")]
    [Range(0, 10000)]
    [Display(Name = "ID")]
    public int id { get; set; }

    [Required(ErrorMessage = "Brakuje nazwy produktu")]
    [StringLength(100)]
    [Display(Name = "Nazwa produktu")]
    public String Name {get; set;}

    [StringLength(100)]
    [Display(Name = "Cena")]
    public String Price {get; set;}

    [StringLength(100)]
    [Display(Name = "Kategoria")]
    public String Category {get; set;}
}

