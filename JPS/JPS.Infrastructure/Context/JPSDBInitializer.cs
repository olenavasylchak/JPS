using JPS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace JPS.Infrastructure.Context
{
	/// <summary>
	/// Class for seeding and another itermediate methods.
	/// </summary>
	public static class JPSDBInitializer
	{
		/// <summary>
		/// Fill database with users, categories, question types,
		/// polls, question sections, questions, options, option rows,
		/// answers, date answers, time answers, text answers, 
		/// paragraph answers, option answers.
		/// </summary>
		/// <param name="modelbuilder">Should get that parameter from DbContext.</param>
		public static void InitializeDB(ModelBuilder modelbuilder)
		{
			modelbuilder.Entity<CategoryEntity>().HasData(GetCategories());
			modelbuilder.Entity<QuestionTypeEntity>().HasData(GetQuestionTypes());

			modelbuilder.Entity<PollEntity>().HasData(GetPolls());

			modelbuilder.Entity<QuestionSectionEntity>().HasData(GetQuestionSections());
			modelbuilder.Entity<QuestionEntity>().HasData(GetQuestions());
			modelbuilder.Entity<OptionEntity>().HasData(GetOptions());
			modelbuilder.Entity<OptionRowEntity>().HasData(GetOptionRows());

			modelbuilder.Entity<AnswerEntity>().HasData(GetAnswers());
			modelbuilder.Entity<DateAnswerEntity>().HasData(GetDateAnswers());
			modelbuilder.Entity<TimeAnswerEntity>().HasData(GetTimeAnswers());
			modelbuilder.Entity<TextAnswerEntity>().HasData(GetTextAnswers());
			modelbuilder.Entity<ParagraphAnswerEntity>().HasData(GetParagraphAnswers());

			modelbuilder.Entity<OptionAnswerEntity>().HasData(GetOptionAnswers());
		}

		private static IEnumerable<OptionAnswerEntity> GetOptionAnswers()
		{
			var optionAnswers = new List<OptionAnswerEntity>();
			optionAnswers.Add(new OptionAnswerEntity { Id = 1, AnswerId = 1, OptionId = 1 });
			optionAnswers.Add(new OptionAnswerEntity { Id = 2, AnswerId = 12, OptionId = 1 });
			optionAnswers.Add(new OptionAnswerEntity { Id = 3, AnswerId = 2, OptionId = 4 });
			optionAnswers.Add(new OptionAnswerEntity { Id = 4, AnswerId = 13, OptionId = 4 });
			optionAnswers.Add(new OptionAnswerEntity { Id = 5, AnswerId = 23, OptionId = 3 });
			optionAnswers.Add(new OptionAnswerEntity { Id = 6, AnswerId = 3, OptionId = 5 });
			optionAnswers.Add(new OptionAnswerEntity { Id = 7, AnswerId = 14, OptionId = 6 });
			optionAnswers.Add(new OptionAnswerEntity { Id = 8, AnswerId = 7, OptionId = 8 });
			optionAnswers.Add(new OptionAnswerEntity { Id = 9, AnswerId = 18, OptionId = 7 });
			optionAnswers.Add(new OptionAnswerEntity { Id = 10, AnswerId = 8, OptionId = 9, OptionRowId = 1 });
			optionAnswers.Add(new OptionAnswerEntity { Id = 11, AnswerId = 19, OptionId = 10, OptionRowId = 2 });
			optionAnswers.Add(new OptionAnswerEntity { Id = 12, AnswerId = 9, OptionId = 12, OptionRowId = 1 });
			optionAnswers.Add(new OptionAnswerEntity { Id = 13, AnswerId = 20, OptionId = 11, OptionRowId = 2 });
			optionAnswers.Add(new OptionAnswerEntity { Id = 14, AnswerId = 24, OptionId = 12, OptionRowId = 2 });
			//first user
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 15,
				AnswerId = 27,
				OptionId = 13
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 16,
				AnswerId = 37,
				OptionId = 38
			});

			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 17,
				AnswerId = 28,
				OptionId = 19
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 18,
				AnswerId = 38,
				OptionId = 42
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 19,
				AnswerId = 38,
				OptionId = 43
			});

			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 20,
				AnswerId = 29,
				OptionId = 22
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 21,
				AnswerId = 39,
				OptionId = 46
			});

			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 22,
				AnswerId = 31,
				OptionId = 29
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 23,
				AnswerId = 41,
				OptionId = 54
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 24,
				AnswerId = 32,
				OptionId = 31,
				OptionRowId = 7
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 25,
				AnswerId = 32,
				OptionId = 31,
				OptionRowId = 8
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 26,
				AnswerId = 32,
				OptionId = 32,
				OptionRowId = 9
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 27,
				AnswerId = 42,
				OptionId = 57,
				OptionRowId = 13
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 28,
				AnswerId = 42,
				OptionId = 55,
				OptionRowId = 14
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 29,
				AnswerId = 42,
				OptionId = 55,
				OptionRowId = 14
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 30,
				AnswerId = 33,
				OptionId = 34,
				OptionRowId = 10
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 31,
				AnswerId = 33,
				OptionId = 35,
				OptionRowId = 11
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 32,
				AnswerId = 33,
				OptionId = 36,
				OptionRowId = 12
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 33,
				AnswerId = 43,
				OptionId = 58,
				OptionRowId = 16
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 34,
				AnswerId = 43,
				OptionId = 58,
				OptionRowId = 17
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 35,
				AnswerId = 43,
				OptionId = 60,
				OptionRowId = 18
			});

			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 36,
				AnswerId = 47,
				OptionId = 15
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 37,
				AnswerId = 57,
				OptionId = 39
			});

			//2nd user
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 38,
				AnswerId = 48,
				OptionId = 20
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 39,
				AnswerId = 58,
				OptionId = 43
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 40,
				AnswerId = 48,
				OptionId = 43
			});

			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 41,
				AnswerId = 49,
				OptionId = 24
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 42,
				AnswerId = 59,
				OptionId = 45
			});

			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 43,
				AnswerId = 51,
				OptionId = 29
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 44,
				AnswerId = 61,
				OptionId = 54
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 45,
				AnswerId = 52,
				OptionId = 32,
				OptionRowId = 7
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 46,
				AnswerId = 52,
				OptionId = 33,
				OptionRowId = 8
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 47,
				AnswerId = 52,
				OptionId = 32,
				OptionRowId = 9
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 48,
				AnswerId = 62,
				OptionId = 57,
				OptionRowId = 13
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 49,
				AnswerId = 62,
				OptionId = 56,
				OptionRowId = 14
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 50,
				AnswerId = 62,
				OptionId = 56,
				OptionRowId = 15
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 51,
				AnswerId = 53,
				OptionId = 35,
				OptionRowId = 10
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 52,
				AnswerId = 53,
				OptionId = 35,
				OptionRowId = 11
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 53,
				AnswerId = 53,
				OptionId = 34,
				OptionRowId = 12
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 54,
				AnswerId = 63,
				OptionId = 59,
				OptionRowId = 16
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 55,
				AnswerId = 63,
				OptionId = 59,
				OptionRowId = 17
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 56,
				AnswerId = 63,
				OptionId = 60,
				OptionRowId = 18
			});

			//3rd user
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 57,
				AnswerId = 67,
				OptionId = 17
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 58,
				AnswerId = 77,
				OptionId = 37
			});

			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 59,
				AnswerId = 68,
				OptionId = 19
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 60,
				AnswerId = 78,
				OptionId = 44
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 61,
				AnswerId = 68,
				OptionId = 43
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 62,
				AnswerId = 69,
				OptionId = 22
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 63,
				AnswerId = 79,
				OptionId = 45
			});

			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 64,
				AnswerId = 71,
				OptionId = 30
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 65,
				AnswerId = 81,
				OptionId = 52
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 66,
				AnswerId = 72,
				OptionId = 32,
				OptionRowId = 7
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 67,
				AnswerId = 72,
				OptionId = 31,
				OptionRowId = 8
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 68,
				AnswerId = 72,
				OptionId = 31,
				OptionRowId = 9
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 69,
				AnswerId = 82,
				OptionId = 56,
				OptionRowId = 13
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 70,
				AnswerId = 82,
				OptionId = 55,
				OptionRowId = 14
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 71,
				AnswerId = 82,
				OptionId = 55,
				OptionRowId = 15
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 72,
				AnswerId = 73,
				OptionId = 35,
				OptionRowId = 10
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 73,
				AnswerId = 73,
				OptionId = 35,
				OptionRowId = 11
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 74,
				AnswerId = 73,
				OptionId = 34,
				OptionRowId = 12
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 75,
				AnswerId = 83,
				OptionId = 59,
				OptionRowId = 16
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 76,
				AnswerId = 83,
				OptionId = 59,
				OptionRowId = 17
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 77,
				AnswerId = 83,
				OptionId = 60,
				OptionRowId = 18
			});

			//4th user
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 78,
				AnswerId = 87,
				OptionId = 17
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 79,
				AnswerId = 97,
				OptionId = 37
			});

			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 80,
				AnswerId = 88,
				OptionId = 19
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 81,
				AnswerId = 98,
				OptionId = 44
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 82,
				AnswerId = 88,
				OptionId = 43
			});

			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 83,
				AnswerId = 89,
				OptionId = 22
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 84,
				AnswerId = 99,
				OptionId = 45
			});

			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 85,
				AnswerId = 91,
				OptionId = 30
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 86,
				AnswerId = 101,
				OptionId = 52
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 87,
				AnswerId = 92,
				OptionId = 32,
				OptionRowId = 7
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 88,
				AnswerId = 92,
				OptionId = 31,
				OptionRowId = 8
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 89,
				AnswerId = 92,
				OptionId = 31,
				OptionRowId = 9
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 90,
				AnswerId = 102,
				OptionId = 56,
				OptionRowId = 13
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 91,
				AnswerId = 102,
				OptionId = 55,
				OptionRowId = 14
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 92,
				AnswerId = 102,
				OptionId = 55,
				OptionRowId = 15
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 93,
				AnswerId = 93,
				OptionId = 35,
				OptionRowId = 10
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 94,
				AnswerId = 93,
				OptionId = 35,
				OptionRowId = 11
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 95,
				AnswerId = 93,
				OptionId = 34,
				OptionRowId = 12
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 96,
				AnswerId = 103,
				OptionId = 59,
				OptionRowId = 16
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 97,
				AnswerId = 103,
				OptionId = 59,
				OptionRowId = 17
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 98,
				AnswerId = 103,
				OptionId = 60,
				OptionRowId = 18
			});

			//5th user
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 99,
				AnswerId = 107,
				OptionId = 13
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 100,
				AnswerId = 117,
				OptionId = 38
			});

			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 101,
				AnswerId = 108,
				OptionId = 19
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 102,
				AnswerId = 118,
				OptionId = 42
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 103,
				AnswerId = 118,
				OptionId = 43
			});

			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 104,
				AnswerId = 109,
				OptionId = 22
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 105,
				AnswerId = 119,
				OptionId = 46
			});

			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 106,
				AnswerId = 111,
				OptionId = 29
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 107,
				AnswerId = 121,
				OptionId = 54
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 108,
				AnswerId = 112,
				OptionId = 31,
				OptionRowId = 7
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 109,
				AnswerId = 112,
				OptionId = 31,
				OptionRowId = 8
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 110,
				AnswerId = 112,
				OptionId = 32,
				OptionRowId = 9
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 111,
				AnswerId = 122,
				OptionId = 57,
				OptionRowId = 13
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 112,
				AnswerId = 122,
				OptionId = 55,
				OptionRowId = 14
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 113,
				AnswerId = 122,
				OptionId = 55,
				OptionRowId = 14
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 114,
				AnswerId = 113,
				OptionId = 34,
				OptionRowId = 10
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 115,
				AnswerId = 113,
				OptionId = 35,
				OptionRowId = 11
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 116,
				AnswerId = 113,
				OptionId = 36,
				OptionRowId = 12
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 117,
				AnswerId = 123,
				OptionId = 58,
				OptionRowId = 16
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 118,
				AnswerId = 123,
				OptionId = 58,
				OptionRowId = 17
			});
			optionAnswers.Add(new OptionAnswerEntity
			{
				Id = 119,
				AnswerId = 123,
				OptionId = 60,
				OptionRowId = 18
			});

			return optionAnswers;
		}

		private static IEnumerable<OptionEntity> GetOptions()
		{
			var options = new List<OptionEntity>();
			options.Add(new OptionEntity { Id = 1, QuestionId = 1, Text = "option 1", Order = 1 });
			options.Add(new OptionEntity { Id = 2, QuestionId = 1, Text = "option 2", Order = 2 });
			options.Add(new OptionEntity { Id = 3, QuestionId = 2, Text = "option 1", Order = 2 });
			options.Add(new OptionEntity { Id = 4, QuestionId = 2, Text = "option 2", Order = 1 });
			options.Add(new OptionEntity { Id = 5, QuestionId = 3, Text = "option 1", Order = 1 });
			options.Add(new OptionEntity { Id = 6, QuestionId = 3, Text = "option 2", Order = 2 });
			options.Add(new OptionEntity { Id = 7, QuestionId = 7, Text = "option 1", Order = 1, Value = 1 });
			options.Add(new OptionEntity { Id = 8, QuestionId = 7, Text = "option 2", Order = 2, Value = 2 });
			options.Add(new OptionEntity { Id = 9, QuestionId = 8, Text = "option 1", Order = 2 });
			options.Add(new OptionEntity { Id = 10, QuestionId = 8, Text = "option 2", Order = 1 });
			options.Add(new OptionEntity { Id = 11, QuestionId = 9, Text = "option 1", Order = 1 });
			options.Add(new OptionEntity { Id = 12, QuestionId = 9, Text = "option 2", Order = 2 });
			options.Add(
				new OptionEntity
				{
					Id = 13,
					QuestionId = 14,
					Text = "Згоден",
					Order = 1
				});
			options.Add(
				new OptionEntity
				{
					Id = 14,
					QuestionId = 14,
					Text = "В прицнипі згоден",
					Order = 2
				});
			options.Add(
				new OptionEntity
				{
					Id = 15,
					QuestionId = 14,
					Text = "Важко сказати, не можу визначитись",
					Order = 3
				});
			options.Add(
				new OptionEntity
				{
					Id = 16,
					QuestionId = 14,
					Text = "Не зовсім згоден",
					Order = 4
				}); options.Add(
				new OptionEntity
				{
					Id = 17,
					QuestionId = 14,
					Text = "Не згоден",
					Order = 5
				});

			options.Add(
				new OptionEntity
				{
					Id = 18,
					QuestionId = 15,
					Text = "Чистота",
					Order = 1
				});
			options.Add(
				new OptionEntity
				{
					Id = 19,
					QuestionId = 15,
					Text = "Менеджмент",
					Order = 2
				}); options.Add(
				new OptionEntity
				{
					Id = 20,
					QuestionId = 15,
					Text = "Матеріальна компенсація",
					Order = 3
				});

			options.Add(
				new OptionEntity
				{
					Id = 21,
					QuestionId = 16,
					Text = "Згоден",
					Order = 1
				});
			options.Add(
				new OptionEntity
				{
					Id = 22,
					QuestionId = 16,
					Text = "В прицнипі згоден",
					Order = 2
				});
			options.Add(
				new OptionEntity
				{
					Id = 23,
					QuestionId = 16,
					Text = "Важко сказати, не можу визначитись",
					Order = 3
				});
			options.Add(
				new OptionEntity
				{
					Id = 24,
					QuestionId = 16,
					Text = "Не зовсім згоден",
					Order = 4
				}); options.Add(
				new OptionEntity
				{
					Id = 25,
					QuestionId = 16,
					Text = "Не згоден",
					Order = 5
				});

			options.Add(
				new OptionEntity
				{
					Id = 26,
					QuestionId = 18,
					Value = 1,
					Order = 1
				});
			options.Add(
				new OptionEntity
				{
					Id = 27,
					QuestionId = 18,
					Value = 2,
					Order = 2
				});
			options.Add(
				new OptionEntity
				{
					Id = 28,
					QuestionId = 18,
					Value = 3,
					Order = 3
				});
			options.Add(
				new OptionEntity
				{
					Id = 29,
					QuestionId = 18,
					Value = 4,
					Order = 4
				}); options.Add(
				new OptionEntity
				{
					Id = 30,
					QuestionId = 18,
					Value = 5,
					Order = 5
				});

			options.Add(
				new OptionEntity
				{
					Id = 31,
					QuestionId = 19,
					Text = "Добре",
					Order = 1
				});
			options.Add(
				new OptionEntity
				{
					Id = 32,
					QuestionId = 19,
					Text = "Нормально",
					Order = 2
				});
			options.Add(
				new OptionEntity
				{
					Id = 33,
					QuestionId = 19,
					Text = "Погано",
					Order = 3
				});

			options.Add(
				new OptionEntity
				{
					Id = 34,
					QuestionId = 20,
					Text = "Умови",
					Order = 1
				});
			options.Add(
				new OptionEntity
				{
					Id = 35,
					QuestionId = 20,
					Text = "Зарплата",
					Order = 2
				});
			options.Add(
				new OptionEntity
				{
					Id = 36,
					QuestionId = 20,
					Text = "Менеджмент",
					Order = 3
				});

			options.Add(
				new OptionEntity
				{
					Id = 37,
					QuestionId = 24,
					Text = "Згоден",
					Order = 1
				});
			options.Add(
				new OptionEntity
				{
					Id = 38,
					QuestionId = 24,
					Text = "В прицнипі згоден",
					Order = 2
				});
			options.Add(
				new OptionEntity
				{
					Id = 39,
					QuestionId = 24,
					Text = "Важко сказати, не можу визначитись",
					Order = 3
				});
			options.Add(
				new OptionEntity
				{
					Id = 40,
					QuestionId = 24,
					Text = "Не зовсім згоден",
					Order = 4
				}); options.Add(
				new OptionEntity
				{
					Id = 41,
					QuestionId = 24,
					Text = "Не згоден",
					Order = 5
				});

			options.Add(
				new OptionEntity
				{
					Id = 42,
					QuestionId = 25,
					Text = "Мотивації",
					Order = 1
				});
			options.Add(
				new OptionEntity
				{
					Id = 43,
					QuestionId = 25,
					Text = "Свободи дій",
					Order = 2
				}); options.Add(
				new OptionEntity
				{
					Id = 44,
					QuestionId = 25,
					Text = "Чвсу",
					Order = 3
				});

			options.Add(
				new OptionEntity
				{
					Id = 45,
					QuestionId = 26,
					Text = "Згоден",
					Order = 1
				});
			options.Add(
				new OptionEntity
				{
					Id = 46,
					QuestionId = 26,
					Text = "В прицнипі згоден",
					Order = 2
				});
			options.Add(
				new OptionEntity
				{
					Id = 47,
					QuestionId = 26,
					Text = "Важко сказати, не можу визначитись",
					Order = 3
				});
			options.Add(
				new OptionEntity
				{
					Id = 48,
					QuestionId = 26,
					Text = "Не зовсім згоден",
					Order = 4
				}); options.Add(
				new OptionEntity
				{
					Id = 49,
					QuestionId = 26,
					Text = "Не згоден",
					Order = 5
				});

			options.Add(
				new OptionEntity
				{
					Id = 50,
					QuestionId = 28,
					Value = 1,
					Order = 1
				});
			options.Add(
				new OptionEntity
				{
					Id = 51,
					QuestionId = 28,
					Value = 2,
					Order = 2
				});
			options.Add(
				new OptionEntity
				{
					Id = 52,
					QuestionId = 28,
					Value = 3,
					Order = 3
				});
			options.Add(
				new OptionEntity
				{
					Id = 53,
					QuestionId = 28,
					Value = 4,
					Order = 4
				}); options.Add(
				new OptionEntity
				{
					Id = 54,
					QuestionId = 28,
					Value = 5,
					Order = 5
				});

			options.Add(
				new OptionEntity
				{
					Id = 55,
					QuestionId = 29,
					Text = "Добре",
					Order = 1
				});
			options.Add(
				new OptionEntity
				{
					Id = 56,
					QuestionId = 29,
					Text = "Нормально",
					Order = 2
				});
			options.Add(
				new OptionEntity
				{
					Id = 57,
					QuestionId = 29,
					Text = "Погано",
					Order = 3
				});

			options.Add(
				new OptionEntity
				{
					Id = 58,
					QuestionId = 30,
					Text = "Умови",
					Order = 1
				});
			options.Add(
				new OptionEntity
				{
					Id = 59,
					QuestionId = 30,
					Text = "Зарплата",
					Order = 2
				});
			options.Add(
				new OptionEntity
				{
					Id = 60,
					QuestionId = 30,
					Text = "Менеджмент",
					Order = 3
				});

			return options;
		}

		private static IEnumerable<OptionRowEntity> GetOptionRows()
		{
			var optionRows = new List<OptionRowEntity>();
			optionRows.Add(new OptionRowEntity
			{
				Id = 1,
				QuestionId = 8,
				Text = "optionRow 1",
				Order = 1
			});
			optionRows.Add(new OptionRowEntity
			{
				Id = 2,
				QuestionId = 8,
				Text = "optionRow 2",
				Order = 2
			});
			optionRows.Add(new OptionRowEntity
			{
				Id = 3,
				QuestionId = 8,
				Text = "optionRow 3",
				Order = 3
			});
			optionRows.Add(new OptionRowEntity
			{
				Id = 4,
				QuestionId = 9,
				Text = "optionRow 1",
				Order = 1
			});
			optionRows.Add(new OptionRowEntity
			{
				Id = 5,
				QuestionId = 9,
				Text = "optionRow 2",
				Order = 2
			});
			optionRows.Add(new OptionRowEntity
			{
				Id = 6,
				QuestionId = 9,
				Text = "optionRow 3",
				Order = 3
			});

			optionRows.Add(new OptionRowEntity
			{
				Id = 7,
				QuestionId = 19,
				Text = "Температура",
				Order = 1
			});
			optionRows.Add(new OptionRowEntity
			{
				Id = 8,
				QuestionId = 19,
				Text = "Вентиляція",
				Order = 2
			});
			optionRows.Add(new OptionRowEntity
			{
				Id = 9,
				QuestionId = 19,
				Text = "Освітлення",
				Order = 3
			});

			optionRows.Add(new OptionRowEntity
			{
				Id = 10,
				QuestionId = 20,
				Text = "Задоволений",
				Order = 1
			});
			optionRows.Add(new OptionRowEntity
			{
				Id = 11,
				QuestionId = 20,
				Text = "Важко сказати",
				Order = 2
			});
			optionRows.Add(new OptionRowEntity
			{
				Id = 12,
				QuestionId = 20,
				Text = "Не задоволений",
				Order = 3
			});

			optionRows.Add(new OptionRowEntity
			{
				Id = 13,
				QuestionId = 29,
				Text = "Атмосфера",
				Order = 1
			});
			optionRows.Add(new OptionRowEntity
			{
				Id = 14,
				QuestionId = 29,
				Text = "Взаємодопомого",
				Order = 2
			});
			optionRows.Add(new OptionRowEntity
			{
				Id = 15,
				QuestionId = 29,
				Text = "Дружність",
				Order = 3
			});

			optionRows.Add(new OptionRowEntity
			{
				Id = 16,
				QuestionId = 30,
				Text = "Задоволений",
				Order = 1
			});
			optionRows.Add(new OptionRowEntity
			{
				Id = 17,
				QuestionId = 30,
				Text = "Важко сказати",
				Order = 2
			});
			optionRows.Add(new OptionRowEntity
			{
				Id = 18,
				QuestionId = 30,
				Text = "Не задоволений",
				Order = 3
			});
			return optionRows;
		}

		private static IEnumerable<ParagraphAnswerEntity> GetParagraphAnswers()
		{
			var paragraphAnswers = new List<ParagraphAnswerEntity>();
			paragraphAnswers.Add(new ParagraphAnswerEntity
			{
				AnswerId = 10,
				Text = "Paragraph answer here"
			});
			paragraphAnswers.Add(new ParagraphAnswerEntity
			{
				AnswerId = 21,
				Text = "Paragraph answer here"
			});

			paragraphAnswers.Add(new ParagraphAnswerEntity
			{
				AnswerId = 26,
				Text = "Гарантія стабільності"
			});
			paragraphAnswers.Add(new ParagraphAnswerEntity
			{
				AnswerId = 36,
				Text = "Мої друзі"
			});

			paragraphAnswers.Add(new ParagraphAnswerEntity
			{
				AnswerId = 46,
				Text = "Опора в житті."
			});
			paragraphAnswers.Add(new ParagraphAnswerEntity
			{
				AnswerId = 56,
				Text = "колектив, який завжди готовий допомогти."
			});

			paragraphAnswers.Add(new ParagraphAnswerEntity
			{
				AnswerId = 66,
				Text = "Стимул розвиватися."
			});
			paragraphAnswers.Add(new ParagraphAnswerEntity
			{
				AnswerId = 76,
				Text = "друга сім'я."
			});

			paragraphAnswers.Add(new ParagraphAnswerEntity
			{
				AnswerId = 86,
				Text = "Пасхалка, єбать."
			});
			paragraphAnswers.Add(new ParagraphAnswerEntity
			{
				AnswerId = 96,
				Text = "Число сорок два(осмислена відповідь)."
			});

			paragraphAnswers.Add(new ParagraphAnswerEntity
			{
				AnswerId = 106,
				Text = "Прогрес."
			});
			paragraphAnswers.Add(new ParagraphAnswerEntity
			{
				AnswerId = 116,
				Text = "це мої колєги."
			});

			return paragraphAnswers;
		}

		private static IEnumerable<TextAnswerEntity> GetTextAnswers()
		{
			var textAnswers = new List<TextAnswerEntity>();
			textAnswers.Add(new TextAnswerEntity
			{
				AnswerId = 6,
				Text = "Something"
			});
			textAnswers.Add(new TextAnswerEntity
			{
				AnswerId = 17,
				Text = "Something 2"
			});

			textAnswers.Add(new TextAnswerEntity
			{
				AnswerId = 25,
				Text = "Я б хотів збільшити температуру в офісі."
			});
			textAnswers.Add(new TextAnswerEntity
			{
				AnswerId = 35,
				Text = "Мене все влаштовує."
			});

			textAnswers.Add(new TextAnswerEntity
			{
				AnswerId = 45,
				Text = "Я б хотів збільшити вологість в офісі."
			});
			textAnswers.Add(new TextAnswerEntity
			{
				AnswerId = 55,
				Text = "Важко сказати."
			});

			textAnswers.Add(new TextAnswerEntity
			{
				AnswerId = 65,
				Text = "У мене немає побажань."
			});

			textAnswers.Add(new TextAnswerEntity
			{
				AnswerId = 85,
				Text = "Все чудово."
			});
			textAnswers.Add(new TextAnswerEntity
			{
				AnswerId = 95,
				Text = "Мене все влаштовує."
			});

			textAnswers.Add(new TextAnswerEntity
			{
				AnswerId = 105,
				Text = "Зремонтуйте стілець."
			});
			textAnswers.Add(new TextAnswerEntity
			{
				AnswerId = 115,
				Text = "Все збс."
			});

			return textAnswers;
		}

		private static IEnumerable<TimeAnswerEntity> GetTimeAnswers()
		{
			var timeAnswers = new List<TimeAnswerEntity>();
			timeAnswers.Add(new TimeAnswerEntity
			{
				AnswerId = 11,
				Time = new TimeSpan(9, 0, 0)
			});
			timeAnswers.Add(new TimeAnswerEntity
			{
				AnswerId = 22,
				Time = new TimeSpan(12, 0, 0)
			});
			timeAnswers.Add(new TimeAnswerEntity
			{
				AnswerId = 30,
				Time = new TimeSpan(12, 0, 0)
			});
			timeAnswers.Add(new TimeAnswerEntity
			{
				AnswerId = 40,
				Time = new TimeSpan(16, 0, 0)
			});

			timeAnswers.Add(new TimeAnswerEntity
			{
				AnswerId = 50,
				Time = new TimeSpan(12, 0, 0)
			});
			timeAnswers.Add(new TimeAnswerEntity
			{
				AnswerId = 60,
				Time = new TimeSpan(16, 0, 0)
			});

			timeAnswers.Add(new TimeAnswerEntity
			{
				AnswerId = 70,
				Time = new TimeSpan(10, 0, 0)
			});
			timeAnswers.Add(new TimeAnswerEntity
			{
				AnswerId = 80,
				Time = new TimeSpan(15, 0, 0)
			});

			timeAnswers.Add(new TimeAnswerEntity
			{
				AnswerId = 90,
				Time = new TimeSpan(8, 0, 0)
			});
			timeAnswers.Add(new TimeAnswerEntity
			{
				AnswerId = 100,
				Time = new TimeSpan(12, 0, 0)
			});

			timeAnswers.Add(new TimeAnswerEntity
			{
				AnswerId = 110,
				Time = new TimeSpan(12, 0, 0)
			});
			timeAnswers.Add(new TimeAnswerEntity
			{
				AnswerId = 120,
				Time = new TimeSpan(16, 0, 0)
			});
			return timeAnswers;
		}

		private static IEnumerable<DateAnswerEntity> GetDateAnswers()
		{
			var dateAnswers = new List<DateAnswerEntity>();
			dateAnswers.Add(new DateAnswerEntity
			{
				AnswerId = 16,
				Date = new DateTimeOffset(1990, 1, 1, 0, 0, 0, TimeSpan.FromHours(3))
			});
			dateAnswers.Add(new DateAnswerEntity
			{
				AnswerId = 5,
				Date = new DateTimeOffset(1995, 10, 10, 0, 0, 0, TimeSpan.FromHours(3))
			});

			dateAnswers.Add(new DateAnswerEntity
			{
				AnswerId = 34,
				Date = new DateTimeOffset(2020, 6, 1, 0, 0, 0, TimeSpan.FromHours(3))
			});
			dateAnswers.Add(new DateAnswerEntity
			{
				AnswerId = 44,
				Date = new DateTimeOffset(2020, 6, 10, 0, 0, 0, TimeSpan.FromHours(3))
			});

			dateAnswers.Add(new DateAnswerEntity
			{
				AnswerId = 54,
				Date = new DateTimeOffset(2020, 6, 1, 0, 0, 0, TimeSpan.FromHours(3))
			});
			dateAnswers.Add(new DateAnswerEntity
			{
				AnswerId = 64,
				Date = new DateTimeOffset(2020, 6, 15, 0, 0, 0, TimeSpan.FromHours(3))
			});

			dateAnswers.Add(new DateAnswerEntity
			{
				AnswerId = 74,
				Date = new DateTimeOffset(2020, 6, 2, 0, 0, 0, TimeSpan.FromHours(3))
			});
			dateAnswers.Add(new DateAnswerEntity
			{
				AnswerId = 84,
				Date = new DateTimeOffset(2020, 6, 1, 0, 0, 0, TimeSpan.FromHours(3))
			});

			dateAnswers.Add(new DateAnswerEntity
			{
				AnswerId = 94,
				Date = new DateTimeOffset(2020, 6, 3, 0, 0, 0, TimeSpan.FromHours(3))
			});
			dateAnswers.Add(new DateAnswerEntity
			{
				AnswerId = 104,
				Date = new DateTimeOffset(2020, 6, 10, 0, 0, 0, TimeSpan.FromHours(3))
			});

			dateAnswers.Add(new DateAnswerEntity
			{
				AnswerId = 114,
				Date = new DateTimeOffset(2020, 6, 1, 0, 0, 0, TimeSpan.FromHours(3))
			});
			dateAnswers.Add(new DateAnswerEntity
			{
				AnswerId = 124,
				Date = new DateTimeOffset(2020, 6, 10, 0, 0, 0, TimeSpan.FromHours(3))
			});
			return dateAnswers;
		}

		private static IEnumerable<AnswerEntity> GetAnswers()
		{
			var answers = new List<AnswerEntity>();
			answers.Add(new AnswerEntity
			{
				Id = 1,
				UserId = "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2",
				QuestionId = 1
			});
			answers.Add(new AnswerEntity
			{
				Id = 2,
				UserId = "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2",
				QuestionId = 2
			});
			answers.Add(new AnswerEntity
			{
				Id = 3,
				UserId = "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2",
				QuestionId = 3
			});
			answers.Add(new AnswerEntity
			{
				Id = 4,
				UserId = "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2",
				QuestionId = 4
			});
			answers.Add(new AnswerEntity
			{
				Id = 5,
				UserId = "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2",
				QuestionId = 5
			});
			answers.Add(new AnswerEntity
			{
				Id = 6,
				UserId = "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2",
				QuestionId = 6
			});
			answers.Add(new AnswerEntity
			{
				Id = 7,
				UserId = "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2",
				QuestionId = 7
			});
			answers.Add(new AnswerEntity
			{
				Id = 8,
				UserId = "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2",
				QuestionId = 8
			});
			answers.Add(new AnswerEntity
			{
				Id = 9,
				UserId = "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2",
				QuestionId = 9
			});
			answers.Add(new AnswerEntity
			{
				Id = 10,
				UserId = "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2",
				QuestionId = 10
			});
			answers.Add(new AnswerEntity
			{
				Id = 11,
				UserId = "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2",
				QuestionId = 11
			});
			answers.Add(new AnswerEntity
			{
				Id = 12,
				UserId = "39be8196-adbd-405e-a4ed-9025abdaaec7",
				QuestionId = 1
			});
			answers.Add(new AnswerEntity
			{
				Id = 13,
				UserId = "39be8196-adbd-405e-a4ed-9025abdaaec7",
				QuestionId = 2
			});
			answers.Add(new AnswerEntity
			{
				Id = 14,
				UserId = "39be8196-adbd-405e-a4ed-9025abdaaec7",
				QuestionId = 3
			});
			answers.Add(new AnswerEntity
			{
				Id = 15,
				UserId = "39be8196-adbd-405e-a4ed-9025abdaaec7",
				QuestionId = 4
			});
			answers.Add(new AnswerEntity
			{
				Id = 16,
				UserId = "39be8196-adbd-405e-a4ed-9025abdaaec7",
				QuestionId = 5
			});
			answers.Add(new AnswerEntity
			{
				Id = 17,
				UserId = "39be8196-adbd-405e-a4ed-9025abdaaec7",
				QuestionId = 6
			});
			answers.Add(new AnswerEntity
			{
				Id = 18,
				UserId = "39be8196-adbd-405e-a4ed-9025abdaaec7",
				QuestionId = 7
			});
			answers.Add(new AnswerEntity
			{
				Id = 19,
				UserId = "39be8196-adbd-405e-a4ed-9025abdaaec7",
				QuestionId = 8
			});
			answers.Add(new AnswerEntity
			{
				Id = 20,
				UserId = "39be8196-adbd-405e-a4ed-9025abdaaec7",
				QuestionId = 9
			});
			answers.Add(new AnswerEntity
			{
				Id = 21,
				UserId = "39be8196-adbd-405e-a4ed-9025abdaaec7",
				QuestionId = 10
			});
			answers.Add(new AnswerEntity
			{
				Id = 22,
				UserId = "39be8196-adbd-405e-a4ed-9025abdaaec7",
				QuestionId = 11
			});
			answers.Add(new AnswerEntity
			{
				Id = 23,
				UserId = "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2",
				QuestionId = 2
			});
			answers.Add(new AnswerEntity
			{
				Id = 24,
				UserId = "39be8196-adbd-405e-a4ed-9025abdaaec7",
				QuestionId = 9
			});

			answers.Add(new AnswerEntity
			{
				Id = 25,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 12
			});
			answers.Add(new AnswerEntity
			{
				Id = 26,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 13
			});
			answers.Add(new AnswerEntity
			{
				Id = 27,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 14
			});
			answers.Add(new AnswerEntity
			{
				Id = 28,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 15
			});
			answers.Add(new AnswerEntity
			{
				Id = 29,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 16
			});
			answers.Add(new AnswerEntity
			{
				Id = 30,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 17
			});
			answers.Add(new AnswerEntity
			{
				Id = 31,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 18
			});
			answers.Add(new AnswerEntity
			{
				Id = 32,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 19
			});
			answers.Add(new AnswerEntity
			{
				Id = 33,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 20
			});
			answers.Add(new AnswerEntity
			{
				Id = 34,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 21
			});
			answers.Add(new AnswerEntity
			{
				Id = 35,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 22
			});
			answers.Add(new AnswerEntity
			{
				Id = 36,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 23
			});
			answers.Add(new AnswerEntity
			{
				Id = 37,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 24
			});
			answers.Add(new AnswerEntity
			{
				Id = 38,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 25
			});
			answers.Add(new AnswerEntity
			{
				Id = 39,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 26
			});
			answers.Add(new AnswerEntity
			{
				Id = 40,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 27
			});
			answers.Add(new AnswerEntity
			{
				Id = 41,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 28
			});
			answers.Add(new AnswerEntity
			{
				Id = 42,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 29
			});
			answers.Add(new AnswerEntity
			{
				Id = 43,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 30
			});
			answers.Add(new AnswerEntity
			{
				Id = 44,
				UserId = "d895b083-82af-47d9-8ff7-abdc9bf862da",
				QuestionId = 31
			});

			answers.Add(new AnswerEntity
			{
				Id = 45,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 12
			});
			answers.Add(new AnswerEntity
			{
				Id = 46,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 13
			});
			answers.Add(new AnswerEntity
			{
				Id = 47,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 14
			});
			answers.Add(new AnswerEntity
			{
				Id = 48,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 15
			});
			answers.Add(new AnswerEntity
			{
				Id = 49,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 16
			});
			answers.Add(new AnswerEntity
			{
				Id = 50,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 17
			});
			answers.Add(new AnswerEntity
			{
				Id = 51,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 18
			});
			answers.Add(new AnswerEntity
			{
				Id = 52,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 19
			});
			answers.Add(new AnswerEntity
			{
				Id = 53,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 20
			});
			answers.Add(new AnswerEntity
			{
				Id = 54,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 21
			});
			answers.Add(new AnswerEntity
			{
				Id = 55,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 22
			});
			answers.Add(new AnswerEntity
			{
				Id = 56,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 23
			});
			answers.Add(new AnswerEntity
			{
				Id = 57,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 24
			});
			answers.Add(new AnswerEntity
			{
				Id = 58,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 25
			});
			answers.Add(new AnswerEntity
			{
				Id = 59,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 26
			});
			answers.Add(new AnswerEntity
			{
				Id = 60,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 27
			});
			answers.Add(new AnswerEntity
			{
				Id = 61,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 28
			});
			answers.Add(new AnswerEntity
			{
				Id = 62,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 29
			});
			answers.Add(new AnswerEntity
			{
				Id = 63,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 30
			});
			answers.Add(new AnswerEntity
			{
				Id = 64,
				UserId = "438d3c8d-0a2e-4112-a9ea-96e3de436595",
				QuestionId = 31
			});
			answers.Add(new AnswerEntity
			{
				Id = 65,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 12
			});
			answers.Add(new AnswerEntity
			{
				Id = 66,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 13
			});
			answers.Add(new AnswerEntity
			{
				Id = 67,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 14
			});
			answers.Add(new AnswerEntity
			{
				Id = 68,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 15
			});
			answers.Add(new AnswerEntity
			{
				Id = 69,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 16
			});
			answers.Add(new AnswerEntity
			{
				Id = 70,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 17
			});
			answers.Add(new AnswerEntity
			{
				Id = 71,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 18
			});
			answers.Add(new AnswerEntity
			{
				Id = 72,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 19
			});
			answers.Add(new AnswerEntity
			{
				Id = 73,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 20
			});
			answers.Add(new AnswerEntity
			{
				Id = 74,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 21
			});
			answers.Add(new AnswerEntity
			{
				Id = 75,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 22
			});
			answers.Add(new AnswerEntity
			{
				Id = 76,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 23
			});
			answers.Add(new AnswerEntity
			{
				Id = 77,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 24
			});
			answers.Add(new AnswerEntity
			{
				Id = 78,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 25
			});
			answers.Add(new AnswerEntity
			{
				Id = 79,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 26
			});
			answers.Add(new AnswerEntity
			{
				Id = 80,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 27
			});
			answers.Add(new AnswerEntity
			{
				Id = 81,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 28
			});
			answers.Add(new AnswerEntity
			{
				Id = 82,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 29
			});
			answers.Add(new AnswerEntity
			{
				Id = 83,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 30
			});
			answers.Add(new AnswerEntity
			{
				Id = 84,
				UserId = "1fea2f55-ea63-472d-a71c-74336c54273c",
				QuestionId = 31
			});

			answers.Add(new AnswerEntity
			{
				Id = 85,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 12
			});
			answers.Add(new AnswerEntity
			{
				Id = 86,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 13
			});
			answers.Add(new AnswerEntity
			{
				Id = 87,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 14
			});
			answers.Add(new AnswerEntity
			{
				Id = 88,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 15
			});
			answers.Add(new AnswerEntity
			{
				Id = 89,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 16
			});
			answers.Add(new AnswerEntity
			{
				Id = 90,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 17
			});
			answers.Add(new AnswerEntity
			{
				Id = 91,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 18
			});
			answers.Add(new AnswerEntity
			{
				Id = 92,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 19
			});
			answers.Add(new AnswerEntity
			{
				Id = 93,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 20
			});
			answers.Add(new AnswerEntity
			{
				Id = 94,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 21
			});
			answers.Add(new AnswerEntity
			{
				Id = 95,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 22
			});
			answers.Add(new AnswerEntity
			{
				Id = 96,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 23
			});
			answers.Add(new AnswerEntity
			{
				Id = 97,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 24
			});
			answers.Add(new AnswerEntity
			{
				Id = 98,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 25
			});
			answers.Add(new AnswerEntity
			{
				Id = 99,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 26
			});
			answers.Add(new AnswerEntity
			{
				Id = 100,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 27
			});
			answers.Add(new AnswerEntity
			{
				Id = 101,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 28
			});
			answers.Add(new AnswerEntity
			{
				Id = 102,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 29
			});
			answers.Add(new AnswerEntity
			{
				Id = 103,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 30
			});
			answers.Add(new AnswerEntity
			{
				Id = 104,
				UserId = "a988b093-8ffe-4830-a011-3fd491e150ba",
				QuestionId = 31
			});
			answers.Add(new AnswerEntity
			{
				Id = 105,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 12
			});
			answers.Add(new AnswerEntity
			{
				Id = 106,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 13
			});
			answers.Add(new AnswerEntity
			{
				Id = 107,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 14
			});
			answers.Add(new AnswerEntity
			{
				Id = 108,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 15
			});
			answers.Add(new AnswerEntity
			{
				Id = 109,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 16
			});
			answers.Add(new AnswerEntity
			{
				Id = 110,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 17
			});
			answers.Add(new AnswerEntity
			{
				Id = 111,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 18
			});
			answers.Add(new AnswerEntity
			{
				Id = 112,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 19
			});
			answers.Add(new AnswerEntity
			{
				Id = 113,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 20
			});
			answers.Add(new AnswerEntity
			{
				Id = 114,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 21
			});
			answers.Add(new AnswerEntity
			{
				Id = 115,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 22
			});
			answers.Add(new AnswerEntity
			{
				Id = 116,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 23
			});
			answers.Add(new AnswerEntity
			{
				Id = 117,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 24
			});
			answers.Add(new AnswerEntity
			{
				Id = 118,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 25
			});
			answers.Add(new AnswerEntity
			{
				Id = 119,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 26
			});
			answers.Add(new AnswerEntity
			{
				Id = 120,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 27
			});
			answers.Add(new AnswerEntity
			{
				Id = 121,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 28
			});
			answers.Add(new AnswerEntity
			{
				Id = 122,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 29
			});
			answers.Add(new AnswerEntity
			{
				Id = 123,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 30
			});
			answers.Add(new AnswerEntity
			{
				Id = 124,
				UserId = "cc115878-58c4-42b3-b384-e780d87bfb02",
				QuestionId = 31
			});
			return answers;
		}

		private static IEnumerable<QuestionEntity> GetQuestions()
		{
			var questions = new List<QuestionEntity>();
			questions.Add(new QuestionEntity
			{
				Id = 1,
				QuestionSectionId = 3,
				QuestionTypeId = 3,
				Text = "How are you?",
				IsRequired = true,
				Order = 1
			});
			questions.Add(new QuestionEntity
			{
				Id = 2,
				QuestionSectionId = 3,
				QuestionTypeId = 4,
				Text = "Why are you crying?",
				IsRequired = false,
				Order = 2
			});
			questions.Add(new QuestionEntity
			{
				Id = 3,
				QuestionSectionId = 3,
				QuestionTypeId = 5,
				Text = "Choose your sex?",
				IsRequired = true,
				Order = 3
			});
			questions.Add(new QuestionEntity
			{
				Id = 4,
				QuestionSectionId = 3,
				QuestionTypeId = 6,
				Text = "Download your selfie",
				IsRequired = false,
				Order = 4
			});
			questions.Add(new QuestionEntity
			{
				Id = 5,
				QuestionSectionId = 3,
				QuestionTypeId = 10,
				Text = "When were you born?",
				IsRequired = true,
				Order = 5
			});
			questions.Add(new QuestionEntity
			{
				Id = 6,
				QuestionSectionId = 4,
				QuestionTypeId = 1,
				Text = "Short feedback about company",
				IsRequired = true,
				Order = 2
			});
			questions.Add(new QuestionEntity
			{
				Id = 7,
				QuestionSectionId = 4,
				QuestionTypeId = 7,
				Text = "Are you satisfied with the service in our company?",
				IsRequired = true,
				Order = 1
			});
			questions.Add(new QuestionEntity
			{
				Id = 8,
				QuestionSectionId = 4,
				QuestionTypeId = 8,
				Text = "Rate our work",
				IsRequired = true,
				Order = 3
			});
			questions.Add(new QuestionEntity
			{
				Id = 9,
				QuestionSectionId = 4,
				QuestionTypeId = 9,
				Text = "What did you respect in",
				IsRequired = true,
				Order = 4
			});
			questions.Add(new QuestionEntity
			{
				Id = 10,
				QuestionSectionId = 5,
				QuestionTypeId = 2,
				Text = "What are you think about your team?",
				IsRequired = true,
				Order = 1
			});
			questions.Add(new QuestionEntity
			{
				Id = 11,
				QuestionSectionId = 5,
				QuestionTypeId = 11,
				Text = "When would you like to come to work?",
				IsRequired = true,
				Order = 2
			});

			questions.Add(new QuestionEntity
			{
				Id = 12,
				QuestionSectionId = 6,
				QuestionTypeId = 1,
				Text = "Що слід покращити в Компанії?",
				IsRequired = true,
				Order = 1
			});
			questions.Add(new QuestionEntity
			{
				Id = 13,
				QuestionSectionId = 6,
				QuestionTypeId = 2,
				Text = "Моя компанія для мене - це...",
				IsRequired = false,
				Order = 2
			});
			questions.Add(new QuestionEntity
			{
				Id = 14,
				QuestionSectionId = 6,
				QuestionTypeId = 3,
				Text = "Компанія надає мені можливості до професійного розвитку.",
				IsRequired = true,
				Order = 3
			});
			questions.Add(new QuestionEntity
			{
				Id = 15,
				QuestionSectionId = 6,
				QuestionTypeId = 4,
				Text = "Виберіть пункти, які б ви покращили у нашій Компанії.",
				CanHaveOtherOption = true,
				IsRequired = false,
				Order = 4
			});
			questions.Add(new QuestionEntity
			{
				Id = 16,
				QuestionSectionId = 6,
				QuestionTypeId = 5,
				Text = "Компанія створює умови для кар'єрного зростання.",
				IsRequired = true,
				Order = 5
			});
			questions.Add(new QuestionEntity
			{
				Id = 17,
				QuestionSectionId = 6,
				QuestionTypeId = 11,
				Text = "О котрій годині Вам зручно починати працювати?",
				IsRequired = false,
				Order = 6
			});
			questions.Add(new QuestionEntity
			{
				Id = 18,
				QuestionSectionId = 6,
				QuestionTypeId = 7,
				Text = "Мені подобається офіс компанії.",
				IsRequired = true,
				Order = 7
			});
			questions.Add(new QuestionEntity
			{
				Id = 19,
				QuestionSectionId = 6,
				QuestionTypeId = 8,
				Text = "Оцініть офісне приміщення.",
				IsRequired = false,
				Order = 8
			});
			questions.Add(new QuestionEntity
			{
				Id = 20,
				QuestionSectionId = 6,
				QuestionTypeId = 9,
				Text = "Зробіть свою оцінку.",
				IsRequired = true,
				Order = 9
			});
			questions.Add(new QuestionEntity
			{
				Id = 21,
				QuestionSectionId = 6,
				QuestionTypeId = 10,
				Text = "Коли б Ви хотіли провести літній корпоратив?",
				IsRequired = false,
				Order = 10
			});
			questions.Add(new QuestionEntity
			{
				Id = 22,
				QuestionSectionId = 7,
				QuestionTypeId = 1,
				Text = "Що слід змінити у Вашій команді?",
				IsRequired = false,
				Order = 1
			});
			questions.Add(new QuestionEntity
			{
				Id = 23,
				QuestionSectionId = 7,
				QuestionTypeId = 2,
				Text = "Моя команда для мене - це...    ",
				IsRequired = true,
				Order = 2
			});
			questions.Add(new QuestionEntity
			{
				Id = 24,
				QuestionSectionId = 7,
				QuestionTypeId = 3,
				Text = "Робота в моїй команді добре координується РМ-ом:",
				CanHaveOtherOption = true,
				IsRequired = false,
				Order = 3
			});
			questions.Add(new QuestionEntity
			{
				Id = 25,
				QuestionSectionId = 7,
				QuestionTypeId = 4,
				Text = "Чого Вам не вистачає?",
				IsRequired = true,
				Order = 4
			});
			questions.Add(new QuestionEntity
			{
				Id = 26,
				QuestionSectionId = 7,
				QuestionTypeId = 5,
				Text = "Мій менеджер заохочує співпрацю в команді.",
				IsRequired = false,
				Order = 5
			});
			questions.Add(new QuestionEntity
			{
				Id = 27,
				QuestionSectionId = 7,
				QuestionTypeId = 11,
				Text = "О котрій годині у Вашої команди Daily call?",
				IsRequired = true,
				Order = 6
			});
			questions.Add(new QuestionEntity
			{
				Id = 28,
				QuestionSectionId = 7,
				QuestionTypeId = 7,
				Text = "Атмосфера у команді.",
				IsRequired = false,
				Order = 7
			});
			questions.Add(new QuestionEntity
			{
				Id = 29,
				QuestionSectionId = 7,
				QuestionTypeId = 8,
				Text = "Оцініть Вашу команду.",
				IsRequired = true,
				Order = 8
			});
			questions.Add(new QuestionEntity
			{
				Id = 30,
				QuestionSectionId = 7,
				QuestionTypeId = 9,
				Text = "Заповніть таблицю стосовно Ваших поглядів на команду.",
				IsRequired = false,
				Order = 9
			});
			questions.Add(new QuestionEntity
			{
				Id = 31,
				QuestionSectionId = 7,
				QuestionTypeId = 10,
				Text = "Оберіть дату для тусовки Вашої команди.",
				IsRequired = true,
				Order = 10
			});
			return questions;
		}

		private static IEnumerable<QuestionSectionEntity> GetQuestionSections()
		{
			var questionSections = new List<QuestionSectionEntity>();
			questionSections.Add(new QuestionSectionEntity
			{
				Id = 1,
				PollId = 1,
				Title = "About you",
				Description = "Here will be questions about you.",
				Order = 1
			});
			questionSections.Add(new QuestionSectionEntity
			{
				Id = 2,
				PollId = 3,
				Title = "About you",
				Description = "Here will be questions about you.",
				Order = 1
			});
			questionSections.Add(new QuestionSectionEntity
			{
				Id = 3,
				PollId = 2,
				Title = "About you",
				Description = "Here will be questions about you.",
				Order = 1
			});
			questionSections.Add(new QuestionSectionEntity
			{
				Id = 4,
				PollId = 2,
				Title = "About company",
				Description = "Here will be questions about company.",
				Order = 2
			});
			questionSections.Add(new QuestionSectionEntity
			{
				Id = 5,
				PollId = 2,
				Title = "About team",
				Description = "Here will be questions about team.",
				Order = 3
			});
			questionSections.Add(new QuestionSectionEntity
			{
				Id = 6,
				PollId = 4,
				Title = "Компанія",
				Description = "У цій секції будуть міститись питання про компанію.",
				Order = 1
			});
			questionSections.Add(new QuestionSectionEntity
			{
				Id = 7,
				PollId = 4,
				Title = "Команда",
				Description = "У цій секції будуть міститись питання про Вашу команду.",
				Order = 2
			});
			return questionSections;
		}

		private static IEnumerable<PollEntity> GetPolls()
		{
			var polls = new List<PollEntity>();
			polls.Add(new PollEntity
			{
				Id = 1,
				CategoryId = 2,
				Title = "ESAT 2019",
				Description = "It`s an ESAT 2019 poll.",
				StartsAt = new DateTimeOffset(2019, 10, 10, 10, 0, 0, TimeSpan.FromHours(3)),
				FinishesAt = new DateTimeOffset(2019, 10, 20, 10, 0, 0, TimeSpan.FromHours(3)),
				IsAnonymous = false
			});
			polls.Add(new PollEntity
			{
				Id = 2,
				CategoryId = 2,
				Title = "ESAT 2020",
				Description = "It`s an ESAT 2020 poll.",
				StartsAt = new DateTimeOffset(2020, 5, 1, 10, 0, 0, TimeSpan.FromHours(3)),
				FinishesAt = new DateTimeOffset(2019, 6, 1, 10, 0, 0, TimeSpan.FromHours(3)),
				IsAnonymous = false
			});
			polls.Add(new PollEntity
			{
				Id = 3,
				CategoryId = 1,
				Title = "Anonymous",
				Description = "It`s an anonymous poll.",
				StartsAt = new DateTimeOffset(2020, 4, 10, 10, 0, 0, TimeSpan.FromHours(3)),
				FinishesAt = new DateTimeOffset(2019, 4, 20, 10, 0, 0, TimeSpan.FromHours(3)),
				IsAnonymous = true
			});
			polls.Add(new PollEntity
			{
				Id = 4,
				CategoryId = 1,
				Title = "ESAT 2020v2",
				Description = "Метою даного опитування є потреба розуміти рівень задоволеності кожного працівника роботою в нашій Компанії.",
				StartsAt = new DateTimeOffset(2020, 5, 6, 10, 0, 0, TimeSpan.FromHours(3)),
				FinishesAt = new DateTimeOffset(2020, 7, 20, 10, 0, 0, TimeSpan.FromHours(3)),
				IsAnonymous = false
			});
			return polls;
		}

		private static IEnumerable<CategoryEntity> GetCategories()
		{
			var categories = new List<CategoryEntity>();
			categories.Add(new CategoryEntity
			{
				Id = 1,
				Title = "JSPSurvey"
			});
			categories.Add(new CategoryEntity
			{
				Id = 2,
				Title = "ESAT",
				ParentCategoryId = 1
			});
			return categories;
		}

		private static IEnumerable<QuestionTypeEntity> GetQuestionTypes()
		{
			var questionTypes = new List<QuestionTypeEntity>();
			questionTypes.Add(new QuestionTypeEntity { Id = 1, Title = "Text" });
			questionTypes.Add(new QuestionTypeEntity { Id = 2, Title = "Paragraph" });
			questionTypes.Add(new QuestionTypeEntity { Id = 3, Title = "Multiple choice" });
			questionTypes.Add(new QuestionTypeEntity { Id = 4, Title = "Checkboxes" });
			questionTypes.Add(new QuestionTypeEntity { Id = 5, Title = "Dropdown" });
			questionTypes.Add(new QuestionTypeEntity { Id = 6, Title = "File upload" });
			questionTypes.Add(new QuestionTypeEntity { Id = 7, Title = "Linear scale" });
			questionTypes.Add(new QuestionTypeEntity { Id = 8, Title = "Multiple choice grid" });
			questionTypes.Add(new QuestionTypeEntity { Id = 9, Title = "Checkbox grid" });
			questionTypes.Add(new QuestionTypeEntity { Id = 10, Title = "Date" });
			questionTypes.Add(new QuestionTypeEntity { Id = 11, Title = "Time" });
			return questionTypes;
		}
	}
}