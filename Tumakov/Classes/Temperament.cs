namespace std
{
    struct Temperament
    {
        public int scandalousness;
        public int intelligence;
        public Temperament(int scandalousness, int intelligence)
        {
            if (scandalousness < 0 || scandalousness > 10)
            {
                throw new ArgumentException("Скандальность должна быть от 0 до 10");
            }
            if (intelligence != 0 && intelligence != 1)
            {
                throw new ArgumentException("Интеллект должен быть 0 или 1");
            }
            this.scandalousness = scandalousness;
            this.intelligence = intelligence;
        }
        public readonly void PrintTemperament()
        {
            Console.WriteLine($"Скандальность: {scandalousness}\nИнтеллект: {intelligence}");
        }
    }
}