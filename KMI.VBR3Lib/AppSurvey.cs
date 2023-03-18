using System;
using System.Collections;
using System.Collections.Generic;
using KMI.Biz.Product;
using KMI.Sim;
using KMI.Sim.Surveys;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for AppSurvey.
	/// </summary>
	// Token: 0x02000037 RID: 55
	[Serializable]
	public class AppSurvey : Survey
	{
		// Token: 0x06000173 RID: 371 RVA: 0x0001446A File Offset: 0x0001346A
		public AppSurvey(long entityID, DateTime date, string[] entityNames, ArrayList surveyQuestions) : base(entityID, date, entityNames, surveyQuestions)
		{
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0001447C File Offset: 0x0001347C
		public override void Execute(int numToSurvey)
		{
			for (int c = 0; c < numToSurvey; c++)
			{
				Customer cust = A.ST.GetRandomCustomer();
				SurveyResponse response = new SurveyResponse(cust.ID);
				foreach (object obj in this.surveyQuestions)
				{
					SurveyQuestion q = (SurveyQuestion)obj;
					response.AddAnswer(this.AskQuestion(cust, q));
				}
				base.Responses.Add(response);
			}
		}

        // Token: 0x06000175 RID: 373 RVA: 0x00014544 File Offset: 0x00013544
        //protected int[] AskQuestion(Customer cust, SurveyQuestion q)
        //{
        //	int[] answer = new int[0];
        //	string shortName = q.ShortName;
        //	if (shortName != null)
        //	{
        //		if (<PrivateImplementationDetails>{E37FE0CE-2F85-4B41-8600-2F5798472861}.$$method0x6000175-1 == null)
        //		{
        //			<PrivateImplementationDetails>{E37FE0CE-2F85-4B41-8600-2F5798472861}.$$method0x6000175-1 = new Dictionary<string, int>(13)
        //			{
        //				{
        //					"live",
        //					0
        //				},
        //				{
        //					"work",
        //					1
        //				},
        //				{
        //					"occupation",
        //					2
        //				},
        //				{
        //					"age",
        //					3
        //				},
        //				{
        //					"howaware",
        //					4
        //				},
        //				{
        //					"shoppedthisweek",
        //					5
        //				},
        //				{
        //					"productpreference",
        //					6
        //				},
        //				{
        //					"preferredradio",
        //					7
        //				},
        //				{
        //					"shoppingtime",
        //					8
        //				},
        //				{
        //					"opinionradio",
        //					9
        //				},
        //				{
        //					"opinionbillboards",
        //					10
        //				},
        //				{
        //					"opiniondirectmail",
        //					11
        //				},
        //				{
        //					"opinionstorefrontads",
        //					12
        //				}
        //			};
        //		}
        //		int num;
        //		if (<PrivateImplementationDetails>{E37FE0CE-2F85-4B41-8600-2F5798472861}.$$method0x6000175-1.TryGetValue(shortName, out num))
        //		{
        //			switch (num)
        //			{
        //			case 0:
        //			{
        //				AppBuilding bldg = cust.Home;
        //				answer = new int[]
        //				{
        //					bldg.Avenue,
        //					bldg.Street,
        //					bldg.Lot
        //				};
        //				break;
        //			}
        //			case 1:
        //			{
        //				AppBuilding bldg = cust.Workplace;
        //				if (bldg != null)
        //				{
        //					answer = new int[]
        //					{
        //						bldg.Avenue,
        //						bldg.Street,
        //						bldg.Lot
        //					};
        //				}
        //				else
        //				{
        //					answer = new int[]
        //					{
        //						-1,
        //						-1,
        //						-1
        //					};
        //				}
        //				break;
        //			}
        //			case 2:
        //				for (int i = 0; i < AppConstants.DemographicTypes.Length; i++)
        //				{
        //					if (i == cust.DemographicType.Index)
        //					{
        //						answer = new int[]
        //						{
        //							i
        //						};
        //					}
        //				}
        //				break;
        //			case 3:
        //			{
        //				int j = (cust.Age - 10) / 15;
        //				j = Math.Min(j, 4);
        //				answer = new int[]
        //				{
        //					j
        //				};
        //				break;
        //			}
        //			case 4:
        //			{
        //				int[] howAware = new int[A.ST.Entity.Count];
        //				int k = 0;
        //				foreach (object obj in A.ST.Entity.Values)
        //				{
        //					AppEntity store = (AppEntity)obj;
        //					howAware[k] = 0;
        //					if (cust.Aware(store.ID))
        //					{
        //						for (int l = 0; l < q.PossibleResponses.Length; l++)
        //						{
        //							if (cust.MaxImpressionSource(store.ID) == q.PossibleResponses[l])
        //							{
        //								howAware[k] = l;
        //							}
        //						}
        //					}
        //					k++;
        //				}
        //				answer = howAware;
        //				break;
        //			}
        //			case 5:
        //			{
        //				int index = -1;
        //				if (cust.CurrentStore != null && cust.State != Customer.States.WalkBy)
        //				{
        //					index = base.SurveyIndexOfEntity(cust.CurrentStore.Name);
        //				}
        //				answer = new int[]
        //				{
        //					index + 1
        //				};
        //				break;
        //			}
        //			case 6:
        //			{
        //				ArrayList needs = cust.DemographicType.Needs;
        //				ProductType prod = AppConstants.ProductTypes[(int)needs[A.ST.Random.Next(needs.Count)]];
        //				for (int i = 0; i < q.PossibleResponses.Length; i++)
        //				{
        //					if (q.PossibleResponses[i] == prod.Name)
        //					{
        //						answer = new int[]
        //						{
        //							i
        //						};
        //					}
        //				}
        //				break;
        //			}
        //			case 7:
        //			{
        //				int stationID;
        //				if (A.ST.Random.NextDouble() < (double)cust.DemographicType.PctPreferredRadioStation)
        //				{
        //					stationID = cust.DemographicType.PreferredRadioStation;
        //				}
        //				else
        //				{
        //					stationID = A.ST.Random.Next(A.ST.RadioStations.Length);
        //				}
        //				answer = new int[]
        //				{
        //					stationID
        //				};
        //				break;
        //			}
        //			case 8:
        //			{
        //				int hr = cust.WakeupTime.Hour;
        //				int a;
        //				if (hr >= 6 && hr <= 9)
        //				{
        //					a = 0;
        //				}
        //				else if (hr >= 10 && hr <= 16)
        //				{
        //					a = 1;
        //				}
        //				else if (hr >= 17 && hr < 20)
        //				{
        //					a = 2;
        //				}
        //				else
        //				{
        //					a = 3;
        //				}
        //				answer = new int[]
        //				{
        //					a
        //				};
        //				break;
        //			}
        //			case 9:
        //			{
        //				int[] opinion = new int[A.ST.Entity.Count];
        //				int k = 0;
        //				foreach (object obj2 in A.ST.Entity.Values)
        //				{
        //					AppEntity store = (AppEntity)obj2;
        //					if (cust.ImpressionImpact(store.ID, "Radio") > 0f)
        //					{
        //						opinion[k] = 1;
        //					}
        //					else
        //					{
        //						opinion[k] = 0;
        //					}
        //					k++;
        //				}
        //				answer = opinion;
        //				break;
        //			}
        //			case 10:
        //			{
        //				int[] opinion = new int[A.ST.Entity.Count];
        //				int k = 0;
        //				foreach (object obj3 in A.ST.Entity.Values)
        //				{
        //					AppEntity store = (AppEntity)obj3;
        //					if (cust.ImpressionImpact(store.ID, "Billboards") > 0f)
        //					{
        //						opinion[k] = 1;
        //					}
        //					else
        //					{
        //						opinion[k] = 0;
        //					}
        //					k++;
        //				}
        //				answer = opinion;
        //				break;
        //			}
        //			case 11:
        //			{
        //				int[] opinion = new int[A.ST.Entity.Count];
        //				int k = 0;
        //				foreach (object obj4 in A.ST.Entity.Values)
        //				{
        //					AppEntity store = (AppEntity)obj4;
        //					float m = cust.ImpressionImpact(store.ID, "Direct Mail");
        //					if (m != 0f)
        //					{
        //						if (m < 0.6f)
        //						{
        //							opinion[k] = 1;
        //						}
        //						else if (m < 1.1f)
        //						{
        //							opinion[k] = 2;
        //						}
        //						else
        //						{
        //							opinion[k] = 3;
        //						}
        //					}
        //					else
        //					{
        //						opinion[k] = 0;
        //					}
        //					k++;
        //				}
        //				answer = opinion;
        //				break;
        //			}
        //			case 12:
        //			{
        //				int[] opinion = new int[A.ST.Entity.Count];
        //				int k = 0;
        //				foreach (object obj5 in A.ST.Entity.Values)
        //				{
        //					AppEntity store = (AppEntity)obj5;
        //					float m = cust.ImpressionImpact(store.ID, "Storefront Ads");
        //					if (m != 0f)
        //					{
        //						if (m < 0.6f)
        //						{
        //							opinion[k] = 1;
        //						}
        //						else if (m < 1.1f)
        //						{
        //							opinion[k] = 2;
        //						}
        //						else
        //						{
        //							opinion[k] = 3;
        //						}
        //					}
        //					else
        //					{
        //						opinion[k] = 0;
        //					}
        //					k++;
        //				}
        //				answer = opinion;
        //				break;
        //			}
        //			default:
        //				goto IL_7D7;
        //			}
        //			return answer;
        //		}
        //	}
        //	IL_7D7:
        //	throw new Exception("Cannot handle survey question." + q.ShortName);
        //}

        protected int[] AskQuestion(Customer cust, SurveyQuestion q)
        {
            AppBuilding home;
            int num;
            int num3;
            int preferredRadioStation;
            int[] numArray3;
            float num9;
            int[] numArray = new int[0];
            switch (q.ShortName)
            {
                case "live":
                    home = cust.Home;
                    return new int[] { home.Avenue, home.Street, home.Lot };

                case "work":
                    home = cust.Workplace;
                    if (home == null)
                    {
                        return new int[] { -1, -1, -1 };
                    }
                    return new int[] { home.Avenue, home.Street, home.Lot };

                case "occupation":
                    for (num = 0; num < AppConstants.DemographicTypes.Length; num++)
                    {
                        if (num == cust.DemographicType.Index)
                        {
                            numArray = new int[] { num };
                        }
                    }
                    return numArray;

                case "age":
                    {
                        int num2 = (cust.Age - 10) / 15;
                        num2 = Math.Min(num2, 4);
                        return new int[] { num2 };
                    }
                case "howaware":
                    {
                        int[] numArray2 = new int[A.ST.Entity.Count];
                        num3 = 0;
                        foreach (AppEntity entity in A.ST.Entity.Values)
                        {
                            numArray2[num3] = 0;
                            if (cust.Aware(entity.ID))
                            {
                                for (int i = 0; i < q.PossibleResponses.Length; i++)
                                {
                                    if (cust.MaxImpressionSource(entity.ID) == q.PossibleResponses[i])
                                    {
                                        numArray2[num3] = i;
                                    }
                                }
                            }
                            num3++;
                        }
                        return numArray2;
                    }
                case "shoppedthisweek":
                    {
                        int num5 = -1;
                        if ((cust.CurrentStore != null) && (cust.State != Customer.States.WalkBy))
                        {
                            num5 = base.SurveyIndexOfEntity(cust.CurrentStore.Name);
                        }
                        return new int[] { (num5 + 1) };
                    }
                case "productpreference":
                    {
                        ArrayList needs = cust.DemographicType.Needs;
                        ProductType type = AppConstants.ProductTypes[(int)needs[A.ST.Random.Next(needs.Count)]];
                        for (num = 0; num < q.PossibleResponses.Length; num++)
                        {
                            if (q.PossibleResponses[num] == type.Name)
                            {
                                numArray = new int[] { num };
                            }
                        }
                        return numArray;
                    }
                case "preferredradio":
                    if (A.ST.Random.NextDouble() >= cust.DemographicType.PctPreferredRadioStation)
                    {
                        preferredRadioStation = A.ST.Random.Next(A.ST.RadioStations.Length);
                        break;
                    }
                    preferredRadioStation = cust.DemographicType.PreferredRadioStation;
                    break;

                case "shoppingtime":
                    {
                        int num8;
                        int hour = cust.WakeupTime.Hour;
                        if ((hour < 6) || (hour > 9))
                        {
                            if ((hour >= 10) && (hour <= 0x10))
                            {
                                num8 = 1;
                            }
                            else if ((hour >= 0x11) && (hour < 20))
                            {
                                num8 = 2;
                            }
                            else
                            {
                                num8 = 3;
                            }
                        }
                        else
                        {
                            num8 = 0;
                        }
                        return new int[] { num8 };
                    }
                case "opinionradio":
                    numArray3 = new int[A.ST.Entity.Count];
                    num3 = 0;
                    foreach (AppEntity entity in A.ST.Entity.Values)
                    {
                        if (cust.ImpressionImpact(entity.ID, "Radio") > 0f)
                        {
                            numArray3[num3] = 1;
                        }
                        else
                        {
                            numArray3[num3] = 0;
                        }
                        num3++;
                    }
                    return numArray3;

                case "opinionbillboards":
                    numArray3 = new int[A.ST.Entity.Count];
                    num3 = 0;
                    foreach (AppEntity entity in A.ST.Entity.Values)
                    {
                        if (cust.ImpressionImpact(entity.ID, "Billboards") > 0f)
                        {
                            numArray3[num3] = 1;
                        }
                        else
                        {
                            numArray3[num3] = 0;
                        }
                        num3++;
                    }
                    return numArray3;

                case "opiniondirectmail":
                    numArray3 = new int[A.ST.Entity.Count];
                    num3 = 0;
                    foreach (AppEntity entity in A.ST.Entity.Values)
                    {
                        num9 = cust.ImpressionImpact(entity.ID, "Direct Mail");
                        if (num9 != 0f)
                        {
                            if (num9 < 0.6f)
                            {
                                numArray3[num3] = 1;
                            }
                            else if (num9 < 1.1f)
                            {
                                numArray3[num3] = 2;
                            }
                            else
                            {
                                numArray3[num3] = 3;
                            }
                        }
                        else
                        {
                            numArray3[num3] = 0;
                        }
                        num3++;
                    }
                    return numArray3;

                case "opinionstorefrontads":
                    numArray3 = new int[A.ST.Entity.Count];
                    num3 = 0;
                    foreach (AppEntity entity in A.ST.Entity.Values)
                    {
                        num9 = cust.ImpressionImpact(entity.ID, "Storefront Ads");
                        if (num9 != 0f)
                        {
                            if (num9 < 0.6f)
                            {
                                numArray3[num3] = 1;
                            }
                            else if (num9 < 1.1f)
                            {
                                numArray3[num3] = 2;
                            }
                            else
                            {
                                numArray3[num3] = 3;
                            }
                        }
                        else
                        {
                            numArray3[num3] = 0;
                        }
                        num3++;
                    }
                    return numArray3;

                default:
                    throw new Exception("Cannot handle survey question." + q.ShortName);
            }
            return new int[] { preferredRadioStation };
        }


        // Token: 0x06000176 RID: 374 RVA: 0x00014D88 File Offset: 0x00013D88
        public override void BuyMailingListHook()
		{
			try
			{
				MailingList list = A.SA.CreateMailingList(this);
				MailingList[] lists = A.SA.GetMailingLists(A.MF.CurrentEntityID);
				list.Name = frmMail.GetNameForList(lists);
				A.SA.AddMailingList(A.MF.CurrentEntityID, list);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}
	}
}
