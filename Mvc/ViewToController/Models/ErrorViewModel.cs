namespace ViewToController.Models
{
    //ErrorViewModel,Hata durumlar�nda kullan�lacak bir modeldir.
    //Model, verilerin yap�s�n� belirler ve verileri view e ta��mak i�in kullan�l�r.
    public class ErrorViewModel
    {
        //RequestId hatayla ili�kili iste�in benzersiz bir kimli�ini temsil eder.
        public string? RequestId { get; set; } //Nullable string, iste�in Id bilgisini tutar (RequestId bo� olabilir.)

        //REquest idnin ge�erli bir de�er i�erip i�ermedi�ini kontrol eder
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        //e�er request�d bo� veya null de�ilse true aksi halde false d�ner
        //bu �zllik genellikle view i�erisinde hatay� takip etmek i�in kullan�l�r.
    }
}
