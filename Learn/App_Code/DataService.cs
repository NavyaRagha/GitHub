using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

/// <summary>
/// Summary description for DataService
/// </summary>
public static  class DataService
{
     static  DataService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public class LearningQuiz
    {
        public int? Id { get; set; }
        public int? QuestionId { get; set; }
        public string Question { get; set; }
        public int? An { get; set; }

    }

    public class Learning
    {
        public int? Id { get; set; }
        public string CapitalLetters { get; set; }
        public string SmallLetters { get; set; }
        public string Explain { get; set; }
        public string Kannada { get; set; }
        public string Hindi { get; set; }
        public byte[] Play { get; set; }
    }
    public static Int32    NewUser(string username)
    {
        Int32 result = 0;
        using (LearnDBConnection db = new LearnDBConnection())
        {
              result = db.Beg_Result.Where(x => x.Username == username).ToList().Count;

        }
        return result;
    }

    public static int? GetTopicsPerChapter(Int32 lessoncompleted)
    {
        int? result = 0;
        using (LearnDBConnection db = new LearnDBConnection())
        {

            result = db.CourseMsts.Where(x => x.Lesson == lessoncompleted).Select(x => x.Topics).SingleOrDefault();
        }
        return result;
    }

    public static List<Learning> LoadChapters(int? getchaptersperday)
    {
        List<Learning> resultList ;
        using (LearnDBConnection db = new LearnDBConnection())
        {

            resultList = db.Beg_Alphabet.Join(db.Beg_Translate, x => x.Id, y => y.begAlphabetId, (x, y) => new {x, y})
                .Join(db.Beg_Files, a => a.x.Id, b => b.BegAlphabetId, (a, b) => new {a, b})
                .Take(Convert.ToInt32(getchaptersperday))
                .Select(xy => new Learning()
                {
                    Id = xy.a.x.Id,
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
        List<Learning> randomList = LoadChapters(getchaptersperday);
        List<LearningQuiz> resultList;
        randomList = randomList.Where(x => RandomService.GenerateRandom().Contains(x.Id)).ToList();
        using (LearnDBConnection db = new LearnDBConnection())
        {
            
            resultList= db.Beg_Test.Join(db.Beg_Translate, x => x.Id, y => y.begAlphabetId, (x, y) => new { x, y })
                           .Join(db.Beg_Files, a => a.x.Id, b => b.BegAlphabetId, (a, b) => new { a, b })
                           .Take(Convert.ToInt32(getchaptersperday))
                           .Select(xy => new LearningQuiz()
                           {
                               Id = xy.a.x.Id,
                               QuestionId = xy.a.x.QuestionNumber,
                               Question  = xy.a.x.Question,
                               An =xy.a.x.BegAlphabetId
                           
                           }).ToList();
        }
        return resultList;
    }
    public static List<Learning> LoadQuizWithRandomSet(int? getchaptersperday,Int32 id)
    {
        List<Learning> resultList = null;
        List<Learning> resultRandomList = null;
        Learning[] resultList1 = null;
        using (LearnDBConnection db = new LearnDBConnection())
        {
            List<int?> randomnum = RandomService.GenerateRandom();
            resultList = db.Beg_Test.Join(db.Beg_Translate, x => x.Id, y => y.begAlphabetId, (x, y) => new { x, y })
                        .Join(db.Beg_Files, a => a.x.Id, b => b.BegAlphabetId, (a, b) => new { a, b })
                       // .Take(Convert.ToInt32(getchaptersperday))
                        .Where(x => x.a.x.Id == id)
                        .Select(xy => new Learning()
                        {
                            Id = xy.a.x.BegAlphabetId,
                            Kannada = xy.a.y.Kannada,
                            Hindi = xy.a.y.Hindi,
                            Play = xy.b.Play
                        }).ToList();

            resultRandomList = db.Beg_Alphabet.Join(db.Beg_Translate, x => x.Id, y => y.begAlphabetId, (x, y) => new { x, y })
                .Join(db.Beg_Files, a => a.x.Id, b => b.BegAlphabetId, (a, b) => new { a, b })
                .Take(Convert.ToInt32(getchaptersperday))
               .Where( xx=> randomnum.Contains( xx.a.x.Id))
                .Select(xy => new Learning()
                {
                    Id = xy.a.x.Id,
                    Kannada = xy.a.y.Kannada,
                    Hindi = xy.a.y.Hindi,
                    Play = xy.b.Play
                }).ToList();

          
            resultList1 = resultList.Concat(resultRandomList).ToArray();
        }
        return resultRandomList;
    }


}