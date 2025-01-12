namespace ViewToController.Models
{
    //ErrorViewModel,Hata durumlarýnda kullanýlacak bir modeldir.
    //Model, verilerin yapýsýný belirler ve verileri view e taþýmak için kullanýlýr.
    public class ErrorViewModel
    {
        //RequestId hatayla iliþkili isteðin benzersiz bir kimliðini temsil eder.
        public string? RequestId { get; set; } //Nullable string, isteðin Id bilgisini tutar (RequestId boþ olabilir.)

        //REquest idnin geçerli bir deðer içerip içermediðini kontrol eder
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        //eðer requestýd boþ veya null deðilse true aksi halde false döner
        //bu özllik genellikle view içerisinde hatayý takip etmek için kullanýlýr.
    }
}
