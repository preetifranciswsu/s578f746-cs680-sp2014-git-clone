/** RANDOMIZEDQUICKSORTCLASS CLASS
 * Author: Preeti Francis
 * WSU ID: S578F746
 * Course: CS560 
 * Sem: S2013
 * 
 * Description of Class : The RandomizedQuickSortClass is the class that contains the main program logic behind
 * the Quick Sort Application. 
 * It implements a randomized quick sort method where the pivot selection is done randomly before sorting. Doing 
 * this improves the chances of getting a balanced partition, thereby achieving a a running time T(n) = O(nlgn)
 * **/

using QuickSort_ProgAssignment.Interfaces;

namespace QuickSort_ProgAssignment.ProgramLogic
{
    class RandomizedQuickSortClass
    {
        private UtilityWrapper _utilityWrapper = new UtilityWrapper();

        //Function : Randomized partition -> Gets a random index in the range p and r
        // and exchanges the value at this index with the value at A[r]. After this,
        // a call is made to the OriginalPartition function.
        //Input : input Array A (int[]), start index p (int) and ending index r (int)
        //Output : Index of the pivot (int) 
        private int RandomizedPartion(int[] A, int p, int r)
        {
            int randomIndex = _utilityWrapper.GetRandomIndexInRange(p, r);

            if(r != randomIndex)
                ExchangeValues(A, r, randomIndex);

            return OriginalPartition(A, p, r);
        }

        //Function : Original partition function which chooses A[r] as the pivot
        // and places it at the correct location in the array.
        //Input : input Array A (int[]), start index p (int) and ending index r (int)
        //Output : Index of the pivot (int)
        private int OriginalPartition(int[] A, int p, int r)
        {
            int x = A[r];

            int i = p - 1;

            for (int j = p; j <= r-1; j++)
            {
                if (A[j] <= x)
                {
                    i++;

                    ExchangeValues(A, i, j);
                }
            }

            ExchangeValues(A, i + 1, r);

            return i + 1;
        }

        //Function : Randomized quicksort algorithm -> function that gets a pivot value
        // from the randomized partition function and works recursively on each partition 
        // to sort the array completely.
        //Inputs : input Array A (int[]) , start index p (int) and ending index r(int)
        public void RandomizedQuickSort(int[] A, int p, int r)
        {
            int q;

            if (p < r)
            {
                q = RandomizedPartion(A, p, r);
                
                RandomizedQuickSort(A, p, q - 1);

                RandomizedQuickSort(A, q + 1, r);
            }
        }

        //Function : Exchanges the values in array A between index1 and index2
        //Input : input Array A (int[]), index1 (int) and index 2 (int)
        private void ExchangeValues(int[] A, int index1, int index2)
        {
            int indexValue1 = A[index1];

            A[index1] = A[index2];

            A[index2] = indexValue1;
        }

    }
}
