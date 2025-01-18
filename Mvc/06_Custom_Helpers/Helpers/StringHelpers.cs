namespace _06_Custom_Helpers.Helpers
{
    public static class StringHelpers//Static yapılar daima sınıf üzerinden çağırılır.
    {
        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))// Metin null veya boş mu ? 
            {
                return input;// Eğer öyleyse orjinal metni dönder.
            }
            return char.ToUpper(input[0]) + input.Substring(1);// ilk harfi büyük yapar ve geri kalanını olduğu gibi ekler.
        }
        public static string CapitalizeWord(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            var words = input.Split(' ');// metni boşluk karakterine göre kelimelere ayır.
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = CapitalizeFirstLetter(words[i]);//Her kelimenin ilk harfini büyük yap.

            }
            return string.Join(" ", words);//kelimeleri tekrar birleştirerek sonucu dönderme


        }
        public static string WordsLength(string input)
        {
            return $"{input} uzunluğu: {input.Length}";//MEtinin uzunluğunu formatlayarak dönder.
        }
    }
}
