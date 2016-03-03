using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataServiceWord
/// </summary>
public class DataServiceWord
{
    public DataServiceWord()
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

    public class LearningWord
    {
        public int? BegPrId { get; set; }
        public int? idName { get; set; }
        public string CapitalLetters { get; set; }
        public string Explain { get; set; }
        public string Kannada { get; set; }
        public string Hindi { get; set; }
        public byte[] Play { get; set; }
    }

    public static int? GetTopicsPerChapter(Int32 lessoncompleted)
    {
        int? result = 0;
        using (dbExtranetEntitiesWord db = new dbExtranetEntitiesWord())
        {

            result = db.Beg_WordCourse.Where(x => x.Lesson == lessoncompleted).Select(x => x.Topics).SingleOrDefault();
        }
        return result;
    }

    public static int? GetNumQuestTaken(string username, int? getChaptersPerDay)
    {

        using (dbExtranetEntitiesWord db = new dbExtranetEntitiesWord())
        {

            List<int?> result1 = db.Beg_WordUserTest.Where(x => x.Username == username).Select(x => x.BegWordTestId).ToList();
            List<int> result2 = db.Beg_WordTest.Select(x => x.Id).ToList();
            var differences = result2.Where(i => !result1.Contains(i)).ToList();
            int diff = differences[0];
            return diff;

        }

    }


    public static List<LearningWord> LoadChapters(int? getchaptersperday)
    {
        List<LearningWord> resultList;
        using (dbExtranetEntitiesWord db = new dbExtranetEntitiesWord())
        {
            resultList = db.Beg_Word.Join(db.Beg_WordTranslate, x => x.Id, y => y.BegWordId, (x, y) => new { x, y })
                        .Join(db.Beg_WordFiles, a => a.x.Id, b => b.BegWordId, (a, b) => new { a, b })
                        .Take(Convert.ToInt32(getchaptersperday))
                        .Select(xy => new LearningWord()
                        {
                            BegPrId = xy.a.x.Id,
                            CapitalLetters = xy.a.x.Word,
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
        using (dbExtranetEntitiesWord db = new dbExtranetEntitiesWord())
        {
            //load question

            resultList =
                db.Beg_WordTest.AsNoTracking().Join(db.Beg_WordTranslate, x => x.Id, y => y.BegWordId, (x, y) => new { x, y })
                    .Join(db.Beg_WordFiles, a => a.x.Id, b => b.BegWordId, (a, b) => new { a, b })
                    .Where(x => x.a.x.Id == getchaptersperday)
                    .Select(xy => new LearningQuiz()
                    {
                        IdTestquiz = xy.a.x.Id,
                        IdquizDay = xy.a.x.Day,
                        QuestionNum = xy.a.x.QuestionNumber,
                        Question = xy.a.x.Question,
                        An = xy.a.x.Answer,
                        BegPrId = xy.a.x.BegWordId
                    }).ToList();
        }
        return resultList;
    }

    public static List<LearningWord> LoadQuizWithRandomSet(int? getchaptersperday, Int32 id, string username)
    {
        // int? nam=0;
        List<LearningWord> resultList = null;
        List<LearningWord> resultRandomList = null;
        List<LearningWord> resultList1 = null;
        Int32 i = 0;
        using (dbExtranetEntitiesWord db = new dbExtranetEntitiesWord())
        {
            List<int?> randomnum = RandomService.GenerateRandom();
            var testid = db.Beg_WordUserTest.Where(x => x.Username == username).Select(x => x.BegWordTestId).Distinct().ToList();


            //takequestion
            resultList =
                db.Beg_WordTest.AsNoTracking()
                    .Join(db.Beg_WordTranslate, x => x.BegWordId, y => y.BegWordId, (x, y) => new { x, y })
                    .Join(db.Beg_WordFiles, a => a.x.BegWordId, b => b.BegWordId, (a, b) => new { a, b })
                    // .Take(Convert.ToInt32(getchaptersperday))
                    .Where(x => x.a.x.BegWordId == id).Take(1)
                    .Select(xy => new LearningWord()
                    {
                        idName = xy.a.x.Id,
                        BegPrId = xy.a.x.BegWordId,
                        Kannada = xy.a.y.Kannada,
                        Hindi = xy.a.y.Hindi,
                        Play = xy.b.Play
                    }).ToList();
            //   nam = resultList[0].idName;
            resultRandomList =
                db.Beg_Word.Join(db.Beg_WordTranslate, x => x.Id, y => y.BegWordId, (x, y) => new { x, y })
                    .Join(db.Beg_WordFiles, a => a.x.Id, b => b.BegWordId, (a, b) => new { a, b })
                    .Join(db.Beg_WordTest, aa => aa.a.x.Id, bb => bb.BegWordId, (aa, bb) => new { aa, bb })
                    .Take(Convert.ToInt32(getchaptersperday))
                    .Where(xx => randomnum.Contains(xx.aa.a.x.Id))
                    .Select(xy => new LearningWord()
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
        using (dbExtranetEntitiesWord db = new dbExtranetEntitiesWord())
        {
            using (var trans = db.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var getquestioninfo = db.Beg_WordTest.SingleOrDefault(x => x.Id == testid);
                    var getAnstext = db.Beg_Word.SingleOrDefault(x => x.Id == begid);
                    var testgiven = new Beg_WordUserTest()
                    {
                        BegWordId = getquestioninfo.BegWordId,
                        Username = username,
                        BegWordTestId = testid,
                        Day = getquestioninfo.Day,
                        Question = getquestioninfo.Question,
                        QuestionNumber = getquestioninfo.QuestionNumber,
                        Answer = getAnstext.Word

                    };
                    db.Beg_WordUserTest.Add(testgiven);
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
        using (dbExtranetEntitiesWord db = new dbExtranetEntitiesWord())
        {
            //var getquestioninfo = db.Beg_Test.SingleOrDefault(x => x.Id == testid);
            result = db.Beg_WordCourse.AsNoTracking().Where(x => x.Lesson == testid).Select(x => x.Topics).SingleOrDefault();
        }
        return result.GetValueOrDefault();
    }

    public static int GetquestAnswered(string testid, string username)
    {
        int? result;
        using (dbExtranetEntitiesWord db = new dbExtranetEntitiesWord())
        {
            result =
                db.Beg_WordUserTest.AsNoTracking()
                    .Where(x => x.Username == username && x.Day == testid.ToString())
                    .ToList()
                    .Count();
        }
        return result.GetValueOrDefault();
    }

    public static bool ResultPassorFail(string testday, string username)
    {
        using (dbExtranetEntitiesWord db = new dbExtranetEntitiesWord())
        {

            bool res = false;
            var results = db.Beg_WordUserTest.AsNoTracking().Where(x => x.Day == testday && x.Username == username).ToList();

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
        using (dbExtranetEntitiesWord db = new dbExtranetEntitiesWord())
        {
            using (var trans = db.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var removeusertest = db.Beg_WordUserTest.Where(x => x.Username == username && x.Day == testday).ToList();
                    db.Beg_WordUserTest.RemoveRange(removeusertest);
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