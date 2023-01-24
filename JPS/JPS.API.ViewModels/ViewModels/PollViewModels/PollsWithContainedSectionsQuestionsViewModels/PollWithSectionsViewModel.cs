using JPS.Common.Enums;
using System;
using System.Collections.Generic;

namespace JPS.API.ViewModels.ViewModels.PollViewModels.PollsWithContainedSectionsQuestionsViewModels
{
	/// <summary>
	/// Model for displaying poll with sections.
	/// </summary>
	public class PollWithSectionsViewModel : PollViewModel
	{
		public IEnumerable<SectionWithQuestionsViewModel> QuestionSections { get; set; }
	}
}
