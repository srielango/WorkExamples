using System.Collections;

namespace LeetCode
{
    public class CinemaSeatAllocation
    {
        public int MaxNumberOfFamilies(int n, int[][] reservedSeats)
        {
            Hashtable seatsStart = new Hashtable();

            for (int i = 0; i < reservedSeats.Length; i++)
            {
                int row = reservedSeats[i][0];
                int col = reservedSeats[i][1];

                if (!seatsStart.ContainsKey(row)) seatsStart.Add(row, new Hashtable());
                Hashtable seat = (Hashtable)seatsStart[row];

                if (col == 2 || col == 3)
                {
                    if (!seat.ContainsKey(2)) seat.Add(2, true);
                }
                else if (col == 4 || col == 5)
                {
                    if (!seat.ContainsKey(4)) seat.Add(4, true);
                    if (!seat.ContainsKey(2)) seat.Add(2, true);
                }
                else if (col == 6 || col == 7)
                {
                    if (!seat.ContainsKey(4)) seat.Add(4, true);
                    if (!seat.ContainsKey(6)) seat.Add(6, true);
                }
                else if (col == 8 || col == 9)
                {
                    if (!seat.ContainsKey(6)) seat.Add(6, true);
                }
            }

            int total = (n - seatsStart.Count) * 2;
            foreach (int key in seatsStart.Keys)
            {
                Hashtable seat = (Hashtable)seatsStart[key];
                if (seat.Count == 0) total += 2;
                else if (seat.Count < 3) total++;
            }

            return total;
        }
    }
}
