﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

/// <summary>
/// Summary description for DataService
/// </summary>
public static class DataService
{
    static DataService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public class LearningQuiz
    {
        public int? BegPrId { get; set; }
        public int? IdTestquiz { get; set; }
        public string IdquizDay { get; set; }
        public int? QuestionNum { get; set; }
        public string Question { get; set; }
        public string An { get; set; }

    }

    public class CourseNotTaken
    {
        public List<int> CourseItems { get; set; }
    }

    public class Learning
    {
        public int? BegPrId { get; set; }
        public int? idName { get; set; }
        public string CapitalLetters { get; set; }
        public string SmallLetters { get; set; }
        public string Explain { get; set; }
        public string Kannada { get; set; }
        public string Hindi { get; set; }
        public byte[] Play { get; set; }
    }

    public static Int32 NewUser(string username)
    {
        Int32 result = 0;
        using (dbExtranetEntities db = new dbExtranetEntities())
        {
            result = db.Beg_Result.Where(x => x.Username == username).ToList().Count;
        }
        return result;
    }

    public static int? GetTopicsPerChapter(Int32 lessoncompleted)
    {
        int? result = 0;
        using (dbExtranetEntities db = new dbExtranetEntities())
        {

            result = db.CourseMsts.Where(x => x.Lesson == lessoncompleted).Select(x => x.Topics).SingleOrDefault();
        }
        return result;
    }

    public static int? GetNumQuestTaken(string username, int? getChaptersPerDay)
    {

        using (dbExtranetEntities db = new dbExtranetEntities())
        {

            List<int?> result1 = db.Beg_UserTest.Where(x => x.Username == username).Select(x => x.Course).ToList();
            List<int> result2 = db.Beg_Test.Select(x => x.Id).ToList();
            var differences = result2.Where(i => !result1.Contains(i)).ToList();
            int diff = differences[0];
            return diff;

        }

    }


    public static List<Learning> LoadChapters(int? getchaptersperday)
    {
        List<Learning> resultList;
        using (dbExtranetEntities db = new dbExtranetEntities())
        {

            resultList = db.Beg_Alphabet.Join(db.Beg_Translate, x => x.Id, y => y.begAlphabetId, (x, y) => new {x, y})
                .Join(db.Beg_Files, a => a.x.Id, b => b.BegAlphabetId, (a, b) => new {a, b})
                .Take(Convert.ToInt32(getchaptersperday))
                .Select(xy => new Learning()
                {
                    BegPrId = xy.a.x.Id,
                    CapitalLetters = xy.a.x.CapitalLetter,
                    SmallLetters = xy.a.x.SmallLetter,
                    Kannada = xy.a.y.Kannada,
                    Hindi = xy.a.y.Hindi,
                    Play = xy.b.Play
                }).ToList();
        }
        return resultList;
    }

    public static List<LearningQuiz> LoadQuiz(int? getchaptersperday)
    {
        //4 quest
        //gets first record
        //List<Learning> randomList = LoadChapters(getchaptersperday);
        List<LearningQuiz> resultList;
        //randomList = randomList.Where(x => RandomService.GenerateRandom().Contains(x.BegPrId )).ToList();
        using (dbExtranetEntities db = new dbExtranetEntities())
        {
//load question

            resultList =
                db.Beg_Test.AsNoTracking().Join(db.Beg_Translate, x => x.Id, y => y.begAlphabetId, (x, y) => new {x, y})
                    .Join(db.Beg_Files, a => a.x.Id, b => b.BegAlphabetId, (a, b) => new {a, b})
                    .Where(x => x.a.x.Id == getchaptersperday)
                    .Select(xy => new LearningQuiz()
                    {
                        IdTestquiz = xy.a.x.Id,
                        IdquizDay = xy.a.x.Day,
                        QuestionNum = xy.a.x.QuestionNumber,
                        Question = xy.a.x.Question,
                        An = xy.a.x.Answer,
                        BegPrId = xy.a.x.BegAlphabetId
                    }).ToList();
        }
        return resultList;
    }

    public static List<Learning> LoadQuizWithRandomSet(int? getchaptersperday, Int32 id, string username)
    {
        // int? nam=0;
        List<Learning> resultList = null;
        List<Learning> resultRandomList = null;
        List<Learning> resultList1 = null;
        Int32 i = 0;
        using (dbExtranetEntities db = new dbExtranetEntities())
        {
            List<int?> randomnum = RandomService.GenerateRandom();
            var testid = db.Beg_UserTest.Where(x => x.Username == username).Select(x => x.Course).Distinct().ToList();


            //takequestion
            resultList =
                db.Beg_Test.AsNoTracking()
                    .Join(db.Beg_Translate, x => x.BegAlphabetId, y => y.begAlphabetId, (x, y) => new {x, y})
                    .Join(db.Beg_Files, a => a.x.BegAlphabetId, b => b.BegAlphabetId, (a, b) => new {a, b})
                    // .Take(Convert.ToInt32(getchaptersperday))
                    .Where(x => x.a.x.BegAlphabetId == id).Take(1)
                    .Select(xy => new Learning()
                    {
                        idName = xy.a.x.Id,
                        BegPrId = xy.a.x.BegAlphabetId,
                        Kannada = xy.a.y.Kannada,
                        Hindi = xy.a.y.Hindi,
                        Play = xy.b.Play
                    }).ToList();
            //   nam = resultList[0].idName;
            resultRandomList =
                db.Beg_Alphabet.Join(db.Beg_Translate, x => x.Id, y => y.begAlphabetId, (x, y) => new {x, y})
                    .Join(db.Beg_Files, a => a.x.Id, b => b.BegAlphabetId, (a, b) => new {a, b})
                    .Join(db.Beg_Test, aa => aa.a.x.Id, bb => bb.BegAlphabetId, (aa, bb) => new {aa, bb})
                    .Take(Convert.ToInt32(getchaptersperday))
                    .Where(xx => randomnum.Contains(xx.aa.a.x.Id))
                    .Select(xy => new Learning()
                    {
                        idName = xy.bb.Id,
                        BegPrId = xy.aa.a.x.Id,
                        Kannada = xy.aa.a.y.Kannada,
                        Hindi = xy.aa.a.y.Hindi,
                        Play = xy.aa.b.Play
                    }).ToList();


            resultList1 = resultList.Union(resultRandomList).ToList();

        }
        return resultList1;
    }

    public static void AnswerGiven(int testid, string username, int begid)
    {
        using (dbExtranetEntities db = new dbExtranetEntities())
        {
            using (var trans = db.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var getquestioninfo = db.Beg_Test.SingleOrDefault(x => x.Id == testid);
                    var getAnstext = db.Beg_Alphabet.SingleOrDefault(x => x.Id == begid);
                    var testgiven = new Beg_UserTest()
                    {
                        BegAlphabetId = getquestioninfo.BegAlphabetId,
                        Username = username,
                        Course = testid,
                        Day = getquestioninfo.Day,
                        Question = getquestioninfo.Question,
                        QuestionNumber = getquestioninfo.QuestionNumber,
                        Answer = getAnstext.CapitalLetter

                    };
                    db.Beg_UserTest.Add(testgiven);
                    db.SaveChanges();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw;
                }

            }
        }
    }

    public static int GetCoursemst(int testid)
    {
        int? result;
        using (dbExtranetEntities db = new dbExtranetEntities())
        {
            //var getquestioninfo = db.Beg_Test.SingleOrDefault(x => x.Id == testid);
            result = db.CourseMsts.AsNoTracking().Where(x => x.Lesson == testid).Select(x => x.Topics).SingleOrDefault();
        }
        return result.GetValueOrDefault();
    }

    public static int GetquestAnswered(string testid, string username)
    {
        int? result;
        using (dbExtranetEntities db = new dbExtranetEntities())
        {
            result =
                db.Beg_UserTest.AsNoTracking()
                    .Where(x => x.Username == username && x.Day == testid.ToString())
                    .ToList()
                    .Count();
        }
        return result.GetValueOrDefault();
    }

    public static bool ResultPassorFail(string testday, string username)
    {
        using (dbExtranetEntities db = new dbExtranetEntities())
        {

            bool res = false;
            var results = db.Beg_UserTest.AsNoTracking().Where(x => x.Day == testday && x.Username == username).ToList();

            foreach (var result in results)
            {
                if (result.Answer == result.Question)
                {
                    res = true;
                }
                else
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

    }

    public static bool SendBacktoSameCourse(string testday, string username)
    {
        using (dbExtranetEntities db = new dbExtranetEntities())
        {
            using (var trans = db.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var removeusertest = db.Beg_UserTest.Where(x => x.Username == username && x.Day == testday).ToList();
                    db.Beg_UserTest.RemoveRange(removeusertest);
                    db.SaveChanges();
                    trans.Commit();

                    return false;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

    }

}




//    public static void UserTestTaken()
//    {
//        using (dbExtranetEntities db = new dbExtranetEntities())
//        {
//            using (var trans = db.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
//            {
//                try
//                {
//                        var but = new Beg_UserTest() 
//                        {
//                            BegAlphabetId  =1 ,
//                            Answer ="1",
//                            Username ="navya",

//                        };
//                        db.Beg_UserTest.Add(but);
//                        db.SaveChanges();
//                        trans.Commit();
//                }
//                catch (Exception ex)
//                {
//                    trans.Rollback();
//                    throw;
//                }

//            }
//        }
//    }
//}