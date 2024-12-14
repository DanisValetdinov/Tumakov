namespace std
{ 
    class QueueManager
    {

        private Stack<Citizen> zinaStack = new Stack<Citizen>();
        private Queue<Citizen> heatingPr = new Queue<Citizen>();
        private Queue<Citizen> paymentPr = new Queue<Citizen>();
        private Queue<Citizen> otherPr = new Queue<Citizen>();
        private Random random = new Random();
        public void AddToQueue(Citizen citizen)
        {
            zinaStack.Push(citizen);
        }
        public void ProcessQueue()
        {
            while (zinaStack.Count > 0)
            {
                Citizen citizen = zinaStack.Pop();

                if (citizen.temperament.intelligence == 0)
                {
                    int randomQueue = random.Next(1, 4);
                    AddToWindowQueue(citizen, randomQueue);
                }
                else
                {
                    AddToWindowQueue(citizen, citizen.problemNumber);
                }
            }
        }
        private void AddToWindowQueue(Citizen citizen, int windowNumber)
        {
            if (citizen.temperament.scandalousness >= 5)
            {
                Console.WriteLine($"{citizen.name} обогнал очередь");

                switch (windowNumber)
                {
                    case 1:
                        ObstructQueue(heatingPr, citizen);
                        break;
                    case 2:
                        ObstructQueue(paymentPr, citizen);
                        break;
                    case 3:
                        ObstructQueue(otherPr, citizen);
                        break;
                }
            }
            else
            {
                switch (windowNumber)
                {
                    case 1:
                        heatingPr.Enqueue(citizen);
                        break;
                    case 2:
                        paymentPr.Enqueue(citizen);
                        break;
                    case 3:
                        otherPr.Enqueue(citizen);
                        break;
                }
            }
        }
        private static void ObstructQueue(Queue<Citizen> queue, Citizen citizen)
        {
            List<Citizen> tempList = new List<Citizen>(queue);
            queue.Clear();
            queue.Enqueue(citizen);
            foreach (var person in tempList)
            {
                queue.Enqueue(person);
            }
        }
        public void PrintQueues()
        {
            Console.WriteLine("\nОчередь к окну 1 (отопление):");
            PrintQueue(heatingPr);

            Console.WriteLine("\nОчередь к окну 2 (оплата):");
            PrintQueue(paymentPr);

            Console.WriteLine("\nОчередь к окну 3 (прочее):");
            PrintQueue(otherPr);
        }
        private static void PrintQueue(Queue<Citizen> queue)
        {
            foreach (var citizen in queue)
            {
                Console.WriteLine($"{citizen.name} | Скандальность: {citizen.temperament.scandalousness}");
            }
        }
    }
}