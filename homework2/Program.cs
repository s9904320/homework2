using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace homework2
{
    /*
     An orderly trail of ants is marching across the park picnic area.

    It looks something like this:

    ..ant..ant.ant...ant.ant..ant.ant....ant..ant.ant.ant...ant..
    But suddenly there is a rumour that a dropped chicken sandwich has been spotted on the ground ahead. The ants surge forward! Oh No, it's an ant stampede!!

    Some of the slower ants are trampled, and their poor little ant bodies are broken up into scattered bits.

    The resulting carnage looks like this:

    ...ant...ant..nat.ant.t..ant...ant..ant..ant.anant..t
    Can you find how many ants have died?

    Notes
    When in doubt, assume that the scattered bits are from the same ant. e.g. 2 heads and 1 body = 2 dead ants, not 3
    */
    class Program
    {
        static void Main(string[] args)
        {
            SampleTests();
        }

        public static int DeadAntCount(string ants)
        {
            int deadAntCount = 0;
            int ant_Count = 0;
            int a_Count = 0;
            int n_Count = 0;
            int t_Count = 0;
            int antLength = 0;
            if (!String.IsNullOrEmpty(ants))
            {
                antLength = ants.Length;

                for (int i = 0; i < ants.Length; i++)
                {
                    //計算頭
                    if (ants.Substring(i, 1) == "a")
                    {
                        a_Count++;
                    }
                    //計算身
                    if (ants.Substring(i, 1) == "n")
                    {
                        n_Count++;
                    }
                    //計算腳
                    if (ants.Substring(i, 1) == "t")
                    {
                        t_Count++;
                    }
                    //計算活著的螞蟻
                    if (i < antLength - 2)
                    {
                        if (ants.Substring(i, 3) == "ant")
                        {
                            ant_Count++;
                        }
                    }
                }

                //死亡螞蟻數
                int[] dead_Numbers = new int[] { a_Count,n_Count,t_Count };
                deadAntCount = dead_Numbers.Max() - ant_Count;
            }


            return deadAntCount;
        }

        [TestMethod()]
        public static void SampleTests()
        {
            Assert.AreEqual(0, DeadAntCount("ant ant ant ant"));
            Assert.AreEqual(0, DeadAntCount(null));
            Assert.AreEqual(2, DeadAntCount("ant anantt aantnt"));
            Assert.AreEqual(1,DeadAntCount("ant ant .... a nt"));
        }
    }
}
