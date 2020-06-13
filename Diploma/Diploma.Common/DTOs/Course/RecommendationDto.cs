using System;

namespace Diploma.Common.DTOs.Course
{
	public class RecommendationDto
	{
		public Guid CourseId { get; set; }
		public decimal Similarity { get; set; }
	}
}
