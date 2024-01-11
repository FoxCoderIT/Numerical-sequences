using System.Collections.Generic;
using System.Text;

namespace laba4
{
    internal class SequenceContainer
    {
        private List<AbsSequence> sequences = new List<AbsSequence>();

        public void AddSequence(AbsSequence sequence)
        {
            sequences.Add(sequence);
        }

        public void RemoveSequence(AbsSequence sequence)
        {
            sequences.Remove(sequence);
        }

        public void Clear() //клир для очистчки контейнера
        {
            sequences.Clear();
        }

        public string Calculate()
        {
            StringBuilder resultBuilder = new StringBuilder();

            for (int i = 0; i < sequences.Count; i++)
            {
                decimal sequenceSum = 0;

                foreach (var value in sequences[i].Values)
                {
                    sequenceSum += value;
                }

                resultBuilder.AppendLine($"Sum for sequence {i + 1}: {sequenceSum}");
            }

            return resultBuilder.ToString();
        }
    }

}
