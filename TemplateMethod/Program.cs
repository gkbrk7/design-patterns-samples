﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    // Bir metot içerisinde farklı operasyonlar ve o operasyonların içerisindeki her bir farklı işlem'i bir şablona almak için kullanılır.
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm scoringAlgorithm;

            Console.WriteLine("Mens");
            scoringAlgorithm = new MensScoringAlgorithm();
            Console.WriteLine(scoringAlgorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Womens");
            scoringAlgorithm = new WomensScoringAlgorithm();
            Console.WriteLine(scoringAlgorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Children");
            scoringAlgorithm = new ChildrensScoringAlgorithm();
            Console.WriteLine(scoringAlgorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));
        }
    }

    abstract class ScoringAlgorithm
    {
        // Template method olacak
        public int GenerateScore(int hits, TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score, reduction);
        }

        public abstract int CalculateOverallScore(int score, int reduction);
        public abstract int CalculateReduction(TimeSpan time);
        public abstract int CalculateBaseScore(int hits);
    }

    class MensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
    }

    class WomensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
    }
    class ChildrensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;

        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }
    }
}
