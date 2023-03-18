using System;
using System.Collections;
using System.Drawing;
using KMI.Utility;

namespace KMI.Sim.Surveys
{
	// Token: 0x0200004F RID: 79
	[Serializable]
	public class Survey
	{
		// Token: 0x060002D2 RID: 722 RVA: 0x00016D14 File Offset: 0x00015D14
		public Survey()
		{
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00016D38 File Offset: 0x00015D38
		public Survey(long entityID, DateTime date, string[] entityNames, ArrayList surveyQuestions)
		{
			this.entityID = entityID;
			this.date = date;
			this.entityNames = entityNames;
			if (Survey.QualifyingQuestionShortName != null)
			{
				bool flag = false;
				foreach (object obj in surveyQuestions)
				{
					SurveyQuestion surveyQuestion = (SurveyQuestion)obj;
					if (surveyQuestion.ShortName == Survey.QualifyingQuestionShortName)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					surveyQuestions.Add(Survey.GetSurveyQuestionByName(Survey.QualifyingQuestionShortName));
				}
			}
			foreach (object obj2 in surveyQuestions)
			{
				SurveyQuestion surveyQuestion = (SurveyQuestion)obj2;
				surveyQuestion.Parent = this;
			}
			this.surveyQuestions = surveyQuestions;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00016E64 File Offset: 0x00015E64
		public virtual void Execute(int numToSurvey)
		{
			throw new Exception("Survey.Execute not overridden.");
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00016E74 File Offset: 0x00015E74
		public void AddUpdateSegmenter(SurveyQuestion question, bool[] includesAnswer)
		{
			SurveySegmenter surveySegmenter = this.GetSegmenter(question);
			if (surveySegmenter != null)
			{
				surveySegmenter.IncludesAnswer = includesAnswer;
			}
			else
			{
				surveySegmenter = new SurveySegmenter(this.QuestionIndex(question), question, includesAnswer);
				this.segmenters.Add(surveySegmenter);
			}
			if (surveySegmenter.AllChecked)
			{
				this.segmenters.Remove(surveySegmenter);
			}
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00016ED4 File Offset: 0x00015ED4
		public void AddUpdateSegmenter(SurveyQuestion question, bool[] includesAnswer, int entityIndex)
		{
			SurveySegmenter surveySegmenter = this.GetSegmenter(question, entityIndex);
			if (surveySegmenter != null)
			{
				surveySegmenter.IncludesAnswer = includesAnswer;
			}
			else
			{
				surveySegmenter = new SurveySegmenter(this.QuestionIndex(question), question, includesAnswer, entityIndex);
				this.segmenters.Add(surveySegmenter);
			}
			if (surveySegmenter.AllChecked)
			{
				this.segmenters.Remove(surveySegmenter);
			}
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00016F38 File Offset: 0x00015F38
		private int QuestionIndex(SurveyQuestion question)
		{
			for (int i = 0; i < this.surveyQuestions.Count; i++)
			{
				if (this.surveyQuestions[i] == question)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00016F7F File Offset: 0x00015F7F
		public void ClearSegmenters()
		{
			this.segmenters = new ArrayList();
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00016F90 File Offset: 0x00015F90
		public SurveySegmenter GetSegmenter(SurveyQuestion question)
		{
			foreach (object obj in this.segmenters)
			{
				SurveySegmenter surveySegmenter = (SurveySegmenter)obj;
				if (surveySegmenter.Question == question)
				{
					return surveySegmenter;
				}
			}
			return null;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0001700C File Offset: 0x0001600C
		public SurveySegmenter GetSegmenter(SurveyQuestion question, int entityIndex)
		{
			foreach (object obj in this.segmenters)
			{
				SurveySegmenter surveySegmenter = (SurveySegmenter)obj;
				if (surveySegmenter.Question == question && surveySegmenter.EntityIndex == entityIndex)
				{
					return surveySegmenter;
				}
			}
			return null;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00017094 File Offset: 0x00016094
		public bool InAllSegments(SurveyResponse r)
		{
			foreach (object obj in this.segmenters)
			{
				SurveySegmenter surveySegmenter = (SurveySegmenter)obj;
				if (surveySegmenter.Excludes(r))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00017110 File Offset: 0x00016110
		public long[] DrawSegments(Graphics g, Rectangle box)
		{
			ArrayList segs = (ArrayList)this.segmenters.Clone();
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.responses)
			{
				SurveyResponse value = (SurveyResponse)obj;
				arrayList.Add(value);
			}
			return this.DrawSubSegments(segs, arrayList, false, g, box);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x000171A8 File Offset: 0x000161A8
		private long[] DrawSubSegments(ArrayList segs, ArrayList resps, bool vertical, Graphics g, Rectangle box)
		{
			Rectangle rectangle = box;
			Rectangle rectangle2 = box;
			string text = "";
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			float num;
			if (segs.Count > 0)
			{
				SurveySegmenter surveySegmenter = (SurveySegmenter)segs[0];
				segs.Remove(surveySegmenter);
				text = surveySegmenter.Question.Question;
				if (surveySegmenter.Question.MultiEntity)
				{
					text = text + " - " + this.entityNames[surveySegmenter.EntityIndex];
				}
				int count = resps.Count;
				for (int i = resps.Count - 1; i >= 0; i--)
				{
					if (surveySegmenter.Excludes((SurveyResponse)resps[i]))
					{
						resps.RemoveAt(i);
					}
				}
				num = 1f - (float)resps.Count / (float)count;
			}
			else
			{
				num = 0f;
			}
			if (vertical)
			{
				rectangle.Height = (int)((float)rectangle.Height * num);
				rectangle2.Y = rectangle.Y + rectangle.Height;
				rectangle2.Height -= rectangle.Height;
			}
			else
			{
				rectangle.Width = (int)((float)rectangle.Width * num);
				rectangle2.X = rectangle.X + rectangle.Width;
				rectangle2.Width -= rectangle.Width;
			}
			if (rectangle.Height > 0 && rectangle.Width > 0)
			{
				g.FillRectangle(new SolidBrush(Color.LightGray), rectangle);
				g.DrawRectangle(new Pen(Color.Black, 1f), rectangle);
				g.DrawString(text, new Font("Arial", 8f), new SolidBrush(Color.Black), rectangle, stringFormat);
			}
			if (rectangle2.Height > 0 && rectangle2.Width > 0)
			{
				g.DrawString(resps.Count.ToString() + " left in segment", new Font("Arial", 10f, FontStyle.Bold), new SolidBrush(Color.White), rectangle2, stringFormat);
			}
			long[] result;
			if (segs.Count > 0)
			{
				result = this.DrawSubSegments(segs, resps, !vertical, g, rectangle2);
			}
			else
			{
				long[] array = new long[resps.Count];
				for (int i = 0; i < resps.Count; i++)
				{
					array[i] = ((SurveyResponse)resps[i]).RespondantID;
				}
				result = array;
			}
			return result;
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002DE RID: 734 RVA: 0x00017488 File Offset: 0x00016488
		public long EntityID
		{
			get
			{
				return this.entityID;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002DF RID: 735 RVA: 0x000174A0 File Offset: 0x000164A0
		public DateTime Date
		{
			get
			{
				return this.date;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x000174B8 File Offset: 0x000164B8
		public string[] EntityNames
		{
			get
			{
				return this.entityNames;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x000174D0 File Offset: 0x000164D0
		public ArrayList SurveyQuestions
		{
			get
			{
				return this.surveyQuestions;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x000174E8 File Offset: 0x000164E8
		public ArrayList Responses
		{
			get
			{
				return this.responses;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x00017500 File Offset: 0x00016500
		public bool Segmented
		{
			get
			{
				return this.segmenters.Count > 0;
			}
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00017520 File Offset: 0x00016520
		public int SurveyIndexOfEntity(string name)
		{
			int result = -1;
			for (int i = 0; i < this.EntityNames.Length; i++)
			{
				if (this.EntityNames[i] == name)
				{
					result = i;
				}
			}
			return result;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00017564 File Offset: 0x00016564
		public static SurveyQuestion GetSurveyQuestionByName(string shortName)
		{
			foreach (SurveyQuestion surveyQuestion in Survey.PossibleSurveyQuestions)
			{
				if (surveyQuestion.ShortName == shortName)
				{
					return surveyQuestion;
				}
			}
			return null;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x000175B0 File Offset: 0x000165B0
		public static void LoadQuestionsFromTable(Type type, string resource)
		{
			Survey.PossibleSurveyQuestions = (SurveyQuestion[])TableReader.Read(type.Assembly, typeof(SurveyQuestion), resource);
			foreach (SurveyQuestion surveyQuestion in Survey.PossibleSurveyQuestions)
			{
				surveyQuestion.PossibleResponses = surveyQuestion.PossibleResponsesConcatenated.Split(new char[]
				{
					'|'
				});
				surveyQuestion.PossibleResponsesConcatenated = null;
			}
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00017626 File Offset: 0x00016626
		public virtual void BuyMailingListHook()
		{
			throw new NotImplementedException("Survey has ShowBuyMailingList on without implementing BuyMailingListHook.");
		}

		// Token: 0x040001C6 RID: 454
		protected long entityID;

		// Token: 0x040001C7 RID: 455
		protected DateTime date;

		// Token: 0x040001C8 RID: 456
		protected string[] entityNames;

		// Token: 0x040001C9 RID: 457
		protected ArrayList surveyQuestions;

		// Token: 0x040001CA RID: 458
		protected ArrayList responses = new ArrayList();

		// Token: 0x040001CB RID: 459
		public static int MaxSurveys = 5;

		// Token: 0x040001CC RID: 460
		public static float BaseCost = 500f;

		// Token: 0x040001CD RID: 461
		public static float RecruitingCostPerPerson = 2f;

		// Token: 0x040001CE RID: 462
		public static float ExecutionCostPerQuestionPerPerson = 0.25f;

		// Token: 0x040001CF RID: 463
		public static string SurveyableObjectName = "Respondents";

		// Token: 0x040001D0 RID: 464
		public static SurveyQuestion[] PossibleSurveyQuestions;

		// Token: 0x040001D1 RID: 465
		public static string QualifyingQuestionShortName;

		// Token: 0x040001D2 RID: 466
		public static bool BillForSurveys = true;

		// Token: 0x040001D3 RID: 467
		public static bool ShowAllSurveyedWhenSegmented = false;

		// Token: 0x040001D4 RID: 468
		public static bool ShowBuyMailingList = false;

		// Token: 0x040001D5 RID: 469
		protected ArrayList segmenters = new ArrayList();
	}
}
