namespace LeetCode
{
    public class Hard
    {
        public IList<string> ReconstructItinerary(IList<IList<string>> tickets)
        {
            var graph = new Dictionary<string, List<string>>();

            foreach (var ticket in tickets)
            {
                if (!graph.ContainsKey(ticket[0]))
                {
                    graph[ticket[0]] = new List<string>();
                }
                graph[ticket[0]].Add(ticket[1]);
            }

            foreach (var key in graph.Keys)
            {
                graph[key].Sort((a, b) => b.CompareTo(a));
            }

            var stack = new Stack<string>();
            stack.Push("JFK");
            var itinerary = new List<string>();

            while (stack.Count > 0)
            {
                string curr = stack.Peek();
                if (graph.ContainsKey(curr) && graph[curr].Count > 0)
                {
                    var next = graph[curr].Last();
                    graph[curr].RemoveAt(graph[curr].Count - 1);
                    stack.Push(next);
                }
                else
                {
                    itinerary.Add(stack.Pop());
                }
            }

            itinerary.Reverse();
            return itinerary;


            //// Not a solution as the problem involves Directed Graph
            //List<string> result = new List<string>();
            //IList<string> nextTicket = new List<string>();

            //for (var i = 0; i < tickets.Count; i++)
            //{
            //    if (tickets[i][0] == "JFK")
            //    {
            //        if(nextTicket.Count == 0)
            //        {
            //            nextTicket = tickets[i];
            //        }
            //        else
            //        {
            //            nextTicket = GetSmallerLexicalOrder(nextTicket, tickets[i]);
            //        }
            //    }
            //}

            ////Tickets are missing 'JFK'
            //if(nextTicket.Count == 0)
            //    return result;

            //result.Add(nextTicket[0]);
            //tickets.Remove(nextTicket);

            //while(tickets.Count > 1)
            //{
            //    for (var i = 0; i < tickets.Count; i++)
            //    {
            //        if (tickets[i][0] == nextTicket[1])
            //        {
            //            nextTicket = GetSmallerLexicalOrder(nextTicket, tickets[i]);
            //            result.Add(nextTicket[0]);
            //        }
            //    }
            //    tickets.Remove(nextTicket);
            //}

            //result.Add(nextTicket[1]);

            //return result;
        }

        private IList<string> GetSmallerLexicalOrder(IList<string> first, IList<string> second)
        {
            if (first[0] != second[0])
                return second;

            if(string.Compare(first[1], second[1]) > 0)
                return second;
            return first;
        }
    }
}
