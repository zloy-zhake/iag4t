using System;
using System.Collections.Generic;
using System.IO;

namespace iag4t
{
	public class AnswerGenerator
	{
		private string input_file;
		private string output_file;
		private int answers_count;
		List<string[]> input_lines;
		List<string[]> output_lines;

		public AnswerGenerator(string in_f,
		                       string out_f,
		                       int n_ans)
		{
			this.input_file = in_f;
			this.output_file = out_f;
			this.answers_count = n_ans;
			this.input_lines = new List<string[]>();
			this.output_lines = new List<string[]>();
		}

		public void Read_From_File()
		{
			// прочитать строки из файла в массив строк input_lines[][2]
			//{
			//	Q1,A1;
			// ...
			//	Qn,An;
			//}
			// если в процессе чтения встречена ошибка форматирования, вывести сообщение (номер строки, текст на это строке)

			string[] tmp_str_arr = File.ReadAllLines(this.input_file);

			for(int i = 0; i < tmp_str_arr.Length; i + 2)
			{
				this.input_lines.Add(new string[2] { tmp_str_arr[i], tmp_str_arr[i + 1] });
			}
		}
		
		void Generate_Answers()
		{
			// Создать массив output_lines[][6]
//{
//	Q1,A1,A-,A-,A-,A-;
// ...
//	Qn,An,A-,A-,A-,A-;
//}
// A- выбираются случайным образом из всех A, кроме правильного.

// If you just want to generate a random number that never repeats you could do something like this

	private Random rand = new Random();
private List<int> used = new List<int>;
protected int randomNonrepeating()
	{
		 int i = rand.next();
		 while(used.contains(i)){
		 		i = rand.next();
		 	}
		 	used.add(i);
		 	return i;
			 	}
			 	}

		}
		
		void Save_Tests_To_File()
		{
			// создать файл
// вывести в него массив output_lines
// закрыть файл
		}
	}
}