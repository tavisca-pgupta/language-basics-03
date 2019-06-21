using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            //Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
		   int[] calorie = new int[protein.Length];
		   int[] result = new int[dietPlans.Length];
		   //List<int> indexes = new List<int>();
		   
		  
		   for(int i=0;i<protein.Length;i++)
		   {
			   calorie[i]=(protein[i]+carbs[i])*5 + fat[i]*9;
		   }
		   
		   for(int i=0;i<dietPlans.Length;i++)
		   {
			   if(dietPlans[i]=="")
			   {
				   result[i] = 0;
			   }
			   else
			   {
				   result[i]=findResult(protein,carbs,fat,calorie,dietPlans[i],new List<int>());
			   }
		   }
		   
		   return result;
        }
		public static int findResult(int[] protein,int[] carbs,int[] fat,int[] calorie,string dietPlan,List<int> indexes)
		{	
			try
			{
				if(dietPlan.Length>0)
				{
					switch(dietPlan[0])
					{
						case 'P' :  indexes=findMaxIndexes(protein,indexes);
									if(indexes.Count>1)
										return findResult(protein,carbs,fat,calorie,dietPlan.Substring(1),indexes);
									else
										return indexes[0];
						case 'p' :  indexes=findMinIndexes(protein,indexes);
									if(indexes.Count>1)
										return findResult(protein,carbs,fat,calorie,dietPlan.Substring(1),indexes);
									else
										return indexes[0];
						case 'C' :  indexes=findMaxIndexes(carbs,indexes);
									if(indexes.Count>1)
										return findResult(protein,carbs,fat,calorie,dietPlan.Substring(1),indexes);
									else
										return indexes[0];
						case 'c' :  indexes=findMinIndexes(carbs,indexes);
									if(indexes.Count>1)
										return findResult(protein,carbs,fat,calorie,dietPlan.Substring(1),indexes);
									else
										return indexes[0];
						case 'F' :  indexes=findMaxIndexes(fat,indexes);
									if(indexes.Count>1)
										return findResult(protein,carbs,fat,calorie,dietPlan.Substring(1),indexes);
									else
										return indexes[0];
						case 'f' :  indexes=findMinIndexes(fat,indexes);
									if(indexes.Count>1)
										return findResult(protein,carbs,fat,calorie,dietPlan.Substring(1),indexes);
									else
										return indexes[0];
						case 'T' :  indexes=findMaxIndexes(calorie,indexes);
									if(indexes.Count>1)
										return findResult(protein,carbs,fat,calorie,dietPlan.Substring(1),indexes);
									else
										return indexes[0];
						case 't' :  indexes=findMinIndexes(calorie,indexes);
									if(indexes.Count>1)
										return findResult(protein,carbs,fat,calorie,dietPlan.Substring(1),indexes);
									else
										return indexes[0];
									
					}
				}
				else
					return indexes[0];
			
			}
			catch(ArgumentOutOfRangeException e)
			{
				Console.WriteLine(e.Message);
			}
			return 0;
		}
		public static List<int> findMaxIndexes(int[] item,List<int> indexes)
		{
			int max,i;
			List<int> indexes2 = new List<int>();
			
			if(indexes.Count>0)
			{
				max=item[indexes[0]];
				foreach(int index in indexes)
				{
					if(max<item[index])
						max=item[index];
				}
				foreach(int index in indexes)
				{
					if(max==item[index])
						indexes2.Add(index);
				}
				
			}
			else
			{
				max=item[0];
				for(i=1;i<item.Length;i++)
				{
					if(max<item[i])
						max=item[i];
				}
				for(i=0;i<item.Length;i++)
				{
					if(max==item[i])
						indexes2.Add(i);
				}
			}
			
			return indexes2;
		
		}
		
		public static List<int> findMinIndexes(int[] item,List<int> indexes)
		{
			int min,i;
			List<int> indexes2 = new List<int>();
			
			if(indexes.Count>0)
			{
				min=item[indexes[0]];
				foreach(int index in indexes)
				{
					if(min>item[index])
						min=item[index];
				}
				foreach(int index in indexes)
				{
					if(min==item[index])
						indexes2.Add(index);
				}
				
			}
			else
			{
				min=item[0];
				for(i=1;i<item.Length;i++)
				{
					if(min>item[i])
						min=item[i];
				}
				for(i=0;i<item.Length;i++)
				{
					if(min==item[i])
						indexes2.Add(i);
				}
			}
			
			return indexes2;
		
		}
    }
}
