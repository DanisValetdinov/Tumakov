namespace std
{
    class Citizen
    {
        public string name { get; private set; }
        private Guid passportNumber = Guid.NewGuid();
        public string problem;
        public int problemNumber { get; private set; }
        public Temperament temperament { get; private set; }
        public Citizen(string name, string problem, int scandalousness, int intelligence)
        {
            this.name = name;
            this.problem = problem;
            this.temperament = new Temperament(scandalousness, intelligence);
            this.problemNumber = SetProblemNumber(problem);
        }
        private static int SetProblemNumber(string problem)
        {
            int num = 3;
            if (problem.Contains("плат"))
            {
                num = 2;
            }
            else if (problem.Contains("отоп"))
            {
                num = 1;

            }
            return num;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Имя: {name}\nНомер паспорта: {passportNumber}\nПроблема: \"{problem}\"\nНомер проблемы: {problemNumber}");
            temperament.PrintTemperament();
        }


    }
}