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

			for(int i = 0; i < tmp_str_arr.Length; i = i + 2)
			{
				this.input_lines.Add(new string[2] { tmp_str_arr[i], tmp_str_arr[i + 1] });
			}
		}

		// TODO разбить метод на несколько служебных методов, а то большеват
		public void Generate_Answers()
		{
			// Создать массив output_lines[][6]
			//{
			//	Q1,A1,A-,A-,A-,A-;
			// ...
			//	Qn,An,A-,A-,A-,A-;
			//}
			// A- выбираются случайным образом из всех A, кроме правильного.

			// созадать массив всех ответов
			List<string> all_answers = new List<string>();
			foreach(var line in this.input_lines)
			{
				all_answers.Add(line[1]);
			}

			// скопировать в output_lines вопросы и правильные ответы
			foreach(var line in this.input_lines)
			{
				this.output_lines.Add(new string[6] { line[0], line[1], "", "", "", "" });
			}

			// добавить неправильные варианты ответов

			// временный массив для неправильных вариантов ответов
			// DELETE string[] tmp_incorrect_answers = new string[4]();
			List<int> answer_indexes = new List<int>();
			Random rand = new Random();

			int i, j, k, v;

			for(i = 0; i < this.output_lines.Count; ++i)
			{
				// подбираем индексы случайных ответов, исключая индекс правильного ответа
				for(j = 0; j < 4; ++j)
				{
					v = rand.Next(all_answers.Count);
					while((answer_indexes.Contains(v)) || (v == i))
					{
						v = rand.Next(all_answers.Count);
					}
					answer_indexes.Add(v);
				}

				// добавляем неверные варианты ответов в output_lines согласно подобранным индексам
				for(k = 0; k < 4; ++k)
				{
					this.output_lines[i][k + 2]	= all_answers[answer_indexes[k]];
				}

				answer_indexes.Clear();
			}
		}

		public void Save_Tests_To_File()
		{
			// вывести в файл массив output_lines

			if(!File.Exists(this.output_file))
			{
				foreach(var test in output_lines)
				{
					File.AppendAllLines(this.output_file, test);
					File.AppendAllText(this.output_file, "\n");
				}

			}
		}
	}
}
